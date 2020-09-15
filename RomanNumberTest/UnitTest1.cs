using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumberSpace;
using System;

namespace RomanNumberTest {
    [TestClass]
    public class UnitTest1 {
        const int maxRepCnt = 3;

        //[TestMethod]
        // Do we have access to class to be testet...? To be removed before moving project to integration server
        public void createRomanNUmber() {
            IRomanNumber romanNumber = new RomanNumber();
            Assert.IsNotNull(romanNumber, "No instance of RomanNumber");
        }

        void conversion(int number, string roman) {
            IRomanNumber romanNumber = new RomanNumber();

            romanNumber.setRomanNumber(number);
            Assert.AreEqual(roman, romanNumber.getRoman(), number + " becomes " + romanNumber.getRoman());

            romanNumber.setRomanNumber(roman);
            Assert.AreEqual(number, romanNumber.getInteger(), roman + " becomes " + romanNumber.getInteger());
        }

        [TestMethod]
        public void uat() {
            conversion(1999, "MCMXCIX");
            conversion(2444, "MMCDXLIV");
            conversion(90, "XC");
        }

        [TestMethod]
        public void illegalArguments() {
            try {
                new RomanNumber().setRomanNumber("VIM");
                Assert.Fail("Wrong argument. Should have thrown an exception");
            }
            catch (ArgumentException) {
            }
            catch (Exception) {
                Assert.Fail("Wrong argument. Wrong exception exception");
            }
            try {
                new RomanNumber().setRomanNumber("ThisIsNotOk");
                Assert.Fail("Wrong argument. Should have thrown an exception");
            }
            catch (ArgumentException) {
            }
            catch (Exception) {
                Assert.Fail("Wrong argument. Wrong exception exception");
            }
        }


        [TestMethod]
        public void range() {
            try {
                new RomanNumber().setRomanNumber(RomanNumber.maxRoman + 1);
                Assert.Fail("Too large a value. Should have thrown an exception");
            }
            catch (ArgumentOutOfRangeException) {
            }
            catch (Exception) {
                Assert.Fail("Too large a value. Wrong exception exception");
            }

            try {
                new RomanNumber().setRomanNumber(RomanNumber.minRoman - 1);
                Assert.Fail("Too litle a value. Should have thrown an exception");
            }
            catch (ArgumentOutOfRangeException) {
            }
            catch (Exception) {
                Assert.Fail("Too litle a value. Wrong exception exception");
            }
        }

        void repetionViolation(string roman) {
            if (roman.Length < 1) {
                Assert.Fail("Value converts to an empty string");
            }

            if(roman.Length==1) {
                return;
            }

            for(int i=0, repCnt=1; i<roman.Length-1; ++i) {
                if(roman[i]==roman[i+1]) {
                    ++repCnt;
                    if(repCnt>maxRepCnt) {
                        Assert.Fail("Too many repetitions of " + roman[i] + " in " + roman);
                    }
                    if(roman[i]=='V' || roman[i]=='L' || roman[i]=='D') {
                        Assert.Fail("Letter " + roman[i] + " may not be repeated");
                    }
                } else {
                    repCnt = 1;
                }
            }
        }

        //  [TestMethod] // repetitionViolation Works - don't touch! And removed this test before it hits integration server
        public void testRepetionViolation() {
            repetionViolation("XXXIII");    //  OK
            repetionViolation("XXIIII");    //  fails
            repetionViolation("XXIVVII");   //  fails
        }

        [TestMethod]
        public void repetition() {
            IRomanNumber romanNumber = new RomanNumber();

            for (int i = RomanNumber.minRoman; i <= RomanNumber.maxRoman; ++i) {
                romanNumber.setRomanNumber(i);
                repetionViolation(romanNumber.getRoman());
            }
        }
    }
}
