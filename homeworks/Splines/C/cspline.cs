using System;
using static System.Console;
using static System.Math;


    public class cspline{
        public double[] x,y,b,c,d;
        public cspline(double[] xs, double[] ys){
            this.x = xs;
            this.y = ys;

            int len_dataset = x.Length;
            int n = len_dataset -1;
            this.b = new double[n+1];
            this.c = new double[n];
            this.d = new double[n];

            double[] p = new double[n];
            double[] h = new double[n];

            for(int i=0; i<n; i++){
                h[i] = x[i+1] -x[i];
                p[i] = (y[i+1]-y[i])/(x[i+1]-x[i]);
            }

            double[] D = new double[n];
            D[0] = 2;
            for(int i = 0; i<n-1; i++){
                D[i+1]=2*h[i]/h[i+1] + 2;
            }
            D[n-1]=2;

            double[] Q = new double[n-1];
            Q[0]=1;
            for(int i = 0; i<n-2; i++){
                Q[i+1] = h[i]/h[i+1];
            }

            double[] B = new double[n];
            B[0] = 3*p[0];
            for(int i = 0; i<n-2; i++){
                B[i+1] = 3*( p[i] + p[i+1]*h[i]/h[i+1] );
            }
            B[n-1] = 3*p[n-1];

            double[] D_tilde = new double[n];
            D_tilde[0] = D[0];
            for(int i=1; i<n; i++){
                D_tilde[i] = D[i]-Q[i-1]/D_tilde[i-1];
            }

            double[] B_tilde = new double[n];
            B_tilde[0] = B[0];
            for(int i = 1; i<n; i++){
                B_tilde[i]=B[i]-B_tilde[i-1]/D_tilde[i-1];
            }

            /// Introducing an auxillary coefficient b[n]
            b[n]=1;
            b[n-1]=B_tilde[n-1]/D_tilde[n-1];
            for(int i = n-2; i>=0; i--){
                b[i]=(B_tilde[i]-Q[i]*b[i+1])/D_tilde[i];
            }

            for(int i=0; i<n-1; i++){
                c[i] = (-2*b[i]-b[i+1]+3*p[i])/h[i];
            }
            

            for(int i = 0; i<n; i++){
                d[i] = (b[i]+b[i+1]-2*p[i])/Pow(h[i],2);
            }

            c[n-1]=-3*d[n-1]*h[n-1];

        }

        public static int binsearch(double[] x, double z){
            if(!(x[0]<=z && z<=x[x.Length-1])) throw new Exception("binsearch: bad z");
            int i = 0, j = x.Length-1;
            while(j-i>1){
                int mid=(i+j)/2;
                if(z>x[mid]) i = mid; else j =mid;
            }
            return i;
        }


        public double evaluate(double z){
            int z_bin = binsearch(x,z);
            return y[z_bin] + b[z_bin]*(z-x[z_bin]) + c[z_bin]*(z-x[z_bin])*(z-x[z_bin]) + d[z_bin]*Pow((z-x[z_bin]),3);
        }


        public double derivative(double z){
            int z_bin = binsearch(x,z);
            return  b[z_bin] + 2.0*c[z_bin]*(z-x[z_bin]) + 3* d[z_bin]*Pow((z-x[z_bin]),2);
        }

        public double integral(double z){
            double h = 0;
            double int_sum = 0;
            int z_bin = binsearch(x,z);
            for(int i=0; i<z_bin; i++){
                h = x[i+1] -x[i];
                int_sum += y[i]*(h) + b[i]*(h*h)/2 + c[i]*Pow((h),3)/3 + d[i]*Pow(h, 4)/4;
            }
            int_sum += y[z_bin]*(z-x[z_bin]) + b[z_bin]*(z-x[z_bin])*(z-x[z_bin])/2 + c[z_bin]*Pow((z-x[z_bin]),3)/3 + d[z_bin]*Pow((z-x[z_bin]), 4)/4;
            return int_sum;
        }

        
	}

