# Examination project for the lecture PPNM at AU in 2023.
My student number ends with 60, therefore is my project: 60 mod 26 = 8:

**Adaptive two-dimensional integrator**

Implement a two-dimensional integrator for integrals in the form

$$\int_a^b dx \int_{d(x)}^{u(x)} dy f(x,y)$$ 	

which applies your favourite adaptive one-dimensional integrator along each of the two dimensions.

### Short describtion of my project

The integrator consists of three subroutines. First of all, the 2d - integrator *integ2D*, which takes the arguments from *main.cs*. The *integrator2d* routine is a recursive adaptive integrator, which integrates the function adaptive, using the trapezium and rectangle rule. In each recursion, the *integrator1d* is called, which is similiar to the integrator from the homework and integrates the function for a given $x$.

In *main.cs*, one defines the function which should be integrated, the boundaries as fixed values or functions, and the accuracy/precision.

I tested the integrator for several functions and checked the results with Wolframalpha or calculated them, if possible, analytically.

Additionally, I added an error estimation for the integral, which is given by the root of the difference between trapezium and rectangle rule.


### Self-evaluation
I would give myself 10 points for this exercise. My two-dimensional integrator integrates the function as it should and fulfills the exercise, if I have not overlooked anything. Furthermore I included an error estiation.

For further improvement one could include a Clenshaw–Curtis variable transformation and count the number of evalutations like in the homework.