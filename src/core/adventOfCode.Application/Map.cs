using System;
using System.Collections.Generic;
using adventOfCode.Domain;

namespace adventOfCode.Application
{
    public class Map
    {
        private readonly char[,] _map;
        private readonly int _width;
        private readonly int _height;

        public Position Position { get; private set; }
        public Char Value => Position.Value;
        public List<Position> Path { get; private set; } = new List<Position>();
        public int TreeCount { get; private set; }

        public Map(List<string> input)
        {
            _map = Parse(input);
            _height = _map.GetLength(dimension: 0);
            _width = _map.GetLength(dimension: 1);
            SetPosition(new Position()
            {
                X = 0,
                Y = 0,
                Value = _map[0, 0]
            });
        }

        public Map Move(Slope slope)
        {
            var position = CalculatePosition(slope);
            SetPosition(position);

            return this;
        }

        public void TraverseDown(Slope slope)
        {
            while (Position.Y < _height - 1)
                Move(slope);
        }

        private Position CalculatePosition(Slope slope)
        {
            
            int y = Position.Y + slope.Down;
            if (y >= _height)
                y %= _height;

            int x = Position.X + slope.Right;
            if (x >= _width)
                x %= _width;

            return new Position()
            {
                X = x,
                Y = y,
                Value = _map[y, x]
            };
        }
        
        private void SetPosition(Position position)
        {
            Position = position;
            Path.Add(position);
            if (position.Value.Equals('#'))
                TreeCount++;
        }

        private char[,] Parse(List<string> input)
        {
            var map = new char[input.Count, input[0].Length];
            int rowIdx = 0;

            foreach (string line in input)
                AddLineToMap(line, map, rowIdx++);

            return map;
        }

        private void AddLineToMap(string line, char[,] map, int rowIdx)
        {
            for (int i = 0; i < line.Length; i++)
                map[rowIdx, i] = line[i];
        }
    }
}
