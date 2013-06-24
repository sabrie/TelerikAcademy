using System;

class MatrixTest
{
    static void Main(string[] args)
    {
        Matrix<int> matrix = new Matrix<int>(4,4); // here the matrix is not a non-zero - all elements are 0

        Console.WriteLine("Test for the \"true\" and \"false\" operator: ");
        // test for the true operator
        Console.WriteLine(matrix ? "Not empty" : "Empty"); // Empty
                
        matrix[0, 0] = 1; // here the matrix is already a non-zero -> not all elements are zero
        // test for the false operator
        Console.WriteLine(matrix ? "Not empty" : "Empty"); // Not Empty
        Console.WriteLine();

        Console.WriteLine("First Matrix: ");
        // test for adding two matrices
        Matrix<int> matrix1 = new Matrix<int>(2,2);
        matrix1[0, 0] = 1;
        matrix1[0, 1] = 2;
        matrix1[1, 0] = 3;
        matrix1[1, 1] = 4;
        
        // prints the matrix using the overriden ToSting();
        Console.WriteLine(matrix1);

        Console.WriteLine("Second Matrix: ");
        Matrix<int> matrix2 = new Matrix<int>(2, 2);
        matrix2[0, 0] = 2;
        matrix2[0, 1] = 2;
        matrix2[1, 0] = 2;
        matrix2[1, 1] = 2;

        // prints the matrix using the overriden ToSting();
        Console.WriteLine(matrix2);

        // prints the addition of the two matrices using the predefined operator +
        Console.WriteLine("Addition of the matrices!");
        Console.WriteLine(matrix1 + matrix2);

        // prints the subtraction of the two matrices using the predefined operator -
        Console.WriteLine("Subtraction of the matrices!");
        Console.WriteLine(matrix1 - matrix2);

        // prints the multiplication of the two matrices using the predefined operator *
        Console.WriteLine("Multiplication of the matrices!");
        Console.WriteLine(matrix1 * matrix2);

        
        //// this will throw an exception as we cannot add two matrices which have different size

        //Console.WriteLine(new string('-', 25));
        //Console.WriteLine("TEST FOR EXCEPTIONS!");
        //Console.WriteLine(new string('-', 25));
        //Console.WriteLine("First Matrix: ");
        //// test for adding two matrices
        //Matrix<int> matrix3 = new Matrix<int>(2, 2);
        //matrix1[0, 0] = 1;
        //matrix1[0, 1] = 2;
        //matrix1[1, 0] = 3;
        //matrix1[1, 1] = 4;

        //// prints the matrix using the overriden ToSting();
        //Console.WriteLine(matrix1);

        //Console.WriteLine("Second Matrix: ");
        //Matrix<int> matrix4 = new Matrix<int>(3, 3);
        //matrix2[0, 0] = 2;
        //matrix2[0, 1] = 2;
        //matrix2[0, 2] = 2;
        //matrix2[1, 0] = 2;
        //matrix2[1, 1] = 2;
        //matrix2[1, 2] = 2;

        //// this will throw an exception as we cannot add two matrices which have different size 
        //Console.WriteLine(matrix3 + matrix4);
    }
}

