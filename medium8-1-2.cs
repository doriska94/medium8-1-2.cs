using System;
using System.Collections.Generic;
using System.Windows;

namespace Task
{
    class Program
    {
        public static void Main(string[] args)
        {
            Object[] objects = new
            {
                new Object('1', 5, 5, true),
                new Object('2', 10, 10, true),
                new Object('3', 15, 15, true)
            };

            Random random = new Random();

            while (true)
            {

                for (int i = 0; i < objects.Length; i++)
                {
                    for (int j = i + 1; j < objects.Length; j++)
                    {
                        objects[i].CheckIsDead(objects[j]);
                    }
                }

                foreach (var obj in objects)
                {
                    var point = GetPoint(random);
                    obj.Add(point);
                }

                foreach (var obj in objects)
                {
                    if (obj.IsAlive)
                    {
                        var position = obj.GetPosition();
                        Console.SetCursorPosition(position.X, position.Y);
                        Console.Write(obj.Symbol);
                    }
                }

            }
        }
        private static Point GetPoint(Random random)
        {
            return new Point(random.Next(-1, 1), random.Next(-1, 1));
        }

    }
    class Object
    {
        public readonly char Symbol;
        private Point _position;
        public bool IsAlive { get; private set; }

        public Object(char symbol, int X, int Y, bool isAlive)
        {
            Symbol = symbol;
            _position = new Point(X, Y);
            IsAlive = isAlive;
        }

        public bool CheckIsDead(Object other)
        {
            if (other._position == _position)
            {
                IsAlive = false;
                other.IsAlive = false;
            }
            return !IsAlive; ;
        }

        public void Add(Point toPoint)
        {
            _position.X = _position.X + toPoint.X < 0 ? 0 : _position.X + toPoint.X;
            _position.Y = _position.Y + toPoint.Y < 0 ? 0 : _position.Y + toPoint.Y;
        }
        public Point GetPosition() => _position;
    }
}