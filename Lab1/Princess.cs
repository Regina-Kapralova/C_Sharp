using System.IO;
using System.Collections.Generic;

namespace Lab1
{
	static class Princess
	{
		private static readonly List<IContender> ex_contenders = new List<IContender>();
		public static void Skip_and_sort(IContender contender)
		{
			if (contender == null) return;
			int start = 0, end = ex_contenders.Count;
			if (end > 0 && Friend.Compare(contender, ex_contenders[0]) != contender)
			{
				ex_contenders.Insert(0, contender);
				return;
			}
			int center = (end - start) / 2;
			while (end - start > 1)
			{
				if (Friend.Compare(contender, ex_contenders[center]) == contender)
				{
					start = center;
					center = (end - start) / 2 + start;
				}
				else
				{
					end = center;
					center = (end - start) / 2;
				}
			}
			ex_contenders.Insert(end, contender);
		}
		public static void Selection()
		{
			IContender contender;
			for (int i = 1; i < 30; i++)
			{
				contender = Hall.Invite_contender();
				Skip_and_sort(contender);
			}
			while ((contender = Hall.Invite_contender()) != null)
			{
				if (Friend.Compare(contender, ex_contenders[ex_contenders.Count - 2]) == contender)
				{
					Hall.Get_married();
					return;
				}
				Skip_and_sort(contender);
			}
			Hall.Dont_get_married();
			return;
		}
	}
}
