using System;

class MissCat
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        // row 0 - cats' numbers
        // row 1 - votes of the jury which corresponds to the cat number 
        // (to be assigned in the switch statement)
        int[,] cat = 
        {
           {1, 2, 3, 4, 5, 6, 7, 8, 9, 10},
           {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},   
        };

        // reads the votes of the jury - n times
        // assigns the number of votes a particular cat has received to array elements in row 1
        // which corresponds to cat numbers in row 0 
        for (int i = 0; i < n; i++)
        {
            int vote = int.Parse(Console.ReadLine());

            switch (vote)
            {
                case 1:
                    cat[1, 0] += 1;
                    break;
                case 2:
                    cat[1, 1] += 1;
                    break;
                case 3:
                    cat[1, 2] += 1;
                    break;
                case 4:
                    cat[1, 3] += 1;
                    break;
                case 5:
                    cat[1, 4] += 1; ;
                    break;
                case 6:
                    cat[1, 5] += 1;
                    break;
                case 7:
                    cat[1, 6] += 1;
                    break;
                case 8:
                    cat[1, 7] += 1;
                    break;
                case 9:
                    cat[1, 8] += 1;
                    break;
                case 10:
                    cat[1, 9] += 1;
                    break;
            }
        }

        int winnerIndex = 0;
        // compares the array elements in row 1 and finds the one with greatest value 
        for (int j = 1; j < 10; j++)
        {
            if (cat[1, winnerIndex] < cat[1, j])
            {
                winnerIndex = j;
            }
        }
        int winner = cat[0, winnerIndex];
        // prints the result
        Console.WriteLine(winner);
    }
}

