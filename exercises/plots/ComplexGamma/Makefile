ComplexGamma.svg : complex_gamma.gpi complex_gamma.data
	gnuplot $<

complex_gamma.data : complex_gamma.exe
	mono complex_gamma.exe > complex_gamma.data

complex_gamma.exe : complex_gamma.cs cmath.dll
	mcs -reference:cmath.dll complex_gamma.cs

DIR = $(HOME)/repos/ppnm/ppnm/matlib/complex
cmath.dll : $(DIR)/cmath.cs $(DIR)/complex.cs
	mcs -target:library -out:./cmath.dll $^
