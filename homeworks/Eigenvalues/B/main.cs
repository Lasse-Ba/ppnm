using System;
using static System.Console;
using static System.Math;
using static System.Random;

class main{
    public static void Main(){
        WriteLine();
        WriteLine();
        WriteLine("Fixed r_max, Delta R varies:");
        fixed_rmax();

        WriteLine();
        WriteLine();
        WriteLine("Fixed Delta R, r_max varies:");
        fixed_dr();

        WriteLine();
        WriteLine();
        WriteLine("Comparison of analytical and numerical solutions");
        analyt_num();

    }

    public static void fixed_rmax(){
        double rmax = 25;
        for(double dr = 0.1; dr<=12.0; dr+=0.1){
            int npoints = (int) (rmax/dr - 1);
            vector r = new vector(npoints);
            for(int i=0; i<npoints; i++){
                r[i] = dr*(i+1);
            }
            matrix H = new matrix(npoints, npoints);
            for(int i=0; i<npoints-1; i++){
                H[i,i]   = -2;
                H[i,i+1] =  1;
                H[i+1,i] =  1;
            }
            H[npoints-1,npoints-1] = -2;
            H *= -0.5/dr/dr;
            for(int i=0; i<npoints; i++){
                H[i,i]+= -1/r[i];
            }
            (matrix D, matrix V) = jacobi.cyclic(H);
            WriteLine($"{dr} {D[0,0]}");
        }
    }

    public static void fixed_dr(){
        double dr = 0.1;
        for(double r_max = 0.2; r_max<=5; r_max+=0.1){
            int npoints = (int) (r_max/dr -1);
            vector r = new vector(npoints);
            for(int i=0; i<npoints; i++){
                r[i] = dr*(i+1);
            }
            matrix H = new matrix(npoints, npoints);
            for(int i=0; i<npoints-1; i++){
                H[i,i]   = -2;
                H[i,i+1] =  1;
                H[i+1,i] =  1;
            }
            H[npoints-1,npoints-1] = -2;
            H *= -0.5/dr/dr;
            for(int i=0; i<npoints; i++){
                H[i,i]+= -1/r[i];
            }
            (matrix D, matrix V) = jacobi.cyclic(H);
            WriteLine($"{r_max} {D[0,0]}");
        }
    }

    public static void analyt_num(){
        double rmax = 15;
        int npoints = 200;
        double dr = rmax/npoints;
        vector r = new vector(npoints);

        for(int i=0; i<npoints;i++){
            r[i]=dr*(i+1); //using i instead of i+1
        }
        matrix H = new matrix(npoints,npoints);
        for(int i=0; i<npoints-1; i++){
            H[i,i]   = -2;
            H[i,i+1] =  1;
            H[i+1,i] =  1;
        }
        H[npoints-1,npoints-1] = -2;
        H *= -0.5/dr/dr;
        for(int i=0; i<npoints; i++){
            H[i,i]+= -1/r[i];
        }
		(matrix D, matrix V) = jacobi.cyclic(H);

        matrix normed_matrix = V;
        ///analytical wavefunctions from 11.04.2023
        ///http://hyperphysics.phy-astr.gsu.edu/hbase/quantum/hydwf.html
        
        for(int i=0; i<V.size2; i++){
            double ana1 = 1/(Sqrt(PI))*Exp(-r[i]);
            double ana2 = 1/(4*Sqrt(2*PI))*(2-r[i])*Exp(-r[i]/2);
            double ana3 = 1/(81*Sqrt(3*PI))*(27-18*r[i]+2*r[i]*r[i])*Exp(-r[i]/3.0);
            WriteLine($"{r[i]} {ana1} {ana2} {ana3}");
        }
        WriteLine();
        WriteLine();
        for(int i=0; i<V.size2; i++){
            double num1 = normed_matrix[i,0]/r[i];
            double num2 = normed_matrix[i,1]/r[i];
            double num3 = normed_matrix[i,2]/r[i];
            WriteLine($"{r[i]} {num1} {num2} {num3} ");
        }
    }

}