using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Project.medium
{
    public class TestOpen_the_Lock
    {
        [TestCase(6, "0202", "0201", "0101", "0102", "1212", "2002")]
        [TestCase(1, "0009", "8888")]
        [TestCase(1, "8888", "8887","8889","8878","8898","8788","8988","7888","9888")]
        public void Test(int exp, string target, params string[] deadends)
        {
            var calc = new Open_the_Lock();
            Assert.AreEqual(exp, calc.OpenLock(deadends, target));
        }


        [Test]
        public void Test2()
        {
            var str = new char[] {'0', '1'};
            var map = new HashSet<char[]>();
            map.Add(str);
            Assert.IsTrue(map.Contains(new[] {'0', '1'}));
        }

        [Test]
        public void TestLockWheel()
        {
            var exp = Open_the_Lock.LockWheel.Is("1234");
            var act = Open_the_Lock.LockWheel.Is("1234");

            Assert.AreEqual(exp, act);
        }
    }

    public class Open_the_Lock
    {
        private string Initial = "0000";

        public int OpenLock(string[] deadends, string target)
        {
            var aim = LockWheel.Is(target);
            var blackList = deadends.Select(LockWheel.Is).ToHashSet();

            var queue = new Queue<LockWheel>();
            queue.Enqueue(LockWheel.Is(Initial));
            var count = 0;
            while (queue.Any())
            {
                var size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    var lp = queue.Dequeue();

                    if (Equals(lp, aim))
                    {
                        return count;
                    }

                    foreach (var lockWheel in lp.Rotate().Except(blackList))
                    {
                        queue.Enqueue(lockWheel);
                    }
                }

                count++;
            }

            return 0;
        }

        public class LockWheel
        {
            private readonly int[] _position;

            public static LockWheel Is(string state)
            {
                return new LockWheel(state);
            }

            private LockWheel(int[] state)
            {
                _position = new int[state.Length];
                Array.Copy(state, _position, state.Length);
            }

            private LockWheel(string state)
            {
                _position = new int [state.Length];
                for (int i = 0; i < state.Length; i++)
                {
                    _position[i] = Convert.ToInt32(state[i].ToString());
                }
            }

            public IEnumerable<LockWheel> Rotate()
            {
                for (var i = 0; i < _position.Length; i++)
                {
                    yield return Rotate(i, 1);
                    yield return Rotate(i, -1);
                }
            }

            private LockWheel Rotate(int index, int direction)
            {
                var lockWheel = new LockWheel(this._position);
                lockWheel._position[index] = (_position[index] + 10 + direction) % 10;
                return lockWheel;
            }

            public override bool Equals(object? obj)
            {
                var dest = obj as LockWheel;
                if (dest == null || this._position.Length != dest._position.Length)
                {
                    return false;
                }

                for (var i = 0; i < _position.Length; i++)
                {
                    if (_position[i] != dest._position[i])
                    {
                        return false;
                    }
                }

                return true;
            }

            public override int GetHashCode()
            {
                if (_position == null || _position.Length == 0)
                {
                    return base.GetHashCode();
                }

                var res = _position[0];
                for (var i = 1; i < _position.Length; i++)
                {
                    res ^= _position[i];
                }

                return res;
            }
        }
    }
}