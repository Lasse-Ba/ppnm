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
		//WriteLine("Q:");
		//linsys.Q.print();
        //linsys.Q.transpose().print();
		WriteLine("R is (should be upper triangular):");
		linsys.R.print();
		matrix QtQ = linsys.Q.transpose()*linsys.Q;
        WriteLine();

        Write("Q^T*Q is (should be I):");
        QtQ.print();
		//WriteLine($"Q*R is approximately A: {(linsys.Q*linsys.R).approx(A)}");
        WriteLine();
        Write($"Q*R is (should be A)");
        matrix QtimesR = linsys.Q*linsys.R;
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
              		
        WriteLine("Solving Ax=b.");
		QRGS linsys = new QRGS(A);
		vector x = linsys.solve(b);

		WriteLine($"A*x is (should be equal to b):");
        var Ax = A*x;
        Ax.print();


        

    }
}