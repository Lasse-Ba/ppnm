using System;
using static System.Math;
using static System.Console;

public class main{

    public static void Main(){
        higgs();
    }

    public static void higgs(){
        var energy = new genlist<double>();
        var signal = new genlist<double>();
        var error  = new genlist<double>();
        var separators = new char[] {' ','\t'};
        var options = StringSplitOptions.RemoveEmptyEntries;
        do{
                string line=Console.In.ReadLine();
                if(line==null)break;
                string[] words=line.Split(separators,options);
                energy.add(double.Parse(words[0]));
                signal.add(double.Parse(words[1]));
                error.add(double.Parse(words[2]));
        }while(true);
        vector first_guesses = new vector(125.0,2,10 );
        first_guesses.print();
        WriteLine($"{first_guesses.size}");
        vector founded_params = minimization.fit(BreitWigner, first_guesses, energy, signal, error);
        double m = founded_params[0];
        double Gamma = founded_params[1];
        double A = founded_params[2];
        WriteLine("For the Breit-Wigner fit I find the paramters to be");
        WriteLine($"Mass m={m}\nFWHM Gamma={Gamma}\nA={A}\n\n");

        
        for(double i=0; i<2000; i++){
            double x = 100 + 60*i/2000;
            double higgs_fit_data = A/( Pow(x-m,2) + Pow(Gamma/2.0, 2) );
            WriteLine($"{x} {higgs_fit_data}");
        };
        
    }

    public static double BreitWigner(vector parameters){
        double x = parameters[0];
        double m = parameters[1];
        double Gamma = parameters[2];
        double A = parameters[3];
        return A/( Pow(x-m,2) + Pow(Gamma/2.0, 2) );
    }
}