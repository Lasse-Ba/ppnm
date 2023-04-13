using System;
using static System.Math;
using static System.Console;

public class main{

    public static void Main(){
        test_integral();
        plot_func_quasi();
        plot_func_plain();
    }

    public static void test_integral(){
        Func<vector, double> f_1 = xy => xy[0];
        vector a_1 = new vector(0,0);
        vector b_1 = new vector(1,2*PI);
        var res_1 = mc.quasimc(f_1, a_1, b_1, 1000000);
        WriteLine("--------------------------------------");
        WriteLine("Test the MC-integration routine by calculating the area of an unit circle:");
        WriteLine($"The area is {res_1.Item1} with an error of {res_1.Item2} (should be {PI})\n\n");
        
    }

    public static void plot_func_quasi(){
        WriteLine();
        WriteLine();
        Func<vector, double> f_2 = xy => xy[0];
        vector a_2 = new vector(0,0);
        vector b_2 = new vector(1,2*PI);
        for(int i=10; i<=100000000; i*=10){
            var res_2 = mc.quasimc(f_2, a_2, b_2, i);
            WriteLine($"{i} {res_2.Item1} {res_2.Item2}");
        }
    }

    public static void plot_func_plain(){
        WriteLine();
        WriteLine();
        Func<vector, double> f_3 = xy => xy[0];
        vector a_3 = new vector(0,0);
        vector b_3 = new vector(1,2*PI);
        for(int i=10; i<=100000000; i*=10){
            var res_3 = mc.plainmc(f_3, a_3, b_3, i);
            WriteLine($"{i} {res_3.Item1} {res_3.Item2}");
        }
    }
}