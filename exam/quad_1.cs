using System;
using static System.Math;
using static System.Double;

public static class quad{

    public static double integrate1D(Func< double, double> f,
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
            else return integrate1D(f, a, (a+b)/2, acc/Sqrt(2), eps, f1, f2) +
                        integrate1D(f, (a+b)/2, b, acc/Sqrt(2), eps, f3, f4); 
        }

    public static double integ2D(
        Func<double, double, double> f,
        double a,   ///lower limit x integral
        double b,   ///upper limit x integral 
        Func<double, double> d,  ///lower limit y integral 
        Func<double, double> u,  ///upper limit y integral 
        double acc=0.01,
        double eps=0.01
    ){
        return IntegrateX(f,a,b,d,u);
    }

    public static double IntegrateX(
        Func<double, double, double> f,
        double a,   ///lower limit x integral
        double b,   ///upper limit x integral 
        Func<double, double> d,  ///lower limit y integral 
        Func<double, double> u,  ///upper limit y integral
        double acc=0.01,
        double eps=0.01
    ){
        Func<double, double> innerIntegrand = y => f(a,y)*u(y);
        Func<double, double> integrand = x =>
        {
            double innerA = d(x);
            double innerB = u(x);
            return IntegrateY(innerIntegrand, innerA, innerB);
        };
        return integrate1D(integrand, a, b);
    }

    public static double IntegrateY(
        Func< double, double> f,
        double a,
        double b,
        double acc=0.01,
        double eps=0.01
    ){
        Func<double, double> integrand = y => f(y); // Ich glaube, hier ist der Fehler
        return integrate1D(integrand, a, b);
    }

}