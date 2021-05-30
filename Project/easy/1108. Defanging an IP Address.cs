using System.Text;
using NUnit.Framework;

namespace Project.easy
{
    public class Defanging_an_IP_Address {

        [TestCase("1[.]1[.]1[.]1", "1.1.1.1")]
        public void Test(string exp, string act)
        {
            Assert.AreEqual(exp, DefangIPaddr(act));
        }
        
        public string DefangIPaddr(string address)
        {
            var sb = new StringBuilder();
            foreach (var adr in address)
            {
                if (adr.Equals('.'))
                {
                    sb.Append($"[{adr}]");
                    continue;
                }

                sb.Append(adr);
            }

            return sb.ToString();
        }
    }
}