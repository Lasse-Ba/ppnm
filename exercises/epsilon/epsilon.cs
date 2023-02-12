using static System.Console;
using static System.Math;
public class epsilon{
	public static bool approx(double a, double b, double acc, double eps){
                        if(Abs(b-a) < acc){ return true;}
                        else if(Abs(b-a) < Max(Abs(a),Abs(b))*eps){ return true;}
                        else {return false;}
                        }
}
