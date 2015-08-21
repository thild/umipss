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
            CP0.SetRegister (Cp0Reg.Cause, 10);
            Console.WriteLine (CP0.GetRegister (Cp0Reg.Cause));
            CP0.SetRegister (10, 20);
            Console.WriteLine (CP0.GetRegister (10));
			Console.WriteLine ("Hello World!");
            CPU.SetRegister (CpuReg.t1, 10);
            CPU.SetRegister (CpuReg.t2, 20);
////			ALU.RInstructions.Add (
////				new R { 
////					OpCode = 0,
////					Rd = 8,
////					Rs = 9,
////					Rt = 10,
////					Funct = 31,
////					//Operation = (a, b) => a + b
////				});
            /// 
            ALU.Exec(new R(0, CpuReg.t1, CpuReg.t2, CpuReg.t0, 0, 0x20));
            Console.WriteLine (CPU.GetRegister (CpuReg.t0));
			Console.ReadLine ();
		}
	}




}
