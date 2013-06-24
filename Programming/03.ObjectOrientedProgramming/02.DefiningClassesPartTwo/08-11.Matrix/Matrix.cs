using System;
using System.Text;

public class Matrix<T>
{
    // field
    private T[,] matrix;

    // constructor
    public Matrix(int rows, int cols)
    {
        this.matrix = new T[rows, cols];
    }

    // indexer to access the inner matrix cells 
    public T this[int row, int col]
    {
        get { return matrix[row, col]; }
        set { matrix[row, col] = value; }
    }

    // property
    public int Rows
    {
        get { return matrix.GetLength(0); }
    }

    // property
    public int Cols {
        get { return matrix.GetLength(1); }
    }

    // operator + for addition of matrices of the same size 
    public static Matrix<T> operator +(Matrix<T> matrix1, Matrix<T> matrix2)
    {
        if (matrix1.Rows != matrix2.Rows || matrix1.Cols != matrix2.Cols)
        {
            throw new ArgumentException(String.Format("The two matrices cannot be added!"));
        }
        
        Matrix<T> result = new Matrix<T>(matrix1.Rows, matrix1.Cols);

        for (int row = 0; row < result.Rows; row++)
        {
            for (int col = 0; col < result.Cols; col++)
            {
                result[row,col] = (dynamic)matrix1[row,col] + matrix2[row,col];
            }
        }
        
        return result;
    }

    // operator "-" for subtraction of matrices of the same size 
    public static Matrix<T> operator -(Matrix<T> matrix1, Matrix<T> matrix2)
    {
        if (matrix1.Rows != matrix2.Rows || matrix1.Cols != matrix2.Cols)
        {
            throw new ArgumentException(String.Format("The two matrices cannot be substracted!"));
        }
        Matrix<T> result = new Matrix<T>(matrix1.Rows, matrix1.Cols);
        
        for (int row = 0; row < result.Rows; row++)
        {
            for (int col = 0; col < result.Cols; col++)
            {
                result[row, col] = (dynamic)matrix1[row, col] - matrix2[row, col];
            }
        }

        return result;
    }

    // operator "*" for multiplication of matrices of the same size
    public static Matrix<T> operator *(Matrix<T> matrix1, Matrix<T> matrix2)
    {
        if (matrix1.Cols != matrix2.Rows)
        {
            throw new ArgumentException(String.Format("The two matrices cannot be multiplied!"));
        }

        Matrix<T> result = new Matrix<T>(matrix1.Rows, matrix2.Cols); // m1.Rows x m2.Cols

        for (int row = 0; row < result.Rows; row++)
        {
            for (int col = 0; col < result.Cols; col++)
            {
                for (int k = 0; k < matrix1.Cols; k++)
                {
                    result[row, col] += (dynamic)matrix1[row, k] * matrix2[k, col];//(dynamic)matrix1[row, col] * matrix2[row, col];
                }
            }
        }

        return result;
    }

    // implements the operator "true" to check for non-zero elements
    public static bool operator true(Matrix<T> matrix)
    {
        for (int rows = 0; rows < matrix.Rows; rows++)
        {
            for (int cols = 0; cols < matrix.Cols; cols++)
            {
                if ((dynamic)matrix[rows, cols] != 0)
                {
                    return true;
                }               
            }
        }
        return false;
    }

    // implements the operator "false" to check for non-zero elements
    public static bool operator false(Matrix<T> matrix)
    {
        for (int rows = 0; rows < matrix.Rows; rows++)
        {
            for (int cols = 0; cols < matrix.Cols; cols++)
            {
                if ((dynamic)matrix[rows, cols] == 0)
                {
                    return true;
                }
            }
        }
        return false;
    }

    // method that overrides ToString()
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        for (int rows = 0; rows < matrix.GetLength(0); rows++)
        {
            for (int cols = 0; cols < matrix.GetLength(1); cols++)
            {
                sb.Append(matrix[rows, cols]+ " ");
            }
            sb.AppendLine();
        }

        return sb.ToString();
    }
}

