using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace UMipss
{

	public class I : IInstruction 
	{
		//public string Mnemonic { get; }

		public int OpCode { get; set; }

        public CpuReg Rs { get; set; }

        public CpuReg Rt { get; set; }

		public int Immediate { get; set; }
	}


}
