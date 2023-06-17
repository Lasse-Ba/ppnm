using System;
using static System.Math;
using static System.Double;

public static class quad{

    public static double Integ2D(
        Func<double, double, double> f,
        double a, double b,
        Func<double, double> d,
        Func<double, double> u,
        double acc, double eps)
    {
        Func<double, double> integrand = y =>
        {
            Func<double, double> g = x => f(x, y) * d(x) * u(x);
            return Integrate(g, a, b, acc, eps);
        };

        return Integrate(integrand, a, b, acc, eps);
    }

    public static double Integrate(
        Func<double, double> f,
        double a, double b,
        double acc, double eps)
    {
        double h = b - a;
        double c = (a + b) / 2.0;
        double fa = f(a);
        double fb = f(b);
        double fc = f(c);
        double integral = h * (fa + 4 * fc + fb) / 6.0;
        return AdaptiveIntegrate(f, a, b, acc, eps, integral, fa, fb, fc);
    }

    public static double AdaptiveIntegrate(
        Func<double, double> f,
        double a, double b,
        double acc, double eps,
        double integral,
        double fa, double fb, double fc)
    {
        double c = (a + b) / 2.0;
        double h = b - a;
        double d = (a + c) / 2.0;
        double e = (c + b) / 2.0;
        double fd = f(d);
        double fe = f(e);
        double integralLeft = h * (fa + 4 * fd + fc) / 12.0;
        double integralRight = h * (fc + 4 * fe + fb) / 12.0;
        double integral2 = integralLeft + integralRight;

        if (Math.Abs(integral2 - integral) <= acc + eps * Math.Abs(integral2))
        {
            return integral2;
        }
        else
        {
            return AdaptiveIntegrate(f, a, c, acc / 2.0, eps, integralLeft, fa, fc, fd) +
                   AdaptiveIntegrate(f, c, b, acc / 2.0, eps, integralRight, fc, fb, fe);
        }
    }
}