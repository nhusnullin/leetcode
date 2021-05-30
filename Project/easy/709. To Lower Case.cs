using System.Diagnostics;
using System.Text;
using NUnit.Framework;

namespace Project.easy
{
    public class To_Lower_Case
    {
        [TestCase("aabb","AaBb")]
        public void Test(string exp, string act)
        {
            Assert.AreEqual(exp, ToLowerCase(act));
        }
        
        public string ToLowerCase(string s)
        {
            var sb = new StringBuilder();
            foreach (var c in s)
            {
                var code = (int) c;
                if (code >= 65 && code <= 90)
                {
                    code += 32;
                    sb.Append((char) code);
                    continue;
                }

                sb.Append(c);
            }

            return sb.ToString();
        }
    }
}