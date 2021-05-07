using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Project.easy
{
    public class Valid_Parentheses
    {
        public bool IsValid(string s)
        {

            var dic = new Dictionary<char, char>(new []
            {
                new KeyValuePair<char, char>('(', ')'),
                new KeyValuePair<char, char>('[', ']'),
                new KeyValuePair<char, char>('{', '}')
            });
            
            var stack = new Stack<char>(s.Length);
            foreach (var c in s)
            {
                if (dic.TryGetValue(c, out var val))
                {
                    stack.Push(val);
                    continue;
                }

                if (stack.Count == 0)
                {
                    return false;
                }

                var closeCharacter = stack.Pop();
                if (closeCharacter != c)
                {
                    return false;
                }
            }

            return stack.Count == 0;
        }
    }
}