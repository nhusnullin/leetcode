using NUnit.Framework;

namespace Project.easy
{
    public class Reverse_String
    {
        [TestCase("olleh", "hello")]
        public void Test(string exp, string act)
        {
            var charArray = act.ToCharArray();
            ReverseString(charArray);
            Assert.AreEqual(exp.ToCharArray(), charArray);
        }
        
        
        public void ReverseString(char[] s)
        {
            ReverseRecursively(0, s);
        }

        private void ReverseRecursively(int index, char[] s)
        {
            if (index >= s.Length / 2)
            {
                return;
            }

            var tmp = s[index]; 
            s[index] = s[s.Length - index - 1];
            s[s.Length - index - 1] = tmp;
            ReverseRecursively(index + 1, s);
        }
    }
}