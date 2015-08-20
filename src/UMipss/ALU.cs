using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace UMipss
{

	public static class ALU
	{
		static Dictionary<Tuple<int, int>, Action<int, int, int, int>> instructionsR;
		static Dictionary<Tuple<int, int>, Action<int, int, int>> instructionsI;
		static Dictionary<Tuple<int, int>, Action<int, int>> instructionsJ;

		static ALU ()
		{
			var isa = ISA.Instructions;
			instructionsR = new Dictionary<Tuple<int, int>, Action<int, int, int, int>> 
				{ { new Tuple<int, int> (isa ["add"].Item1, isa ["add"].Item2), 
					(rd, rs, rt, shamt) => {
						try {
							CPU.Registers [rd] = checked(CPU.Registers [rs] + CPU.Registers [rt]); 
							CPU.Cause ^= 0x800;
						} catch (OverflowException ex) {
							CPU.Cause |= 0x800;
						}
					}

				}, { new Tuple<int, int> (isa ["addu"].Item1, isa ["addu"].Item2), 
					(rd, rs, rt, shamt) => {
						uint rsu = (uint)CPU.Registers [rs];
						uint rtu = (uint)CPU.Registers [rt];
						uint rdu = rsu + rtu;
						CPU.Registers [rd] = (int)rdu;
					}

				}, { new Tuple<int, int> (isa ["and"].Item1, isa ["and"].Item2), 
					(rd, rs, rt, shamt) => CPU.Registers [rd] = CPU.Registers [rs] & CPU.Registers [rt]
						
				}, { new Tuple<int, int> (isa ["div"].Item1, isa ["div"].Item2), 
					(rd, rs, rt, shamt) => {
						CPU.LO = CPU.Registers [rs] / CPU.Registers [rt]; 
						CPU.HI = CPU.Registers [rs] % CPU.Registers [rt]; 
					}

				}, { new Tuple<int, int> (isa ["divu"].Item1, isa ["divu"].Item2), 
					(rd, rs, rt, shamt) => {
						CPU.LO = CPU.Registers [rs] / CPU.Registers [rt]; 
						CPU.HI = CPU.Registers [rs] % CPU.Registers [rt]; 
					}

				}, { new Tuple<int, int> (isa ["jr"].Item1, isa ["jr"].Item2), 
					(rd, rs, rt, shamt) => CPU.PC = CPU.Registers [rs]
						
				}, { new Tuple<int, int> (isa ["mfhi"].Item1, isa ["mfhi"].Item2), 
					(rd, rs, rt, shamt) => CPU.Registers [rd] = CPU.HI
						
				}, { new Tuple<int, int> (isa ["mflo"].Item1, isa ["mflo"].Item2), 
					(rd, rs, rt, shamt) => CPU.Registers [rd] = CPU.LO
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

		public static Dictionary<Tuple<int, int>, Action<int, int, int, int>> InstructionsR {
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

		public static void Exec (R instruction)
		{
//			Func<int, int, int> op;
//			instructionsR.TryGetValue(instruction.
//			CPU.Registers [instruction.Rd] = 
//				Operation (CPU.Registers [i nstruction.Rs], CPU.Registers [instruction.Rt]);
		}

	}
	
}
