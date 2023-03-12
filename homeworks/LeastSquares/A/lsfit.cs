using System;

public static class lsfit{
    public static vector lsfitvec(Func<double,double>[] fs, vector x, vector y, vector dy){
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
        return c;
    }
}