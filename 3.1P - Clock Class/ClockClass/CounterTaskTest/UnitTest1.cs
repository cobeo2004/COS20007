/*
 * Usings.cs
 global using NUnit.Framework;
 global using CounterTask;
 */

namespace CounterTaskTest;

public class Tests
{
    private Counter _testCounter;
    [SetUp]
    public void Setup()
    {
        _testCounter = new Counter("test counter");
    }

    [Test]
    public void TestIncrement()
    {
        _testCounter.Increment();
        Assert.That(_testCounter.Ticks, Is.EqualTo(1));
    }

    [Test]
    public void TestReset()
    {
        const int MAX = 15000;
        for(int i = 0; i < MAX; i++)
        {
            _testCounter.Increment();
        }
        _testCounter.Reset();
        Assert.That(_testCounter.Ticks, Is.EqualTo(0));
    }

    [TestCase("test counter")]
    public void TestName(object obj)
    {
        Assert.That(_testCounter.Name, Is.EqualTo(obj));
    }
}
