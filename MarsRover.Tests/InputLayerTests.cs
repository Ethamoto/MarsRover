using mars_rover.Enums;
using mars_rover.Input_Layer;

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
        string stringInput = "5,3,N";
        (int, int, CompassDirection) ExpectedOutPut = (5, 3, CompassDirection.North);
        (int, int, CompassDirection) ActualOutPut = InputParser.PositionParser(stringInput);
        Assert.That(ActualOutPut, Is.EqualTo(ExpectedOutPut));
    }

    [Test]
    public void PositionParserCorrectStringWithSpaces()
    {
        //Correct input from user.
        string stringInput = "5 ,3 ,N ";
        (int, int, CompassDirection) ExpectedOutPut = (5, 3, CompassDirection.North);
        (int, int, CompassDirection) ActualOutPut = InputParser.PositionParser(stringInput);
        Assert.That(ActualOutPut, Is.EqualTo(ExpectedOutPut));
    }


    [Test]
    public void PositionParserTestIncorrectCompassDirection()
    {
        string stringInput = "5,3,North";

        var ex = Assert.Throws<FormatException>(() => InputParser.PositionParser(stringInput));

        Assert.That(ex.Message, Is.EqualTo(
            "You must input Postions in the following format - Xcoordinate, Ycoordinate, Direction e.g. 5,4,N \n" +
            "The co-ordinates for the rover have not been parsed correctly, please try again "));
    }

    [Test]
    public void PositionParserTestIncorrectXCoordinate()
    {
        string stringInput = "X,3,North";

        var ex = Assert.Throws<FormatException>(() => InputParser.PositionParser(stringInput));

        Assert.That(ex.Message, Is.EqualTo(
            "You must input Postions in the following format - Xcoordinate, Ycoordinate, Direction e.g. 5,4,N \n" +
            "The co-ordinates for the rover have not been parsed correctly, please try again "));
    }

    [Test]
    public void PositionParserTestIncorrectYCoordinate()
    {
        string stringInput = "5,X,North";

        var ex = Assert.Throws<FormatException>(() => InputParser.PositionParser(stringInput));

        Assert.That(ex.Message, Is.EqualTo(
            "You must input Postions in the following format - Xcoordinate, Ycoordinate, Direction e.g. 5,4,N \n" +
            "The co-ordinates for the rover have not been parsed correctly, please try again "));
    }

    public void PositionParserTestEmptyInput()
    {
        string stringInput = "";

        var ex = Assert.Throws<FormatException>(() => InputParser.PositionParser(stringInput));

        Assert.That(ex.Message, Is.EqualTo(
            "You must input Postions in the following format - Xcoordinate, Ycoordinate, Direction e.g. 5,4,N \n" +
            "The co-ordinates for the rover have not been parsed correctly, please try again "));
    }
}
