all : Out.txt Higgs.svg

Higgs.svg : higgs.gpi Out.txt
	gnuplot $<

Out.txt : main.exe
	mono main.exe < higgs.data 1> Out.txt 2> log

main.exe : main.cs minimization.dll vector.dll genlist.dll
	mcs -target:exe -reference:minimization.dll -reference:vector.dll -reference:genlist.dll $<

minimization.dll : minimization.cs vector.dll QRGS.dll genlist.dll
	mcs -target:library -reference:vector.dll -reference:QRGS.dll -reference:genlist.dll $<

QRGS.dll : ../../LinearEquations/B/QRGS.cs vector.dll
	mcs -target:library -reference:vector.dll -out:./$@ $<

vector.dll : ../../../matlib/vector/matrix.cs  ../../../matlib/vector/vector.cs
	mcs -target:library -out:./$@ $^

genlist.dll : ../../../exercises/generic_list/genlist.cs
	mcs -target:library -out:./$@ $^

clean:
	rm -f *.exe *.dll *.txt