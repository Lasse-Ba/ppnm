all: Gamma.svg LnGamma.svg Erf.svg 

Gamma.svg : gamma.gpi gamma.data factorials.data
	gnuplot $<

LnGamma.svg : lngamma.gpi lngamma_data.data
	gnuplot $<

Erf.svg : erf.gpi erf_data.data
	gnuplot $<



gamma.data : main.exe
	mono $< > $@

lngamma_data.data : lngamma_data.exe
	mono $< > $@

erf_data.data : erf_data.exe
	mono $< > $@




main.exe : main.cs sfuns.dll
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

lngamma_data.exe : lngamma_data.cs sfuns.dll
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

erf_data.exe : erf_data.cs sfuns.dll
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))



sfuns.dll : gamma.cs erf.cs lngamma.cs 
	mcs -target:library -out:$@ $^



factorials.data : Makefile
	>$@
	echo 0 1 >>$@
	echo 1 1 >>$@
	echo 2 2 >>$@
	echo 3 6 >>$@
	echo 4 24 >>$@
	echo 5 120 >>$@
#	echo 6 `echo '6*120' | bc` >>$@