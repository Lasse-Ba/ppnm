using System;
using static System.Math;
using static System.Console;

public class main{
    public static void Main(){
        Func<double, double> gaussian_wavelet = delegate(double x){
            return x*Exp(x*x);
        };
        
        int m = 20;
        vector x = new vector(m);
        vector y = new vector(m);
        
        for(int i=0; i<m; i++){
            x[i] = -1.0 + 2.0*i/m;
            y[i] = Cos(5.0*x[i]-1.0)*Exp(-x[i]*x[i]);
            WriteLine($"{x[i]} {y[i]}")
        }


    }
}