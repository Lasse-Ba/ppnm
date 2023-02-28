using System;
using static System.Console;
using static System.Math;
class complex_gamma_data{
	public static void Main(){
	for(double x= -5+1.0/128;x<=5;x+=1.0/64){
		for(double y= -5+1.0/128;x<=5;x+=1.0/64){
			WriteLine($"{x} {y} {cmath.abs(complex_gamma(new complex(x,y)))}");
		}
	}
}
}