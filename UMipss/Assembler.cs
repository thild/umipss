using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace UMipss
{

	public static class Assembler
	{
		static Dictionary<string, int> registersMap = new Dictionary<string, int> () {
			{ "zero", 0 }, { "$at", 1 }, { "$v0", 2 }, { "$v1", 3 }, 
			{ "$a0", 4 }, { "$a1", 5 }, { "$a2", 6 }, { "$a3", 7 },
			{ "$t0", 8 }, { "$t1", 9 }, { "$t2", 10 }, { "$t3", 11 },
			{ "$t4", 12 }, { "$t5", 13 }, { "$t6", 14 }, { "$t7", 15 },
			{ "$s0", 16 }, { "$s1", 17 }, { "$s2", 18 }, { "$s3", 19 },
			{ "$s4", 20 }, { "$s5", 21 }, { "$s6", 22 }, { "$s7", 23 },
			{ "$t8", 24 }, { "$t9", 25 }, { "$k0", 26 }, { "$k1", 27 },
			{ "$gp", 28 }, { "$sp", 29 }, { "$fp", 30 }, { "$ra", 31 }
		};

		static Assembler ()
		{
		}

		public static int GetRegisterPosition (RegisterFileType register)
		{	
			return (int)register;
		}

		public static int GetRegisterPosition (string name)
		{
			var regex = new Regex ("\\$r[0-9]{1,2}");

			int i;

			if (regex.Match (name).Success) {
				if (!int.TryParse (name.Substring (2), out i)) {
					throw new KeyNotFoundException ("Register not found.");
				}
				return i;
			}

			if (!registersMap.TryGetValue (name, out i)) {
				throw new KeyNotFoundException ("Register not found.");
			}
			return i;
		}

		public static IInstruction EmitR (string mnemonic, int rs, int rt, int rd, int shamt)
		{
			Tuple<int, int, InstructionType> i;
			if (!ISA.Instructions.TryGetValue (mnemonic, out i)) {
				throw new KeyNotFoundException ("Register not found.");
			}
			if (i.Item3 != InstructionType.R) {
				throw new Exception ("Wrong instruction type.");
			}
			return new R { 
				OpCode = i.Item1,
				Rs = rs,
				Rt = rt,
				Rd = rd,
				Shamt = shamt,
				Funct = i.Item2
			};
		}

		public static IInstruction EmitI (string mnemonic, int rs, int rt, int immediate)
		{
			Tuple<int, int, InstructionType> i;
			if (!ISA.Instructions.TryGetValue (mnemonic, out i)) {
				throw new KeyNotFoundException ("Register not found.");
			}
			if (i.Item3 != InstructionType.I) {
				throw new Exception ("Wrong instruction type.");
			}
			return new I { 
				OpCode = i.Item1,
				Rs = rs,
				Rt = rt,
				Immediate = immediate
			};
		}

		public static IInstruction EmitJ (string mnemonic, int address)
		{
			Tuple<int, int, InstructionType> i;
			if (!ISA.Instructions.TryGetValue (mnemonic, out i)) {
				throw new KeyNotFoundException ("Register not found.");
			}
			if (i.Item3 != InstructionType.J) {
				throw new Exception ("Wrong instruction type.");
			}
			return new J { 
				OpCode = i.Item1,
				Address = address
			};
		}
	}
}

