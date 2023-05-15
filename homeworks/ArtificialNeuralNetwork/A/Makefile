all : Out.txt Plot.svg

Plot.svg : plot.gpi Out.txt
	gnuplot $<

Out.txt : main.exe
	mono $< > $@

main.exe : main.cs ann.dll vector.dll
	mcs -target:exe -reference:ann.dll -reference:vector.dll $<

ann.dll :ann.cs vector.dll minimization.dll
	mcs -target:library -reference:vector.dll -reference:minimization.dll $<

minimization.dll : ../../Minimization/A/minimization.cs vector.dll QRGS.dll	
	mcs -target:library -reference:vector.dll -reference:QRGS.dll -out:./$@ $<

QRGS.dll : ../../LinearEquations/B/QRGS.cs vector.dll
	mcs -target:library -reference:vector.dll -out:./$@ $<

vector.dll : ../../../matlib/vector/matrix.cs  ../../../matlib/vector/vector.cs
	mcs -target:library -out:./$@ $^



clean:
	rm -f *.exe *.dll *.txt *.svg