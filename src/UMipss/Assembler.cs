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

        public static IInstruction EmitR (InstructionMetadata instruction, CpuReg rs, CpuReg rt, CpuReg rd, int shamt)
		{
            if (instruction.Format != InstructionFormat.R) {
				throw new Exception ("Wrong instruction type.");
			}
			return new R { 
                OpCode = instruction.OpCode,
				Rs = rs,
				Rt = rt,
				Rd = rd,
				Shamt = shamt,
                Funct = instruction.Function
			};
		}

        public static IInstruction EmitI (InstructionMetadata instruction, CpuReg rs, CpuReg rt, int immediate)
		{
            if (instruction.Format != InstructionFormat.I) {
				throw new Exception ("Wrong instruction type.");
			}
			return new I { 
                OpCode = instruction.OpCode,
				Rs = rs,
				Rt = rt,
				Immediate = immediate
			};
		}

        public static IInstruction EmitJ (InstructionMetadata instruction, int address)
		{
            if (instruction.Format != InstructionFormat.J) {
				throw new Exception ("Wrong instruction type.");
			}
			return new J { 
                OpCode = instruction.OpCode,
				Address = address
			};
		}
	}
}

