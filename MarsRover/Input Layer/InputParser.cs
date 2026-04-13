using mars_rover.Enums;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace mars_rover.Input_Layer
{
    public class InputParser
    {
        
        public static (int,int,CompassDirection) PositionParser(string stringInput)
        {

            char[] input = stringInput.Trim().ToArray();

            //Deal with length that is not exactly 3 characters
            if (input.Length !=3)
            {
                throw new FormatException("You must input Postions in the following format - Xcoordinate, Ycoordinate, Direction e.g. 54N \n" +
                                          "The co-ordinates for the rover have not been parsed correctly, please try again ");
            }

            string[] stringInputArr = new string[3];

            bool xsuccess = int.TryParse(input[0].ToString(), out int xCoordinate);
            bool ysuccess = int.TryParse(input[1].ToString(), out int yCoordinate);

            string compassDirecton = input[2].ToString().ToLower();
            string[] validDirections = { "n", "e", "s", "w" };

            //Make sure the three characters fits thw x,y,direction format
            if (!validDirections.Contains(compassDirecton) || !xsuccess || !ysuccess)

            {
                throw new FormatException("You must input Postions in the following format - Xcoordinate, Ycoordinate, Direction e.g. 54N \n" +
                                          "The co-ordinates for the rover have not been parsed correctly, please try again ");
            }

            CompassDirection compassDirectionReturn = new CompassDirection();

            if (compassDirecton == "n") { compassDirectionReturn = CompassDirection.North; }
            if (compassDirecton == "e") { compassDirectionReturn = CompassDirection.East; }
            if (compassDirecton == "s") { compassDirectionReturn = CompassDirection.South; }
            if (compassDirecton == "w") { compassDirectionReturn = CompassDirection.West; }


            return (xCoordinate, yCoordinate, compassDirectionReturn);
            //return (xCoordinate, yCoordinate, CompassDirection.South);
        }

        
        public static List<Instruction> InstructionParser(string stringInput)
        {
            char [] SplitStringArray = stringInput.Trim().ToUpper().ToArray();
            char[] ValidInputs = {'L', 'R', 'M' };
            
            bool checkInputIsValid = SplitStringArray.All(element => ValidInputs.Contains(element)) && SplitStringArray.Length > 0;

            Console.WriteLine(checkInputIsValid);
            if (!checkInputIsValid)
            {
                throw new FormatException("Your input was not valid. " +
                    "Valid inputs are L for Left 90 degreed, " +
                    "R for right 90 degrees and M for move forward 1. e.g. L,M,R \n" +
                    "Please try again.");
            }

            Dictionary <char,Instruction> MapDictionary = new Dictionary<char, Instruction>
            {
                { 'L',Instruction.L },
                { 'R',Instruction.R },
                { 'M',Instruction.M },
            };

            List<Instruction> listToReturn = new List<Instruction> {};

            foreach (char instruction in SplitStringArray)
            {
                listToReturn.Add(MapDictionary[instruction]);
            }


            return listToReturn;
        }
    }
}
