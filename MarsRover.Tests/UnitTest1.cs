namespace MarsRover.Tests
{
    public class HelloWorldTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Successfully_runs_a_test()
        {
            Assert.That(true, Is.True);
        }
    }
}