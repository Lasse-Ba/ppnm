using System;
using static System.Math;

public static class minimization{

    public static vector numeric_gradient(
        Func<vector,double> f,
        vector x
    ){
        double Delta = Pow(2,-26);

        int n = x.size;
        vector gradient = new vector(n);
        double f_x = f(x);
        for(int i=0; i<n; i++){
            double dx;
            double x_i = x[i];
            if(Abs(x_i)<Sqrt(Delta)){
                dx = Delta;
            }
            else{
                dx = Abs(x_i)*Delta;
            };

            x[i] = x_i+dx;
            gradient[i] = (f(x)-f_x)/dx;
            x[i] = x_i;
        }
        return gradient;
    }


    public static (vector,int) qnewton(
        Func<vector,double> f,
        vector x,
        double acc = 0.01
    ){
        int steps = 0;
        int n = x.size;
        matrix B = matrix.id(n);

        vector grad_x = numeric_gradient(f,x);
        vector s = new vector(n);
        vector u = new vector(n);
        vector y = new vector(n);
        matrix dB = new matrix(n,n);

        while(grad_x.norm()>acc){
            vector Delta_x = -B*grad_x;
            double lambda = 1.0;
            while(true){
                s = lambda*Delta_x;
                if(f(x+s)<f(x)){
                    vector grad_x_without_s = grad_x;
                    x = x+s;
                    grad_x = numeric_gradient(f,x);
                    y = grad_x-grad_x_without_s;
                    u = s - B*y;
                    double u_y = u.dot(y);
                    if(Abs(u_y)>1e-6){ //change number here
                        dB = matrix.outer(u,u)/u_y;
                        B = B+dB;
                    };
                    break;
                }
                lambda = lambda/2;
                if(lambda<1.0/Pow(2,10)){
                    x = x+s;
                    grad_x = numeric_gradient(f,x);
                    B =  matrix.id(n);
                    break;
                }
            }
            steps++;
        }
        return (x,steps);
    }

    /*
    public static (vector, int) qnewton(
        Func<vector,double> f,
        vector x,
        double acc = 0.01,
        matrix B = null,
        int steps = 0
    ){
        double Delta = Pow(2,-26);
        double epsilon = Pow(1,-6);

        double f_x = f(x);
        vector grad_x = numeric_gradient(f,x);
        if (B == null){
			B = matrix.id(x.size);
		}
        if(grad_x.dot(grad_x)<acc){
            return (x,steps);
        }
        
        double lambda = 1.0;
        vector del_x = -B*grad_x;
        while(true){
            if( f(x+del_x)<f(x) ){     
                var lamb_del = lambda*del_x;
                x = x + lamb_del;
                var diff = numeric_gradient(f,x+lamb_del) - numeric_gradient(f,x);
                var u = lamb_del-B*diff;
                var gamma = (u.dot(diff))/(2.0*lamb_del.dot(diff));
                if(Abs(lamb_del.dot(diff))>epsilon){
                    var a = (u-gamma*lamb_del)/(lamb_del.dot(diff));
                    B.update(a,lamb_del);
                    B.update(lamb_del,a);
                };
                break;
            };

            lambda = lambda/2.0;
            if(lambda<1.0/64){
                var lamb_del = lambda*del_x;
                x = x + lamb_del;
                B.set_identity();
                break;
            }; 
        };
        return qnewton(f, x, acc, B, steps+1);
    }
    */

}