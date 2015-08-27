using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Linq;

namespace UMipss
{

	public static class ALU
	{
		static Dictionary<InstructionMnemonic, Action<CpuReg, CpuReg, CpuReg, int>> instructionsR;
		static Dictionary<InstructionMnemonic, Action<CpuReg, CpuReg, int>> instructionsI;
		static Dictionary<InstructionMnemonic, Action<int>> instructionsJ;

		static ALU ()
		{
			instructionsR = new Dictionary<InstructionMnemonic, Action<CpuReg, CpuReg, CpuReg, int>> { { InstructionMnemonic.add, 
					(rd, rs, rt, shamt) => {
						try {
							CPU.SetRegister (rd, checked(CPU.GetRegister (rs) + CPU.GetRegister (rt))); 
							CP0.Cause ^= 0x800;
						} catch (OverflowException) {
							CP0.Cause |= 0x800;
						}
					}

				}, { InstructionMnemonic.addu, 
					(rd, rs, rt, shamt) => {
						uint rsu = (uint)CPU.GetRegister (rs);
						uint rtu = (uint)CPU.GetRegister (rt);
						uint rdu = rsu + rtu;
						CPU.SetRegister (rd, (int)rdu);
					}

				}, { InstructionMnemonic.and, 
					(rd, rs, rt, shamt) => CPU.SetRegister (rd, CPU.GetRegister (rs) & CPU.GetRegister (rt))
						
				}, { InstructionMnemonic.div, 
					(rd, rs, rt, shamt) => {
						CPU.LO = CPU.GetRegister (rs) / CPU.GetRegister (rt); 
						CPU.HI = CPU.GetRegister (rs) % CPU.GetRegister (rt); 
					}

				}, { InstructionMnemonic.divu, 
					(rd, rs, rt, shamt) => {
						CPU.LO = CPU.GetRegister (rs) / CPU.GetRegister (rt); 
						CPU.HI = CPU.GetRegister (rs) % CPU.GetRegister (rt); 
					}

				}, { InstructionMnemonic.jr, 
					(rd, rs, rt, shamt) => CPU.PC = CPU.GetRegister (rs)
						
				}, { InstructionMnemonic.mfhi, 
					(rd, rs, rt, shamt) => CPU.SetRegister (rd, CPU.HI)
						
				}, { InstructionMnemonic.mflo, 
					(rd, rs, rt, shamt) => CPU.SetRegister (rd, CPU.LO)
				}, 

			};

			instructionsI = new Dictionary<InstructionMnemonic, Action<CpuReg, CpuReg, int>> { { 
					InstructionMnemonic.lw, 
					(rs, rt, immediate) => {
						var mem = CPU.DataMemory[CPU.GetRegister (rs) + immediate * 4];
						CPU.SetRegister (rt, mem);
					}
				},
				{ 
					InstructionMnemonic.ori, 
					(rs, rt, immediate) => {
						CPU.SetRegister (rt, CPU.GetRegister (rs) | immediate);
					}
				},
			};
		}

		//        public static Dictionary<InstructionMnemonic, Action<CpuReg, CpuReg, CpuReg, int>> InstructionsR {
		//            get {
		//                return instructionsR;
		//            }
		//        }
		//
		//		public static Dictionary<InstructionMnemonic, Action<CpuReg, CpuReg, int>> InstructionsI {
		//            get {
		//                return instructionsI;
		//            }
		//        }
		//
		//		public static Dictionary<InstructionMnemonic, Action< int>> InstructionsJ {
		//            get {
		//                return instructionsJ;
		//            }
		//        }

		public static void Exec (InstructionR i)
		{
			instructionsR [i.Instruction] (i.Rd, i.Rs, i.Rt, i.Shamt);
		}

		public static void Exec (InstructionI i)
		{
			instructionsI [i.Instruction] (i.Rs, i.Rt, i.Immediate);
		}

		public static void Exec (InstructionJ i)
		{
			instructionsJ [i.Instruction] (i.Address);
		}

	}
	
}
