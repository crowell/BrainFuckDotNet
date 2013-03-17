   The Brainfuck Language 

Brainfuck is an esoteric programming language noted for its extreme minimalism. It is a Turing tarpit, designed to challenge and amuse programmers, and was not made to be suitable for practical use. It was created in 1993 by Urban Müller.


BrainFuckDotNet, the .NET brainfuck compiler

The brainfuck compiler creates a .NET executable assembly from brainfuck source code. This assembly can then be run using the Microsoft .NET Framework, or the Mono Runtime. 
The brainfuck compiler is written in C#. It can be compiled and used under Microsoft Windows or GNU/Linux: A Microsoft Visual Studio 8 solution file is included in the source archive.
To compile a binary, run: [mono] bfc.exe filename.bf [-o filename.exe]. Omitting the output filename will produce a program named "a.exe".
Some exceptions are sent if your code is invalid, if you don't have write access to the output binary for example. Please feel free to submit a patch if you find a bug. 
