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
			StreamWriter sw = new StreamWriter("C:\\Users\\Регина\\OneDrive\\Рабочий стол\\Programming\\C#\\Lab1\\out.txt", true);
			IContender contender;
			for (int i = 1; i < 30; i++)
			{
				contender = Hall.Invite_contender();
				sw.WriteLine(contender.Name);
				Skip_and_sort(contender);
			}
			while ((contender = Hall.Invite_contender()) != null)
			{
				sw.WriteLine(contender.Name);
				if (Friend.Compare(contender, ex_contenders[ex_contenders.Count - 2]) == contender)
				{
					sw.WriteLine(Hall.Get_married());
					sw.Close();
					return;
				}
				Skip_and_sort(contender);
			}
			sw.WriteLine(Hall.Dont_get_married());
			sw.Close();
			return;
		}
	}
}
