using System;
using static System.Math;

public class ann{
    public int n; // number of hidden neurons
    public Func<double, double> f = delegate(double x){
        return x * Exp(-x * x); // activation function
    }; 
    public vector p; // network parameters

    public ann(int n){
        this.n = n;
        p = new vector(3 * n); /// a_i, b_i, and w_i for each hidden neuron
    }

    public ann(vector p){
        this.n = p.size/3;
        this.p = p;
    }

    

    public double response(double x_inp){
        double sum = 0;
        for (int i = 0; i < n; i++){
            double ai = p[3 * i];
            double bi = p[3 * i + 1];
            double wi = p[3 * i + 2];
            double input = f((x_inp - ai) / bi) * wi;
            sum += input;
        }
        return sum;
    }

    public vector train(vector x, vector y){
        for(int i=0; i<n; i++){
            p[i] = 1.0;
            p[i+n] = 1.0;
            p[i+2*n] = x[0] + ( x[x.size-1] - x[0] )*i/(n-1);
        };
        Func<vector,double> cost = delegate(vector v){
            ann ann_v = new ann(v);
            double sum=0;
            for (int k = 0; k < x.size; k++){
                double diff = ann_v.response(x[k])-y[k];
                sum += diff * diff;
            };
            return sum/x.size;
        };
        var (p_trained, steps) = minimization.qnewton(cost, p);
        p = p_trained;
        return p;
    }

    
}
