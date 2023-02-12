using System;
using static System.Console;
using static System.Math;
public static class main{
        static void MaxInt(){
                int i=1; while(i+1>i) {i++;}
                Write("my max int   = {0}\n",i);
                Write($"int.MaxValue = {int.MaxValue}\n\n");
        }

        static void MinInt(){
                int j=1; while(j-1<j) {j--;}
                Write("my min int   = {0}\n",j);
                Write($"int.MinValue = {int.MinValue}\n\n");
        }

        static void machine_double(){
                double x=1; while(1+x!=1){x/=2;} x*=2;
                Write("my max double        = {0}\n",x);
                Write($"machine double 2^{-52} = {Pow(2,-52)}\n\n");
        }

        static void machine_float(){
                float y=1F; while((float)(1F+y) != 1F){y/=2F;} y*=2F;
                Write("my max float        = {0}\n",y);
                Write($"machine float 2^{-23} = {Pow(2,-23)}\n\n");
        }


        static void epsilon(){
                int n=(int)1e6;
                double epsilon = Pow(2,-52);
                double tiny = epsilon/2;
                double sumA = 0, sumB = 0;

                sumA+=1; for(int k=0;k<n;k++){sumA+=tiny;}
                for(int l=0;l<n;l++){sumB+=tiny;} sumB+=1;

                WriteLine($"sumA-1 = {sumA-1:e} should be {n*tiny:e}");
                WriteLine($"sumB-1 = {sumB-1:e} should be {n*tiny:e}\n");

                double d1 = 0.1+0.1+0.1+0.1+0.1+0.1+0.1+0.1;
                double d2 = 8*0.1;
                WriteLine($"d1={d1:e15}");
                WriteLine($"d2={d2:e15}");
                WriteLine($"d1==d2 ? => {d1==d2}\n");
        }

                
        static bool approx(double a, double b, double acc=1e-9, double eps=1e-9){
                WriteLine($"Abs(a-b): {Abs(a-b)}");
                WriteLine($"Abs(a-b)/(Abs(a)+Abs(b)): {Abs(a-b)/(Abs(a) + Abs(b))}");
                return (Abs(a-b)<acc) || (Abs(a-b)/(Abs(a)+Abs(b)))<eps;
                }

        static void testapprox(){
                double a = 1;
                double b = a - 1e-9;
                WriteLine($"approx(1, 1-1e-9) = {approx(a,b)} should be True");
                b = 2;
                WriteLine($"approx(1, 2) = {approx(a,b)} should be False");
                }
        
        public static void Main(){
            MaxInt();
            MinInt();
            machine_double();
            machine_float();
            epsilon();            
            testapprox();
        }
        
}
