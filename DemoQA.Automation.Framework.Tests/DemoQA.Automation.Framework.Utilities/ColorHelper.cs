using System;
using System.Text;
using System.Text.RegularExpressions;

namespace DemoQA.Automation.Framework.Utilities
{
    public static class ColorHelper
    {
        /// <summary>
        /// Converts Color from Rgba format to Hex format. 
        /// </summary>
        /// <param name="rgba">Color on rgba format.</param>
        /// <returns>Color on Hex format.</returns>
        public static string ConvertRgbaToHex(string rgba)
        {
            if (!Regex.IsMatch(rgba, @"rgba\((\d{1,3},\s*){3}(0(\.\d+)?|1)\)"))
            {
                throw new FormatException("rgba string was in a wrong format");
            }

            var matches = Regex.Matches(rgba, @"\d+");
            StringBuilder hexaString = new StringBuilder("#");

            for (int i = 0; i < matches.Count - 1; i++)
            {
                int value = int.Parse(matches[i].Value);

                hexaString.Append(value.ToString("X"));
            }

            return hexaString.ToString();
        }


        /// <summary>
        /// Converts Color from Rgb format to Hex format.
        /// </summary>
        /// <param name="rgb">Color on rgb format.</param>
        /// <returns>Color on Hex format.</returns>
        public static string ConvertRgbToHex(string rgb)
        {
            var matches = Regex.Matches(rgb, @"\d+");
            StringBuilder hexaString = new StringBuilder("#");

            for (int i = 0; i < matches.Count; i++)
            {
                hexaString.Append(DecimalToHexadecimal(int.Parse(matches[i].Value)));
            }

            return hexaString.ToString();
        }

        /// <summary>
        /// Converts decimal to hexadecimal value.
        /// </summary>
        /// <param name="dec">decimal value.</param>
        /// <returns>Decimal value on hexadecimal.</returns>
        private static string DecimalToHexadecimal(int dec)
        {
            // System.Drawing.Color color = new System.Drawing.Color();
            if (dec <= 0)
            {
                return "00";
            }

            int hex = dec;
            string hexStr = string.Empty;

            while (dec > 0)
            {
                hex = dec % 16;

                if (hex < 10)
                {
                    hexStr = hexStr.Insert(0, Convert.ToChar(hex + 48).ToString());
                }
                else
                {
                    hexStr = hexStr.Insert(0, Convert.ToChar(hex + 55).ToString());
                }

                dec /= 16;
            }

            return hexStr;
        }
    }
}
