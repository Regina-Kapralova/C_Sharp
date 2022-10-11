
namespace Lab1
{
	class Contender : IContender
	{
		public string Name { get; private set; }
		public int Mark { get; private set; }
		public int Number { get; private set; }
		public Contender(string name, int mark, int number)
		{
			Name = name;
			Mark = mark;
			Number = number;
		}
	}
}
