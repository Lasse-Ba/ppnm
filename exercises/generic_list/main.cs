using System;
using static System.Console;
using static System.Math;
class main{
	public static void Main(){
		genlist<double[]> list = new genlist<double[]>();
		char[] delimiters = {' ','\t'};
		var options = StringSplitOptions.RemoveEmptyEntries;
		for(string line = ReadLine(); line!=null; line = ReadLine()){
			var words = line.Split(delimiters,options);
			int n = words.Length;
			var numbers = new double[n];
			for(int i=0;i<n;i++) numbers[i] = double.Parse(words[i]);
			list.add(numbers);
				}
		for(int i=0;i<list.size;i++){
			var numbers = list[i];
			foreach(var number in numbers)Write($"{number : 0.00e+00;-0.00e+00} ");
			WriteLine();
				}
		

		genlist<double> listd = new genlist<double>();
		listd.add(57.0);
		listd.add(4.0);
		listd.add(52.0);
		listd.add(35.0);
		listd.add(325.0);
		WriteLine();
		for(int j=0;j<listd.size;j++){
			double x = listd[j];
			WriteLine($"List element {j}: {x} ");
		}
		listd.remove(2);
		for(int k=0; k<listd.size; k++){
			double y = listd[k];
			WriteLine($"List element removed {k}: {y}, gives ");
		}
	}
}
