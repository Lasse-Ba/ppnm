using System;
using static System.Console;
using static System.Math;

public static class main{
    public static complex complex_gamma(complex x){
        ///single precision gamma function (Gergo Nemes, from Wikipedia)
        if(cmath.abs(x)<0)return PI/cmath.sin(PI*x)/complex_gamma(1-x);
        if(cmath.abs(x)<9)return complex_gamma(x+1)/x;
        complex lngamma=x*cmath.log(x+1/(12*x-1/x/10))-x+cmath.log(2*PI/x)/2;
        return  cmath.exp(lngamma);
    }

    public static void Main(){
	    for(double x= -5+1.0/16; x<=5; x+=1.0/8){
		    for(double y= -5+1.0/16;y<=5;y+=1.0/8){
			    WriteLine($"{x} {y} {cmath.abs(complex_gamma(new complex(x,y)))}");
		    }
            WriteLine("");
	    }
        
    }

}//class