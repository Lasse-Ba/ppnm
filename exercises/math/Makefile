Out.txt : main.exe
	mono main.exe > Out.txt

sfuncs.dll : sfuncs.cs
	mcs $^ -target:library -out:sfuncs.dll

main.exe : main.cs sqrt.cs power2.cs euler_as_basis.cs pi_as_basis.cs sfuncs.dll
	mcs main.cs sqrt.cs power2.cs euler_as_basis.cs pi_as_basis.cs -reference:sfuncs.dll  -target:exe -out:main.exe



#hello.dll : static_hello.cs static_world.cs hello.cs
	#mcs $^ -target:library -out:hello.dll
	#mcs static_hello.cs static_world.cs -target:library -out:hello.dll

#main.exe : main.cs hello.dll
	#mcs main.cs -reference:hello.dll -target:exe -out:main.exe
