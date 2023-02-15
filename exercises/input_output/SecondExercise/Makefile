Out.txt : main.exe
	echo 1 2 3 4 5 > input.txt
	mono main.exe < input.txt > out.txt

main.exe : main.cs
	mcs -target:exe -out:$@ $(filter %.cs, $^) $(addprefix -reference:,$(filter %.dll,$^))

clean:
	$(RM) *.exe *.dll [Oo]ut* log*
