using System;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;

namespace Project.hard
{
    public class Robot_Room_Cleaner_Test
    {
        [TestCase(new[]
        {
            1, 1, 1, 1, 1, 0, 1, 1,
            1, 1, 1, 1, 1, 0, 1, 1,
            1, 0, 1, 1, 1, 1, 1, 1,
            0, 0, 0, 1, 0, 0, 0, 0,
            1, 1, 1, 1, 1, 1, 1, 1
        }, 8)]
        public void Test(int[] input, int size)
        {
            var robot = new MyRobot(size, input);
            new Robot_Room_Cleaner().CleanRoom(robot);
            Assert.IsTrue(robot.IsOver());
        }
    }

    public class Robot_Room_Cleaner
    {
        // directions, o - up, 1 - right, 2 - down, 3 - left
        private int[][] _directions = new[] {new[] {-1, 0}, new[] {0, 1}, new[] {1, 0}, new[] {0, -1}};

        public void GoBack(Robot robot)
        {
            robot.TurnRight();
            robot.TurnRight();
            robot.Move();
            robot.TurnRight();
            robot.TurnRight();
        }

        private HashSet<Tuple<int, int>> _grid = new HashSet<Tuple<int, int>>();

        public void CleanRoom(Robot robot)
        {
            CleanRoom(robot, new Tuple<int, int>(0, 0), 0);
        }

        public void CleanRoom(Robot robot, Tuple<int, int> point, int d)
        {
            robot.Clean();
            _grid.Add(point);

            for (int i = 0; i < 4; i++)
            {
                var newD = (d + i) % 4;
                var newPoint = new Tuple<int, int>(point.Item1 + _directions[newD][0], point.Item2 + _directions[newD][1]);

                if (!_grid.Contains(newPoint) && robot.Move())
                {
                    CleanRoom(robot, newPoint, newD);
                    GoBack(robot);
                }

                robot.TurnRight();
            }
        }
    }


    // This is the robot's control interface.
    // You should not implement it, or speculate about its implementation
    public interface Robot
    {
        // Returns true if the cell in front is open and robot moves into the cell.
        // Returns false if the cell in front is blocked and robot stays in the current cell.
        public bool Move();

        // Robot will stay in the same cell after calling turnLeft/turnRight.
        // Each turn will be 90 degrees.
        public void TurnLeft();

        public void TurnRight();

        // Clean the current cell.
        public void Clean();
    }

    public class MyRobot : Robot
    {
        private readonly int _size;
        private int[,] _grid;
        private int i;
        private int j;

        // directions, o - up, 1 - right, 2 - down, 3 - left
        private readonly int[][] _directions = new[] {new[] {-1, 0}, new[] {0, 1}, new[] {1, 0}, new[] {0, -1}};
        private int _rotation = 0;

        public MyRobot(int size, int[] input)
        {
            _size = size;
            _grid = new int[size, size];
            for (var i = 0; i < input.Length; i++)
            {
                _grid[i / size, i % size] = input[i];
            }
        }

        public bool Move()
        {
            _rotation %= 4;
            if (_rotation < 0)
            {
                _rotation = 4 - Math.Abs(_rotation);
            }

            var temp_i = i + _directions[_rotation][0];
            var temp_j = j + _directions[_rotation][1];

            if (temp_i < 0 || temp_j < 0 ||
                temp_i >= _size || temp_j >= _size ||
                _grid[temp_i, temp_j] == 0)
            {
                return false;
            }

            i = temp_i;
            j = temp_j;

            return true;
        }

        public void TurnLeft()
        {
            _rotation--;
        }

        public void TurnRight()
        {
            _rotation++;
        }

        public void Clean()
        {
            _grid[i, j]++;
            Visualize();
        }

        private void Visualize()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    var print = ' ';
                    switch (_grid[i, j])
                    {
                        case 0:
                            print = 'x';
                            break;
                        case 1:
                            print = '.';
                            break;
                        case 2:
                            print = ' ';
                            break;
                        default:
                            print = _grid[i, j].ToString()[0];
                            break;
                    }

                    Trace.Write($"{print} ");
                }

                Trace.WriteLine("");
            }
        }

        public bool IsOver()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (_grid[i, j] == 1)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}