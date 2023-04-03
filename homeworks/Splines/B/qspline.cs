using System;
using static System.Console;
using static System.Math;


    public class qspline{
        public double[] x,y,b,c;
        public qspline(double[] xs, double[] ys){
            this.x = xs;
            this.y = ys;

            int len_dataset = x.Length;
            this.b = new double[len_dataset-1];
            this.c = new double[len_dataset-1];

            double[] p = new double[len_dataset-1];

            for(int i=0; i<len_dataset-1; i++){
                p[i] = (y[i+1]-y[i])/(x[i+1]-x[i]);
            }

            double[] c_forward = new double[len_dataset-1];
            c_forward[0] = 0;
            for(int i=0; i<len_dataset-2; i++){
                c_forward[i+1] = (p[i+1]-p[i]-c_forward[i]*(x[i+1]-x[i]))/(x[i+2]-x[i+1]);
            }

            double[] c_backward = new double[len_dataset-1];
            c_backward[len_dataset-2] = 0;
            for(int i=len_dataset-3; i>=0; i--){
                c_backward[i] = (p[i+1]-p[i] - c_backward[i+1]*(x[i+2]-x[i+1]))/(x[i+1]-x[i]);
            }

            for(int i=0; i<len_dataset-1; i++){
                c[i]=(c_backward[i]+c_forward[i])/2;
            }

            for(int i=0; i<len_dataset-1; i++){
                b[i] = p[i]-c[i]*(x[i+1]-x[i]);
            }
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
            return y[z_bin] + b[z_bin]*(z-x[z_bin]) + c[z_bin]*(z-x[z_bin])*(z-x[z_bin]);
        }


        public double derivative(double z){
            int z_bin = binsearch(x,z);
            return  b[z_bin] + 2.0*c[z_bin]*(z-x[z_bin]);
        }

        public double integral(double z){
            double int_sum = 0;
            int z_bin = binsearch(x,z);
            for(int i=0; i<z_bin; i++){
                int_sum += y[i]*(x[i+1]-x[i]) + b[i]*(x[i+1]-x[i])* (x[i+1]-x[i])/2 + c[i]*Pow((x[i+1]-x[i]),3)/3;
            }
            int_sum += y[z_bin]*(z-x[z_bin]) + b[z_bin]*(z-x[z_bin])*(z-x[z_bin])/2 + c[z_bin]*Pow((z-x[z_bin]),3)/3;
            return int_sum;
        }

        
	}

