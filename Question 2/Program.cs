using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_2
{
    class Program
    {
        public static int findDeepestPitPlan(int[] A)
        {
            int n = A.Length;

            int maxDepth = -1;
            int P = 0, Q = -1, R = -1;

            for (int i = 1; i < n; i++)
            {
                if (Q < 0 && A[i] < A[i - 1])
                {
                    Q = i - 1;
                }
                if (Q >= 0 && (R < 0 || A[i] < A[i - 1]))
                {
                    R = i;
                }
                if (R >= 0 && A[i] > A[i - 1])
                {
                    maxDepth = Math.Max(maxDepth, Math.Min(A[P] - A[Q], A[R] - A[Q]));
                    P = i - 1;
                    Q = -1;
                    R = -1;
                }
            }

            return maxDepth;
        }

        public static int findDeepestPit(int[] A)
        {
            int n = A.Length;
            int maxDepth = -1;

            for (int P = 0; P < n - 2; P++)
            {
                for (int Q = P + 1; Q < n - 1; Q++)
                {
                    if (A[P] > A[Q])
                    {
                        for (int R = Q + 1; R < n; R++)
                        {
                            if (A[Q] < A[R])
                            {
                                int depth = Math.Min(A[P] - A[Q], A[R] - A[Q]);
                                maxDepth = Math.Max(maxDepth, depth);
                            }
                        }
                    }
                }
            }

            return maxDepth;
        }
        static void Main(string[] args)
        {
            int[] A = { 0, 1, 3, -2, 0, -3, 2, 3 };
            int[] B = { 1, 2, 3, 1, 2, 3, 1, 2, 3 };
            Console.Write(findDeepestPit(B)); // Output should be the depth of the deepest pit

            Console.Read();
        }
    }
}
