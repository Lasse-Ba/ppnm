using System;
using static System.Console;
using static System.Math;

public class main{
    public static void Main(){
        WriteLine("_______________________________________");
        WriteLine("Testing Clenshaw-Curtis");

        int ncalls_1 = 0;
        int ncalls_2 = 0;

        double a = 0.0;
        double b = 1.0;

        Func<double,double> f_1 = x => {
            ncalls_1++;
            return 1.0/Sqrt(x);
            };
        Func<double,double> f_2 = x => {
            ncalls_2++;
            return Log(x)/Sqrt(x);
            };
        
        double sol_int_1 = quad.integrate(f_1, a, b);
        double sol_int_2 = quad.integrate(f_2, a, b);

        WriteLine($"The integral of 1/sqrt(x) from 0 to 1 is {sol_int_1} with {ncalls_1} evaluations");
        WriteLine($"The integral of ln(x)/sqrt(x) from 0 to 1 is {sol_int_2} with {ncalls_2} evaluations");


        ncalls_1 = 0;
        ncalls_2 = 0;

        double sol_CC_1 = quad.ClenshawCurtis(f_1, a, b);
        double sol_CC_2 = quad.ClenshawCurtis(f_2, a, b);

        WriteLine($"The Clenshaw-Curtis integral of 1/sqrt(x) from 0 to 1 is {sol_CC_1} with {ncalls_1} evaluations");
        WriteLine($"The Clenshaw-Curtis integral of ln(x)/sqrt(x) from 0 to 1 is {sol_CC_2} with {ncalls_2} evaluations");

        WriteLine();
        WriteLine("With Python:");
        WriteLine("Integral of 1/sqrt(x) is 1.9999999999999984 with 231 evolutions");
        WriteLine("Integral of ln(x)/sqrt(x) is -4.000000000000075 with 231 evolutions");
        WriteLine("Python needs less evaluations than the recursive adaptive integrator\nbut more then the Clenshaw Curtis algorithm");

    }   


}