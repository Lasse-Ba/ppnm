using System;
using static System.Math;

public static class roots{

    public static vector newton(
        Func<vector,vector> f,
        vector x,
        double eps=0.01
    ){
        int n = x.size;
        matrix J = new matrix(n,n);
        vector f_x = f(x);
        double delta = 0.0;
        bool not_converge = true;
        int itrerations = 0;

        while(not_converge){
            for(int i=0; i<n; i++){
                delta = Abs(x[i])*Pow(2,-26);
                for(int k=0; k<n; k++){
                    vector x_k = x.copy();
                    x_k[k] += delta;
                    J[i,k] = (f(x_k)[i]-f(x)[i])/delta;
                }
            }
            vector dx = new QRGS(J).solve(-f_x);
            double lambda = 1.0;
            while( (f(x+lambda*dx)).norm() > (1.0-lambda/2.0) && lambda>1.0/32.0 ){
                lambda = lambda/2.0;
            }
            x += lambda*dx;
            not_converge = (f(x)).norm()>eps &&  itrerations<100; 
            f_x = f(x);
            itrerations++;
        }

        return x;
    }
}