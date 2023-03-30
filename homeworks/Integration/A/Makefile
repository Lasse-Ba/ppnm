all : Out.txt erf.svg

erf.svg : erf.gpi Out.txt
	gnuplot $<

Out.txt : main.exe 
	mono $< > $@

main.exe: main.cs quad.dll
	mcs -target:exe -reference:quad.dll $<

quad.dll: quad.cs 
	mcs -target:library  $<

clean:
	rm -f *.exe *.dll *.txt