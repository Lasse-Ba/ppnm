using System;
using static System.Console;
using static System.Math;

class main{
    public static void Main(){
        test_quadinterp();
    }

    public static void test_quadinterp(){
        int n = 5;
        double[] xs = new double[n];
        double[] y1 = new double[n];
        double[] y2 = new double[n];
        double[] y3 = new double[n];
        for(int j=0; j<n; j++){
            xs[j] = j+1;
            y1[j] = 1;
            y2[j] = j+1;
            y3[j] = Pow(j+1,2);
        }

        WriteLine("Generate data points");
        for(int j=0; j<n; j++){
            WriteLine($"{xs[j]} {y1[j]}");
        }
        WriteLine();
        WriteLine();
        for(int j=0; j<n; j++){
            WriteLine($"{xs[j]} {y2[j]}");
        }
        WriteLine();
        WriteLine();
        for(int j=0; j<n; j++){
            WriteLine($"{xs[j]} {y3[j]}");
        }
        WriteLine();
        WriteLine();

        qspline q1 = new qspline(xs,y3);
        WriteLine("Pick a z, interploate and integrate the data points");
        double z=2.4;
        WriteLine($"z={z} f(z)={q1.evaluate(z)} Integral {q1.integral(z)}");
        WriteLine();


    }

}