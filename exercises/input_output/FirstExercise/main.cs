using System;
using static System.Console;
using static System.Math;
class main{
	public static void Main(string[] args){
		exercise1(args);
	}
	static void exercise1(string[] args){
	foreach(var arg in args){
		var words = arg.Split(':');
		if(words[0]=="-numbers"){
			var numbers=words[1].Split(',');
			foreach(var number in numbers){
				double x = double.Parse(number);
				WriteLine($"{x} {Sin(x)} {Cos(x)}");
				}
			}
		}
	}

	/*
	static void exercise2(string[] args){
	char[] split_delimiters = {' ','\t','\n'};
	var split_options = StringSplitOptions.RemoveEmptyEntries;
	for( string line = ReadLine(); line != null; line = ReadLine() ){
		var numbers = line.Split(split_delimiters,split_options);
		foreach(var number in numbers){
			double x = double.Parse(number);
			WriteLine($"{x} {Sin(x)} {Cos(x)}");
			}
		}
	}
*/
}
