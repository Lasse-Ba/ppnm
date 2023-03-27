using System;
using static System.Console;
using static System.Math;

class main{
    public static void Main(){
        test_quadinterp();
    }

    public static void test_quadinterp(){
        int n = 5;
        double[] xs = new double[n];
        double[] y1 = new double[n];
        double[] y2 = new double[n];
        double[] y3 = new double[n];
        for(int j=0; j<n; j++){
            xs[j] = j+1;
            y1[j] = 1;
            y2[j] = j+1;
            y3[j] = Pow(j+1,2);
        }

        WriteLine("Generate data points");
        for(int j=0; j<n; j++){
            WriteLine($"{xs[j]} {y1[j]}");
        }
        WriteLine();
        WriteLine();
        for(int j=0; j<n; j++){
            WriteLine($"{xs[j]} {y2[j]}");
        }
        WriteLine();
        WriteLine();
        for(int j=0; j<n; j++){
            WriteLine($"{xs[j]} {y3[j]}");
        }
        WriteLine();
        WriteLine();

        qspline q_1 = new qspline(xs,y1);
        qspline q_2 = new qspline(xs,y2);
        qspline q_3 = new qspline(xs,y3);
        WriteLine("Pick a z, interploate and integrate the data points");
        double z=2.4;
        WriteLine($"z={z} f(z)={q_1.evaluate(z)} Integral {q_1.integral(z)}");
        WriteLine();


        WriteLine("-------------------------------");
        WriteLine("Compare the paramters manually calculated {b_i,c_i} with those calculated by the program");
        double[] c_const = new double[]{0,0,0,0};
        double[] b_const = new double[]{0,0,0,0};
        WriteLine();
        WriteLine();

        WriteLine("For f(x)=1:");
        WriteLine("manually calculated c_i:");
        for(int i=0; i<4; i++){
            Write($"{c_const[i]} ");
        }
        WriteLine();
        WriteLine("qspline calculated c_i:");
        for(int i=0; i<4; i++){
            Write($"{q_1.c[i]} ");
        }
        WriteLine();
        WriteLine("manually calculated b_i:");
        for(int i=0; i<4; i++){
            Write($"{b_const[i]} ");
        }
        WriteLine();
        WriteLine("qspline calculated b_i:");
        for(int i=0; i<4; i++){
            Write($"{q_1.b[i]} ");
        }




        double[] c_lin = new double[]{0,0,0,0};
        double[] b_lin = new double[]{1,1,1,1};
        WriteLine();
        WriteLine();

        WriteLine("For f(x)=x:");
        WriteLine("manually calculated c_i:");
        for(int i=0; i<4; i++){
            Write($"{c_lin[i]} ");
        }
        WriteLine();
        WriteLine("qspline calculated c_i:");
        for(int i=0; i<4; i++){
            Write($"{q_2.c[i]} ");
        }
        WriteLine();
        WriteLine("manually calculated b_i:");
        for(int i=0; i<4; i++){
            Write($"{b_lin[i]} ");
        }
        WriteLine();
        WriteLine("qspline calculated b_i:");
        for(int i=0; i<4; i++){
            Write($"{q_2.b[i]} ");
        }

        


        double[] c_quad = new double[]{1,1,1,1};
        double[] b_quad = new double[]{2,4,6,8};
        WriteLine();
        WriteLine();

        WriteLine("For f(x)=x^2:");
        WriteLine("manually calculated c_i:");
        for(int i=0; i<4; i++){
            Write($"{c_quad[i]} ");
        }
        WriteLine();
        WriteLine("qspline calculated c_i:");
        for(int i=0; i<4; i++){
            Write($"{q_3.c[i]} ");
        }
        WriteLine();
        WriteLine("manually calculated b_i:");
        for(int i=0; i<4; i++){
            Write($"{b_quad[i]} ");
        }
        WriteLine();
        WriteLine("qspline calculated b_i:");
        for(int i=0; i<4; i++){
            Write($"{q_3.b[i]} ");
        }
        WriteLine();



    }

}