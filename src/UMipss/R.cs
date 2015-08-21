using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace UMipss
{

	public interface IInstruction
	{
		//string Mnemonic { get; }

		int OpCode { get; set; }
	}

	public class R : IInstruction
	{
        public R ()
        {
            
        }

        public R (int opcode, CpuReg rs, CpuReg rt, CpuReg rd, int shamt, int funct)
        {
            OpCode = opcode;
            Rs = rs;
            Rt = rt;
            Rd = rd;
            Shamt = shamt;
            Funct = funct;
        }


		public int OpCode { get; set; }

        public CpuReg Rs { get; set; }

        public CpuReg Rt { get; set; }

        public CpuReg Rd { get; set; }

		public int Shamt { get; set; }

		public int Funct { get; set; }

	}
	
}
