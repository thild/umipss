using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace UMipss
{

	public class InstructionI : IInstruction 
	{
		public InstructionI ()
		{
			
		}

		public InstructionI (int opcode, CpuReg rs, CpuReg rt, int immediate)
		{
			OpCode = opcode;
			Rs = rs;
			Rt = rt;
			Immediate = immediate;
		}

		public InstructionMnemonic Instruction { get; set; }

		public int OpCode { get; set; }

        public CpuReg Rs { get; set; }

        public CpuReg Rt { get; set; }

		public int Immediate { get; set; }
	}


}
