TIME = time --portability --append --output $@

N = 2e8
Out.txt : main.exe pfor.exe
	>$@
	$(TIME) mono main.exe -terms:$N -threads:1 >> $@
	$(TIME) mono main.exe -terms:$N -threads:2 >> $@
	$(TIME) mono main.exe -terms:$N -threads:3 >> $@
	$(TIME) mono main.exe -terms:$N -threads:4 >> $@
	$(TIME) mono pfor.exe -terms:$N >> $@


main.exe : main.cs
	mcs $<

pfor.exe : pfor.cs
	mcs $<

clean:
	$(RM) *.exe *.dll [Oo]ut* log*

