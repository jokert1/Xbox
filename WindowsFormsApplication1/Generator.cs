using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Generator
    {
        public static List<double> Exp(double len, double l)
        {
            List<double> X = new List<double>();

            for (int i = 0; i < len; i++)
            {
                X.Add(TestSimpleRNG.SimpleRNG.GetExponential(1 / l));
            }
            return X;
        }
        public static List<double> Norm(double len, double Ave, double SQRAve)
        {
            List<double> X = new List<double>();

            for (int i = 0; i < len; i++)
            {
                X.Add(TestSimpleRNG.SimpleRNG.GetNormal(Ave, SQRAve));
            }
            return X;
        }
        public static List<double> LogNorm(double len,double Ave, double SQRAve)
        {
            double mu = Math.Log(Ave);
            List<double> X = new List<double>();
            for(int i = 0; i < len; i++)
            {
                X.Add(TestSimpleRNG.SimpleRNG.GetLogNormal(mu, SQRAve));
            }
            for(int i = 0; i < X.Count; i++)
            {
                X[i] = Math.Round(X[i], 4);
            }
            return X;
        }
    }
}
