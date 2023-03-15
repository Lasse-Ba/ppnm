using System;
using static System.Console;
using static System.Math;

class main{
    public static void Main(){
        test_lininterp();
    }

    public static void test_lininterp(){
        int n = 15;
        double[] x = new double[n];
        double[] y = new double[n];
        for(int j=0; j<n; j++){
            x[j] = j/4.0;
            y[j] = Sin(j/4.0);
        }

        for(int j=0; j<n; j++){
            WriteLine($"{x[j]} {y[j]}");
        }
        WriteLine();
        for(double z=0.0+1/32; z<3.3; z+=1.0/16){
            WriteLine($"{z} {spline.linterp(x,y,z)} {spline.linterpInteg(x,y,z)}");
        }
        


    }

}