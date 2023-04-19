using System;
using static System.Math;
using static System.Console;

public class main{

    public static void Main(){
        test_routine();
        rosenbrock_valley();
        
    }

    public static void test_routine(){
        Func<vector, vector> f_1 = xy => new vector(Pow(xy[0],2)-4);
        vector a_11 = new vector(1.95);
        vector a_12 = new vector(-5.0);
        var res_11 = roots.newton(f_1, a_11);
        var res_12 = roots.newton(f_1, a_12);
        WriteLine("--------------------------------------");
        WriteLine("Test the root-finder routine by finding the roots of f(x)=x^2-4:");
        WriteLine($"One root is at {res_11[0]}  (should be at 2) and the other at {res_12[0]}  (should be at -2)\n\n");

        Func<vector, vector> f_2 = xy => new vector(Pow(xy[0],2)-4,Pow(xy[1],2)-1);
        vector a_21 = new vector(1.95, 1.1);
        var res_21 = roots.newton(f_2, a_21);
        WriteLine("Test the root-finder routine by finding the roots of f(x)=(x^2-4, y^2-1):");
        WriteLine($"One root is at ({res_21[0]}, {res_21[1]})  (should be at (2, 1)) \n\n");
        
    }

    public static void rosenbrock_valley(){
        Func<vector, vector> f_2 = xy => new vector(
            -4*xy[0]*(1-xy[0]*xy[0]) - 400*xy[0]*(xy[1]-xy[0]*xy[0]),
            200*(xy[1]-xy[0]*xy[0])
            );
        vector a_21 = new vector(-0.99999,1.1);
        var res_21 = roots.newton(f_2, a_21);
        vector a_22 = new vector(1.00001,1.1);
        var res_22 = roots.newton(f_2, a_22);
        WriteLine("--------------------------------------");
        WriteLine("Find the extrema of the Rosenbrock's Valley function of f(x)=(1-x^2)^2+100(y-x^2)^2:");
        WriteLine($"The extrema are at ({res_21[0]}, {res_21[1]}) and ({res_22[0]}, {res_22[1]})  (should be at (±1, 1)) \n\n");
        
    }

}