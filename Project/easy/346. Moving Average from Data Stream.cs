using System;
using NUnit.Framework;

namespace Project.easy
{
    public class test
    {
        [Test]
        public void Test()
        {
            var avg = new MovingAverage_ConstantSumTime(3);
            Assert.AreEqual(1.0, avg.Next(1));
            Assert.AreEqual(5.5, avg.Next(10));
            avg.Next(3);
            Assert.AreEqual(6.0, avg.Next(5));
        }
    }

    public class MovingAverage_ConstantSumTime
    {
        private readonly int _capacity;
        private readonly int[] _array;

        private int _count = 0;
        private int sum = 0;

        public MovingAverage_ConstantSumTime(int size)
        {
            _capacity = size;
            _array = new int[_capacity];
        }

        public double Next(int val)
        {
            _count++;
            sum += val;
            var index = (_count - 1) % _capacity;
            var tail = _count > _capacity ? _array[index] : 0;
            _array[index] = sum;

            var avg = (sum - tail) * 1.0 / Math.Min(_count, _capacity);
            return avg;
        }
    }

    public class MovingAverage
    {
        private int[] _array;
        private int _capacity;
        private int _index = -1;
        private int _count = 0;

        /** Initialize your data structure here. */
        public MovingAverage(int size)
        {
            _capacity = size;
            _array = new int[_capacity];
        }

        public double Next(int val)
        {
            _index = ++_index % _capacity;
            _array[_index] = val;
            _count = Math.Min(++_count, _capacity);
            return Avg();
        }

        public double Avg()
        {
            double avg = 0;
            for (int i = 0; i < Math.Min(_count, _array.Length); i++)
            {
                avg += _array[i];
            }

            return avg /= _count;
        }
    }
}