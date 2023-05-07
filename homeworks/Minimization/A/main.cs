using System;
using static System.Math;
using static System.Console;

public class main{

    public static void Main(){
        rosenbrock_valley();
        himmelblau();
    }

    public static void rosenbrock_valley(){
        WriteLine("--------------------------------------");
        WriteLine("Find the extrema of the Rosenbrock's Valley function of f(x)=(1-x^2)^2+100(y-x^2)^2:");
        Func<vector, double> f = delegate(vector x){
            return (1-x[0])*(1-x[0]) + 100*(x[1]-x[0]*x[0])*(x[1]-x[0]*x[0]);
        };
        vector a = new vector(1.1,2);
        var (res,steps) = minimization.qnewton(f, a);
        WriteLine($"The minimum is at (x,y) = ({res[0]}, {res[1]}) (should be (1,1)),\nstarting at ({a[0]},{a[1]}) with {steps} steps");
    }

    public static void himmelblau(){
        WriteLine("--------------------------------------");
        WriteLine("Find the minima of the Himmelblau's function of f(x)=(x^2+y-11)^2+(x+y^2-7)^2:");
        Func<vector, double> f = delegate(vector x){
            return Pow(x[0]*x[0]+x[1]-11,2) + Pow(x[0]+x[1]*x[1]-7,2);
        };
        vector a_1 = new vector(3.5,1.9);
        vector a_2 = new vector(-3.5,-3.2);
        vector a_3 = new vector(-2.8,3.2);
        vector a_4 = new vector(3.5,-1.9);
        var (res_1,steps_1) = minimization.qnewton(f, a_1);
        var (res_2,steps_2) = minimization.qnewton(f, a_2);
        var (res_3,steps_3) = minimization.qnewton(f, a_3);
        var (res_4,steps_4) = minimization.qnewton(f, a_4);
        WriteLine($"The minima are at:");
        WriteLine($"(x,y) = ({res_1[0]}, {res_1[1]}) (should be (3,2)), starting at ({a_1[0]},{a_1[1]}) with {steps_1} steps");
        WriteLine($"(x,y) = ({res_2[0]}, {res_2[1]}) (should be (-3.78,-3.28)), starting at ({a_2[0]},{a_2[1]}) with {steps_2} steps");
        WriteLine($"(x,y) = ({res_3[0]}, {res_3[1]}) (should be (-2.81,3.13)), starting at ({a_3[0]},{a_3[1]}) with {steps_3} steps");
        WriteLine($"(x,y) = ({res_4[0]}, {res_4[1]}) (should be (3.58,-1.85)), starting at ({a_4[0]},{a_4[1]}) with {steps_4} steps");

    }
}