using System;
using static System.Console;
using static System.Math;
using static System.Random;

class main{
    public static void Main(){
        test_Jacob();
    }

    public static void test_Jacob(){

        int n=4;
        int m=4;

        matrix A = new matrix(n,m);
        Random rnd = new Random();
        for(int i=0; i<n; i++){
            for(int j=0; j<=i; j++){
                A[i,j]=rnd.Next(10);
                A[j,i]=A[i,j];
            }
        }

        WriteLine("Jacobi diagonalization");
        WriteLine("Random symmetric matrix A:");
        A.print();
        WriteLine();

        WriteLine("Diagonal matrix D with the corresponding eigenvalue:");
		matrix D;
		matrix V;
		(D,V) = jacobi.cyclic(A);
		D.print();
		WriteLine();

		WriteLine("Orthogonal matrix V of eigenvectors:");
		V.print();
		WriteLine();

		matrix VtAV = (V.transpose())*A*V;
        WriteLine("V^TAV is (should be equal to D):");
        VtAV.print();
        WriteLine();

		matrix VDVt = V*D*(V.transpose());
        WriteLine("VDV^T is (should be equal to A):");
        VDVt.print();
        WriteLine();

		matrix VtV = V.transpose()*V;
        WriteLine("V^TV is (should be equal to I):");
        VtV.print();
        WriteLine();

		matrix VVt = V*(V.transpose());
        WriteLine("VV^T is (should be equal to I):");
        VVt.print();
        WriteLine();
    }

}