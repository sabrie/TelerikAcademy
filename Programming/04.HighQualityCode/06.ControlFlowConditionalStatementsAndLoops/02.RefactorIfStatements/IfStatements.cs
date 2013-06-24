/*
 Refactor the following if statements: 

  1. First If statement
  ----------------------
 Potato potato;
//... 
if (potato != null)
   if(!potato.HasNotBeenPeeled && !potato.IsRotten)
	Cook(potato);

 2. Second If statement
 -----------------------
 if (x >= MIN_X && (x =< MAX_X && ((MAX_Y >= y && MIN_Y <= y) && !shouldNotVisitCell)))
{
   VisitCell();
}
 */

using System;
using System.Linq;

class IfStatements
{
    static void Main()
    {
        // First "if statement" refactored
        Potato potato = new Patato();
        //... 

        if (potato != null)
        {
            if (!potato.isRotten && potato.isPeeled)
            {
                Cook(potato);
            }
        }

        // Second "if statement" refactored
        const int MIN_ROW = 10;
        const int MAX_ROW = 20;
        const int MIN_COL = 10;
        const int MAX_COL = 20;
        int currentRow = 12;
        int currentCol = 15;
        bool isRowInRange = IsInRange(currentRow, MIN_ROW, MAX_ROW);
        bool isColInRange = IsInRange(currentCol, MIN_COL, MAX_COL);
        bool[,] isVisited = new bool[MAX_ROW, MAX_COL];

        if (isRowInRange && isColInRange && !isVisited[currentRow, currentCol])
        {
            VisitCell(currentRow, currentCol);
            isVisited[currentRow, currentCol] = true;
        }
    }

    private static bool IsInRange(int valueToCheck, int min, int max)
    {
        if (min >= valueToCheck && valueToCheck <= max)
        {
            return true;
        }
        return false;
    }

    private static void VisitCell(int row, int col)
    {
        //...
    }
}