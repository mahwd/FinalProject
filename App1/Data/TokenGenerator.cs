using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace WAU.Data
{
    public class TokenGenerator
    {
        public static string Generate()
        {
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWYZ";
            string nums = "0123456789";

            StringBuilder sb = new StringBuilder();
            int lettersLen = letters.Length;
            int numbersLen = nums.Length;

            for (int i = 0; i < 16; i++)
            {
                int randNum = new Random().Next(0,9);
                if (randNum % 2 == 0)
                {
                    sb.Append(letters[new Random().Next(letters[0], letters[lettersLen])]);
                }
                else
                {
                    sb.Append(nums[new Random().Next(0, nums[numbersLen])]);
                }
            }
            return sb.ToString();
        }
    }
}