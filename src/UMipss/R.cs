using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace UMipss
{

	public interface IInstruction
	{
		//string Mnemonic { get; }

		int OpCode { get; set; }
	}

	public class R : IInstruction
	{
		//public string Mnemonic { get; }

		public int OpCode { get; set; }

		public int Rs { get; set; }

		public int Rt { get; set; }

		public int Rd { get; set; }

		public int Shamt { get; set; }

		public int Funct { get; set; }


	}
	
}
