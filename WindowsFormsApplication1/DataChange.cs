using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class DataChange
    {
        public static List<double> standartA(List<double> A, double sum)
        {
            List<double> X = new List<double>();
            for (int i = 0; i < sum; i++)
            {
                A[i] = (A[i] - PointMark.Ave(A)) / PointMark.SQRAve(PointMark.Disp(A,PointMark.Ave(A)));
            }
            return A;
        }
        public static List<double> logA(List<double> A, double sum, double z = 10)
        {
            if (A.Min() <= 0)
            {
                for (int i = 0; i < sum; i++)
                {
                    A[i] = A[i] + Math.Abs(A.Min()) + 1;
                }
            }
            for (int i = 0; i < sum; i++)
            {
                A[i] = Math.Log(A[i], z);
            }
            return A;
        }
        public static List<double> powA(List<double> A, double sum, double z = 1)
        {
            for (int i = 0; i < sum; i++)
            {
                A[i] = Math.Pow(A[i], z);
            }
            return A;
        }
        public static List<double> dispA(List<double> A, double sum, double z = 1)
        {
            for (int i = 0; i < sum; i++)
            {
                A[i] = A[i] + z;
            }
            return A;
        }
    }
}