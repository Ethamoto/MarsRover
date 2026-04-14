using mars_rover.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mars_rover
{
    internal class Rover
    {
        public static int RoverCount = 0;
        public Position Position { get; set; }

        public int RoverID { get; set; }

        public string RoverName { get; set; }

        public Rover(Position initialPosition, string name) 
        { 
        Position = initialPosition;
        RoverName = name;
        RoverID = RoverCount;
        RoverCount += 1;
        }

        public void UpdatePosition(List<Instruction> instructions)
        {
            CompassDirection[] CompassArray = Enum.GetValues<CompassDirection>();

            foreach (Instruction instruction in instructions)
            {
                CompassDirection startingDirection = Position.DirectionFacing;
                int StartingDirectionAsInt = Array.IndexOf(CompassArray, Position.DirectionFacing);

                //Handles movement
                if (instruction == Instruction.M)
                {
                    if (startingDirection == CompassDirection.North) { Position.YCoordinate += 1; }
                    if (startingDirection == CompassDirection.East) { Position.XCoordinate += 1; }
                    if (startingDirection == CompassDirection.South) { Position.YCoordinate -= 1; }
                    if (startingDirection == CompassDirection.West) { Position.XCoordinate -= 1; }
                }

                else
                {
                    //Handles Rotation
                    int rotation = 0;
                    if (instruction == Instruction.L) { int roation = 1; }
                    if (instruction == Instruction.R) { int roation = -1; }
                    int NewDirectionAsInt = StartingDirectionAsInt + rotation;
                    if (NewDirectionAsInt % 4 != 0) { NewDirectionAsInt = NewDirectionAsInt % 4; }
                    Position.DirectionFacing = CompassArray[NewDirectionAsInt];
                }
              
            }

        }
    }
}
