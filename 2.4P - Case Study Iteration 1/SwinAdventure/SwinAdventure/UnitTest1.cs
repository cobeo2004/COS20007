/*
Using.cs - Importer

global using NUnit.Framework;
global using System;
global using System.Collections.Generic;
global using System.Linq;

 */

namespace SwinAdventure
{
    [TestFixture]
    public class IdentifiableObjectTest
    {
        private IdentifiableObject _testIdentifiableObject;

        private IdentifiableObject _testIdentifiableObjectEmpty;
        

        [SetUp]
        public void Setup()
        {
            _testIdentifiableObject = new IdentifiableObject(new string[] {"Onana", "Mount", "Ramnus", "Amrabat" });
            _testIdentifiableObject.AddIdentifiers("Simon");

            _testIdentifiableObjectEmpty = new IdentifiableObject(new string[] { });
            _testIdentifiableObjectEmpty.AddIdentifiers("");
        }

        [Test]
        public void TestAreYou()
        {
            Assert.IsTrue(_testIdentifiableObject.AreYou("Mount"));
        }

        [Test]
        public void TestNotAreYou()
        {
            Assert.IsFalse(_testIdentifiableObject.AreYou("Minh"));
        }

        [Test]
        public void TestCaseSensitive()
        {
            Assert.IsTrue(_testIdentifiableObject.AreYou("sImOn"));
        }

        [Test]
        public void TestFirstID()
        {
            Assert.AreEqual("onana", _testIdentifiableObject.FirstId);
            Assert.AreNotEqual("mount", _testIdentifiableObject.FirstId);
        }

        [Test]
        public void TestFirstIDWithNoID()
        {
            Assert.AreEqual("", _testIdentifiableObjectEmpty.FirstId);
        }

        [Test]
        public void TestAddID()
        {
            _testIdentifiableObject.AddIdentifiers("Rashford");
            Assert.IsTrue(_testIdentifiableObject.AreYou("Rashford".ToUpper()));
        }
    }
}


