using System;
using static System.Console;
using static System.Math;

class main{
    public static void Main(){
        test_quadinterp();
    }

    public static void test_quadinterp(){
        int n = 15;
        double[] x = new double[n];
        double[] y = new double[n];
        for(int j=0; j<n; j++){
            x[j] = j/2.0;
            y[j] = Sin(j/2.0);
        }

        WriteLine("The interpolation by my cspline is, except for the end-point (where I chose an auxiliary coefficient),\nthe same as the interpolation from build in Gnuplot (copmare plot).");
        WriteLine("\n_____________________________________");
        WriteLine("Generate data points, following a sin(x)");
        for(int j=0; j<n; j++){
            WriteLine($"{x[j]} {y[j]}");
        }
        WriteLine();


        cspline q1 = new cspline(x,y);
        WriteLine("Pick a z, interploate and integrate the data points");
        double z=2.4;
        WriteLine($"z={z} f(z)={q1.evaluate(z)}, Derivative {q1.derivative(z)} Integral {q1.integral(z)}");
        WriteLine();




    }

}