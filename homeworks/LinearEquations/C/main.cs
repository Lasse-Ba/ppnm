using System;
using static System.Console;
using static System.Math;
using static System.Random;

class main{
    public static void Main(string[] args){
        int n=5;

        foreach(var arg in args){
			var words = arg.Split(':');
			if(words[0]=="-size"){
				var number=words[1];
				n = int.Parse(number);
			}
		}

        matrix A = new matrix(n,n);
        Random rnd = new Random();
        for(int i=0; i<n; i++){
            for(int j=0; j<n; j++){
                A[i,j]=rnd.Next(10);
            }
        }
        WriteLine("Random matrix A");
        A.print();
        QRGS linsys = new QRGS(A);
		WriteLine("R is (should be upper triangular):");
		linsys.R.print();



    }
}