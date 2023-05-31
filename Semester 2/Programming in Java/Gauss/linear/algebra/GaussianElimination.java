package linear.algebra;

import java.text.DecimalFormat;

public class GaussianElimination
{
    private int rows;
    private int cols;
    private double[][] matrix;

    public GaussianElimination(int rows, int cols, double[][] matrix)
    {
        this.rows = rows;
        this.cols = cols;

        checkMatrixDimensions(matrix);

        this.matrix = matrix;
    }

    private void checkMatrixDimensions(double[][] matrix)
    {
        if (matrix.length != rows)
        {
            throw new IllegalArgumentException();
        }
        for (int i = 0; i < rows; i++)
        {
            if (matrix[i].length != cols)
            {
                throw new IllegalArgumentException();
            }
        }
    }

    public int getRows()
    {
        return rows;
    }

    public int getCols()
    {
        return cols;
    }

    public double[][] getMatrix()
    {
        return matrix;
    }

    public void setMatrix(double[][] matrix)
    {
        checkMatrixDimensions(matrix);

        this.matrix = matrix;
    }

    private int argMax(int i, int j)
    {
        double max = Math.abs(matrix[i][j]);
        int maxRowInd = i;

        for (int currRow = i + 1; currRow < rows; currRow++)
        {
            if (Math.abs(matrix[currRow][j]) > max)
            {
                max = Math.abs(matrix[currRow][j]);
                maxRowInd = currRow;
            }
        }

        return maxRowInd;
    }

    private void swapRows(int u, int v)
    {
        for (int i = 0; i < cols; i++)
        {
            double temp = matrix[u][i];
            matrix[u][i] = matrix[v][i];
            matrix[v][i] = temp;
        }
    }

    private void multiplyAndAddRow(int addRow, int mulRow, int colIndex)
    {
        double f = matrix[addRow][colIndex] / matrix[mulRow][colIndex];
        matrix[addRow][colIndex] = 0;
        for (int i = colIndex + 1; i < cols; i++)
        {
            matrix[addRow][i] -= matrix[mulRow][i] * f;
        }
    }

    private void multiplyRow(int i, int j)
    {
        double divisor = matrix[i][j];
        for (int currCol = j; currCol < cols; currCol++)
        {
            matrix[i][currCol] /= divisor;
        }
    }

    public void print()
    {
        char[] alphabet = "abcdefghijklmnopqrstuvwxyz".toCharArray();
        DecimalFormat rounded = new DecimalFormat("0.00");

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (j == cols - 1)
                {
                    System.out.print(" = " + rounded.format(matrix[i][j]));
                }
                else
                {
                    System.out.print(((matrix[i][j] < 0) ? "-" : "+") + rounded.format(Math.abs(matrix[i][j])) + alphabet[j]);
                }
            }
            System.out.println();
        }
        System.out.println();
    }

    public void rowEchelonForm()
    {
        int pivotRow = 0; // pivot row
        int pivotCol = 0; // pivot column

        while (pivotRow < rows && pivotCol < cols)
        {
            int i_max = argMax(pivotRow, pivotCol);
            if (matrix[i_max][pivotCol] == 0)
            {
                pivotCol++;
            }
            else
            {
                swapRows(pivotRow, i_max);
                for (int i = pivotRow + 1; i < rows; i++)
                {
                    multiplyAndAddRow(i, pivotRow, pivotCol);
                }

                multiplyRow(pivotRow, pivotCol);

                pivotRow++;
                pivotCol++;
            }
        }
    }

    public void backSubstitution()
    {
        int currRow = rows - 1;
        int currCol = cols - 2;
        while (currRow >= 0)
        {
            if (matrix[currRow][currCol] == 0)
            {
                throw new IllegalArgumentException();
            }

            for (int addRow = currRow - 1; addRow >= 0; addRow--)
            {
                multiplyAndAddRow(addRow, currRow, currCol);
            }

            currRow--;
            currCol--;
        }
    }
}