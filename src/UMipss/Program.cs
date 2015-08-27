using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


/// <summary>
/// Main class.
/// https://www.doc.ic.ac.uk/lab/secondyear/spim/
/// </summary>
namespace UMipss
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			CPU.Memory [40] = 10;
			CPU.Memory [44] = 20;
			Clock.Frequency = 1000;
			Clock.Start ();
			Pipeline.Start ();
			ALU.Exec (Assembler.Emit (InstructionMnemonic.ori, CpuReg.zero, CpuReg.t3, 40));
			ALU.Exec (Assembler.Emit (InstructionMnemonic.lw, CpuReg.t3, CpuReg.t1, 0));
			ALU.Exec (Assembler.Emit (InstructionMnemonic.lw, CpuReg.t3, CpuReg.t2, 1));
			ALU.Exec(Assembler.Emit (InstructionMnemonic.add, CpuReg.t1, CpuReg.t2, CpuReg.t0, 0));
			Console.WriteLine (CPU.t0);
			Console.ReadLine ();
		}
	}




}
