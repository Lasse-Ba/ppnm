Examination project for the lecture PPNM at AU in 2023.
My student number ends with 60, therefore is my project
    60 % 26 = 8 

=> Adaptive two-dimensional integrator

Implement a two-dimensional integrator for integrals in the form

∫abdx ∫_d(x)^u(x)dy f(x,y)

which applies your favourite adaptive one-dimensional integrator along each of the two dimensions. The signature might be something like

static double integ2D(
	Func<double,double,double> f,
	double a, double b,
	Func<double,double> d,
	Func<double,double> u,
	double acc, double eps)
