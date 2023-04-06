import numpy as np 
from scipy.integrate import quad

def f_1(x):
    return 1/np.sqrt(x)

def f_2(x):
    return np.log(x)/np.sqrt(x)

a = 0
b = 1

solution_1, err_1, info_1 = quad(f_1, a, b, full_output=True, epsabs=0.01, epsrel=0.01)
solution_2, err_2, info_2 = quad(f_2, a, b, full_output=True, epsabs=0.01, epsrel=0.01)

n_evals_1 = info_1['neval']
n_evals_2 = info_2['neval']

print(f'Integral of 1/sqrt(x) is {solution_1} with {n_evals_1} evolutions')
print(f'Integral of ln(x)/sqrt(x) is {solution_2} with {n_evals_2} evolutions')