# Examination project for the lecture PPNM at AU in 2023.
My student number ends with 60, therefore is my project
    60 mod 26 = 8 

**Adaptive two-dimensional integrator**
Implement a two-dimensional integrator for integrals in the form

$$\int_a^b dx \int_{d(x)}^{u(x)} dy f(x,y)$$

∫abdx ∫_d(x)^u(x)dy f(x,y)

which applies your favourite adaptive one-dimensional integrator along each of the two dimensions.

### Short describtion of my project


### Self-evaluation
I would give myself a 9/10. My two-dimensional integrator integrates the function as it should and fulfills the exercise,
but I see points for further improvement, especially that the functions for the lower and upper limit u(x) and d(x) has 
to be defined in both files, *quad.cs* and *main.cs*.

For further improvement one could include a Clenshaw–Curtis variable transformation like in the homework as well as an
error estimation.