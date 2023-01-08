namespace EqSolverWinForms
{
    internal static class Controller
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary> 

        //Improvements that could be made
        //1. - support for D = 0, so that the program's accounting for the non-trivial solutions as well
        //2. - calculating the proportions between the x-s in the afformentioned case
        //3. - support for unknowns as coefficients
        //4. - support for imaginary and complex numbers
        //5. - nicer UI
        //6. - easier to handle UX

        static int nOUnknowns;
        static double[,]? equations;
        static double[]? solutions;

        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        public static void SetNOU(int value)
        {
            nOUnknowns = value;

            equations = Matrix.CreateSquared(nOUnknowns);
            solutions = new double[nOUnknowns];
        }

        public static int GetNOU()
        {
            return nOUnknowns;
        }

        public static void SetEq(int row, int col, double value)
        {
            if (equations != null)
            {
                equations[row, col] = value;
            }
        }

        public static void SetSol(int index, double value)
        {
            if (solutions != null)
            {
                solutions[index] = value;
            }
        }

        public static double[,]? GetEq()
        {
            if (equations != null)
            {
                return equations;
            }
            else
                return null;
        }

        public static double[]? GetSol()
        {
            if (solutions != null)
            {
                return solutions;
            }
            else
                return null;
        }

        public static double[] Solve(double[,] equations, double[] solutions)
        {
            double[][,] DMatrices = new double[equations.GetLength(0) + 1][,];
            double[] D = new double[equations.GetLength(0) + 1];
            double[] results = new double[equations.GetLength(0)];

            //D - matrix
            DMatrices[0] = equations;

            //Creating D1 - matrix to DN - matrix
            for (int i = 1; i < DMatrices.GetLength(0); i++)
            {
                //HAVE TO USE ARRAY.CLONE because if not it only creates a reference
                DMatrices[i] = (double[,])DMatrices[0].Clone();

                //replace the i-th column of the Determinant matrix(Dmatrix) with the solutions
                for (int j = 0; j < solutions.Length; j++)
                {
                    DMatrices[i][j, i - 1] = solutions[j];
                }
            }

            //Calculate all of the determinants of all of the matrices D, D1, ... , DN
            for (int i = 0; i < D.Length; i++)
            {
                D[i] = Matrix.Determinant(DMatrices[i]);
            }

            //Calculate the results of the unknowns
            for (int i = 0; i < D.Length - 1; i++)
            {
                results[i] = D[i + 1] / D[0];
            }

            return results;
        }
    }

    //custom class for matrix operations and creating matrices
    public class Matrix
    {
        public static double[,] CreateSquared(int rows)
        {
            return new double[rows, rows];
        }

        public static double[,] Create(int rows, int cols)
        {
            return new double[rows, cols];
        }

        //calculating the determinant
        public static double Determinant(double[,] input)
        {
            if (input.GetLength(0) > 2)
            {
                double value = 0;
                //unfolding determinant by first row
                for (int j = 0; j < input.GetLength(0); j++)
                {
                    double[,] temp = CreateSmallerRank(input, 0, j);
                    value += input[0, j] * (SignOfCurrent(0, j) * Determinant(temp));
                }
                return value;
            }
            //of course this could be deleted but this really helps performance
            else if (input.GetLength(0) == 2)
            {
                return input[0, 0] * input[1, 1] - input[0, 1] * input[1, 0];
            }
            else
            {
                return input[0, 0];
            }
        }

        //for unfolding the determinants, gives the sign of the next member of the addition
        private static int SignOfCurrent(int i, int j)
        {
            int sign = ((i + j) % 2 == 0) ? 1 : -1;
            return sign;
        }

        //Create a matrix that is one rank smaller than 'input' with the specified i row and j column removed
        private static double[,] CreateSmallerRank(double[,] input, int i, int j)
        {
            double[,] output;
            output = new double[input.GetLength(0) - 1, input.GetLength(1) - 1];

            int x = 0, y = 0;
            for (int m = 0; m < input.GetLength(0); m++, x++) //or GetLength(1)
            {
                if (m != i)
                {
                    y = 0;
                    for (int n = 0; n < input.GetLength(0); n++) //or GetLength(1)
                    {
                        if (n != j)
                        {
                            output[x, y] = input[m, n];
                            y++;
                        }
                    }
                }
                else
                {
                    x--;
                }
            }
            return output;
        }
    }
}