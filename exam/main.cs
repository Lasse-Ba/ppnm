using System;
using static System.Console;
using static System.Math;

public class main{
    public static void Main(){
        WriteLine("_______________________________________");
        WriteLine("Compute different integrals for x∈[0,1] and y∈[x,x^2]");
        integrate_test_1();
        integrate_test_2();
        integrate_test_3();
    }   


    public static void integrate_test_1(){
        
        Func<double,double, double> f = (x,y) => x*y;
        double a = 0.0;
        double b = 1.0;
        Func<double, double> d = x => x;
        Func<double, double> u = x => x*x;
        double acc = 1e-8;
        double eps = 1e-8;
        var result= quad.Integrate2D(f,a,b,d,u,acc, eps);
        //WriteLine($"{result.Item1} {result.Item2}");
        WriteLine($"f(x,y) = xy integrated results in {result} (should be -1/24≈0-0.041667)\n\n");
    }

    public static void integrate_test_2(){
        Func<double,double, double> f = (x,y) => Exp(y)*Sin(x);
        double a = 0.0;
        double b = 1.0;
        Func<double, double> d = x => x;
        Func<double, double> u = x => x*x;
        double acc = 1e-8;
        double eps = 1e-8;
        var result= quad.Integrate2D(f,a,b,d,u,acc, eps);
        //WriteLine($"{result.Item1} {result.Item2}");
        WriteLine($"f(x,y) = exp(y)*sin(x) integrated results in {result} (should be -0.130586)\n\n");
    }

    public static void integrate_test_3(){
        Func<double,double, double> f = (x,y) => -y - x*x + y*y*Cos(x)*Cos(x);
        double a = 0.0;
        double b = 1.0;
        Func<double, double> d = x => x;
        Func<double, double> u = x => x*x;
        double acc = 1e-8;
        double eps = 1e-8;
        var result= quad.Integrate2D(f,a,b,d,u,acc, eps);
        //WriteLine($"{result.Item1} {result.Item2}");
        WriteLine($"f(x,y) = -y - x*x + y*y*Cos(x)*Cos(x) integrated results in {result} (should be 0.096008)\n\n");
    }
}