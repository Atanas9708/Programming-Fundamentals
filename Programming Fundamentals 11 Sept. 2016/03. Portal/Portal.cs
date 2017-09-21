using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Portal
{
    public class Portal
    {
        public static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var matrix = ReadMatrix(rows);
            var path = Console.ReadLine().ToCharArray();

            FindExit(matrix, path);
        }

        public static void FindExit(List<List<char>> matrix, char[] path)
        {
            var turns = 0;
            var playerRow = matrix.IndexOf(matrix.Single(row => row.Contains('S')));
            var playerCol = matrix.Single(row => row.Contains('S')).IndexOf('S');

            Position player = new Position(playerRow, playerCol);

            foreach (char direction in path)
            {
                var dir = DirectionGetter(direction);

                Move(dir, matrix, player);

                turns++;

                if (matrix[player.Row][player.Col] != 'E') continue;

                Console.WriteLine("Experiment successful. {0} turns required.", turns);
                return;
            }

            Console.WriteLine("Robot stuck at {0} {1}. Experiment failed.", player.Row, player.Col);
        }

        public static void Move(int dir, List<List<char>> matrix, Position player)
        {
            switch (dir)
            {
                case 2:
                    MoveVertical(1, matrix, player);
                    break;
                case -2:
                    MoveVertical(-1, matrix, player);
                    break;
                default:
                    MoveHorizontal(dir, matrix, player);
                    break;
            }
        }

        public static void MoveVertical(int dir, List<List<char>> matrix, Position player)
        {
            if (player.Row + dir >= matrix.Count)
            {
                for (int currentRow = 0; currentRow < matrix.Count; currentRow++)
                {
                    if (player.Col < matrix[currentRow].Count)
                    {
                        player.Row = currentRow;
                        break;
                    }
                }

            }
            else if (player.Row + dir < 0)
            {
                for (int currentRow = matrix.Count - 1; currentRow >= 0; currentRow--)
                {
                    if (player.Col < matrix[currentRow].Count)
                    {
                        player.Row = currentRow;
                        break;
                    }
                }
            }
            else
            {
                List<char> nextRow;

                if (dir < 0)
                {
                    nextRow = matrix.LastOrDefault(row => row.Count > player.Col && matrix.IndexOf(row) < player.Row);

                    if (nextRow == null)
                    {
                        nextRow = matrix.Last(row => row.Count > player.Col && matrix.IndexOf(row) >= player.Row);
                    }
                }
                else
                {
                    nextRow = matrix.FirstOrDefault(row => row.Count > player.Col && matrix.IndexOf(row) > player.Row);

                    if (nextRow == null)
                    {
                        nextRow = matrix.First(row => row.Count > player.Col && matrix.IndexOf(row) <= player.Row);
                    }
                }


                player.Row = matrix.IndexOf(nextRow);
            }
        }

        public static void MoveHorizontal(int dir, List<List<char>> matrix, Position player)
        {
            if (dir > 0)
            {
                player.Col = (player.Col + 1) % matrix[player.Row].Count;
                return;
            }
            player.Col = (player.Col - 1 + matrix[player.Row].Count) % matrix[player.Row].Count;
        }

        public static int DirectionGetter(char direction)
        {
            if (direction == 'D') return 2;
            if (direction == 'U') return -2;
            if (direction == 'L') return -1;
            return 1;
        }

        public static List<List<char>> ReadMatrix(int size)
        {
            var matrix = new List<List<char>>();

            for (int i = 0; i < size; i++)
            {
                matrix.Add(Console.ReadLine().ToCharArray().ToList());
            }

            return matrix;
        }
    }

    public class Position
    {
        public int Row { get; set; }
        public int Col { get; set; }

        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }
    }
}
