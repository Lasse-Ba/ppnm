using System;
using static System.Math;

public static class lsfit{
    public static (vector,matrix,vector) lsfitvec(Func<double,double>[] fs, vector x, vector y, vector dy){
        int n = x.size;
        int m = fs.Length;

        matrix A = new matrix(n,m);
        vector b = new vector(n);

        for(int i=0; i<n; i++){
            b[i] = y[i]/dy[i];
            for(int j=0; j<m; j++){
                A[i,j] = fs[j](x[i])/dy[i];
            }
        }

        QRGS qrfac = new QRGS(A);
        vector c = qrfac.solve(b);
        matrix AtA = A.transpose()*A;
        QRGS solve_AtA = new QRGS(AtA);
        matrix covs = solve_AtA.inverse();

        vector err = new vector(m);
        for(int i=0; i<m; i++){
            err[i] = Sqrt(covs[i][i]);
        }
        return (c,covs,err);
    }
}