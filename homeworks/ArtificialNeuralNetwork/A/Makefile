all : Out.txt Plot.svg

Plot.svg : plot.gpi Out.txt
	gnuplot $<

Out.txt : main.exe
	mono $< > $@

main.exe : main.cs ann.dll matrix.dll
	mcs -target:exe -reference:ann.dll -reference:matrix.dll $<

ann.dll :ann.cs matrix.dll minimization.dll
	mcs -target:library -reference:matrix.dll -reference:minimization.dll $<

minimization.dll : ../../Minimization/A/minimization.cs matrix.dll QRGS.dll	
	mcs -target:library -reference:matrix.dll -reference:QRGS.dll -out:./$@ $^

QRGS.dll : ../../LinearEquations/B/QRGS.cs matrix.dll
	mcs -target:library -reference:matrix.dll -out:./$@ $^

matrix.dll : ../../../matlib/vector/vector.cs ../../../matlib/vector/matrix.cs 
	mcs -target:library -out:./$@ $^

clean:
	rm -f *.exe *.dll *.txt *.svg