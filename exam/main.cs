using System;
using static System.Console;
using static System.Math;

public class main{
    public static void Main(){
        WriteLine("Compute different integrals I=∫dx∫dy f(x,y):\n");
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
        double acc = 1e-6;
        double eps = 1e-6;
        var result= quad.integ2D(f,a,b,d,u,acc, eps);
        WriteLine($"f(x,y) = xy integrated over x∈[0,1] and y∈[x,x^2] results in \nI=({Round(result.Item1,5)}±{Round(result.Item2,5)}) (should be -1/24≈-0.04167)\n\n");
    }

    public static void integrate_test_2(){
        Func<double,double, double> f = (x,y) => Exp(y)*Sin(x);
        double a = 0.0;
        double b = 1.0;
        Func<double, double> d = x => Exp(x);
        Func<double, double> u = x => -Sin(x);
        double acc = 1e-3;
        double eps = 1e-3;
        var result= quad.integ2D(f,a,b,d,u,acc, eps);
        WriteLine($"f(x,y) = exp(y)*sin(x) integrated over x∈[0,1] and y∈[-sin(x),exp(x)] results in\nI=({Round(result.Item1,5)}±{Round(result.Item2,5)}) (should be 3.39164)\n\n");
    }

    public static void integrate_test_3(){
        Func<double,double, double> f = (x,y) => -y - x*x + y*y*Cos(x)*Cos(x);
        double a = 0.5;
        double b = 1.0;
        Func<double, double> d = x => Sqrt(x);
        Func<double, double> u = x => 5;
        double acc = 1e-3;
        double eps = 1e-3;
        var result= quad.integ2D(f,a,b,d,u,acc, eps);
        WriteLine($"f(x,y) = -y - x*x + y*y*Cos(x)*Cos(x) integrated over x∈[0.5,1] and y∈[Sqrt(x),5] results in\nI=({Round(result.Item1,5)}±{Round(result.Item2,5)}) (should be 3.80859)\n\n");
    }
    
}