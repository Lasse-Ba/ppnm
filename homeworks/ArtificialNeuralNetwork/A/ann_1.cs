using System;
using static System.Console;
using static System.Math;

public class ann{
    public int n; /* number of hidden neurons */
    public Func<double,double> f = x => x*Exp(-x*x); /* activation function */
    public vector p;

    public ann(int n){
        /* network parameters */
        vector p = new vector(3*n);  //p = (n*a,n*b,n*w)
    }

    public double response(double x){
    /* return the response of the network to the input signal x */
        double F_p = 0.0;
        for(i=0; i<n; i++){
            f_i = f((x-a_i)/b_i)*w_i;
            F_p += f_i;
        }
        return F_p;
    }



    
    public void train(vector x, vector y){
    /* train the network to interpolate the given table {x,y} */
    int m = x.size;
        for(int i=0; i<n; i++){
            p[i] = x[0]+(x[m]-x[0])*i/n; ///a_i
            p[n+i] = 1.0; ///b_i
            p[2*n+i] = 1.0; ///w_i;
        };
        int n_calls = 0;
        Func<vector, double> mismatch = u =>{
            n_calls++;
            ann ann_u = new ann(u);
            double Sum = 0;
            for(int i=0; i<x.size; i++){
                sum += Pow( ann_u.F_p(x[i])-y[i], 2 );
            }
            return sum/m;
        };
        var (p_opt, steps) = minimization.qnewton(mismatch,x);
    }
}