using mars_rover.Input_Layer;

namespace mars_rover
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Plateau
            var Plateau = new PlateauSize(5,5);

            //Rover1
            var RoverOnePostion = InputParser.PositionParser("12N");
            var RoverOneInstructions = InputParser.InstructionParser("LMLMLMLMM");

            ////Rover2
            var RoverTwoPostion = InputParser.PositionParser("33E");
            var RoverTwoInstructions = InputParser.InstructionParser("MMRMMRMRRM");

        }
    }
}
