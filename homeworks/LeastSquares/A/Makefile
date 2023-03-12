all: Out.txt Fit.svg

Fit.svg : fit.gpi Out.txt
	gnuplot $<

Out.txt : main.exe
	mono $< > $@

main.exe : main.cs lsfit.dll matrix.dll
	mcs -target:exe -reference:lsfit.dll -reference:matrix.dll $<

lsfit.dll : lsfit.cs matrix.dll QRGS.dll
	mcs -target:library -reference:matrix.dll -reference:QRGS.dll $<

QRGSDIR = ../../LinearEquations/A

QRGS.dll : $(QRGSDIR)/QRGS.cs matrix.dll
	mcs -target:library -reference:matrix.dll -out:./$@ $<

LIBPATH = ../../../matlib/vector

matrix.dll : $(LIBPATH)/vector.cs $(LIBPATH)/matrix.cs
	mcs -target:library -out:$@ $^

clean:
	rm -f *.exe *.dll *.txt
