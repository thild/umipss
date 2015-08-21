using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace UMipss
{

    public enum Instruction
    {
        add,
        addi,
        addiu,
        addu,
        and,
        andi,
        beq,
        bne,
        div,
        divu,
        j,
        jal,
        jr,
        lbu,
        lhu,
        lui,
        lw,
        mfhi,
        mflo,
        mfc0,
        mult,
        multu,
        nor,
        xor,
        or,
        ori,
        sb,
        sh,
        slt,
        slti,
        sltiu,
        sltu,
        sll,
        srl,
        sra,
        sub,
        subu,
        sw
    }

    /// <summary>
    /// IS.
    /// </summary>
    public static class ISA
    {

        private static InstructionMetadata _add = new InstructionMetadata (Instruction.add, 0x00, 0x20, InstructionFormat.R);
        private static InstructionMetadata _addi = new InstructionMetadata (Instruction.addi, 0x08, 0x00, InstructionFormat.I);
        private static InstructionMetadata _addiu = new InstructionMetadata (Instruction.addiu, 0x09, 0x00, InstructionFormat.I);
        private static InstructionMetadata _addu = new InstructionMetadata (Instruction.addu, 0x00, 0x21, InstructionFormat.R);
        private static InstructionMetadata _and = new InstructionMetadata (Instruction.and, 0x00, 0x24, InstructionFormat.R);
        private static InstructionMetadata _andi = new InstructionMetadata (Instruction.andi, 0x0C, 0x00, InstructionFormat.I);
        private static InstructionMetadata _beq = new InstructionMetadata (Instruction.beq, 0x04, 0x00, InstructionFormat.I);
        private static InstructionMetadata _bne = new InstructionMetadata (Instruction.bne, 0x05, 0x00, InstructionFormat.I);
        private static InstructionMetadata _div = new InstructionMetadata (Instruction.div, 0x00, 0x1A, InstructionFormat.R);
        private static InstructionMetadata _divu = new InstructionMetadata (Instruction.divu, 0x00, 0x1B, InstructionFormat.R);
        private static InstructionMetadata _j = new InstructionMetadata (Instruction.j, 0x02, 0x00, InstructionFormat.J);
        private static InstructionMetadata _jal = new InstructionMetadata (Instruction.jal, 0x03, 0x00, InstructionFormat.J);
        private static InstructionMetadata _jr = new InstructionMetadata (Instruction.jr, 0x00, 0x08, InstructionFormat.R);
        private static InstructionMetadata _lbu = new InstructionMetadata (Instruction.lbu, 0x24, 0x00, InstructionFormat.I);
        private static InstructionMetadata _lhu = new InstructionMetadata (Instruction.lhu, 0x25, 0x00, InstructionFormat.I);
        private static InstructionMetadata _lui = new InstructionMetadata (Instruction.lui, 0x0F, 0x00, InstructionFormat.I);
        private static InstructionMetadata _lw = new InstructionMetadata (Instruction.lw, 0x23, 0x00, InstructionFormat.I);
        private static InstructionMetadata _mfhi = new InstructionMetadata (Instruction.mfhi, 0x00, 0x10, InstructionFormat.R);
        private static InstructionMetadata _mflo = new InstructionMetadata (Instruction.mflo, 0x00, 0x12, InstructionFormat.R);
        private static InstructionMetadata _mfc0 = new InstructionMetadata (Instruction.mfc0, 0x10, 0x00, InstructionFormat.R);
        private static InstructionMetadata _mult = new InstructionMetadata (Instruction.mult, 0x00, 0x18, InstructionFormat.R);
        private static InstructionMetadata _multu = new InstructionMetadata (Instruction.multu, 0x00, 0x19, InstructionFormat.R);
        private static InstructionMetadata _nor = new InstructionMetadata (Instruction.nor, 0x00, 0x27, InstructionFormat.R);
        private static InstructionMetadata _xor = new InstructionMetadata (Instruction.xor, 0x00, 0x26, InstructionFormat.R);
        private static InstructionMetadata _or = new InstructionMetadata (Instruction.or, 0x00, 0x25, InstructionFormat.R);
        private static InstructionMetadata _ori = new InstructionMetadata (Instruction.ori, 0x0D, 0x00, InstructionFormat.I);
        private static InstructionMetadata _sb = new InstructionMetadata (Instruction.sb, 0x28, 0x00, InstructionFormat.I);
        private static InstructionMetadata _sh = new InstructionMetadata (Instruction.sh, 0x29, 0x00, InstructionFormat.I);
        private static InstructionMetadata _slt = new InstructionMetadata (Instruction.slt, 0x00, 0x2A, InstructionFormat.R);
        private static InstructionMetadata _slti = new InstructionMetadata (Instruction.slti, 0x0A, 0x00, InstructionFormat.I);
        private static InstructionMetadata _sltiu = new InstructionMetadata (Instruction.sltiu, 0x0B, 0x00, InstructionFormat.I);
        private static InstructionMetadata _sltu = new InstructionMetadata (Instruction.sltu, 0x00, 0x2B, InstructionFormat.R);
        private static InstructionMetadata _sll = new InstructionMetadata (Instruction.sll, 0x00, 0x00, InstructionFormat.R);
        private static InstructionMetadata _srl = new InstructionMetadata (Instruction.srl, 0x00, 0x02, InstructionFormat.R);
        private static InstructionMetadata _sra = new InstructionMetadata (Instruction.sra, 0x00, 0x03, InstructionFormat.R);
        private static InstructionMetadata _sub = new InstructionMetadata (Instruction.sub, 0x00, 0x22, InstructionFormat.R);
        private static InstructionMetadata _subu = new InstructionMetadata (Instruction.subu, 0x00, 0x23, InstructionFormat.R);
        private static InstructionMetadata _sw = new InstructionMetadata (Instruction.sw, 0x2B, 0x00, InstructionFormat.I);

        static ISA ()
        {
           

        }

        public static InstructionMetadata add  { get { return _add; } }

        public static InstructionMetadata addi  { get { return _addi; } }

        public static InstructionMetadata addiu  { get { return _addiu; } }

        public static InstructionMetadata addu  { get { return _addu; } }

        public static InstructionMetadata and  { get { return _and; } }

        public static InstructionMetadata andi  { get { return _andi; } }

        public static InstructionMetadata beq  { get { return _beq; } }

        public static InstructionMetadata bne  { get { return _bne; } }

        public static InstructionMetadata div  { get { return _div; } }

        public static InstructionMetadata divu  { get { return _divu; } }

        public static InstructionMetadata j  { get { return _j; } }

        public static InstructionMetadata jal  { get { return _jal; } }

        public static InstructionMetadata jr  { get { return _jr; } }

        public static InstructionMetadata lbu  { get { return _lbu; } }

        public static InstructionMetadata lhu  { get { return _lhu; } }

        public static InstructionMetadata lui  { get { return _lui; } }

        public static InstructionMetadata lw  { get { return _lw; } }

        public static InstructionMetadata mfhi  { get { return _mfhi; } }

        public static InstructionMetadata mflo  { get { return _mflo; } }

        public static InstructionMetadata mfc0  { get { return _mfc0; } }

        public static InstructionMetadata mult  { get { return _mult; } }

        public static InstructionMetadata multu  { get { return _multu; } }

        public static InstructionMetadata nor  { get { return _nor; } }

        public static InstructionMetadata xor  { get { return _xor; } }

        public static InstructionMetadata or  { get { return _or; } }

        public static InstructionMetadata ori  { get { return _ori; } }

        public static InstructionMetadata sb  { get { return _sb; } }

        public static InstructionMetadata sh  { get { return _sh; } }

        public static InstructionMetadata slt  { get { return _slt; } }

        public static InstructionMetadata slti  { get { return _slti; } }

        public static InstructionMetadata sltiu  { get { return _sltiu; } }

        public static InstructionMetadata sltu  { get { return _sltu; } }

        public static InstructionMetadata sll  { get { return _sll; } }

        public static InstructionMetadata srl  { get { return _srl; } }

        public static InstructionMetadata sra  { get { return _sra; } }

        public static InstructionMetadata sub  { get { return _sub; } }

        public static InstructionMetadata subu  { get { return _subu; } }

        public static InstructionMetadata sw  { get { return _sw; } }

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