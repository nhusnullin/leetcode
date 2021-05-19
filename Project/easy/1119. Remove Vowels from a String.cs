using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Project.easy
{
    public class Remove_Vowels_from_a_String {

        [TestCase("ltcdscmmntyfrcdrs", "leetcodeisacommunityforcoders")]
        public void Test(string exp, string s)
        {
            Assert.AreEqual(exp, RemoveVowels(s));
        }
        
        // Given a string s, remove the vowels 'a', 'e', 'i', 'o', and 'u' from it, and return the new string.
        public string RemoveVowels(string s)
        {
            var map = new HashSet<char>(new []{'a', 'e', 'i', 'o', 'u'});
            var res = new StringBuilder(s.Length);
            foreach (var c in s)
            {
                if (map.Contains(c))
                {
                    continue;
                }

                res.Append(c);
            }

            return res.ToString();
        }
    }
}