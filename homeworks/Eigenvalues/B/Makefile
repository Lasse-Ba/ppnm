all: Out.txt fixed_rmax.svg fixed_dr.svg wavefunctions.svg

fixed_rmax.svg : fixed_rmax.gpi Out.txt
	gnuplot $<

fixed_dr.svg : fixed_dr.gpi Out.txt
	gnuplot $<

wavefunctions.svg : wavefunctions.gpi Out.txt
	gnuplot $<

Out.txt : main1.exe
	mono $< > $@

main1.exe: main1.cs matrix.dll jacobi.dll
	mcs -target:exe -reference:matrix.dll -reference:jacobi.dll $<

jacobi.dll: jacobi.cs matrix.dll
	mcs -target:library -reference:matrix.dll $<

LIBPATH = ../../../matlib/vector

matrix.dll : $(LIBPATH)/vector.cs $(LIBPATH)/matrix.cs
	mcs -target:library -out:$@ $^

clean:
	rm -f *.exe *.dll *.txt *.svg
