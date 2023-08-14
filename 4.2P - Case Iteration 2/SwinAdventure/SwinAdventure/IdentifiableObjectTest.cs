/*
Using.cs - Importer

global using NUnit.Framework;
global using System;
global using System.Collections.Generic;
global using System.Linq;

 */

namespace SwinAdventure
{
    public class IdentifiableObjectTest
    {
        private IdentifiableObject _testIdentifiableObject;
        private string _testStr;
        private string _notInIdentifiableObject;
        private string _caseSensitive;
        private string _firstIdentifier;
        private string _notFirstIdentifier;
        private string _addIdentifier;
        private string[] _testStrArray;

        private IdentifiableObject _testIdentifiableObjectEmpty;
        private string _testStrEmpty;
        private string _firstIdentifierEmpty;
        private string[] _testStrArrayEmpty;

        [SetUp]
        public void Setup()
        {
            _testStr = "Simon";
            _notInIdentifiableObject = "Haha";
            _caseSensitive = "oNaNa";
            _firstIdentifier = "onana";
            _notFirstIdentifier = "Mason";
            _addIdentifier = "Rashford";
            _testStrArray = new string[] {"Onana", "Mount", "Ramnus", "Amrabat" };
            _testIdentifiableObject = new IdentifiableObject(_testStrArray);
            _testIdentifiableObject.AddIdentifiers(_testStr);

            _testStrEmpty = "";
            _firstIdentifierEmpty = _testStrEmpty;
            _testStrArrayEmpty = new string[] { };
            _testIdentifiableObjectEmpty = new IdentifiableObject(_testStrArrayEmpty);
            _testIdentifiableObjectEmpty.AddIdentifiers(_testStrEmpty);
        }

        [Test]
        public void TestAreYou()
        {
            Assert.IsTrue(_testIdentifiableObject.AreYou(_testStr));
        }

        [Test]
        public void TestNotAreYou()
        {
            Assert.IsFalse(_testIdentifiableObject.AreYou(_notInIdentifiableObject));
        }

        [Test]
        public void TestCaseSensitive()
        {
            Assert.IsTrue(_testIdentifiableObject.AreYou(_caseSensitive));
        }

        [Test]
        public void TestFirstID()
        {
            Assert.AreEqual(_firstIdentifier, _testIdentifiableObject.FirstId);
            Assert.AreNotEqual(_notFirstIdentifier, _testIdentifiableObject.FirstId);
        }

        [Test]
        public void TestFirstIDWithNoID()
        {
            Assert.AreEqual(_firstIdentifierEmpty, _testIdentifiableObjectEmpty.FirstId);
        }

        [Test]
        public void TestAddID()
        {
            _testIdentifiableObject.AddIdentifiers(_addIdentifier);
            Assert.IsTrue(_testIdentifiableObject.AreYou(_addIdentifier.ToUpper()));
        }
    }
}


