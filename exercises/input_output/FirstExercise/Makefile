Out.txt : main.exe
	mono main.exe -numbers:1,2,3,4,5 > Out.txt

main.exe : main.cs
	mcs -target:exe -out:$@ $(filter %.cs, $^) $(addprefix -reference:,$(filter %.dll,$^))

clean:
	$(RM) *.exe *.dll [Oo]ut* log*
