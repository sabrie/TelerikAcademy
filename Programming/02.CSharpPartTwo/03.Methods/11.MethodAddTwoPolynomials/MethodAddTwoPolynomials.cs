/* Write a method that adds two polynomials. Represent them as arrays of 
 * their coefficients as in the example below: x2 + 5 = 1x2 + 0x + 5 -> 5 0 1
*/

using System;

class MethodAddTwoPolynomials
{
    static int[] AddTwoPolinomials(int[] firstPolynomial, int[] secondPolynomial)
    {
        int minLength = Math.Min(firstPolynomial.Length, secondPolynomial.Length);
        int maxLength = Math.Max(firstPolynomial.Length, secondPolynomial.Length);

        // holds the value of the sum of the two polynomials
        int[] result = new int[maxLength];
        for (int i = 0; i < maxLength; i++)
        {
            if (i < minLength)
            {
                result[i] = firstPolynomial[i] + secondPolynomial[i];
            }
            else
            {
                if (firstPolynomial.Length > secondPolynomial.Length)
                {
                    result[i] = firstPolynomial[i];
                }
                else
                {
                    result[i] = secondPolynomial[i];
                }
            }            
        }
        return result;
    }

    static void PrintArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }


    static void Main()
    {
        // polynomials are represented as arrays of their coefficients 
        // as in the example : x2 + 5 = 1x2 + 0x + 5 -> 5 0 1
        Console.WriteLine("Polynomials are represented as arrays of their coefficients");
        Console.Write("First Polynomial: ");
        int[] firstPolynomial = {5, 0, 1};
        PrintArray(firstPolynomial);

        Console.Write("Second Polynomial: ");
        int[] secondPolynomial = {3, 2, 1, 6 };
        PrintArray(secondPolynomial);

        Console.Write("Sum of Polynomials: ");
        int[] sum = AddTwoPolinomials(firstPolynomial, secondPolynomial);
        PrintArray(sum);
    }
}

