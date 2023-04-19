all : Out.txt 

Out.txt : main.exe 
	mono $< > $@
	python3 integral.py >> Out.txt

main.exe: main.cs quad.dll
	mcs -target:exe -reference:quad.dll $<

quad.dll: quad.cs 
	mcs -target:library  $<

clean:
	rm -f *.exe *.dll *.txt