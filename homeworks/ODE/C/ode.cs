using System;
using static System.Console;
using static System.Math;

public class main{
    public static void Main(){        

        double a = 1.5;
        double b = 1.0;
        double c = 3.0;
        double d = 1.0;
        
        vector y_as = new vector(10,5);
        Func<double, vector, vector>  f_s = (x,y_s) => new vector(a*y_s[0] - b*y_s[0]*y_s[1], -c*y_s[1]+d*y_s[0]*y_s[1]);
        var (x_sA, p_sA) = ode.driver(f_s, 0, y_as, 15);
        var (x_sB, p_sB) = ode.driver(f_s, 0, y_as, 15, acc:0.0001, eps:0.0001, xlist: new genlist<double>(), ylist: new genlist<vector>());
        for(int i=0; i<x_sA.size; i++){
            WriteLine($"{x_sA[i]} {p_sA[i][0]} {p_sA[i][1]}");
        }
        WriteLine();
        WriteLine();
        for(int j=0; j<x_sB.size; j++){
            WriteLine($"{x_sB[j]} {p_sB[j][0]} {p_sB[j][1]}");
        }

    }
}