using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Linq;

namespace UMipss
{

    public static class ALU
    {
        static Dictionary<Instruction, Action<CpuReg, CpuReg, CpuReg, int>> instructionsR;
        static Dictionary<Tuple<int, int>, Action<int, int, int>> instructionsI;
        static Dictionary<Tuple<int, int>, Action<int, int>> instructionsJ;

        static ALU ()
        {
            instructionsR = new Dictionary<Instruction, Action<CpuReg, CpuReg, CpuReg, int>> { 
                { Instruction.add, 
                    (rd, rs, rt, shamt) => {
                        try {
                            CPU.SetRegister (rd, checked(CPU.GetRegister (rs) + CPU.GetRegister (rt))); 
                            CP0.Cause ^= 0x800;
                        } catch (OverflowException) {
                            CP0.Cause |= 0x800;
                        }
                    }

                }, { Instruction.addu, 
                    (rd, rs, rt, shamt) => {
                        uint rsu = (uint)CPU.GetRegister (rs);
                        uint rtu = (uint)CPU.GetRegister (rt);
                        uint rdu = rsu + rtu;
                        CPU.SetRegister (rd, (int)rdu);
                    }

                }, { Instruction.and, 
                    (rd, rs, rt, shamt) => CPU.SetRegister (rd, CPU.GetRegister (rs) & CPU.GetRegister (rt))
						
                }, { Instruction.div, 
                    (rd, rs, rt, shamt) => {
                        CPU.LO = CPU.GetRegister (rs) / CPU.GetRegister (rt); 
                        CPU.HI = CPU.GetRegister (rs) % CPU.GetRegister (rt); 
                    }

                }, { Instruction.divu, 
                    (rd, rs, rt, shamt) => {
                        CPU.LO = CPU.GetRegister (rs) / CPU.GetRegister (rt); 
                        CPU.HI = CPU.GetRegister (rs) % CPU.GetRegister (rt); 
                    }

                }, { Instruction.jr, 
                    (rd, rs, rt, shamt) => CPU.PC = CPU.GetRegister (rs)
						
                }, { Instruction.mfhi, 
                    (rd, rs, rt, shamt) => CPU.SetRegister (rd, CPU.HI)
						
                }, { Instruction.mflo, 
                    (rd, rs, rt, shamt) => CPU.SetRegister (rd, CPU.LO)
                },
            };
            /*
add 
addu 
and 
div 
divu 
jr 
mfhi 
mflo 
mfc0 
mult 
multu 
nor 
xor 
or 
slt 
sltu 
sll 
srl 
sra 
sub 
subu 

			 */
        }

        public static Dictionary<Instruction, Action<CpuReg, CpuReg, CpuReg, int>> InstructionsR {
            get {
                return instructionsR;
            }
        }

        public static Dictionary<Tuple<int, int>, Action<int, int, int>> InstructionsI {
            get {
                return instructionsI;
            }
        }

        public static Dictionary<Tuple<int, int>, Action<int, int>> InstructionsJ {
            get {
                return instructionsJ;
            }
        }

        public static void Exec (R i)
        {
            //instructionsR [im] (i.Rd, i.Rs, i.Rt, i.Shamt);
        }

    }
	
}
