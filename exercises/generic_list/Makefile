Out.txt : main.exe
	mono main.exe < input.txt > out.txt

main.exe : main.cs genlist.dll
	mcs -target:exe -out:$@ -reference:genlist.dll $<

genlist.dll : genlist.cs
	mcs -target:library -out:$@ $<

clean:
	$(RM) *.exe *.dll [Ou]ut* log*
