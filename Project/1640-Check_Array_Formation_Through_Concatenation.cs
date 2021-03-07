using NUnit.Framework;

namespace Project
{
    [TestFixture]
    public class Check_Array_Formation_Through_Concatenation
    {
        private static object[][] _combinationTests = new[]
        {
            new object[] {new[] {85}, new[] {new[] {85}}, true},
            new object[] {new[] {85}, new[] {new[] {85, 84}}, false},
            new object[] {new[] {49, 18, 16}, new[] {new[] {16, 18, 49}}, false},
            new object[] {new[] {91, 4, 64, 78}, new[] {new[] {78}, new[] {4, 64}, new[] {91}}, true},
            new object[] {new[] {1, 3, 5, 7}, new[] {new[] {2}, new[] {4}, new[] {6}, new[] {8}}, false},
        };
        
        [Test]
        [TestCaseSource(nameof(_combinationTests))]
        public void Test(int[] arr, int[][] pieces, bool expected)
        {
            
            Assert.AreEqual(expected, CanFormArray(arr, pieces));
        }

        private bool CanFormArray(int[] arr, int[][] pieces)
        {
            var i = 0;
            while (i < arr.Length)
            {
                var prev = i;
                for (var index = 0; index < pieces.Length; index++)
                {
                    var piece = pieces[index];
                    if (piece.Length == 0 || arr[i] != piece[0])
                    {
                        continue;
                    }

                    if (i + piece.Length > arr.Length)
                    {
                        return false;
                    }
                    
                    i++;
                    for (int j = 1; j < piece.Length; j++)
                    {
                        if (arr[i] == piece[j])
                        {
                            i++;
                        }
                        else
                        {
                            return false;
                        }
                    }

                    break;
                }

                if (i == prev)
                {
                    return false;
                }
            }

            return true;
        }
    }
}