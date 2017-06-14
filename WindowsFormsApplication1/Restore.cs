using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meta.Numerics.Functions;

namespace WindowsFormsApplication1
{
    class Restore
    {
        public static double fExp(List<double> X, double x)
        {
            double ave = 0;
            double z = 0;
            for(int i = 0; i < X.Count; i++)
            {
               z += X[i];
                ave = z / X.Count;
            }
            double lamda = 1 / ave;
            double f = lamda * Math.Exp(-1*(lamda*x));

            return f;
        }
        static public double NormalfFound(double x, double m, double g)
        {
            return Math.Exp(-Math.Pow((x - m) / g, 2) / 2) / (g * Math.Sqrt(2 * Math.PI));
        }
        static public double NormalFFound(double x)
        {
            if (x < 0)
            {
                return 1 - NormalFFound(Math.Abs(x));
            }
            double[] b = { 0.31938153, -0.356563782, 1.781477937, -1.821255978, 1.330274429 };
            double e = 7.8 * Math.Pow(10, -8);
            double p = 0.2316419;
            double T = 1 / (1 + p * x);
            double hlpdoubl = Math.Pow(Math.E, -(x * x) / 2) / Math.Sqrt(2 * Math.PI);
            double rez = 1 - hlpdoubl * (b[0] * T + b[1] * Math.Pow(T, 2) + b[2] * Math.Pow(T, 3) + b[3] * Math.Pow(T, 4) + b[4] * Math.Pow(T, 5)) + e;
            return rez;
        }
        public static double FExp(List<double> X, double x)
        {
            double lamda = 1 / PointMark.Ave(X);
            double F = 1 - Math.Exp(-lamda * x);
            return F;
        }
        public static double fNorm(double x, double SQRAve, double AVE)
        {
            double f = (1 / (SQRAve * Math.Sqrt(2 * Math.PI))) * Math.Exp(-((Math.Pow((x - AVE), 2))/(SQRAve)));
            return NormalfFound(x,AVE,SQRAve);
        }
        public static double FNorm(double AVE, double x, double SQRAve)
        {
            return NormalFFound((x - AVE)/SQRAve);
            //double po = 0.2316419;
            //double u = (x - AVE) / SQRAve;
            //double t = 1/(1 + po*u);
            //double b1 = 0.31938153;
            //double b2 = -0.356563782;
            //double b3 = 1.781477937;
            //double b4 = -1.821255978;
            //double b5 = 1.330274429;
            //double F = 1 - ((1 / (SQRAve)))*
            //    Math.Exp(-(Math.Pow(u,2)/2))*((b1*Math.Pow(t,1)) +
            //    ((b2 * Math.Pow(t, 2)) + ((b3 * Math.Pow(t, 3)) + 
            //    ((b4 * Math.Pow(t, 4)) + ((b5 * Math.Pow(t, 5)))))));
            //if (u < 0)
            //    return 1 - F;
            
            //return F;
        }
        public static double FLogNorm(List<double> A, double x)
        {
            List<double> PA = new List<double>();
            for(int i = 0; i < A.Count; i++)
            {
                PA.Add(Math.Pow(A[i], 2));
            }

           for(int i = 0; i < A.Count;i++)
            {
                if(A[i] < 0)
                {
                    A[i] = Math.Abs(A[i]);
                }
            }

            double mu = PointMark.Ave(A)/*2 * Math.Log(Moment.StartMoment(1,A.Count,A))-1/2*Math.Log(Moment.StartMoment(2, A.Count, A))*/;
            double sigm = PointMark.Disp(A, PointMark.Ave(A)) /*Math.Sqrt(Math.Log(Moment.StartMoment(2, A.Count, A)) - 2* Math.Log(Moment.StartMoment(1, A.Count, A)))*/;
            double FLN =(1.0/2) + (1.0/2)*(AdvancedMath.Erf((Math.Log(x) - mu )/(sigm)));
            return FLN;
        }
        public static double dov_exp(List<double> X,double sum,double x)
        {
            double D = 0;
            double N = sum;
            double lamda = 1 / PointMark.Ave(X);
            double nk = Quantil.NormalQuantil();
            double D_lyam = Math.Pow(lamda, 2) / N;
            D = nk * Math.Sqrt(Math.Pow(x, 2) * Math.Exp(-2 * lamda * x) * D_lyam);
            return D;
            }
    }
}
