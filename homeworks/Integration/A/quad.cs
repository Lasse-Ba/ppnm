using System;
using static System.Math;
using static System.Double;

public static class quad{

    public static double integrate(Func< double, double> f,
        double a,
        double b,
        double acc=0.01,
        double eps=0.01,
        double f2=NaN,
        double f3=NaN){
            double h = b-a;

            if(IsNaN(f2)){
                f2 = f(a+2*h/6);
                f3 = f(a+4*h/6);
            } // first call, no points to reuse

            double f1 = f(a+h/6.0);
            double f4 = f(a+5.0*h/6.0);

            double Q = (2*f1+f2+f3+2*f4)/6*(b-a); // higher order rule
            double q = (  f1+f2+f3+  f4)/4*(b-a); // lower order rule
            double err = Abs(Q-q);
            if(err <= acc+eps*Abs(Q)) return Q;
            else return integrate(f, a, (a+b)/2, acc/Sqrt(2), eps, f1, f2) +
                        integrate(f, (a+b)/2, b, acc/Sqrt(2), eps, f3, f4); 
        }

    public static double erf(double z){
        if(Abs(z)<=1.0){
            Func<double,double> f = x => Exp(-x*x);
            double a = 0.0;
            double b = z;
            double integral = quad.integrate(f,a,b);
            return 2.0/Sqrt(PI) * integral;
        }
        if(1.0<=z){
            Func<double,double> f = x => Exp(-Pow((z+(1-x)/x),2) )/x/x ;
            double a = 0.0;
            double b = 1;
            double integral = quad.integrate(f,a,b);
            return 1-2.0/Sqrt(PI) * integral;
        }
        else return -erf(-z);
    }


}