all:  Out.txt Plot.svg

Out.txt : main.exe
	mono $< > $@

Plot.svg : plot.gpi data.data
	gnuplot $<

data.data : data.exe
	mono $< > $@ 

data.exe: data.cs cspline.dll
	mcs -target:exe -reference:cspline.dll $<

main.exe: main.cs cspline.dll
	mcs -target:exe -reference:cspline.dll $<

cspline.dll: cspline.cs
	mcs -target:library $<

clean:
	rm -f *.exe *.dll *.txt
