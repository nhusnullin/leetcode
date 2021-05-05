using System;
using NUnit.Framework;

namespace Project.medium
{
    public class Design_Circular_Queue
    {
        [Test]
        public void Test()
        {
            MyCircularQueue q = new MyCircularQueue(3);
            Assert.IsTrue(q.EnQueue(1)); // return True
            Assert.AreEqual(1, q.Size);
            Assert.IsTrue(q.EnQueue(2)); // return True
            Assert.AreEqual(2, q.Size);
            Assert.IsTrue(q.EnQueue(3)); // return True
            Assert.AreEqual(3, q.Size);
            Assert.IsFalse(q.EnQueue(4)); // return False
            Assert.AreEqual(3, q.Rear()); // return 3
            Assert.IsTrue(q.IsFull()); // return True
            Assert.IsTrue(q.DeQueue()); // return True
            Assert.IsTrue(q.EnQueue(4)); // return True
            Assert.AreEqual(4, q.Rear()); // return 4
        }

        [TestCase(0, -1, -1, 3)]
        [TestCase(1, 0, 0, 3)]
        [TestCase(1, 1, 1, 3)]
        [TestCase(3, 1, 0, 3)]
        [TestCase(3, 2, 1, 3)]
        [TestCase(2, 2, 0, 3)]
        [TestCase(2, 1, 2, 3)]
        public void SizeTest(int expSize, int head, int tail, int k)
        {
            var q = new MyCircularQueue(head, tail, k);
            Assert.AreEqual(expSize, q.Size);
        }

        [Test]
        public void Test1()
        {
            var q = new MyCircularQueue(6);
            Assert.IsTrue(q.EnQueue(6));
            Assert.AreEqual(6, q.Rear());
            Assert.AreEqual(6, q.Rear());
            Assert.IsTrue(q.DeQueue());
            Assert.IsTrue(q.EnQueue(5));
            Assert.AreEqual(5, q.Rear());
            Assert.IsTrue(q.DeQueue());
            Assert.AreEqual(-1, q.Front());
            Assert.IsFalse(q.DeQueue());
            Assert.IsFalse(q.DeQueue());
            Assert.IsFalse(q.DeQueue());
        }

        [Test]
        public void Test2()
        {
            var q = new MyCircularQueue(2);
            q.EnQueue(1);
            q.EnQueue(2);
            q.DeQueue();
            q.EnQueue(3);
            q.DeQueue();
            q.EnQueue(3);
            q.DeQueue();
            q.EnQueue(3);
            q.DeQueue();
            q.Front();
        }

        [Test]
        public void Test3()
        {
            var q = new MyCircularQueue(3);
            Assert.IsTrue(q.EnQueue(1));
            Assert.IsTrue(q.EnQueue(2));
            Assert.IsTrue(q.EnQueue(3));
            Assert.IsTrue(q.DeQueue());
            Assert.IsTrue(q.DeQueue());
            Assert.AreEqual(1, q.Size);
            Assert.IsTrue(q.EnQueue(3));
            Assert.AreEqual(2, q.Size);
            Assert.IsTrue(q.EnQueue(5));
            Assert.AreEqual(3, q.Size);
            Assert.IsTrue(q.DeQueue());
            Assert.IsTrue(q.DeQueue());
            Assert.IsTrue(q.DeQueue());
            Assert.IsFalse(q.DeQueue());
        }
    }

    public class MyCircularQueue
    {
        private int[] _array;
        private int _tail = -1;
        private int _head = -1;
        private int _k;

        internal MyCircularQueue(int head, int tail, int k)
        {
            _head = head;
            _tail = tail;
            _k = k;
        }

        public MyCircularQueue(int k)
        {
            _k = k;
            _array = new int[k];
        }

        public bool EnQueue(int value)
        {
            if (IsFull())
            {
                return false;
            }

            if (IsEmpty())
            {
                _head++;
            }

            _tail++;
            _tail %= _k;
            
            _array[_tail] = value;
            return true;
        }

        public bool DeQueue()
        {
            if (IsEmpty())
            {
                return false;
            }

            if (_tail == _head)
            {
                _tail = -1;
                _head = -1;
                return true;
            }
            
            _head++;
            _head %= _k; 

            return true;
        }

        public int Front()
        {
            if (!IsEmpty())
            {
                return _array[_head];
            }

            return -1;
        }

        public int Rear()
        {
            if (!IsEmpty())
            {
                return _array[_tail];
            }

            return -1;
        }

        public bool IsEmpty()
        {
            return Size == 0;
        }

        public bool IsFull()
        {
            return Size == _k;
        }

        public int Size
        {
            get
            {
                if (_head == -1)
                {
                    return 0;
                }

                if (_head > _tail)
                {
                    return _k - _head + _tail + 1;
                }

                if (_head < _tail)
                {
                    return _tail - _head + 1;
                }

                if (_head == _tail)
                {
                    return 1;
                }

                throw new NotImplementedException();
            }
        }
    }
}