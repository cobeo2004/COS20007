/*
 * Usings.cs
   global using ClockClassMain;
   global using NUnit.Framework;
 */

namespace ClockClassTest;

public class Tests
{
    private Clock _clock;
    [SetUp]
    public void Setup()
    {
        _clock = new Clock();
    }

    [Test]
    public void TestRunInitialise()
    {
        Assert.That(_clock.CurrentTime, Is.EqualTo("00:00:00"));
    }

    [Test]
    public void TestReset()
    {
        const int MAX = 15000;
        for(int i = 0; i <= MAX; i++)
        {
            _clock.Tick();
        }
        _clock.Reset();
        Assert.That(_clock.CurrentTime, Is.EqualTo("00:00:00"));
    }

    [TestCase(0, "00:00:00")]
    [TestCase(60, "00:01:00")]
    [TestCase(3600, "01:00:00")]
    public void TestEachCounter(int tick, string curr_time)
    {
        for(int i = 0; i < tick; i++)
        {
            _clock.Tick();
        }
        Assert.That(_clock.CurrentTime, Is.EqualTo(curr_time));
    }

    [TestCase("00:00:59", "00:01:00")]
    [TestCase("01:59:59", "00:02:00")]
    [TestCase("23:59:59", "00:00:00")]
    public void TestTimeFormatWhenChange(string par_time, string expected_time)
    {
        _clock.SetTime(par_time);
        _clock.Tick();
        Assert.That(expected_time, Is.EqualTo(expected_time));
    }

}