using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace UMipss
{

	public class InstructionJ : IInstruction 
	{

		public InstructionJ ()
		{

		}

		public InstructionJ (int opcode, int address)
		{
			OpCode = opcode;
			Address = address;
		}

		public InstructionMnemonic Instruction { get; set; }

		public int OpCode { get; set; }

		public int Address { get; set; }
	}


}
