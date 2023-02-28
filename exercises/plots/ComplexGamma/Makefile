ComplexGamma.svg : complex_gamma.gpi complex_gamma.data
	gnuplot $<

complex_gamma.data : complex_gamma.exe
	mono complex_gamma.exe > complex_gamma.data

complex_gamma.exe : complex_gamma.cs cmath.dll
	mcs -reference:cmath.dll complex_gamma.cs

DIR = $(HOME)/repos/ppnm/ppnm/matlib/complex
cmath.dll : $(DIR)/cmath.cs $(DIR)/complex.cs
	mcs -target:library -out:./cmath.dll $^


#ComplexGamma.svg : complex_gamma.gpi complex_gamma_data.data
#	gnuplot $<
#
#
#complex_gamma_data.data : main.exe
#	mono $< > $@
#
#
#main.exe : main.cs cmath.dll
#	mcs -target:exe -reference:cmath.dll -out:$@ $<
#
#DIR = $(HOME)/repos/ppnm/ppnm/matlib/complex
#cmath.dll : $(DIR)/cmath.cs $(DIR)/complex.cs
#	mcs -target:library -out:./cmath.dll $^
