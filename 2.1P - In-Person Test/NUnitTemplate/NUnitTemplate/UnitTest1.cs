﻿/*
* File: NunitTemplate.cs
* Unit: COS20007 Object Oriented Programming
* Institution: Swinburne University of Technology
*/
using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using NUnit.Framework; //Don't forget this.
using NUnit.Framework.Internal;
using MathTest;
namespace NUnitTests //This should match your NUnit test project name.
{
    [TestFixture]
    public class NUnitTemplate //Rename this appropriately.
    {
        /// <summary>
        /// FIELDS
        /// Declare the fields you are going to use to access the objects you testing here.
        /// </summary>
        //For Example:
        private Object _testableObject;
        private string _testableString;
        /// <summary>
        /// SETUP
        /// Use this method to setup the objects you are going to use for each test.
        /// This method will be executed before each test is run, "resetting" your objects/data.
        /// </summary>
        //For Example:
        [SetUp]
        public void SetUp()
        {
            _testableObject = new object();
            _testableString = "Some string.";
        }
        /// <summary>
        /// TESTS
        /// Use these methods to run tests with only one scenario.
        /// Remember to name your test methods appropriately.
        /// </summary>
        //For Example:
        [Test]
        public void TestObjectExists()
        {
            /* ASSERT STATEMENTS
            * Assert statements are how you test your data.
            * If the data is what you expect, the assert statements pass and so do
            your tests.
            * If the data does not match what you expect, the test will fail.
            */
            Assert.IsNotNull(_testableObject); //For example
            /* Most assert statments take 3 arguments:
            * - expected: The value/data you are expecting to get.
            * - actual: The actual data you have generated in your test.
            * - message (optional): A short message informing you (the programmer)
            what the
            * assert statement is testing. For your own benefit when you are
            debugging later.
            * For example:
            */
            Assert.AreEqual
            (
            "Some string.", //expected
            _testableString, //actual
            "Testing that the string matches, including the case" //message
            );
            /* There are many different types of assert statements.
            * Don't forget to use the most appropriate assert statement for the
            data you are
            * testing.
            * For Example:
            * - Assert.IsTrue/IsFalse to test a boolean.
            * - Assert.AreEqual to compare two values.
            * - Assert.AreSame to compare two objects.
            * - Many other assert statements for different scenarios...
            * - NOTE: You can use 'Assert.AreEqual' for almost every test in this
            unit.
            */
        }
        /// <summary>
        /// TESTCASES
        /// Use these methods to run tests when you have multiple scenarios you want to test.
        /// Create parameters to allow you to pass in the unique data you will be testing
        /// against for each scenario.
        /// Pass your unique data for each scenario as arugments in each TestCase.
        /// Please Note: The data you pass in must be static and cannot be a pointer to an
        /// object instance.
        /// The test will run once per TestCase.
        /// </summary>
        //For Example:
        [TestCase("Some string.")] //Scenario 1: Exact match.
        [TestCase("SOME sTrInG.")] //Scenario 2: Contains uppercase characters.
        [TestCase("some string.")] //Scenario 3: All lowercase characters.
        public void TestString(string toTest)
        {
            StringAssert.AreEqualIgnoringCase(toTest, _testableString, "Testing the strings are actually the same");
            // Note: You will need to match the case in most of your tasks.
            // Therefore, use Assert.AreEqual instead
        }
        /*
        * Don't forget to run the tests using the test explorer.
        * How you do this differs slightly depending on what version of VS you are
        running
        * and what OS you have.
        * If you are unsure how to do this, have a google or seek help in the the
        help desk.
        * Happy Testing! :)
        */
    }

}