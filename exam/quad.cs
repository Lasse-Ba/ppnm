using System;
using static System.Math;
using static System.Double;

public static class quad{

    public static double x_t(double t, double a, double b)
    {
        return a+(b-a)*t;
    }

    public static double w(double w, double a, double b)
    {
        return (b-a)*w;
    }

    /*
    public static double d(double x)
    {
        return x;
    }

    public static double u(double x)
    {
        return x*x;
    }
    */


    public static double Driver1D(
        Func<double, double, double> f, 
        double x, 
        double a, 
        double b, 
        double acc, 
        double eps,
        double f2, 
        double f3)
    {
        double[] high = { 2.0/6, 1.0/6, 1.0/6, 2.0/6 };
        double[] low = { 1.0/4, 1.0/4, 1.0/4, 1.0/4 };
        double[] xs = { 1.0/6, 2.0/6, 4.0/6, 5.0/6 };

        double f1 = f(x, x_t(xs[0], a, b));
        double f4 = f(x, x_t(xs[3], a, b));
        double Q = w(high[0], a, b)*f1 + w(high[1], a, b)*f2 + w(high[2], a, b)*f3 + w(high[3], a, b)*f4;
        double q = w(low[0], a, b)*f1 + w(low[1], a, b)*f2 + w(low[2], a, b)*f3 + w(low[3], a, b)*f4;
        double err = Abs(Q-q);
        if (err < acc + eps*Abs(Q))
        {
            return Q;
        }
        else
        {
            return Driver1D(f, x, a, (a+b)/2, acc/Sqrt(2), eps, f1, f2) +
                   Driver1D(f, x, (a+b)/2, b, acc/Sqrt(2), eps, f3, f4);
        }
    }

    public static double Driver2D(
        Func<double, double, double> f,
        double a, 
        double b, 
        Func<double, double> d,
        Func<double, double> u,
        double acc, 
        double eps,
        double f2,
        double f3,
        ref double error)
    {

        double[] high = { 2.0/6, 1.0/6, 1.0/6, 2.0/6 };
        double[] low = { 1.0/4, 1.0/4, 1.0/4, 1.0/4 };
        double[] xs = { 1.0/6, 2.0/6, 4.0/6, 5.0/6 };


        double x1 = x_t(xs[0], a, b);
        var a1 = d(x1);
        var b1 = u(x1);

        double x4 = x_t(xs[3], a, b);
        var a4 = d(x4);
        var b4 = u(x4);

        double f1 = Driver1D(f, x1, a1, b1, acc, eps, f(x1, x_t(xs[1], a1, b1)), f(x1, x_t(xs[2], a1, b1)));
        double f4 = Driver1D(f, x4, a4, b4, acc, eps, f(x4, x_t(xs[1], a4, b4)), f(x4, x_t(xs[2], a4, b4)));
        double Q = w(high[0], a, b)*f1 + w(high[1], a, b)*f2 + w(high[2], a, b)*f3 + w(high[3], a, b)*f4;
        double q = w(low[0], a, b)*f1 + w(low[1], a, b)*f2 + w(low[2], a, b)*f3 + w(low[3], a, b)*f4;
        double err = Abs(Q - q);

        if (err < acc + eps * Abs(Q))
        {
            error += err;
            return Q;
        }
        else
        {
            return Driver2D(f, a, (a+b)/2, d, u, acc/Sqrt(2), eps, f1, f1, ref error) +
                   Driver2D(f, (a+b)/2, b, d, u, acc/Sqrt(2), eps, f3, f4,  ref error);
        }
    }

    public static (double,double) Integrate2D(
        Func<double, double, double> f,
        double a, 
        double b, 
        Func<double, double> d,
        Func<double, double> u,
        double acc,
        double eps)
    {
        double[] interval_points = { 1.0/6, 2.0/6, 4.0/6, 5.0/6 };

        double estimate = 0;
        double error = 0;

        double x2 = x_t(interval_points[1], a, b);
        double a2 = d(x2);
        double b2 = u(x2);

        double x3 = x_t(interval_points[2], a, b);
        double a3 = d(x3);
        double b3 = u(x3);

        double start2 = Driver1D(f, x2, a2, b2, acc, eps, f(x2, x_t(interval_points[1], a2, b2)), f(x2, x_t(interval_points[2], a2, b2)));
        double start3 = Driver1D(f, x3, a3, b3, acc, eps, f(x3, x_t(interval_points[1], a3, b3)), f(x3, x_t(interval_points[2], a3, b3)));

        estimate = Driver2D(f, a, b, d, u, acc, eps, start2, start3, ref error);

        return (estimate, Sqrt(error));
    }


    }