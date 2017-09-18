using System;
using System.Linq;

namespace _03.Target_Multiplier
{
    public class TargetMultiplier
    {
        public static void Main()
        {
            var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = dimensions[0];
            var cols = dimensions[1];
            var matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var inputRow = Console.ReadLine().Split();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = int.Parse(inputRow[col]);
                }
            }

            var targetCell = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var targetRow = targetCell[0];
            var targetCol = targetCell[1];

            var startRow = targetRow - 1;
            var endRow = targetRow + 1;
            var startCol = targetCol - 1;
            var endCol = targetCol + 1;

            var targetCellValue = matrix[targetRow, targetCol];

            var sumOfNeighbors = 0;
            for (int row = startRow; row <= endRow; row++)
            {
                for (int col = startCol; col <= endCol; col++)
                {
                    sumOfNeighbors += matrix[row, col];
                }
            }

            var newTargetCellValue = sumOfNeighbors - targetCellValue;

            for (int row = startRow; row <= endRow; row++)
            {
                for (int col = startCol; col <= endCol; col++)
                {
                    if (row == targetRow && col == targetCol)
                    {
                        matrix[row, col] = newTargetCellValue;
                    }
                    matrix[row, col] *= targetCellValue;
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
