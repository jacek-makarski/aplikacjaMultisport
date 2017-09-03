using System;
using System.Text;

namespace AppMultisport {

    public static class RomanNumerals {

        public static string Numeral(int n) {
            if (n < 1 || n > 100) {
                throw new ArgumentOutOfRangeException();
            }
            if (n == 100) {
                return "C";
            } else {
                StringBuilder result = new StringBuilder();
                int tens = n / 10;
                switch (tens) {
                    case 1:
                        result.Append("X");
                        break;
                    case 2:
                        result.Append("XX");
                        break;
                    case 3:
                        result.Append("XXX");
                        break;
                    case 4:
                        result.Append("XL");
                        break;
                    case 5:
                        result.Append("L");
                        break;
                    case 6:
                        result.Append("LX");
                        break;
                    case 7:
                        result.Append("LXX");
                        break;
                    case 8:
                        result.Append("LXXX");
                        break;
                    case 9:
                        result.Append("XC");
                        break;
                    default:
                        break;
                }
                int units = n % 10;
                switch (units) {
                    case 1:
                        result.Append("I");
                        break;
                    case 2:
                        result.Append("II");
                        break;
                    case 3:
                        result.Append("III");
                        break;
                    case 4:
                        result.Append("IV");
                        break;
                    case 5:
                        result.Append("V");
                        break;
                    case 6:
                        result.Append("VI");
                        break;
                    case 7:
                        result.Append("VII");
                        break;
                    case 8:
                        result.Append("VIII");
                        break;
                    case 9:
                        result.Append("IX");
                        break;
                    default:
                        break;
                }
                return result.ToString();
            }
        }

    }

}
