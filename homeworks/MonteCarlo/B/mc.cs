using System;
using static System.Math;

public static class mc{

    public static (double, double) plainmc(
        Func<vector,double> f,
        vector a,
        vector b,
        int N
    ){
        int dim=a.size;
        double V=1;

        for(int i=0; i<dim; i++){
            V*=b[i]-a[i];
        }

        double sum=0;
        double sum2=0;
        var x = new vector(dim);
        var rand = new Random();

        for(int i=0; i<N; i++){
            for(int k=0; k<dim; k++){
                //double ran_num = rand.NextDouble();
                x[k] = a[k] + rand.NextDouble()*(b[k]-a[k]);
            }
            double fx = f(x);
            sum +=fx;
            sum2 += fx*fx;
        }

        double mean = sum/N;
        double sigma = Sqrt(sum2/N - mean*mean);
        var result = (mean*V, sigma*V/Sqrt(N));
        return result;
    }

    public static (double, double) quasimc(
        Func<vector,double> f,
        vector a,
        vector b,
        int N
    ){
        int dim = a.size;
        double V=1;

        for(int i=0; i<dim; i++){
            V*=b[i]-a[i];
        }

        double sum=0;
        double sum2=0;
        var x = new vector(dim);
        var x_2 = new vector(dim);

        for(int i=0; i<N; i++){
            var h = halton(i, dim);
            var h_2 = halton(i, dim, true);

            for(int k=0; k<dim; k++){
                x[k] = a[k] + h[k]*(b[k]-a[k]);
                x_2[k] = a[k] + h_2[k]*(b[k]-a[k]);
            }
            double fx = f(x);
            double fx_2 = f(x_2);
            sum +=fx;
            sum2 += fx*fx;
        }

        double mean = sum/N;
        double mean_2 = sum2/N;
        var result = (mean*V, Abs(mean-mean_2)*V);
        return result;
    }

    public static double corput( int n , int b ){
        double q=0;
        double bk=(double) 1.0/b;
        while( n>0){
            q += ( n % b )*bk;
            n /= b ;
            bk /= b;
        }
        return q ;
    }

    public static vector halton( int n, int d, bool reverse=false ){
        int[] b = new int[]{ 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61};
        if(d>b.Length){
            throw new System.Exception("Dimension too large in this Sequence");
        }

        var x = new vector(d);
        if(reverse){
            Array.Reverse(b);
        }
        for( int i =0; i <d ; i ++){
            x[i]= corput(n, b[i] ) ;
        }
        return x;
    }
}