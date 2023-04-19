using System;
using static System.Math;
using static System.Console;

public class main{

    public static void Main(){
        lowest_root();
        
    }

    public static double F_E(double r, double e){
        double r_min = 0.001;
        double r_max = 8.0;

        if(r<r_min){
            return r-r*r_min;
        }

        Func<double, vector, vector> r_f = (x,y) => {
            return new vector(new double[] {y[1], -2.0*(e+1.0/x)*y[0]});
        };

        vector y_min = new vector(new double[] {r_min-r_min*r_min, 1-2*r_min});
        vector y_max = ode.driver(r_f, r_min, y_min, r);
        return y_max[0];
    }

    public static void lowest_root(){
        double r_min = 0.001;
        double r_max = 8.0;

        vector f_0 = new vector(r_min-r_min*r_min, 1.0-2.0*r_min);
        Func<vector,vector> Mr = delegate(vector epsx){
			Func<double,vector,vector> r_f = delegate(double r, vector y){
				double f = y[0], f_deriv = y[1];
				vector res = new vector(2);
				res[0] = f_deriv;
				res[1] = -2.0*epsx[0]*f - 2.0*f/r;
				return res;
			};
        };
        vector res_lr = ode.driver(Mr, r_min, f_0, r_max);
        WriteLine("--------------------------------------");
        WriteLine($"One root is at {res_lr[0]}\n\n");        
    }

}