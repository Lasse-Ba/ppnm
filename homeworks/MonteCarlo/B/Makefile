all : Out.txt Plot.svg

Plot.svg : plot.gpi Out.txt
	gnuplot $<

Out.txt : main.exe 
	mono $< > $@

main.exe: main.cs vector.dll mc.dll
	mcs -target:exe -reference:vector.dll -reference:mc.dll $<

mc.dll: mc.cs vector.dll
	mcs -target:library -reference:vector.dll $<


LIBDIR = ../../../matlib/vector

vector.dll : $(LIBDIR)/matrix.cs $(LIBDIR)/vector.cs
	mcs -target:library -out:./$@ $^

clean:
	rm -f *.exe *.dll *.txt