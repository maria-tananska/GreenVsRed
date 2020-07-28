using System;
using System.Linq;

namespace GreenVsRed
{
    public class Program
    {
        public static void Main()
        {
            int[] size = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            if (size[1]>1000 || size[0]>size[1])
            {
                Console.WriteLine("Condition: x<=y<1000");
                size = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            }

            int row = size[1];
            int col = size[0];

            var generationZero = new int[row, col];

            for (int r = 0; r < row; r++)
            {
                var currentRow = Console.ReadLine();
                int[] currentRowAsInt = new int[col];

                for (int i = 0; i < currentRow.Length; i++)
                {
                    currentRowAsInt[i] = (int.Parse)(currentRow[i].ToString());
                }
                

                for (int c = 0; c < col; c++)
                {
                    generationZero[r, c] = currentRowAsInt[c];
                }
            }

            int[] cordinates = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int x1 = cordinates[0];
            int y1 = cordinates[1];
            int n = cordinates[2];

            int countOfGreen = 0;
            int result = 0;

            if (generationZero[y1, x1] == 1)
            {
                result++;
            }

            for (int i = 1; i <= n; i++)
            {  
                int[,] nextGeneration = new int[row, col];


                for (int r = 0; r < row; r++)
                {
                    for (int c = 0; c < col; c++)
                    {
                        countOfGreen = GetCountOfGreen(r, c, generationZero);
                        
                        int newColor = ChangeColor(generationZero[r, c], countOfGreen);

                        nextGeneration[r, c] = newColor;
                    }
                }

                 generationZero = nextGeneration;

                if (generationZero[y1, x1] == 1)
                {
                    result++;
                }
            }

            Console.WriteLine(result);
        }
        public static int ChangeColor(int color, int countOfGreen)
        {

            
            if (color == 0)
            {
                if (countOfGreen == 3 || countOfGreen == 6)
                {
                    color = 1;
                }
            }
            else if (color == 1)
            {
                if (countOfGreen != 2 && countOfGreen != 3 && countOfGreen != 6)
                {
                    color = 0;
                }


            }

            return color;

        }

        public static  int GetCountOfGreen(int row, int col, int[,] grid)
        {
            int count = 0;

            if (row-1 >=0)
            {
                if (grid[row-1,col]==1)
                {
                    count++;
                }

                if (col-1>=0)
                {
                    if (grid[row-1,col-1]==1)
                    {
                        count++;
                    }
                }

                if (col+1<grid.GetLength(1))
                {
                    if (grid[row-1,col+1]==1)
                    {
                        count++;
                    }
                }
            }

            if (col-1>=0)
            {
                if (grid[row,col-1]==1)
                {
                    count++;
                }
            }

            if (col+1<grid.GetLength(1))
            {
                if (grid[row,col+1]==1)
                {
                    count++;
                }
            }

            if (row+1<grid.GetLength(0))
            {
                if (col-1>=0)
                {
                    if (grid[row+1,col-1]==1)
                    {
                        count++;
                    }
                }

                if (grid[row+1,col]==1)
                {
                    count++;
                }

                if (col+1<grid.GetLength(1))
                {
                    if (grid[row+1,col+1]==1)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
