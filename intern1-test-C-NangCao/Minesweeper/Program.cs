using System;
using System.Text;

namespace Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Symbol: ");
            Console.WriteLine("X: Flag");
            Console.WriteLine("#: not opened");
            Console.WriteLine("-: opened");
            Console.WriteLine("M: mines' location");
            Console.Write("Size of the grid? ");
            int size = int.Parse(Console.ReadLine());
            Console.Write("Number of mines? ");
            int numMines = int.Parse(Console.ReadLine());
            
            // Create game
            int numFlag = numMines;
            int[,] mineGrid = new int[size, size];
            int[,] player = new int[size, size];
            const int MINED = -1, FLAGED = -2, OPENED = -3;

            // Create Mine
            int mineNum = 0;
            while (mineNum < numMines)
            {
                Random rand = new Random();
                int row = rand.Next(size);
                int col = rand.Next(size);
                if (mineGrid[row, col] != MINED)
                {
                    mineGrid[row, col] = MINED;
                    mineNum++;
                }
            }

            // Count Mine surrounding
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (mineGrid[i, j] != MINED)
                    {
                        int count = 0;
                        for (int row = i - 1; row <= i + 1; row++)
                        {
                            for (int col = j - 1; col <= j + 1; col++)
                            {
                                if (row >= 0 && row < size && col >= 0 && col < size && mineGrid[i, j] != MINED)
                                {
                                    count = mineGrid[row, col] == MINED ? count += 1 : count;
                                }
                            }
                        }
                        mineGrid[i, j] = count;
                    }
                }
            }

            // test
            Console.WriteLine("\nMines' location: ");
            Console.Write("  ");
            for (int i = 0; i < size; i++)
            {
                Console.Write(i != size - 1 ? i + " " : i + "\n");
            }
            for (int row = 0; row < size; row++)
            {
                Console.Write(row + " ");
                for (int col = 0; col < size; col++)
                {
                    Console.Write(mineGrid[row, col] == -1 ? "M " : "- ");
                }
                Console.WriteLine();
            }

            // Play
            while (true)
            { 
                Console.Clear();
                // Print Player Grid
                Console.Write("  ");
                for (int i = 0; i < size; i++)
                {
                    Console.Write(i != size-1 ? i + " " : i + "\n");
                }
                for (int row = 0; row < size; row++)
                {
                    Console.Write(row + " ");
                    for (int col = 0; col < size; col++)
                    {
                        Console.Write(player[row, col] == FLAGED ? "X " 
                            : player[row, col] == OPENED && mineGrid[row, col] > 0 ? mineGrid[row, col] + " "
                            : player[row, col] == OPENED ? "- " : "# ");
                    }
                    Console.WriteLine();
                }

                // Exception
                Exception myexception = new Exception("Cell was opened");
                Exception myexception1 = new Exception("Cell was flagged");
                // Ask a command
                Console.WriteLine("Num of flags left: " + numFlag);
                Console.Write("Want to flag/unflag (press \"F\"), restart (press \"R\"), or new step (press enter/other keys)? ");
                string ans = Console.ReadLine().ToLower();
                if (ans.StartsWith("r"))
                {
                    Console.WriteLine("Game stopped");
                    break;
                }
                else if (ans.StartsWith("f"))
                {
                    // Flag
                    while (true)
                    {
                        Console.Write("Flag at row (0 -> {0}) ? ", size);
                        int rowFlag = int.Parse(Console.ReadLine());
                        Console.Write("Flag at col (0 -> {0}) ? ", size);
                        int colFlag = int.Parse(Console.ReadLine());

                        if (player[rowFlag, colFlag] != OPENED && player[rowFlag, colFlag] != FLAGED && numFlag > 0)
                        {
                            player[rowFlag, colFlag] = FLAGED;
                            numFlag--;
                            break;
                        }
                        else if (player[rowFlag, colFlag] == FLAGED)
                        {
                            player[rowFlag, colFlag] = 0;
                            numFlag++;
                            break;
                        }
                        else
                        {
                            Console.WriteLine(myexception);
                        }
                    }
                }
                else
                {
                    // Input step
                    while (true)
                    {
                        try
                        {
                            Console.Write("Step row (0 -> {0}) ? ", size);
                            int newRow = int.Parse(Console.ReadLine());
                            Console.Write("Step column (0 -> {0}) ? ", size);
                            int newCol = int.Parse(Console.ReadLine());
                            // Check if Game ends 
                            if (mineGrid[newRow, newCol] == MINED && player[newRow, newCol] != FLAGED)
                            {
                                Console.WriteLine("\nGame over!!!");
                                break;
                            }
                            else if (player[newRow, newCol] == OPENED)
                            {
                                Console.WriteLine(myexception);
                            }
                            else if (player[newRow, newCol] == FLAGED)
                            {
                                Console.WriteLine(myexception1);
                            }
                            else
                            {
                                player[newRow, newCol] = OPENED;
                                // Open Cell
                                OpenCell(size, mineGrid, player, newRow, newCol);
                                break;
                            }

                        }
                        catch (Exception err)
                        {
                            Console.WriteLine(err.Message);
                        }
                    }
                }


                // Count total Mine left
                int count = 0;
                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        count = (mineGrid[row, col] == MINED && player[row, col] != FLAGED) ? count += 1 : count;
                    }
                }
                if (count == 0)
                {
                    Console.WriteLine("\nWin!!!");
                    break;
                }
            }

            // Print Mine Grid
            Console.WriteLine("\nMines' location: ");
            Console.Write("  ");
            for (int i = 0; i < size; i++)
            {
                Console.Write(i != size - 1 ? i + " " : i + "\n");
            }
            for (int row = 0; row < size; row++)
            {
                Console.Write(row + " ");
                for (int col = 0; col < size; col++)
                {
                    Console.Write(mineGrid[row, col] == -1 ? "M " : "- ");
                }
                Console.WriteLine();
            }
        }

        // Open Cell
        public static void OpenCell(int size, int[,] mineGrid, int[,] player, int row, int col)
        {
            int OPENED = -3, FLAGED = -2;
            // base case 1
            if (mineGrid[row, col] != OPENED && mineGrid[row, col] > 0 )
            {
                player[row, col] = OPENED;
            }
            // base case 2
            else if (player[row, col] == FLAGED) {}
            else if (mineGrid[row, col] == 0)
            {
                player[row, col] = OPENED;
                // open upward
                if (row - 1 >= 0 && player[row - 1, col] != OPENED)
                {
                    OpenCell(size, mineGrid, player, row - 1, col);
                }
                // open downward
                if (row + 1 < size && player[row + 1, col] != OPENED)
                {
                    OpenCell(size, mineGrid, player, row + 1, col);
                }
                // open leftward
                if (col - 1 >= 0 && player[row, col - 1] != OPENED)
                {
                    OpenCell(size, mineGrid, player, row, col - 1);
                }
                // open rightward
                if (col + 1 < size && player[row, col + 1] != OPENED)
                {
                    OpenCell(size, mineGrid, player, row, col + 1);
                }
            }
        }
    }
}
