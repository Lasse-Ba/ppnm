Out.txt : main.exe
	mono main.exe -input:input.txt -output:out.txt

main.exe : main.cs
	mcs -target:exe -out:$@ $(filter %.cs, $^) $(addprefix -reference:,$(filter %.dll,$^))

clean:
	$(RM) *.exe *.dll [Oo]ut* log*
