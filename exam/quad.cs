using System;
using static System.Math;
using static System.Double;

public static class quad{

    public static double x_t(double t, double a, double b)
    {
        return a + (b - a) * t;
    }

    public static double w(double w, double a, double b)
    {
        return (b - a) * w;
    }

    public static double d(double x)
    {
        return x;
    }

    public static double u(double x)
    {
        return x*x;
    }


    public static double Driver1D(
        Func<double, double, double> f, 
        double x, 
        double a, 
        double b, 
        double acc, 
        double eps,
        double two, 
        double three, 
        double[] high, 
        double[] low, 
        double[] xs)
    {
        double one = f(x, x_t(xs[0], a, b));
        double four = f(x, x_t(xs[3], a, b));
        double Q = w(high[0], a, b) * one + w(high[1], a, b) * two + w(high[2], a, b) * three + w(high[3], a, b) * four;
        double q = w(low[0], a, b) * one + w(low[1], a, b) * two + w(low[2], a, b) * three + w(low[3], a, b) * four;
        double err = Math.Abs(Q - q);
        if (err < acc + eps * Math.Abs(Q))
        {
            return Q;
        }
        else
        {
            return Driver1D(f, x, a, (a + b) / 2, acc / Math.Sqrt(2.0), eps, one, two, high, low, xs) +
                   Driver1D(f, x, (a + b) / 2, b, acc / Math.Sqrt(2.0), eps, three, four, high, low, xs);
        }
    }

    // RECURSIVE INTEGRATION FUNCTION 2D
    public static double Driver2D(
        Func<double, double, double> f,
        double a, 
        double b, 
        double acc, 
        double eps,
        double two,
        double three,
        double[] high,
        double[] low,
        double[] xs,
        ref double error)
    {
        double x1 = x_t(xs[0], a, b);
        double a1 = d(x1);
        double b1 = u(x1);

        double x4 = x_t(xs[3], a, b);
        double a4 = d(x4);
        double b4 = u(x4);

        double one = Driver1D(f, x1, a1, b1, acc, eps, f(x1, x_t(xs[1], a1, b1)), f(x1, x_t(xs[2], a1, b1)), high, low, xs);
        double four = Driver1D(f, x4, a4, b4, acc, eps, f(x4, x_t(xs[1], a4, b4)), f(x4, x_t(xs[2], a4, b4)), high, low, xs);
        double Q = w(high[0], a, b) * one + w(high[1], a, b) * two + w(high[2], a, b) * three + w(high[3], a, b) * four;
        double q = w(low[0], a, b) * one + w(low[1], a, b) * two + w(low[2], a, b) * three + w(low[3], a, b) * four;
        double err = Math.Abs(Q - q);

        if (err < acc + eps * Math.Abs(Q))
        {
            error += err;
            return Q;
        }
        else
        {
            return Driver2D(f, a, (a + b) / 2, acc / Math.Sqrt(2.0), eps, one, two, high, low, xs, ref error) +
                   Driver2D(f, (a + b) / 2, b, acc / Math.Sqrt(2.0), eps, three, four, high, low, xs, ref error);
        }
    }

    public static Tuple<double, double> Integrate2D(
        Func<double, double, double> f,
        double a, 
        double b, 
        Func<double, double> d,
        Func<double, double> u,
        double acc,
        double eps)
    {
        double[] Higher_order = { 2.0 / 6, 1.0 / 6, 1.0 / 6, 2.0 / 6 };
        double[] Lower_order = { 1.0 / 4, 1.0 / 4, 1.0 / 4, 1.0 / 4 };
        double[] interval_points = { 1.0 / 6, 2.0 / 6, 4.0 / 6, 5.0 / 6 };

        double estimate = 0;
        double error = 0;

        double x2 = x_t(interval_points[1], a, b);
        double a2 = d(x2);
        double b2 = u(x2);

        double x3 = x_t(interval_points[2], a, b);
        double a3 = d(x3);
        double b3 = u(x3);

        double start2 = Driver1D(f, x2, a2, b2, acc, eps, f(x2, x_t(interval_points[1], a2, b2)), f(x2, x_t(interval_points[2], a2, b2)),Higher_order,Lower_order,interval_points);
        double start3 = Driver1D(f, x3, a3, b3, acc, eps, f(x3, x_t(interval_points[1], a3, b3)), f(x3, x_t(interval_points[2], a3, b3)),Higher_order,Lower_order,interval_points);

        estimate = Driver2D(f, a, b, acc, eps, start2, start3, Higher_order, Lower_order, interval_points, ref error);

        return Tuple.Create(estimate, Math.Sqrt(error));
    }


    }