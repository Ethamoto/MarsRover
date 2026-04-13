using mars_rover.Input_Layer;

namespace mars_rover
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            InputParser.InstructionParser("LMLM");
        }
    }
}
