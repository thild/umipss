using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

//http://www.eecg.toronto.edu/~yuan/teaching/ece344/mips.html

namespace UMipss
{

	public static class CPU
	{
		
		static int[] gpregs = new int[32];


		/// <summary>
		/// Gets or sets the P.
		/// Program counter.
		/// </summary>
		/// <value>The P.</value>
		public static int PC { get; set; }

		/// <summary>
		/// Gets or sets the H.
		/// High-order word of 64-bit multiply result, or remainder of divide result.
		/// </summary>
		/// <value>The H.</value>
		public static int HI { get; set; }

		/// <summary>
		/// Gets or sets the L.
		/// Low-order word of 64-bit multiply result, or quotient of divide result.
		/// </summary>
		/// <value>The L.</value>
		public static int LO { get; set; }

		/// <summary>
		/// Gets or sets the cause.
		/// c0_cause
		/// </summary>
		/// <value>The cause.</value>
		public static int Cause { get; set; }

		public static int[] Registers {
			get { return gpregs; }
		}

		public static int GetRegister (int i)
		{
			return gpregs [i];
		}

		public static void SetRegister (int i, int value)
		{
			gpregs [i] = value;
		}

		public static void SetRegister (string name, int value)
		{
			gpregs [Assembler.GetRegisterPosition (name)] = value;
		}

		public static int GetRegister (string name)
		{

			return GetRegister (Assembler.GetRegisterPosition (name));
		}


		public static Func<int, int, int> Operation { get; set; }

		public static void Exec (R instruction)
		{
			CPU.Registers [instruction.Rd] = 
				Operation (CPU.Registers [instruction.Rs], CPU.Registers [instruction.Rt]);
		}

		public static void Exec (I instruction)
		{
			CPU.Registers [instruction.Rs] = 
				Operation (CPU.Registers [instruction.Rt], CPU.Registers [instruction.Immediate]);
		}

	}
}
