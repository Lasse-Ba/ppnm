using System;
using static System.Console;
using static System.Math;
public static class main{
	public static void Main(){
		complex x = new complex(1,0);
		complex n1 = -complex.One;
		complex y = new complex(0,1);
		WriteLine($"1 =  {x}");
		WriteLine($"-1 =  {n1}");
		WriteLine($"i =  {y}");
		WriteLine($"sqrt(-1) = {cmath.sqrt(n1)} should be ±i");
		WriteLine($"sqrt(i) = {cmath.sqrt(y)} should be (1+i)/sqrt(2)");
		WriteLine($"exp(i) = {cmath.exp(y)} should be cos(1)+isin(1) = 0.54+i*0.84");
		WriteLine($"exp(pi*i) = {cmath.exp(PI*y)} should be -1");
		WriteLine($"i^i = {cmath.pow(y,y)} should be e^(-pi/2)=0.2078");
		WriteLine($"ln(i) = {cmath.log(y)} should be i*pi/2=1.57i");
		WriteLine($"sin(i*pi) = {cmath.sin(PI*y)} should be i*sinh(pi)=11.55*i");
	}
}
