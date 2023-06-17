using System;
using static System.Console;
using static System.Math;

public class main{
    public static void Main(){
        WriteLine("_______________________________________");
        WriteLine("Compute different integrals");
        integrate_test();
    }   


    public static void integrate_test(){
        Func<double,double, double> f = (x,y) => x*y;
        double a = 0.0;
        double b = 1.0;
        Func<double, double> d = x => x;
        Func<double, double> u = x => x*x;
        double acc = 1e-6;
        double eps = 1e-6;
        var result= quad.Integrate2D(f,a,b,d,u,acc, eps);
        WriteLine($"{result.Item1} {result.Item2}");
    

    }
    /*
    public static void integrate_test_1(){
        Func<double,double, double> f = (x,y) => x*y;
        double a = 0.0;
        double b = 1.0;
        Func<double, double> d = x => x;
        Func<double, double> u = x => x*x;
        double acc = 1e-6;
        double eps = 1e-6;
        double integral = quad.Integ2D(f,a,b,d,u,acc, eps);
        WriteLine($"The integral of x^2*y^2 for x∈[0,1] and y∈[x,2x] is {integral} (should be 0.389)") ;
    }
    */
}