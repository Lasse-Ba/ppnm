using System;
using static System.Math;
using static System.Console;

public class main{

    public static void Main(){
        test_integral();
        difficult_integral();
        plot_func();
    }

    public static void test_integral(){
        Func<vector, double> f_1 = xy => xy[0];
        vector a_1 = new vector(0,0);
        vector b_1 = new vector(1,2*PI);
        var res_1 = mc.plainmc(f_1, a_1, b_1, 1000000);
        WriteLine("--------------------------------------");
        WriteLine("Test the MC-integration routine by calculating the area of an unit circle:");
        WriteLine($"The area is {res_1.Item1} with an error of {res_1.Item2} (should be {PI})\n\n");
        
    }

    public static void difficult_integral(){
        Func<vector, double> f_2 = xy => 1/(1-Cos(xy[0])*Cos(xy[1])*Cos(xy[2]))/Pow(PI,3);
        vector a_2 = new vector(0,0,0);
        vector b_2 = new vector(PI,PI,PI);
        var res_2 = mc.plainmc(f_2, a_2, b_2, 1000000);
        WriteLine("--------------------------------------");
        WriteLine("Calculating the complicated integral:");
        WriteLine($"The integral is {res_2.Item1} with an error of {res_2.Item2} (should be {1.3932039296856768591842462603255})\n");
    }

    public static void plot_func(){
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