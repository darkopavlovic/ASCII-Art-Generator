using System;
using System.IO;

namespace ASCII_Art_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            string strLine = null; //Hold line from txt file
            string[] strArray = null; //Hold split string
            int unicode; //Hold ASCII value
            char character; //Hold ASCII character

            int rows = 85; //Grid row
            int columns = 100; //Grid column

            //Create 2D array for grid
            string[,] strPrint = new string[rows, columns];

            //Fill 2D array with white space
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    strPrint[i, j] = " ";
                }
            }

            //Reads in txt file
            using (StreamReader sr = new StreamReader("../../../ascii.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    strLine = sr.ReadLine().Replace("[", "").Replace("]", "");
                    strArray = strLine.Split(',');

                    //Adds the ASCII value to the correct x,y
                    strPrint[int.Parse(strArray[1]), int.Parse(strArray[0])] = strArray[2].ToString();
                }
            }

            //Print grid
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (strPrint[i, j] != " ")
                    {
                        //Convert ASCII value to char
                        unicode = int.Parse(strPrint[i, j]);
                        character = (char)unicode;
                        Console.Write(character);
                        if (j == columns - 1)
                        {
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.Write(strPrint[i, j]);
                        if (j == columns - 1)
                        {
                            Console.WriteLine();
                        }
                    }
                }
            }
        }
    }
}
