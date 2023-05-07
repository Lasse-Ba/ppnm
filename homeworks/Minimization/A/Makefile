all : Out.txt

Out.txt : main.exe
	mono $< > $@

main.exe : main.cs minimization.dll vector.dll
	mcs -target:exe -reference:minimization.dll -reference:vector.dll $<

minimization.dll : minimization.cs vector.dll QRGS.dll	
	mcs -target:library -reference:vector.dll -reference:QRGS.dll $<

QRGS.dll : ../../LinearEquations/B/QRGS.cs vector.dll
	mcs -target:library -reference:vector.dll -out:./$@ $<

vector.dll : ../../../matlib/vector/matrix.cs  ../../../matlib/vector/vector.cs
	mcs -target:library -out:./$@ $^

clean:
	rm -f *.exe *.dll *.txt