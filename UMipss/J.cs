using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace UMipss
{

	public class J : IInstruction 
	{
		//public string Mnemonic { get; }

		public int OpCode { get; set; }

		public int Address { get; set; }
	}


}
