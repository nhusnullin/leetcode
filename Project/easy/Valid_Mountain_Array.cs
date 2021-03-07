using NUnit.Framework;

namespace Project.easy
{
    class Replace_Elements_with_Greatest_Element_on_Right_Side
    {
        public int[] ReplaceElements(int[] arr)
        {

            var max = arr[^1];
            arr[^1] = -1;
            for (int i = arr.Length - 2; i >= 0; i--)
            {
                if (arr[i] < max)
                {
                    arr[i] = max;
                }
                else
                {
                    var tmp = arr[i];
                    arr[i] = max;
                    max = tmp;
                }
            }

            return arr;
        }
    }
    
    public class Valid_Mountain_Array
    {
        [TestCase(new[] {0, 3, 2, 1}, true)]
        [TestCase(new[] {0, 3}, false)]
        [TestCase(new[] {2, 1}, false)]
        [TestCase(new[] {0,1,2,4,2,1}, true)]
        [TestCase(new[] {1, 2, 3 , 4}, false)]
        [TestCase(new[] {9, 8, 7, 6, 5, 4, 3, 2, 1, 0}, false)]
        public void Test(int[] arr, bool exp)
        {
            Assert.AreEqual(exp, ValidMountainArray(arr));
        }

        public bool ValidMountainArray(int[] arr)
        {
            if (arr.Length < 3)
            {
                return false;
            }

            int left = 0;
            for (; left < arr.Length-1; left++)
            {
                if (arr[left] >= arr[left + 1])
                {
                    break;
                }
            }

            int right = arr.Length - 1;
            for (; right > 0; right--)
            {
                if (arr[right] >= arr[right - 1])
                {
                    break;
                }
            }
            
            if (left > 0 && right < arr.Length - 1 && right - left <= 1)
            {
                return true;
            }
            
            return false;
        }

        public bool ValidMountainArray1(int[] arr)
        {
            if (arr.Length < 3)
            {
                return false;
            }

            var left = 0;
            var right = arr.Length - 1;

            var delta = true;
            
            while (delta )
            {
                delta = false;
                
                if (left + 1 < arr.Length && arr[left] < arr[left + 1])
                {
                    delta = true;
                    left++;
                }

                if (right - 1 >= 0 && arr[right-1] > arr[right])
                {
                    delta = true;
                    right--;
                }
            }

            if (left > 0 && right < arr.Length - 1 && right - left <= 1)
            {
                return true;
            }
            
            return false;
        }
    }
}