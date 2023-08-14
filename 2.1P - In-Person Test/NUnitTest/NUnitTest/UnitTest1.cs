namespace NUnitTest {

    [TestFixture]
    public class Tests
    {
        SimpleMath math;

        [SetUp]
        public void Setup()
        {
            math = new SimpleMath();
        }

        [TestCase(2,3,5)]
        [TestCase(3,4,7)]
        [TestCase(5,5,10)]
        public void TestAdd(int firstParam, int secondParam, int expected)
        {
            Assert.AreEqual(expected, math.Add(firstParam, secondParam));
        }

        [TestCase(2, 3, -1)]
        [TestCase(3, 4, -1)]
        [TestCase(5, 5, 0)]
        public void TestMinus(int firstParam, int secondParam, int expected)
        {
            Assert.AreEqual(expected, math.Minus(firstParam, secondParam));

        }

        [TestCase(2, 3, 6)]
        [TestCase(3, 4, 12)]
        [TestCase(5, 5, 25)]
        public void TestMultiply(int firstParam, int secondParam, int expected)
        {
            Assert.AreEqual(expected, math.Multiply(firstParam, secondParam));

        }

        [TestCase(3, 3, 1)]
        [TestCase(10, 5, 2)]
        [TestCase(25, 5, 5)]
        public void TestDivide(int firstParam, int secondParam, int expected)
        {
            Assert.AreEqual(expected, math.Divide(firstParam, secondParam));

        }
    }
}
