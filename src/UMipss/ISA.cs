using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace UMipss
{


	/// <summary>
	/// IS.
	/// </summary>
	public static class ISA
	{

		/// <summary>
		/// Key: Mnemonic
		/// Tuple: opcode, funct
		/// </summary>
		static Dictionary<string, Tuple<int, int, InstructionType>> instructions;

		static ISA ()
		{
			instructions = new Dictionary<string, Tuple<int, int, InstructionType>> {
				{ "add", 	new Tuple<int, int, InstructionType> (0x00, 0x20, InstructionType.R) },
				{ "addi", 	new Tuple<int, int, InstructionType> (0x08, 0x00, InstructionType.I) },
				{ "addiu", 	new Tuple<int, int, InstructionType> (0x09, 0x00, InstructionType.I) },
				{ "addu", 	new Tuple<int, int, InstructionType> (0x00, 0x21, InstructionType.R) },
				{ "and", 	new Tuple<int, int, InstructionType> (0x00, 0x24, InstructionType.R) },
				{ "andi", 	new Tuple<int, int, InstructionType> (0x0C, 0x00, InstructionType.I) },
				{ "beq", 	new Tuple<int, int, InstructionType> (0x04, 0x00, InstructionType.I) },
				{ "bne", 	new Tuple<int, int, InstructionType> (0x05, 0x00, InstructionType.I) },
				{ "div", 	new Tuple<int, int, InstructionType> (0x00, 0x1A, InstructionType.R) },
				{ "divu", 	new Tuple<int, int, InstructionType> (0x00, 0x1B, InstructionType.R) },
				{ "j", 		new Tuple<int, int, InstructionType> (0x02, 0x00, InstructionType.J) },
				{ "jal", 	new Tuple<int, int, InstructionType> (0x03, 0x00, InstructionType.J) },
				{ "jr", 	new Tuple<int, int, InstructionType> (0x00, 0x08, InstructionType.R) },
				{ "lbu", 	new Tuple<int, int, InstructionType> (0x24, 0x00, InstructionType.I) },
				{ "lhu", 	new Tuple<int, int, InstructionType> (0x25, 0x00, InstructionType.I) },
				{ "lui", 	new Tuple<int, int, InstructionType> (0x0F, 0x00, InstructionType.I) },
				{ "lw", 	new Tuple<int, int, InstructionType> (0x23, 0x00, InstructionType.I) },
				{ "mfhi", 	new Tuple<int, int, InstructionType> (0x00, 0x10, InstructionType.R) },
				{ "mflo", 	new Tuple<int, int, InstructionType> (0x00, 0x12, InstructionType.R) },
				{ "mfc0", 	new Tuple<int, int, InstructionType> (0x10, 0x00, InstructionType.R) },
				{ "mult", 	new Tuple<int, int, InstructionType> (0x00, 0x18, InstructionType.R) },
				{ "multu",	new Tuple<int, int, InstructionType> (0x00, 0x19, InstructionType.R) },
				{ "nor", 	new Tuple<int, int, InstructionType> (0x00, 0x27, InstructionType.R) },
				{ "xor", 	new Tuple<int, int, InstructionType> (0x00, 0x26, InstructionType.R) },
				{ "or", 	new Tuple<int, int, InstructionType> (0x00, 0x25, InstructionType.R) },
				{ "ori", 	new Tuple<int, int, InstructionType> (0x0D, 0x00, InstructionType.I) },
				{ "sb", 	new Tuple<int, int, InstructionType> (0x28, 0x00, InstructionType.I) },
				{ "sh", 	new Tuple<int, int, InstructionType> (0x29, 0x00, InstructionType.I) },
				{ "slt", 	new Tuple<int, int, InstructionType> (0x00, 0x2A, InstructionType.R) },
				{ "slti", 	new Tuple<int, int, InstructionType> (0x0A, 0x00, InstructionType.I) },
				{ "sltiu", 	new Tuple<int, int, InstructionType> (0x0B, 0x00, InstructionType.I) },
				{ "sltu", 	new Tuple<int, int, InstructionType> (0x00, 0x2B, InstructionType.R) },
				{ "sll", 	new Tuple<int, int, InstructionType> (0x00, 0x00, InstructionType.R) },
				{ "srl", 	new Tuple<int, int, InstructionType> (0x00, 0x02, InstructionType.R) },
				{ "sra", 	new Tuple<int, int, InstructionType> (0x00, 0x03, InstructionType.R) },
				{ "sub", 	new Tuple<int, int, InstructionType> (0x00, 0x22, InstructionType.R) },
				{ "subu", 	new Tuple<int, int, InstructionType> (0x00, 0x23, InstructionType.R) },
				{ "sw", 	new Tuple<int, int, InstructionType> (0x2B, 0x00, InstructionType.I) }

			};
		}

		public static Dictionary<string, Tuple<int, int, InstructionType>> Instructions {
			get {
				return instructions;
			}
		}
	}
	
}

/*
https://en.wikibooks.org/wiki/MIPS_Assembly/Instruction_Formats
Mnemonic 	Meaning 									Type 	Opcode 	Funct
add 		Add 										R 		0x00 	0x20
addi 		Add Immediate 								I 		0x08 	NA
addiu 		Add Unsigned Immediate 						I 		0x09 	NA
addu 		Add Unsigned 								R 		0x00 	0x21
and 		Bitwise AND 								R 		0x00 	0x24	
andi 		Bitwise AND Immediate 						I 		0x0C 	NA
beq 		Branch if Equal 							I 		0x04 	NA
bne 		Branch if Not Equal 						I 		0x05 	NA
div 		Divide 										R 		0x00 	0x1A
divu 		Unsigned Divide 							R 		0x00 	0x1B
j 			Jump to Address 							J 		0x02 	NA
jal 		Jump and Link 								J 		0x03 	NA
jr 			Jump to Address in Register 				R 		0x00 	0x08
lbu 		Load Byte Unsigned 							I 		0x24 	NA
lhu 		Load Halfword Unsigned 						I 		0x25 	NA
lui 		Load Upper Immediate 						I 		0x0F 	NA
lw 			Load Word 									I 		0x23 	NA
mfhi 		Move from HI Register 						R 		0x00 	0x10
mflo 		Move from LO Register 						R 		0x00 	0x12
mfc0 		Move from Coprocessor 0 					R 		0x10 	NA
mult 		Multiply 									R 		0x00 	0x18
multu 		Unsigned Multiply 							R 		0x00 	0x19
nor 		Bitwise NOR (NOT-OR) 						R 		0x00 	0x27
xor 		Bitwise XOR (Exclusive-OR) 					R 		0x00 	0x26
or 			Bitwise OR 									R 		0x00 	0x25
ori 		Bitwise OR Immediate 						I 		0x0D 	NA
sb 			Store Byte 									I 		0x28 	NA
sh 			Store Halfword 								I 		0x29 	NA
slt 		Set to 1 if Less Than 						R 		0x00 	0x2A
slti 		Set to 1 if Less Than Immediate 			I 		0x0A 	NA
sltiu 		Set to 1 if Less Than Unsigned Immediate 	I 		0x0B 	NA
sltu 		Set to 1 if Less Than Unsigned 				R 		0x00 	0x2B
sll 		Logical Shift Left 							R 		0x00 	0x00
srl 		Logical Shift Right (0-extended) 			R 		0x00 	0x02
sra 		Arithmetic Shift Right (sign-extended) 		R 		0x00 	0x03
sub 		Subtract 									R 		0x00 	0x22
subu 		Unsigned Subtract 							R 		0x00 	0x23
sw 			Store Word 									I 		0x2B 	NA
*/