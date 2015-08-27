using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace UMipss
{

	public interface IInstruction
	{
		InstructionMnemonic Instruction { get; set; }

		int OpCode { get; set; }
	}
	
}
