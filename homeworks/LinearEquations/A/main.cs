using System;
using static System.Console;
using static System.Math;
using static System.Random;

class main{
    public static void Main(){
        test_decomp();
        test_solve();
    }

    public static void test_decomp(){

        int n=4;
        int m=3;

        matrix A = new matrix(n,m);
        Random rnd = new Random();
        for(int i=0; i<n; i++){
            for(int j=0; j<m; j++){
                A[i,j]=rnd.Next(10);
            }
        }
        WriteLine("Gram-Schmidt orthonormalization");
        WriteLine("Random matrix A");
        A.print();
        WriteLine();

        WriteLine("Factorize A into QR:");
		QRGS linsys = new QRGS(A);
		WriteLine("R is (should be upper triangular):");
		linsys.R.print();
		matrix QtQ = linsys.Q.transpose()*linsys.Q;
        WriteLine();

        Write($"Q^T*Q should be I: {QtQ.approx(matrix.id(m))} \nwith Q^TQ = ");
        QtQ.print();
        WriteLine();
        matrix QtimesR = linsys.Q*linsys.R;
        Write($"Q*R should be A: {QtimesR.approx(A)}\nwith Q*R=");
        QtimesR.print();
		WriteLine();
        WriteLine();

    }

    public static void test_solve(){
        int n = 4;

        matrix A = new matrix(n,n);
        vector b = new vector(n);
        Random rnd = new Random();
        for(int i=0; i<n; i++){
            b[i] = rnd.Next(10);
            for(int j=0; j<n; j++){
                A[i,j]=rnd.Next(10);
            }
        }
        WriteLine("_____________________________");
        WriteLine("Solve the equation QRx=b");
        WriteLine($"Matrix A: ");
	    A.print();
		WriteLine($"Vector b: ");
		b.print();
              		
        WriteLine("\nSolving Ax=b. with x = ");
		QRGS linsys = new QRGS(A);
		vector x = linsys.solve(b);
        x.print();


        var Ax = A*x;
		WriteLine($"\nA*x should be equal to b: {b.approx(Ax)}\nwith Ax =");
        Ax.print();


        

    }
}