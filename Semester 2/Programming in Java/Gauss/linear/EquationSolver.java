package linear;

import linear.algebra.GaussianElimination;

public class EquationSolver 
{
    public static void main(String[] args) 
    {
        double[][] matrix = stringsToDoubles(args);
        GaussianElimination ge = new GaussianElimination(matrix.length, matrix[0].length, matrix);
        ge.print();
        ge.rowEchelonForm();
        ge.print();
        ge.backSubstitution();
        ge.print();
    }

    public static double[][] stringsToDoubles(String[] conv)
    {
        double[][] doubleArr = new double[conv.length][];

        for (int i = 0; i < conv.length; i++)
        {
            String[] currRow = conv[i].split(",");
            doubleArr[i] = new double[currRow.length];
            for (int j = 0; j < doubleArr[i].length; j++)
            {
                doubleArr[i][j] = Double.parseDouble(currRow[j]);
            }
        }

        return doubleArr;
    }
}
