all:  Out.txt Plot.svg

Out.txt : main.exe
	mono $< > $@

Plot.svg : plot.gpi data.data
	gnuplot $<

data.data : data.exe
	mono $< > $@ 

data.exe: data.cs qspline.dll
	mcs -target:exe -reference:qspline.dll $<

main.exe: main.cs qspline.dll
	mcs -target:exe -reference:qspline.dll $<

qspline.dll: qspline.cs
	mcs -target:library $<

clean:
	rm -f *.exe *.dll *.txt
