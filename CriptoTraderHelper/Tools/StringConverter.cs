using System;

namespace CriptoTraderHelper.Tools
{
    public static class StringConverter
    {
        public static string ConvertNumberFromStringWithK(decimal number)
        {
            if (number >= 1000)
                return Math.Round((number / 1000), 0).ToString("0.##") + "k";
            else
               return number.ToString();
        }
    }
}
