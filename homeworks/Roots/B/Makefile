all : Out.txt Wavefunction.svg

Wavefunction.svg : wavefunction.gpi Out.txt
	gnuplot $<

Out.txt : main.exe 
	mono $< > $@

main.exe: main.cs roots.dll vector.dll ode.dll
	mcs -target:exe -reference:roots.dll -reference:vector.dll -reference:ode.dll $<

roots.dll: roots.cs vector.dll QRGS.dll
	mcs -target:library -reference:vector.dll -reference:QRGS.dll $<

ode.dll : ../../ODE/A/ode.cs vector.dll
	mcs -target:library -reference:vector.dll -out:./$@ $<

QRGS.dll : ../../LinearEquations/B/QRGS.cs vector.dll
	mcs -target:library -reference:vector.dll -out:./$@ $<

vector.dll : ../../../matlib/vector/matrix.cs  ../../../matlib/vector/vector.cs
	mcs -target:library -out:./$@ $^

clean:
	rm -f *.exe *.dll *.txt