using System;
using static System.Console;
using static System.Math;

public class main{
    public static void Main(){
        WriteLine("_______________________________________");
        WriteLine("Compute different integrals");
        integrate_sqrt();
        inv_sqrt();
        complicated_sqrt();
        ln_sqrt();
        WriteLine("_______________________________________");
        WriteLine("The error function is plottet in 'erf.svg' together with tabulated values\nfrom Wikipedia. They fit well to each other except at +-1 where the funtion is not\nsmooth because I change the method to calculate the error function.");
        WriteLine("VGL mit Plot aufgabe fehlt noch");
        WriteLine();
        WriteLine();
        erf_data();

    }   


    public static void integrate_sqrt(){
        Func<double,double> f = x => Sqrt(x);
        double a = 0.0;
        double b = 1.0;
        double integral = quad.integrate(f,a,b);
        WriteLine($"The integral of sqrt(x) from 0 to 1 is         {integral} (should be 2/3)") ;
    }

    public static void inv_sqrt(){
        Func<double,double> f = x => 1.0/Sqrt(x);
        double a = 0.0;
        double b = 1.0;
        double integral = quad.integrate(f,a,b);
        WriteLine($"The integral of 1/sqrt(x) from 0 to 1 is       {integral} (should be 2)") ;
    }

    public static void complicated_sqrt(){
        Func<double,double> f = x => 4*Sqrt(1-x*x);
        double a = 0.0;
        double b = 1.0;
        double integral = quad.integrate(f,a,b);
        WriteLine($"The integral of 4*sqrt(1-x^2) from 0 to 1 is   {integral} (should be pi)") ;
    }

    public static void ln_sqrt(){
        Func<double,double> f = x => Log(x)/Sqrt(x);
        double a = 0.0;
        double b = 1.0;
        double integral = quad.integrate(f,a,b);
        WriteLine($"The integral of ln(x)/sqrt(x) from 0 to 1 is  {integral} (should be -4)") ;
    }

    public static void erf_data(){
        for(double i=-3.5+1/32; i<=3.5+1/32; i=i+1.0/32.0){
            double erf_i = quad.erf(i);
            WriteLine($"{i} {erf_i}");
        }
    }
}