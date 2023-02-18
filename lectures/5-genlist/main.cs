using System;
using static System.Console;
using static System.Math;
class main{
	public static void Main(){
	Write("hello\n");
	genlist<double> listd = new genlist<double>();
	listd.add(1.0);
	listd.add(2.0);
	listd.add(5.0);
	listd.add(4.0);
	Func<double,double> f;
//	f = Sin;
//	f = delegate(double x){return x*x;};
	f = (double x) => x*x;
	for(int i=0;i<listd.size;i++){
		double x = listd[i];
		WriteLine($"{x} {f(x)}");
		}
	}
}
