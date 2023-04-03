all: Out.txt out_times.data time_plot.svg

time_plot.svg : plot.gpi out_times.data
	gnuplot $<

out_times.data : main.exe
	>$@
	for N in $$(seq 40 20 200); do \
		time --format "$$N %e" --output $@ --append \
		mono $< -size:$$N 1>out 2>err ;\
	done

Out.txt : main.exe
	mono $< > $@

main.exe: main.cs matrix.dll QRGS.dll
	mcs -target:exe -reference:matrix.dll -reference:QRGS.dll $<

QRGS.dll: QRGS.cs matrix.dll
	mcs -target:library -reference:matrix.dll $<

matrix.dll : ../vector.cs ../matrix.cs
	mcs -target:library -out:$@ $^

clean:
	rm -f *.exe *.dll *.tx4