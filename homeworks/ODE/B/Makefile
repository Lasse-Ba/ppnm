all : Out.txt lotke_volterra.svg

lotke_volterra.svg : lotke_volterra.gpi Out.txt
	gnuplot $<

Out.txt : main.exe
	mono $< > $@

main.exe : main.cs vector.dll ode.dll genlist.dll
	mcs -target:exe -reference:vector.dll -reference:ode.dll -reference:genlist.dll $<

ode.dll : ode.cs vector.dll genlist.dll
	mcs -target:library -reference:vector.dll -reference:genlist.dll -out:$@ ode.cs


vector.dll : ../../../matlib/vector/matrix.cs ../../../matlib/vector/vector.cs
	mcs -target:library -out:./$@ $^	

genlist.dll : ../../../exercises/generic_list/genlist.cs
	mcs -target:library -out:./$@ $^

clean:
	rm -f *.exe *.dll *.txt