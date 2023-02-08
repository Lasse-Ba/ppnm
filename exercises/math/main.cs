using System;
using static System.Console;
using static System.Math;
public static class main{
	static void Main(){
		double s = sqrt.sqrt2;
		Write($"Sqareroot(2) = {s}\n");
		Write($"Sqareroot(2)^2 = {s*s} (should be equal 2)\n");
		double power = power2.two_to_power;
		Write($"2^(1/5) = {power}\n");
		Write($"(2^(1/5))^5 = {Pow(power,5)} (should be equal 2)\n");
		double power_e = euler_as_basis.e_to_pi;
		Write($"e^pi = {power_e}\n");
		Write($"ln(e^pi) = {Log(power_e)} (should be equal 3.14)\n");
		double power_pi = pi_as_basis.pi_to_e;
		Write($"pi^e = {power_pi}\n");
		Write($"(pi^e)^(1/e) = {Pow(power_pi,1/E)} (should be equal 3.14)\n");
	}
}
