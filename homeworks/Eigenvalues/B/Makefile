all: Out.txt wavefuncs.png r_convergence.png dr_convergence.png
	cat Out.txt

wavefuncs.png: Out.txt Makefile
	echo '\
	set term png;\
	set out "$@";\
	set title "Calculated radial wavefunctions vs. analytical";\
	set xlabel "r";\
	set ylabel "R";\
	set key out;\
	set xrange [-1:25];\
	plot \
	"Out.txt" index 0 using 1:2 pointtype 7 pointsize 1 title "E_0 numerical"\
	,"Out.txt" index 0 using 1:3 with lines title "E_0 analytical"\
	,"Out.txt" index 1 using 1:2 pointtype 7 pointsize 1 title "E_1 numerical"\
	,"Out.txt" index 1 using 1:3 with lines title "E_1 analytical"\
	,"Out.txt" index 2 using 1:2 pointtype 7 pointsize 1 title "E_2 numerical"\
	,"Out.txt" index 2 using 1:3 with lines title "E_2 analytical"\
	' | tee log | gnuplot

r_convergence.png: conv_rmax.txt Makefile
	echo '\
	set term png;\
	set out "$@";\
	set title "Calculated energies for hydrogen with respect to rmax";\
	set xlabel "r_{max}";\
	set ylabel "Energies";\
	set key out;\
	set xrange [-1:30];\
	plot \
	"conv_rmax.txt" index 0 using 1:2 with lines title "E_0"\
	,"conv_rmax.txt" index 0 using 1:3 with lines title "E_1"\
	,"conv_rmax.txt" index 0 using 1:4 with lines title "E_2"\
	,-1.0/2 with lines title "exact E_0"\
	,-1.0/8 with lines title "exact E_1"\
	,-1.0/18 with lines title "exact E_2"\
	' | tee log | gnuplot

dr_convergence.png: conv_dr.txt Makefile
	echo '\
	set term png;\
	set out "$@";\
	set title "Calculated energies for hydrogen with respect to dr";\
	set xlabel "dr";\
	set ylabel "Energies";\
	set key out;\
	set grid;\
	plot [] [-0.51:]\
	"conv_dr.txt" index 0 using 1:2 with lines title "E_0"\
	,"conv_dr.txt" index 0 using 1:3 with lines title "E_1"\
	,"conv_dr.txt" index 0 using 1:4 with lines title "E_2"\
	,-1.0/2 with lines title "exact E_0"\
	,-1.0/8 with lines title "exact E_1"\
	,-1.0/18 with lines title "exact E_2"\
	' | tee log | gnuplot

Out.txt : main.exe
	mono $< > $@

main.exe: main.cs matrix.dll jacobi.dll
	mcs -target:exe -reference:matrix.dll -reference:jacobi.dll $<

jacobi.dll: jacobi.cs matrix.dll
	mcs -target:library -reference:matrix.dll $<

LIBPATH = ../../../matlib/vector

matrix.dll : $(LIBPATH)/vector.cs $(LIBPATH)/matrix.cs
	mcs -target:library -out:$@ $^

clean:
	rm -f *.exe *.dll *.txt
