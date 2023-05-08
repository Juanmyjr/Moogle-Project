namespace MoogleEngine;
public  class Matrix
{
    private int[,] matrix;
    private int rows;
    private int columns;

    public Matrix(int[,] matrix)
    {
        this.matrix = matrix;
        this.rows = matrix.GetLength(0);
        this.columns = matrix.GetLength(1);
    }

    public static Matrix operator +(Matrix matrix1, Matrix matrix2)
    {
        if (matrix1.rows != matrix2.rows || matrix1.columns != matrix2.columns)
        {
            throw new ArgumentException("Las matrices deben tener las mismas dimensiones");
        }

        int[,] result = new int[matrix1.rows, matrix1.columns];

        for (int i = 0; i < matrix1.rows; i++)
        {
            for (int j = 0; j < matrix1.columns; j++)
            {
                result[i, j] = matrix1.matrix[i, j] + matrix2.matrix[i, j];
            }
        }

        return new Matrix(result);
    }

    public int[] ProductbyVector(int[] vector)
    {
        if (this.columns != vector.Length)
        {
            throw new ArgumentException("El vector debe tener la misma cantidad de elementos que columnas en la matriz");
        }

        int[] result = new int[this.rows];

        for (int i = 0; i < this.rows; i++)
        {
            int addition  = 0;

            for (int j = 0; j < this.columns; j++)
            {
                addition  += this.matrix[i, j] * vector[j];
            }

            result[i] = addition ;
        }

        return result;
    }

    public Matrix ProductbyScalar(int scalar)
    {
        int[,] result = new int[this.rows, this.columns];

        for (int i = 0; i < this.rows; i++)
        {
            for (int j = 0; j < this.columns; j++)
            {
                result[i, j] = this.matrix[i, j] * scalar;
            }
        }

        return new Matrix(result);
    }

    public int this[int i, int j]
    {
        get { return this.matrix[i, j]; }
        set { this.matrix[i, j] = value; }
    }
}