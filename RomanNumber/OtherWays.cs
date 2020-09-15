using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
namespace RomanNumber {
    class OtherWays {

        public string getRomanNUmber(int val) {
            StringBuilder romanNumber = new StringBuilder();
            while(val>=1000) {
                val -= 1000;
                romanNumber.Append('M');
            }
            if (val >= 900) {
                val -= 900;
                romanNumber.Append("CM");
            }
            if(val >= 500) {
                val -= 500;
                romanNumber.Append('D');
            }
            if (val >= 400) {
                val -= 400;
                romanNumber.Append("CD");
            }
            while(val>=100) {
                val -= 100;
                romanNumber.Append('C');
            }
            if (val >= 50) {
                val -= 50;
                romanNumber.Append('L');
            }
            if (val >= 40) {
                val -= 40;
                romanNumber.Append("XL");
            }
            while (val >= 10) {
                val -= 10;
                romanNumber.Append('X');
            }
            if (val >= 9) {
                val -= 9;
                romanNumber.Append("IX");
            }
            if (val >= 5) {
                val -= 5;
                romanNumber.Append('V');
            }
            if (val >= 4) {
                val -= 4;
                romanNumber.Append("IV");
            }
            while (val >= 1) {
                val -= 1;
                romanNumber.Append('I');
            }
            return romanNumber.ToString();
        }
    }
}
*/