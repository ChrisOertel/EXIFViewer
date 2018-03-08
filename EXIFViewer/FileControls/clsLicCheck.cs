using System;
using System.Collections.Generic;
using System.Text;

namespace de.coe.components.License
{
    internal class LicCheck
    {
        private static int RegKeyPartInfo(string Part)
        {
            string PossibleChars = ""; // = "123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ" 
            int i;
            for (i = 49; i <= 57; i++)
            {
                PossibleChars += (char)i;//Ziffern 
            }
            for (i = 65; i <= 90; i++)
            {
                PossibleChars += (char)i;//Buchstaben 
            }
            int v = 0;
            string s;
            for (int x = 0; x < Part.Length; x++)
            {
                s = Part.Substring(x, 1);
                v += PossibleChars.IndexOf(s) + 1;
            }
            return v;
        }

        public static string CheckKeyForRegKey(string Key)
        {
            string[] soKeys = Key.Split(Convert.ToChar("-"));
            string ssResult = "";
            try
            {
                ssResult = Convert.ToString(RegKeyPartInfo(soKeys[0]), 16).PadLeft(2, Convert.ToChar("0")) + Convert.ToString(RegKeyPartInfo(soKeys[1]), 16).PadLeft(2, Convert.ToChar("0")) + Convert.ToString(RegKeyPartInfo(soKeys[2]), 16).PadLeft(2, Convert.ToChar("0")) + Convert.ToString(RegKeyPartInfo(soKeys[3]), 16).PadLeft(2, Convert.ToChar("0")) + Convert.ToString(RegKeyPartInfo(soKeys[4]), 16).PadLeft(2, Convert.ToChar("0"));
            }
            catch
            {
                ssResult = "";
            }
            return ssResult.ToUpper();
        } 
    }
}
