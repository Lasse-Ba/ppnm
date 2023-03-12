using System;
using static System.Console;
using static System.Math;
using static System.Random;

class main{
    static double rmax = 10;
    static int npoints = 100;
    static double dr = rmax/npoints;
    static vector r = new vector(npoints);

    public static void Main(){

        //Fill vector with grid
        for(int i=0; i<npoints;i++){
            r[i]=dr*(i+1); //using i instead of i+1
        }

        int noEnergies = 3;
        matrix H = build_H();
        (matrix D, matrix V) = jacobi.cyclic(H);
        var Rfuncs = new Func<double, double>[]{
            x => x*2.0*Exp(-x),
            x => x*1.0/Sqrt(2)*(1.0-x/2.0)*Exp(-x/2.0),
            x => x*2.0/(3.0*Sqrt(3))*(1-2.0*x/3.0+2.0/27*x*x)*Exp(-x/3.0)};

        for(int e_i=0; e_i<noEnergies; e_i++){
            WriteLine($"{0} {0} {0}");
            for(int i=0; i<V.size1;i++){
                int indx = 4;
                double factor=V[e_i][indx]/Rfuncs[e_i](r[indx]);
                WriteLine($"{r[i]} {V[e_i][i]} {Rfuncs[e_i](r[i])*factor}");
            }
            WriteLine();
            WriteLine();
        }
        rmaxConv();
        //drConv();

    }

    public static matrix build_H(){
        for(int i =0; i<npoints; i++){
            r[i]=dr*(i+1); //using i instead of i+1
        }

        matrix H = new matrix(npoints,npoints);
        for(int i=0; i<npoints-1; i++){
            matrix.set(H,i,i,-2);
            matrix.set(H,i,i+1,1);
            matrix.set(H,i+1,i,1);
        }
        matrix.set(H,npoints-1,npoints-1,-2);
        H *= -0.5/dr/dr;
        for(int i=0; i<npoints; i++){
            H[i,i]+= -1/r[i];
        }
        return H;
    }

    public static void rmaxConv(){
        using(var outfile = new System.IO.StreamWriter("conv_rmax.txt")){
            for(int r_max=2; r_max<=30; r_max++){
                double dr=0.2;
                int npoints = (int)(r_max/dr-1);
                vector r = new vector(npoints);
                for(int i=0; i<npoints;i++){
                    r[i]=dr*(i+1);
                }
                matrix H = new matrix(npoints,npoints);
                for(int i=0; i<npoints-1;i++){
                    matrix.set(H,i,i,-2);
                    matrix.set(H,i,i+1,1);
                    matrix.set(H,i+1,i,1);
                }
                matrix.set(H,npoints-1,npoints-1,-2);
                H*=0.5/dr/dr;
                for(int i=0;i<npoints;i++){
                    H[i,i]+=-1/r[i];
                }
                (matrix D, matrix V) = jacobi.cyclic(H);

                outfile.WriteLine($"{r_max} {D[0,0]} {D[1,1]} {D[2,2]}");
            }
        }
    }

    

}