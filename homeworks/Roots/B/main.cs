using System;
using static System.Math;
using static System.Console;

public class main{

    public static void Main(){
        numerical_solution();
        variation_r_min();
        variation_r_max();
        variation_eps();
        variation_abs();
    }

    public static void variation_abs(){
        WriteLine("\n\n abs_convergence");
        
        double r_min = 0.001;
        double r_max = 8.0;

        double[] initial_cond = new double[]{r_min-r_min*r_min, 1.0-2.0*r_min};
        vector f_0 = new vector(initial_cond);
        for(double i=1e-6; i<10.0; i*=1.1){
            double abs = i;
            Func<vector,vector> M_r = delegate(vector eps_x){
                Func<double, vector, vector> r_f = delegate(double r, vector y){
                    double f = y[0];
                    double f_derivative = y[1];
                    vector res = new vector(2);
                    res[0] = f_derivative;
                    res[1] = -2.0*eps_x[0]*f - 2.0*f/r;
                    return res;
                };
                vector sol = ode.driver(r_f, r_min, f_0, r_max, acc:abs, eps:0.1);
                return new vector(sol[0]);
            };

            vector r_init = new vector(-0.65);
        
            vector f_r_root = roots.newton(M_r,r_init);
            double energy = f_r_root[0];
            WriteLine($"{abs} {energy}");
        }
    }

    public static void variation_eps(){
        WriteLine("\n\n eps_convergence");
        
        double r_min = 0.001;
        double r_max = 8.0;

        double[] initial_cond = new double[]{r_min-r_min*r_min, 1.0-2.0*r_min};
        vector f_0 = new vector(initial_cond);
        for(double i=1e-4; i<1; i*=1.1){
            double eps = i;
            Func<vector,vector> M_r = delegate(vector eps_x){
                Func<double, vector, vector> r_f = delegate(double r, vector y){
                    double f = y[0];
                    double f_derivative = y[1];
                    vector res = new vector(2);
                    res[0] = f_derivative;
                    res[1] = -2.0*eps_x[0]*f - 2.0*f/r;
                    return res;
                };
                vector sol = ode.driver(r_f, r_min, f_0, r_max, 0.001, 0.001, eps);
                return new vector(sol[0]);
            };

            vector r_init = new vector(-0.65);
        
            vector f_r_root = roots.newton(M_r,r_init);
            double energy = f_r_root[0];
            WriteLine($"{eps} {energy}");
        }
    }

    public static void variation_r_max(){
        WriteLine("\n\n r_max_convergence");
        for(int i=0; i<100; i++){
            double r_min = 0.001;
            double r_max = 1.0 + 9.0*i/100;

            double[] initial_cond = new double[]{r_min-r_min*r_min, 1.0-2.0*r_min};
            vector f_0 = new vector(initial_cond);

            Func<vector,vector> M_r = delegate(vector eps_x){
                Func<double, vector, vector> r_f = delegate(double r, vector y){
                    double f = y[0];
                    double f_derivative = y[1];
                    vector res = new vector(2);
                    res[0] = f_derivative;
                    res[1] = -2.0*eps_x[0]*f - 2.0*f/r;
                    return res;
                };
                vector sol = ode.driver(r_f, r_min, f_0, r_max, 0.001, 0.001, 1e-6);
                return new vector(sol[0]);
            };

            vector r_init = new vector(-0.65);
            vector f_r_root = roots.newton(M_r,r_init);
            double energy = f_r_root[0];
            WriteLine($"{r_max} {energy}");
        }
    }

    public static void variation_r_min(){
        WriteLine("\n\n r_min_convergence");
        for(int i=1; i<100; i++){
            double r_min = i/100.0;
            double r_max = 8.0;

            double[] initial_cond = new double[]{r_min-r_min*r_min, 1.0-2.0*r_min};
            vector f_0 = new vector(initial_cond);

            Func<vector,vector> M_r = delegate(vector eps_x){
                Func<double, vector, vector> r_f = delegate(double r, vector y){
                    double f = y[0];
                    double f_derivative = y[1];
                    vector res = new vector(2);
                    res[0] = f_derivative;
                    res[1] = -2.0*eps_x[0]*f - 2.0*f/r;
                    return res;
                };
                vector sol = ode.driver(r_f, r_min, f_0, r_max, 0.001, 0.001, 1e-6);
                return new vector(sol[0]);
            };

            vector r_init = new vector(-0.65);
            vector f_r_root = roots.newton(M_r,r_init);
            double energy = f_r_root[0];
            WriteLine($"{r_min} {energy}");
        }
    }

    public static void numerical_solution(){
        double r_min = 0.001;
        double r_max = 8.0;

        double[] initial_cond = new double[]{r_min-r_min*r_min, 1.0-2.0*r_min};
        vector f_0 = new vector(initial_cond);

        Func<vector,vector> M_r = delegate(vector eps_x){
            Func<double, vector, vector> r_f = delegate(double r, vector y){
                double f = y[0];
                double f_derivative = y[1];
                vector res = new vector(2);
                res[0] = f_derivative;
                res[1] = -2.0*eps_x[0]*f - 2.0*f/r;
                return res;
            };
            vector sol = ode.driver(r_f, r_min, f_0, r_max, 0.001, 0.001, 1e-6);
            return new vector(sol[0]);
        };

        vector r_init = new vector(-0.65);
		vector f_r_root = roots.newton(M_r,r_init);
		double energy = f_r_root[0];
		WriteLine($"Energy is found to be {energy} Hartree, should be -0.5 Hartree");
        WriteLine($"The numerical solution follows the analytical one.\n\n");
        for(double r=0; r<r_max; r+=1.0/4.0){
            WriteLine($"{r} {F_e(r,energy)}");
        }
    }

    public static double F_e(double r, double E){
        double r_min = 0.001;
        if(r<r_min){
            return r-r*r;
        }
        Func<double, vector, vector> r_f = (x,y_s) => {
            return new vector(new double[] {y_s[1], -2.0*(1.0/x + E)*y_s[0]});  
        };
        vector y_min = new vector(new double[] {r_min-r_min*r_min, 1-2*r_min});
        vector y_max = ode.driver(r_f, r_min, y_min, r, 0.001, 0.001, 1e-6);
        return y_max[0];
    }



    
    }