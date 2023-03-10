using System;
using static System.Console;
using static System.Math;
class main{
	public static int Main(string[] args){
	Write("reading from stdin to stdout\n");

	for(string line=In.ReadLine();line != null;line=In.ReadLine()){
		double x = double.Parse(line);
		Out.WriteLine($"{x} {Sin(x)}");
	}
	Write("reading from a given file writing to a given file\n");
	string infile=null, outfile=null;
	foreach(string arg in args){
		System.Console.Out.WriteLine(arg);
		var words = arg.Split(':');
		if(words[0]=="-input") infile = words[1];
		if(words[0]=="-output") outfile = words[1];
		}
	if(infile!=null && outfile !=null){
		var inputstream = new System.IO.StreamReader(infile);
		var outputstream = new System.IO.StreamWriter(outfile,append:false);
		for(string line=In.inputstrean.Readline();
			line!=null;
			line=inputstream.ReadLine()){
                double x = double.Parse(line);
                outputstream.WriteLine($"{x} {Sin(x)}");
        }
	}
/*
	if(infile == null){Error.WriteLine("no input file");return 1;}
	if(outfile == null){Error.WriteLine("no input file");return 1;}
*/


	double[] numbers = input.get_numbers_from_args(args);
	foreach(double number in numbers)System.Console.Out.WriteLine($"{number:0.00e+00}");
	System.Console.Error.WriteLine("return code 0");

	for(string line=inputstream.ReadLine();line != null;line=inputstream.ReadLine()){
		double x = double.Parse(line);
		outputstream.WriteLine($"{x} {Sin(x)}");
	}
	inputstream.Close();
	outputstream.Close();
/*
	for(string line=In.ReadLine();line != null;line=In.ReadLine()){
		double x = double.Parse(line);
		Out.WriteLine($"{x} {Sin(x)}");
	}
*/
	return 0;
	}
}
