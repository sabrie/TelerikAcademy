/* We are given a matrix of strings of size N x M. Sequences in the matrix we define 
 * as sets of several neighbor elements located on the same line, column or diagonal. 
 * Write a program that finds the longest sequence of equal strings in the matrix.
 */
using System;

class FindLongestSeqOfEqualStrings
{
    static void Main()
    {
        //string[,] strMatrix= new string[,]
        //{
        //    {"ha", "fifi", "ho", "hi"},
        //    {"fo", "as", "hi", "xx"},
        //    {"xxx", "fo", "ha", "as"}
        //};
        // result - fo fo

        //string[,] strMatrix = new string[,]
        //{
        //    {"ha", "fifi", "ho", "s"},
        //    {"fo", "ha", "hi", "s"},
        //    {"xxx", "fo", "ha", "s"}
        //};
        // result - s s s

        string[,] strMatrix = new string[,]
        {
            {"ha", "fifi", "ho", "hi"},
            {"fo", "ha", "hi", "xx"},
            {"xxx", "ho", "ha", "xx"}
        }; 
          // result ha ha ha


        int currentSeqRow = 1; // counts the sequence of equal elements on the same row
        int maxSequence = 1; // holds the value of maximal sequence of equal elements
        string bestElement = "ne"; // holds the value of the element which has maximal sequence

        // compare neighbour elements on the same row
        for (int row = 0; row < strMatrix.GetLength(0); row++)
        {
            for (int col = 0; col < strMatrix.GetLength(1) - 1; col++)
            {
                // if neighbour elements are equal we increase the value of currentSequence counter
                if (strMatrix[row, col] == strMatrix[row, col + 1])
                {
                    currentSeqRow++;
                }
                // if neighbour elements are not equal we assign the value 1 to currentSequence
                // because this is the minimal value for a max sequence in an array
                else
                {
                    currentSeqRow = 1;
                }
                if (currentSeqRow > maxSequence)
                {
                    maxSequence = currentSeqRow;
                    bestElement = strMatrix[row, col];
                }
            }            
        }

        int currentSeqCol = 1; // counts the sequence of equal elements on the same row
        
        // compare neighbour elements on the same col
        for (int col = 0; col < strMatrix.GetLength(1); col++)
        {
            for (int row = 0; row < strMatrix.GetLength(0) - 1; row++)
            {
                // if neighbour elements are equal we increase the value of currentSequence counter
                if (strMatrix[row, col] == strMatrix[row + 1, col])
                {
                    currentSeqCol++;
                }
                // if neighbour elements are not equal we assign the value 1 to currentSequence
                // because this is the minimal value for a max sequence in an array
                else
                {
                    currentSeqCol = 1;
                }
                if (currentSeqCol > maxSequence)
                {
                    maxSequence = currentSeqCol;
                    bestElement = strMatrix[row, col];
                }
            }
        }

        int currentSeqRightDiag = 1;
        // compare neighbour elements on the same diagonal in the top-right
        for (int i = 0; i < strMatrix.GetLength(1); i++)
        {
            for (int row = 0, col = i; col < strMatrix.GetLength(1) - 2; row++, col++)
            {
                // if neighbour elements are equal we increase the value of currentSequence counter
                if (strMatrix[row, col] == strMatrix[row + 1, col + 1])
                {
                    currentSeqRightDiag++;
                }
                // if neighbour elements are not equal we assign the value 1 to currentSequence
                // because this is the minimal value for a max sequence in an array
                else
                {
                    currentSeqRightDiag = 1;
                }
                if (currentSeqRightDiag > maxSequence)
                {
                    maxSequence = currentSeqRightDiag;
                    bestElement = strMatrix[row, col];
                }
            }            
        }

        int currentSeqLeftDiag = 1;
        // compare neighbour elements on the same left diagonal in the bottom-left part
        for (int i = 1; i < strMatrix.GetLength(0) - 1; i++)
        {
            for (int row = i, col = 0; col < strMatrix.GetLength(0) - 2; row++, col++)
            {
                // if neighbour elements are equal we increase the value of currentSequence counter
                if (strMatrix[row, col] == strMatrix[row + 1, col + 1])
                {
                    currentSeqLeftDiag++;
                }
                // if neighbour elements are not equal we assign the value 1 to currentSequence
                // because this is the minimal value for a max sequence in an array
                else
                {
                    currentSeqLeftDiag = 1;
                }
                if (currentSeqLeftDiag > maxSequence)
                {
                    maxSequence = currentSeqLeftDiag;
                    bestElement = strMatrix[row, col];
                }
            }
        }
        Console.WriteLine();
        // print the matrix
        for (int row = 0; row < strMatrix.GetLength(0); row++)
        {
            for (int col = 0; col < strMatrix.GetLength(1); col++)
            {
                Console.Write("{0,6}", strMatrix[row, col]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        Console.Write("The longest sequence of equal elements is: ");
        // print the result
        for (int i = 0; i < maxSequence; i++)
        {
            Console.Write(bestElement + " ");
        }
        Console.WriteLine();
    }
}

