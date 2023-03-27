using System;
using static System.Console;
using static System.Math;
using static System.Random;

class main{
    static double rmax = 10;
    static int npoints = 10;
    static double dr = rmax/npoints;
    static vector r = new vector(npoints);

    public static void Main(){

        //Fill vector with grid
        for(int i=0; i<npoints;i++){
            r[i]=dr*(i+1); //using i instead of i+1
        }
        matrix H = build_H();
        matrix D;
		matrix V;
		(D,V) = jacobi.cyclic(H);
        
        double lowestE = new double 1e10;
        int lowestIndex = 0;
        for(int i = 0; i < npoints; i++){
            if(D[i,i] < lowestE){
                lowestE = D[i,i];
                lowestIndex = i;
            }
        }

        lowestWaveFunction = v[lowestIndex];

        

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


}