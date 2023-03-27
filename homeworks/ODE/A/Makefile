all : Out.txt scipy_pendulum.svg ode_test.svg

scipy_pendulum.svg : scipy_pendulum.gpi Out.txt
	gnuplot $<

ode_test.svg : ode_test.gpi Out.txt
	gnuplot $<

Out.txt : main.exe
	mono $< > $@

main.exe : main.cs vector.dll ode.dll
	mcs -target:exe -reference:vector.dll -reference:ode.dll $<

ode.dll : ode.cs vector.dll
	mcs -target:library -reference:vector.dll -out:$@ ode.cs

LIBDIR = ../../../matlib/vector

vector.dll : $(LIBDIR)/matrix.cs $(LIBDIR)/vector.cs
	mcs -target:library -out:./$@ $^

clean:
	rm -f *.exe *.dll *.txt