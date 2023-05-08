using System;
using static System.Math;

public static class ode{
    public static (vector, vector) rkstep45(Func< double, vector, vector> f, double x, vector y, double h){
vector k1 = f(x,y);
        vector k2 = f(x+h/4.0, y+h*(k1/4.0));
        vector k3 = f(x+h*3.0/8.0, y+h*(k1*3.0/32.0 + k2*9.0/32.0));
        vector k4 = f(x+h*12.0/13.0, y+h*(k1*1932.0/2197.0 - k2*7200.0/2197.0 + k3*7296.0/2197.0));
        vector k5 = f(x+h, y+h*(k1*439.0/216.0 - 8*k2 + k3*3680.0/513.0 - k4*845.0/4140.0));
        vector k6 = f(x+h/2.0, y+h*(-k1*8.0/27.0 + k2*2.0 - k3*3544.0/2565.0 + k4*1859.0/4104.0 - k5*11.0/40.0));

        vector y_h = y + h*(k1*16.0/135.0 + k3*6656.0/12825.0 + k4*28561.0/56430.0 - k5*9.0/50.0 + k6*2.0/55.0);
        vector e_r = h*( k1*(16.0/135.0 - 25.0/216.0) + k3*(6656.0/12825.0 - 1408.0/2565.0) + k4*(28561.0/56430.0 - 2197.0/4104.0) + k5*(-9.0/50.0+1.0/5.0) + k6*2.0/55.0 );
        return (y_h,e_r);
    }

    public static (genlist<double>,genlist<vector>) driver(
        Func<double,vector,vector> f, /* the f from dy/dx=f(x,y) */
        double a,                    /* the start-point a */
        vector ya,                   /* y(a) */
        double b,                    /* the end-point of the integration */
        double h=0.01,               /* initial step-size */
        double acc=0.01,             /* absolute accuracy goal */
        double eps=0.01,             /* relative accuracy goal */
        genlist<double> xlist=null,
        genlist<vector> ylist=null
    ){
        if(a>b) throw new ArgumentException("driver: a>b");
        double x = a;
        vector y = ya.copy();
        if(xlist != null && ylist !=null){
            xlist = new genlist<double>(); xlist.add(x);
            ylist = new genlist<vector>(); ylist.add(y);
        }

        do{
            if(x>=b){
                if (xlist == null && ylist == null){
                    xlist = new genlist<double>();
                    ylist = new genlist<vector>();
                    xlist.add(x);
                    ylist.add(y);
                    return (xlist, ylist);
                }
                else
                    return (xlist, ylist); /* job done */
            }

            if(x+h>=b) h = b-x;
            var(y_h, erv) = rkstep45(f,x,y,h);

            double[] tol = new double[y.size];
            double[] err = new double[y.size];
            for(int i=0; i<y.size; i++){
                tol[i] = Max(acc, y_h.norm()*eps)*Sqrt(h/(b-a));
            }
            bool ok = true;

            for(int i=0; i<y.size; i++){
                if(!(erv[i]<tol[i]))
                    ok=false;
            }

            if(ok){
                x+=h;
                y=y_h; 
                if(xlist != null && ylist != null){
                    xlist.add(x);
                    ylist.add(y);
                }
            }
            double factor = tol[0]/Abs(erv[0]);
            for(int i=1;i<y.size;i++){
                factor=Min(factor,tol[i]/Abs(erv[i]));
            }
            h *= Min( Pow(factor,0.25)*0.95 ,2);
        }while(true);
    }

}
