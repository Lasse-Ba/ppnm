# Examination project for the lecture PPNM at AU in 2023.
My student number ends with 60, therefore is my project: 60 mod 26 = 8:

**Adaptive two-dimensional integrator**

Implement a two-dimensional integrator for integrals in the form

$$\int_a^b dx \int_{d(x)}^{u(x)} dy f(x,y)$$ 	

which applies your favourite adaptive one-dimensional integrator along each of the two dimensions.

### Short describtion of my project

The integrator consists of three subroutines. First of all, the 2d - integrator, which takes the arguments from *main.cs*. The Driver2d routine is a recursive adaptive integrator, which integrates the function adaptive, using the trapezium and rectangle rule. In each recursion, the Driver1D is called, which is similiar to the integrator from the homework and integrates the function for a given $x$.

I tested the integrator for several functions and checked the results with Wolframalpha or calculated them, if possible, analytically.


### Self-evaluation
I would give myself a 9/10. My two-dimensional integrator integrates the function as it should and fulfills the exercise,
but I see points for further improvement, especially that the functions for the lower and upper limit u(x) and d(x) has 
to be defined in both files, *quad.cs* and *main.cs*.

For further improvement one could include a Clenshaw–Curtis variable transformation like in the homework as well as an
error estimation.