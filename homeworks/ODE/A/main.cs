using System;
using static System.Console;
using static System.Math;

public class main{
    public static void Main(){
        double step = 1.0/16.0;
        Func<double, vector, vector> osc = delegate(double t, vector y){
			return new vector(y[1], -y[0]);
		};


        WriteLine("___________________________________________________");
        WriteLine("Solve u''=-u with the initial conditions y_0=(1,0)");
        double[] initial_cond = new double[] {1.0, 0.0};
        vector ya_osc = new vector(initial_cond);
            for(double t_i = step; t_i<=10.0; t_i+=step){
                vector sol = ode.driver(osc, t_i-step, ya_osc, t_i);
                WriteLine($"{t_i} {sol[0]} {sol[1]}");
                ya_osc = sol;
            
        }

        WriteLine();
        WriteLine();
        WriteLine("___________________________________________________");
        WriteLine("SciPy example");
        double b = 0.25;
        double c = 5.0;
        Func<double, vector, vector> pendulum = delegate(double t, vector y){
            double theta = y[0];
            double omega = y[1];
            return new vector(omega, -b*omega - c*Sin(theta));
        };

        double[] initial_cond2 = new double[] {Math.PI -0.1, 0.0};
        vector ya_pendulum = new vector(initial_cond2);

        for(double t_i = step; t_i<=10.0; t_i+=step){
            vector sol = ode.driver(pendulum, t_i-step, ya_pendulum, t_i);
            WriteLine($"{t_i} {sol[0]} {sol[1]}");
            ya_pendulum = sol;
        }
    }
}