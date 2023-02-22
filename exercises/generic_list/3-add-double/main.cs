using System;
using static System.Console;
using static System.Math;
class main{
	public static void Main(){
		list<double> listd = new list<double>();
		listd.add(57.0);
		listd.add(4.0);
		listd.add(52.0);
		listd.add(35.0);
		listd.add(325.0);
		WriteLine();
		foreach(var number in listd){
			WriteLine(number);
		}
		/*
		for(int j=0;j<listd.Count;j++){
			double x = listd[j];
			WriteLine($"List element {j}: {x} ");
		}
		*/

	}
}
