
namespace PickyBrideProblem
{
    class Contender : IContender
    {
        public string Name { get; private set; }
        public int Mark { get; private set; }

        public Contender(string name, int mark)
        {
            Name = name;
            Mark = mark;
        }
    }
}
