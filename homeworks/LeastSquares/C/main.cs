using System;
using static System.Console;
using static System.Math;

class main{
    public static void Main(){

        ///Time
        double[] t = new double[]{1,  2,  3, 4, 6, 9,   10,  13,  15};
        ///Activity(t)
        double[] y = new double[]{117,100,88,72,53,29.5,25.2,15.2,11.1};
        ///Uncertainity Activity(t)
        double[] dy = new double[]{5,5,5,4,4,3,3,2,2};


        var fs = new Func<double,double>[]{z=> 1.0, z=>z};

        double[] logy = new double[y.Length];
        double[] dlogy = new double[y.Length];

        ///Calculate logarithmic values and errors
        for(int i=0; i<y.Length; i++){
            logy[i]=Log(y[i]);
            dlogy[i]=dy[i]/y[i];
        }

        ///Do the least square fit
        var lsfit_fit = lsfit.lsfitvec(fs, t, logy, dlogy);
        vector coeffs = lsfit_fit.Item1;
        matrix covs = lsfit_fit.Item2;
        vector errs = lsfit_fit.Item3;
        double halflife_err = Log(2)*errs[1]/Pow(coeffs[1],2);

        ///Write given data
        for(int i=0; i<y.Length; i++){
            WriteLine($"{t[i]} {y[i]} {dy[i]}");
        }

        WriteLine();
        WriteLine();

        ///Calculate Data points with the fittet values to plot the function
        for(double i=1.0; i<16; i+=1.0/4.0){
            WriteLine($"{i} {Exp(coeffs[0]) * Exp(coeffs[1]*i)}");
        }
        WriteLine();
        WriteLine();

        ///Calculate Data points with the errors
        for(double i=1.0; i<16; i+=1.0/4.0){
            WriteLine($"{i} {Exp(coeffs[0]  +errs[0]) * Exp((coeffs[1]+errs[1])*i)}");
        }
        WriteLine();
        WriteLine();

        for(double i=1.0; i<16; i+=1.0/4.0){
            WriteLine($"{i} {Exp(coeffs[0] - errs[0]) * Exp((coeffs[1]-errs[1])*i)}");
        }
        WriteLine();
        WriteLine();

        
        
        		



    }
}