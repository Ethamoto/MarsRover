using mars_rover.Enums;
using mars_rover.Input_Layer;
using System.Diagnostics.CodeAnalysis;

namespace MarsRover.Tests;

public class InputLayerTests
{
    [SetUp]
    public void Setup()
    {
    }

    /// <summary>
    /// Postion Parser Tests
    /// </summary>
    [Test]
    public void PositionParserCorrectString()
    {
        //Correct input from user.
        string stringInput = "53N";
        (int, int, CompassDirection) ExpectedOutPut = (5, 3, CompassDirection.North);
        (int, int, CompassDirection) ActualOutPut = InputParser.PositionParser(stringInput);
        Assert.That(ActualOutPut, Is.EqualTo(ExpectedOutPut));
    }

    [Test]
    public void PositionParserCorrectStringWithSpaces()
    {
        //Correct input from user.
        string stringInput = "5 3 N ";
        var ex = Assert.Throws<FormatException>(() => InputParser.PositionParser(stringInput));

        Assert.That(ex.Message, Is.EqualTo(
            "You must input Postions in the following format - Xcoordinate, Ycoordinate, Direction e.g. 54N \n" +
            "The co-ordinates for the rover have not been parsed correctly, please try again "));
    }


    [Test]
    public void PositionParserTestIncorrectCompassDirection()
    {
        string stringInput = "53North";

        var ex = Assert.Throws<FormatException>(() => InputParser.PositionParser(stringInput));

        Assert.That(ex.Message, Is.EqualTo(
            "You must input Postions in the following format - Xcoordinate, Ycoordinate, Direction e.g. 54N \n" +
            "The co-ordinates for the rover have not been parsed correctly, please try again "));
    }

    [Test]
    public void PositionParserTestIncorrectXCoordinate()
    {
        string stringInput = "X3N";

        var ex = Assert.Throws<FormatException>(() => InputParser.PositionParser(stringInput));

        Assert.That(ex.Message, Is.EqualTo(
            "You must input Postions in the following format - Xcoordinate, Ycoordinate, Direction e.g. 54N \n" +
            "The co-ordinates for the rover have not been parsed correctly, please try again "));
    }

    [Test]
    public void PositionParserTestIncorrectYCoordinate()
    {
        string stringInput = "5XN";

        var ex = Assert.Throws<FormatException>(() => InputParser.PositionParser(stringInput));

        Assert.That(ex.Message, Is.EqualTo(
            "You must input Postions in the following format - Xcoordinate, Ycoordinate, Direction e.g. 54N \n" +
            "The co-ordinates for the rover have not been parsed correctly, please try again "));
    }

    public void PositionParserTestEmptyInput()
    {
        string stringInput = "";

        var ex = Assert.Throws<FormatException>(() => InputParser.PositionParser(stringInput));

        Assert.That(ex.Message, Is.EqualTo(
            "You must input Postions in the following format - Xcoordinate, Ycoordinate, Direction e.g. 54N \n" +
            "The co-ordinates for the rover have not been parsed correctly, please try again "));
    }

    /// <summary>
    /// Instruction Parser Tests
    /// </summary>
    /// 
    [Test]
    public void InstructionParserTestOneInstrcution()
    {
        string input = "L";
        List<Instruction> ActualOutput = InputParser.InstructionParser(input);
        List <Instruction> expectedOutput = new List<Instruction> { Instruction.L };
        Assert.That(ActualOutput, Is.EqualTo(expectedOutput));

    }

    [Test]
    public void InstructionParserTestTwoInstrcution()
    {
        string input = "LM";
        List<Instruction> ActualOutput = InputParser.InstructionParser(input);
        List<Instruction> expectedOutput = new List<Instruction>
        { Instruction.L,Instruction.M };
        Assert.That(ActualOutput, Is.EqualTo(expectedOutput));
    }

    [Test]
    public void InstructionParserTestManyInstrcution()
    {
        string input = "LMRMLLM";
        List<Instruction> ActualOutput = InputParser.InstructionParser(input);
        List<Instruction> expectedOutput = new List<Instruction>
        { Instruction.L,Instruction.M,Instruction.R,Instruction.M,Instruction.L,Instruction.L,Instruction.M };
        Assert.That(ActualOutput, Is.EqualTo(expectedOutput));
    }

    [Test]
    public void InstructionParserInvalidInput()
    {
        string input = "L!M";

        string expectedErrorMesage = "Your input was not valid. " +
                    "Valid inputs are L for Left 90 degreed, " +
                    "R for right 90 degrees and M for move forward 1. e.g. L,M,R \n" +
                    "Please try again.";
        var exception = Assert.Throws<FormatException>(() => InputParser.InstructionParser(input));
        Assert.That(exception.Message, Is.EqualTo(expectedErrorMesage));
    }

    [Test]
    public void InstructionParserEmptyInput()
    {
        string input = "";

        string expectedErrorMesage = "Your input was not valid. " +
                    "Valid inputs are L for Left 90 degreed, " +
                    "R for right 90 degrees and M for move forward 1. e.g. L,M,R \n" +
                    "Please try again.";
        var exception = Assert.Throws<FormatException>(() => InputParser.InstructionParser(input));
        Assert.That(exception.Message, Is.EqualTo(expectedErrorMesage));
    }
}
