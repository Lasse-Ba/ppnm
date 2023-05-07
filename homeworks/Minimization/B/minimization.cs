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

    public static vector fit(
        Func<vector, double> f,
        vector initial_values,
        genlist<double> x,
        genlist<double> y,
        genlist<double> y_err,
        double acc = 0.01
    ){
        Func<vector,double> find_min = param => {
            double sum = 0;
            int n = x.size;
            vector parameter = new vector(initial_values.size+1);
            for(int i=0; i<n; i++){
                parameter[0] = x[i];
                for(int j=0; j<initial_values.size; j++){
                    parameter[j+1] = param[j];
                }
                sum += Pow( (f(parameter)-y[i])/y_err[i], 2 );
            }
            return sum;
        };
        var (fit_paramters,steps) = qnewton(find_min, initial_values);
        return fit_paramters;
    }
}