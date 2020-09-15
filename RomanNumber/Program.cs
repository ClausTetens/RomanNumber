using System;
using System.Text;

namespace RomanNumberSpace {
    class RomanValue {
        public string roman { get; set; }
        public int value { get; set; }
        public RomanValue(string roman, int value) {
            this.roman = roman;
            this.value = value;
        }
    }

    public interface IRomanNumber {
        void setRomanNumber(int val);
        void setRomanNumber(string val);
        int getInteger();
        string getRoman();
    }

    public class RomanNumber : IRomanNumber {
        public const int minRoman = 1;
        public const int maxRoman = 2999;

        static RomanValue[] romanValues = {
            new RomanValue("MM", 2000), new RomanValue("M", 1000), new RomanValue("CM", 900), new RomanValue("D", 500),
            new RomanValue("CD", 400), new RomanValue("CC", 200), new RomanValue("C", 100), new RomanValue("XC", 90),
            new RomanValue("L", 50), new RomanValue("XL", 40), new RomanValue("XX", 20), new RomanValue("X", 10),
            new RomanValue("IX", 9), new RomanValue("V", 5), new RomanValue("IV", 4),
            new RomanValue("II", 2), new RomanValue("I", 1)};

        private int number;

        public int getInteger() {
            return number;
        }

        public string getRoman() {
            int rest = number;
            StringBuilder roman = new StringBuilder();

            for (int i = 0; i < romanValues.Length; ++i) {
                if (rest >= romanValues[i].value) {
                    rest -= romanValues[i].value;
                    roman.Append(romanValues[i].roman);
                }
            }

            return roman.ToString();
         }

        protected void testRange(int val) {
            if (val < minRoman || val > maxRoman) throw new ArgumentOutOfRangeException();
        }

        public void setRomanNumber(int val) {
            testRange (val) ;
            number = val;
         }

        int longestMatch(string val) {
            int matchPosition = -1;
            int matchLength=0;
            for (int i = 0; i < romanValues.Length; ++i) {
                if (romanValues[i].roman.Length <= val.Length &&
                    romanValues[i].roman == val.Substring(0, romanValues[i].roman.Length) &&
                    romanValues[i].roman.Length > matchLength) {
                    matchLength = romanValues[i].roman.Length;
                    matchPosition = i;
                }
            }
            return matchPosition;
        }

        public void setRomanNumber(string val) {
            int matchPosition = 0;
            int newMatchPosition;

            number = 0;

            while (val.Length > 0) {
                newMatchPosition = longestMatch(val);

                if (newMatchPosition < matchPosition) {
                    throw new ArgumentException();
                }

                matchPosition = newMatchPosition;

                number += romanValues[matchPosition].value;
                val = val.Substring(romanValues[matchPosition].roman.Length);
            }

            if (val.Length > 0) {
                throw new ArgumentException();
            }
            testRange(number);
        }
    }

    class Program {
        void conversion(int number, string roman) {
            IRomanNumber romanNumber = new RomanNumber();
            romanNumber.setRomanNumber(number);
            Console.WriteLine(number + " becomes " + romanNumber.getRoman());
            romanNumber.setRomanNumber(roman);
            Console.WriteLine(roman + " becomes " + romanNumber.getInteger());
        }
        
        public void uat() {
            conversion(1999, "MCMXCIX");
            conversion(2444, "MMCDXLIV");
            conversion(90, "XC");
        }

        static void Main(string[] args) {
            new Program().uat();
            Console.Write("[Enter] ");
            Console.Read();
        }
    }
}