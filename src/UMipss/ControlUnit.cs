//
// ControlUnit.cs
//
// Author:
//       tony <>
//
// Copyright (c) 2015 tony
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;


//http://fourier.eng.hmc.edu/e85_old/lectures/processor/node7.html

namespace UMipss
{

    public static class ControlUnit
    {
        static ControlUnit ()
        {
        }

        public bool RegDst { get; set; } //1 bit -
         
        public bool RegWrite { get; set; } //1 bit -

        public bool MemRead { get; set; } //1 bit - 

        public bool MemWrite { get; set; } //1 bit -

        public bool MemtoReg { get; set; } //1 bit - 

        public bool IorD { get; set; } //1 bit -

        public bool IRWrite { get; set; } //1 bit

        public bool ALUSrcA { get; set; } //1 bit

        public bool ALUSrcB { get; set; } //2 bits

        public bool ALUOp { get; set; } //2 bits

        public bool PCWrite { get; set; } //1 bit
        //---
        public bool PCSource { get; set; } //2 bits

        public bool PCWriteCond { get; set; } //1 bit


    }

}
//http://www.d.umn.edu/~gshute/mips/multicycle.xhtml
/*

Activity                    Signal      Purpose
-------------------------------------------------
PC Update                   Branch      Combined with a condition test boolean to enable loading the branch target address into the PC.
                            Jump        Enables loading the jump target address into the PC (only appears in Figure 4.24 in Patterson and Hennessey).
-------------------------------------------------
Source Operand Fetch        ALUSrc      Selects the second source operand for the ALU (rt or sign-extended immediate field in Patterson and Hennessey).
-------------------------------------------------
ALU Operation               ALUOp       Either specifies the ALU operation to be performed or specifies that the operation should be determined from the function bits.
-------------------------------------------------
Memory Access               MemRead     Enables a memory read for load instructions.
                            MemWrite    Enables a memory write for store instructions.
-------------------------------------------------
Register Write              RegWrite    Enables a write to one of the registers.
                            RegDst      Determines how the destination register is specified (rt or rd in Patterson and Hennessey).
                            MemtoReg    Determines where the value to be written comes from (ALU result or memory in Patterson and Hennessey). 


public static class ControlUnit
    {
        static ControlUnit ()
        {
        }

        public bool RegDst { get; set; }

        public bool RegWrite { get; set; }

        public bool ALUSrc { get; set; }

        public bool PCSrc { get; set; }

        public bool MemRead { get; set; }

        public bool MemWrite { get; set; }

        public bool MemtoReg { get; set; }
        //---
        public bool Branch { get; set; }

        public bool Jump { get; set; }


        public bool ALUOp { get; set; }


    }
*/