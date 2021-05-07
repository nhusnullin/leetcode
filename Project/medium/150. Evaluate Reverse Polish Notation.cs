using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Project.medium
{
    public class Evaluate_Reverse_Polish_Notation {

        [TestCase(9, new []{"2","1","+","3","*"})]
        [TestCase(6, new []{"4","13","5","/","+"})]
        [TestCase(22, new []{"10","6","9","3","+","-11","*","/","*","17","+","5","+"})]
        public void Test(int exp, string[] tokens)
        {
            Assert.AreEqual(exp, EvalRPN(tokens));
        }
        
        public int EvalRPN(string[] tokens) {
            
            Func<int, int, int> sum = (i, j) => i + j;
            Func<int, int, int> min = (i, j) => i - j;
            Func<int, int, int> multiple = (i, j) => i * j;
            Func<int, int, int> devide = (i, j) => i / j;

            var operations = new Dictionary<string, Func<int, int, int>>();
            operations.Add("+", sum);
            operations.Add("-", min);
            operations.Add("*", multiple);
            operations.Add("/", devide);

            var stack = new Stack<int>();
            foreach (var token in tokens)
            {
                if (operations.ContainsKey(token))
                {
                    var b = stack.Pop();
                    var a = stack.Pop();

                    stack.Push(operations[token](a, b));
                    continue;
                }
                
                stack.Push(Convert.ToInt32(token));
            }

            return stack.Pop();
        }
    }
}