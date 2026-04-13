using mars_rover.Enums;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mars_rover.Input_Layer
{
    public class InputParser
    {
        
        public static (int,int,CompassDirection) PositionParser(string stringInput)
        {
            string[] input = stringInput.Trim().Split(",");

            bool xsuccess = int.TryParse(input[0], out int xCoordinate);
            bool ysuccess = int.TryParse(input[1], out int yCoordinate);
            
            string compassDirecton = input[2].ToLower();
            string[] validDirections = { "n","e","s","w" };
            
            if (!validDirections.Contains(compassDirecton) | !xsuccess | !ysuccess)
                 
            {
                throw new FormatException("You must input Postions in the following format - Xcoordinate, Ycoordinate, Direction e.g. 5,4,N \n" +
                                          "The co-ordinates for the rover have not been parsed correctly, please try again ");
            }

            CompassDirection compassDirectionReturn = new CompassDirection();

            if (compassDirecton == "n") { compassDirectionReturn = CompassDirection.North; }
            if (compassDirecton == "e") { compassDirectionReturn = CompassDirection.East; }
            if (compassDirecton == "s") { compassDirectionReturn = CompassDirection.South; }
            if (compassDirecton == "w") { compassDirectionReturn = CompassDirection.West; }


            return (xCoordinate, yCoordinate, compassDirectionReturn);
        }

        
        public static Instruction InstructionParser(string stringInput)
        {


            return Instruction.L;
        }
    }
}
