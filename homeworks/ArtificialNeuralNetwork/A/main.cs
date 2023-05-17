using System;
using static System.Math;
using static System.Console;

public class main{
    public static void Main(){
        Func<double,double> g = delegate(double x){
            return Cos(5*x-1.0)*Exp(-x*x);
        };
        int n=5;
        var network = new ann(n);
        double a = -1.0;
        double b = 1.0;
        int interv = 15;
        var x_s = new vector(interv);
        var y_s = new vector(interv);
        for(int i=0; i<interv; i++){
            x_s[i] = a+(b-a)*i/(interv-1);
            y_s[i] = g(x_s[i]);
            WriteLine($"{x_s[i]} {y_s[i]}");
        };
        WriteLine("\n\n");
        network.train(x_s,y_s);
        
        for(int i = 0; i<1000; i++){
            double x_i = -3.0 + 6.0*i/999.0;
            double y_i = network.response(x_i);
            WriteLine($"{x_i} {y_i}");
        };
        WriteLine("\n\n");
        for(int j = 0; j<1000; j++){
            double x_j = -3.0 + 6.0*j/999.0;
            double y_j = g(x_j);
            WriteLine($"{x_j} {y_j}");
        };
        
    }
}