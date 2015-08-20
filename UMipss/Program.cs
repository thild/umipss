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
			Console.WriteLine ("Hello World!");
			CPU.SetRegister ("$t1", 10);
			CPU.SetRegister ("$t2", 20);
//			ALU.RInstructions.Add (
//				new R { 
//					OpCode = 0,
//					Rd = 8,
//					Rs = 9,
//					Rt = 10,
//					Funct = 31,
//					//Operation = (a, b) => a + b
//				});
			//ALU.RInstructions [0].Exec ();
			Console.WriteLine (CPU.GetRegister ("$t0"));
			Console.ReadLine ();
		}
	}




}
