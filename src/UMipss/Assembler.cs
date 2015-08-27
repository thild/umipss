using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace UMipss
{

	public static class Assembler
	{
		static Assembler ()
		{
		}

		public static InstructionR Emit (InstructionMnemonic mnemonic, 
										   CpuReg rs, CpuReg rt, CpuReg rd, 
										   int shamt)
		{
			var instruction = ISA.GetInstruction (mnemonic);
            if (instruction.Format != InstructionFormat.R) {
				throw new Exception ("Wrong instruction type.");
			}
			return new InstructionR { 
				Instruction = instruction.Instruction,
                OpCode = instruction.OpCode,
				Rs = rs,
				Rt = rt,
				Rd = rd,
				Shamt = shamt,
                Funct = instruction.Function
			};
		}

		public static InstructionI Emit (InstructionMnemonic mnemonic, 
										   CpuReg rs, CpuReg rt, 
			                               int immediate)
		{
			var instruction = ISA.GetInstruction (mnemonic);
            if (instruction.Format != InstructionFormat.I) {
				throw new Exception ("Wrong instruction type.");
			}
			return new InstructionI { 
				Instruction = instruction.Instruction,
                OpCode = instruction.OpCode,
				Rs = rs,
				Rt = rt,
				Immediate = immediate
			};
		}

		public static InstructionJ Emit (InstructionMnemonic mnemonic, int address)
		{
			var instruction = ISA.GetInstruction (mnemonic);
            if (instruction.Format != InstructionFormat.J) {
				throw new Exception ("Wrong instruction type.");
			}
			return new InstructionJ { 
				Instruction = instruction.Instruction,
                OpCode = instruction.OpCode,
				Address = address
			};
		}
	}
}

