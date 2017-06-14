using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Mark
    {
        public static double sigmaAve(double SQRAve, double sum)
        {
            double Save = SQRAve / Math.Sqrt(sum);
            return Save;
        }
        public static double sigmaSQRAve(double SQRAve, double sum)
        {
            double SQRVA = SQRAve / Math.Sqrt(2 * sum);
            return SQRVA;
        }
        public static double sigmaAssimetric(double sum)
        {
            double SAssimetric = Math.Sqrt((6 * (sum - 2)) / (sum + 1) * (sum + 3));
            return SAssimetric;
        }
        public static double sigmaExes(double sum)
        {
            double SExes = Math.Sqrt((24 / sum) * (1 - (225 / (15 * sum + 124))));
            return SExes;
        }
        public static double sigmaContrExes(double EX, double sum)
        {
            double SContrExes = Math.Sqrt((Math.Abs(EX) / (29 * sum)) * Math.Pow(Math.Abs(Math.Pow(EX, 2) - 1), 3 / 4));
            return SContrExes;
        }
        public static double sigmaPirson(double Var_Pirson, double sum)
        {
            double SPirson = Var_Pirson * Math.Sqrt((1 + 2 * Math.Pow(Var_Pirson, 2)) / (2 * sum));
            return Math.Abs(SPirson);
        }
    }
    class Moment
    {
        public static double StartMoment(int k, double sum, List<double> A)
        {
            double sm = 0;
            for (int i = 0; i < sum; i++)
            {
                sm += Math.Pow(A[i], k);
            }
            double SM = sm / sum;
            return SM;
        }
        public static double CenterMoment(int k, double sum, List<double> A)
        {
            double cm = 0;
            for(int i = 0; i < sum; i++)
            {
                cm += Math.Pow((A[i] - StartMoment(k, sum, A)), k);
            }
            double CM = cm / sum;
            return CM;
        }
    }
    class Quantil
    {
        public static double NormalQuantil()
        {
            double a = 0.95;
            double p = a / 2;
            double t = Math.Abs(Math.Sqrt(Math.Log(1 / Math.Pow(p, 2))));
            double Ealpha = 4.5 * Math.Pow(10, -4);
            double c0 = 2.515517;
            double c1 = 0.802853;
            double c2 = 0.010328;
            double d1 = 1.432788;
            double d2 = 0.1892659;
            double d3 = 0.001308;
            double u = t - ((c0 + c1*t + c2*Math.Pow(t,2)) / (1 + d1*t + d2*Math.Pow(t,2) + d3*Math.Pow(t,3))) + Ealpha;
            return u;
        }
        public static double StudentQuantil(double sum, List<double> A)
        {
            double g1 = (Math.Pow(NormalQuantil(), 3) + NormalQuantil())/4;
            double g2 = (5 * Math.Pow(NormalQuantil(), 5) + 16 * Math.Pow(NormalQuantil(), 3) + 3 * NormalQuantil()) / 96;
            double g3 = (3 * Math.Pow(NormalQuantil(), 7) + 19 * Math.Pow(NormalQuantil(), 5) + 17 * Math.Pow(NormalQuantil(), 3) + 15 * NormalQuantil()) / 384;
            double g4 = (79 * Math.Pow(NormalQuantil(), 9) + 779 * Math.Pow(NormalQuantil(), 7) + 1482 * Math.Pow(NormalQuantil(), 5) + 1920 * Math.Pow(NormalQuantil(),3) + 945 * NormalQuantil()) / 92160;
            double SQ = NormalQuantil() + (g1 / Moment.StartMoment(1, sum, A) + (g2 / Moment.StartMoment(2, sum, A)) + (g3 / Moment.StartMoment(3, sum, A)) + (g4 / Moment.StartMoment(4, sum, A)));
            return SQ;
        }
    }
    class Interval_Mark
    {
        public static double LowLimitAve(double Ave, double SQRAve, double sum, List<double> A)
        {
            double LLA = Ave - Math.Abs(Quantil.StudentQuantil(sum, A)) * Mark.sigmaAve(SQRAve, sum);
            return LLA;
        }
        public static double LowLimitSQRAve(double SQRAve, double sum, List<double> A)
        {
            double LLSA = SQRAve - Math.Abs(Quantil.StudentQuantil(sum, A)) * Mark.sigmaSQRAve(SQRAve, sum);
            return LLSA;
        }
        public static double LowLimitAssimetric(double Assimetric, double sum, List<double> A)
        {
            double LLAs = Assimetric - Math.Abs(Quantil.StudentQuantil(sum, A)) * Mark.sigmaAssimetric(sum);
            return LLAs;
        }
        public static double LowLimitExes(double Exes, double sum, List<double> A)
        {
            double LLEx = Exes - Math.Abs(Quantil.StudentQuantil(sum, A)) * Mark.sigmaExes(sum);
            return LLEx;
        }
        public static double LowLimitContrExes(double ConterEx, double Ex, double sum, List<double> A)
        {
            double LLCE = ConterEx - Math.Abs(Quantil.StudentQuantil(sum, A)) * Mark.sigmaContrExes(Ex, sum);
            return LLCE;
        }
        public static double LowLimitPirson(double Var_Pirson, double sum, List<double> A)
        {
            double LLP = Var_Pirson - Math.Abs(Quantil.StudentQuantil(sum, A)) * Mark.sigmaPirson(Var_Pirson, sum);
            return LLP;
        }
        public static double HighLimitAve(double Ave, double SQRAve, double sum, List<double> A)
        {
            double HLA = Ave + Math.Abs(Quantil.StudentQuantil(sum, A)) * Mark.sigmaAve(SQRAve, sum);
            return HLA;
        }
        public static double HighLimitSQRAve(double SQRAve, double sum, List<double> A)
        {
            double HLSA = SQRAve + Math.Abs(Quantil.StudentQuantil(sum, A)) * Mark.sigmaSQRAve(SQRAve, sum);
            return HLSA;
        }
        public static double HighLimitAssimetric(double Assimetric, double sum, List<double> A)
        {
            double HLAs = Assimetric + Math.Abs(Quantil.StudentQuantil(sum, A)) * Mark.sigmaAssimetric(sum);
            return HLAs;
        }
        public static double HighLimitExes(double Exes, double sum, List<double> A)
        {
            double HLEx = Exes + Math.Abs(Quantil.StudentQuantil(sum, A)) * Mark.sigmaExes(sum);
            return HLEx;
        }
        public static double HighLimitContrExes(double ConterEx, double Ex, double sum, List<double> A)
        {
            double HLCE = ConterEx + Math.Abs(Quantil.StudentQuantil(sum, A)) * Mark.sigmaContrExes(Ex, sum);
            return HLCE;
        }
        public static double HighLimitPirson(double Var_Pirson, double sum, List<double> A)
        {
            double HLP = Var_Pirson + Math.Abs(Quantil.StudentQuantil(sum, A)) * Mark.sigmaPirson(Var_Pirson, sum);
            return HLP;
        }
    }
    class PointMark
    {
        public static double Ave(List<double> A)
        {
            double sum = 0;
            int count = A.Count;
            for (int i = 0; i < A.Count; i++)
            {
                sum += A[i];
            }
            double ave = (sum / count);
            return ave;
        }
        public static double Med(List<double> A)
        {
            double MED = 0;
            if (A.Count % 2 != 0)
            {
                double n_1 = A[(A.Count / 2) + 1];
                MED = n_1;
            }
            else
            {
                double n = A[A.Count / 2];
                double n_1 = A[(A.Count / 2) + 1];
                MED = (n + n_1) / 2;
            }
            return MED;
        }
        public static double Mad(List<double> A, double MED)
        {
            List<double> mad = new List<double>();
            double MAD;

            for (int i = 1; i < A.Count; i++)
            {
                double med = A[i] - MED;
                mad.Add(med);
            }
            mad.Sort();
            double med1 = 0;
            if (mad.Count % 2 != 0)
            {
                med1 = mad[(mad.Count / 2) + 1];
            }
            else
            {
                double n = mad[mad.Count / 2];
                double n_1 = mad[(mad.Count / 2) + 1];
                med1 = (n + n_1) / 2;
            }
            MAD = 1.483 * med1;
            return MAD;
        }
        public static double Disp(List<double> A, double Ave)
        {
            double sumanum = 0;
            double sum = A.Count;
            for (int i = 0; i < A.Count; i++)
            {
                double Xs = Math.Pow(A[i], 2) - 2 * A[i] * Ave + Math.Pow(Ave, 2);
                sumanum += Xs;
            }
            double disp = sumanum / (sum - 1);
            return disp;
        }
        public static double SQRAve(double disp)
        {
            double SQRAve = Math.Sqrt(disp);
            return SQRAve;
        }
        public static double DisSqrAve(List<double> A, double Ave)
        {
            double Xnum = 0;
            double sum = A.Count;
            for (int i = 0; i < A.Count; i++)
            {
                double Xq = (A[i] + Ave) * (A[i] - Ave);
                Xnum += Xq;
            }
            double disposeSQRAve = Math.Sqrt(Xnum / sum);
            return disposeSQRAve;
        }
        public static double Assimetric(List<double> A, double Ave, double DispSqrAve)
        {
            double sumas = 0;
            double sum = A.Count;
            for (int i = 0; i < A.Count; i++)
            {
                double g = Math.Pow(A[i] - Ave, 3);
                sumas += g;
            }
            double DisAs = sumas / (sum * Math.Pow(DispSqrAve, 3));
            double As = (Math.Sqrt(sum * (sum - 1)) * DisAs) / (sum - 2);
            return As;
        }
        public static double Exes(List<double> A, double Ave, double DispSqrAve)
        {
            double sumex = 0;
            double sum = A.Count;
            for (int i = 0; i < A.Count; i++)
            {
                double g = Math.Pow(A[i] - Ave, 4);
                sumex += g;
            }
            double DisEx = sumex / (sum * Math.Pow(DispSqrAve, 4));
            double Ex = ((Math.Pow(sum, 2) - 1) / ((sum - 2) * (sum - 3))) * ((DisEx - 3) + (6) / (sum + 1));
            return Ex;
        }
        public static double ConterEx(double Ex)
        {
            double ContrEx = 1 / Math.Sqrt(Math.Abs(Ex));
            return ContrEx;
        }
        public static double Var_Pirson(double AVE, double SQRAve)
        {
            double Var_Pirson = SQRAve / AVE;
            return Var_Pirson;
        }
        public static double No_Param_Kovar(double MED, double MAD)
        {
            double no_param_kovar = MAD / MED;
            return no_param_kovar;
        }
        public static double Yolsh(List<double> X)
        {
            List<double> MAD = new List<double>();
            for (int i = 0; i < X.Count; i++)
                for (int j = i; j < X.Count; j++)
                    MAD.Add((X[i] + X[j]) / 2);
            MAD.Sort();
            return MAD[(int)(MAD.Count / 2)];
        }
    }
    class Abnormals
    {
       public static List<double> AbnormalsX(List<double> X, double sum)
        {
            int N = 0;
            double
                       t = 1.55 + 0.8 * (Math.Sqrt(Math.Abs(PointMark.Exes(X, PointMark.Ave(X), PointMark.DisSqrAve(X, PointMark.Ave(X))))) * Math.Log10(sum / 10)),
                       A = PointMark.Ave(X) - t * PointMark.DisSqrAve(X, PointMark.Ave(X)),
                       B = PointMark.Ave(X) + t * PointMark.DisSqrAve(X, PointMark.Ave(X));
            List<double> F = new List<double>();
            /*double[] Buf_allnum = new double[allnum.Length];*/ // temporary array

            for (int i = 0; i < sum; i++)
            {
                if (X[i] < B && X[i] > A)
                {
                    F.Add(X[i]);
                }
            }
            X = F;
            N = X.Count;
            return X;
        }
    }
}