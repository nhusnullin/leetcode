using System;
using NUnit.Framework;

namespace Project
{
    [TestFixture]
    public class Longest_Substring_Without_Repeating_Characters
    {
        [TestCase("abcabcbb", 3)]
        [TestCase("bbbbb", 1)]
        [TestCase("pwwkew", 3)]
        [TestCase(" ", 1)]
        [TestCase("a", 1)]
        [TestCase("au", 2)]
        [TestCase("aub", 3)]
        [TestCase("dvdf", 3)]
        public void Test(string s, int expected)
        {
            Assert.AreEqual(expected, LengthOfLongestSubstring2(s));
        }

        
        public int LengthOfLongestSubstring2(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            if (s.Length == 1)
            {
                return 1;
            }

            var map = new int[128];
            var left = 0;
            var max = 0;
            for (var right = 0; right < s.Length; right++)
            {
                var prev = map[s[right]];

                if (prev > left && left < right)
                {
                    left = prev;
                }

                max = Math.Max(right + 1 - left, max);
                
                map[s[right]] = right + 1;
            }

            return max;
        }

        public int LengthOfLongestSubstring(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            if (s.Length == 1)
            {
                return 1;
            }

            var start = 0;
            var max = Int32.MinValue;
            var i = 0;
            for (; i < s.Length; i++)
            {
                for (var j = start; j < i; j++)
                {
                    if (s[j] == s[i])
                    {
                        max = Math.Max(i - start, max);
                        start = j + 1;
                        break;
                    }
                }
            }
            max = Math.Max(i - start, max);
            return max;
        }
    }
}