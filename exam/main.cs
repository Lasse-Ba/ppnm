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
        Func<double,double, double> f = (x,y) => x*x*y*y;
        double a = 0.0;
        double b = 1.0;
        Func<double, double> d = x => x;
        Func<double, double> u = x => 2.0*x;
        double integral = quad.integ2D(f,a,b,d,u);
        WriteLine($"The integral of x^2*y^2 for x∈[0,1] and y∈[x,2x] is {integral} (should be 0.389)") ;
    }
}