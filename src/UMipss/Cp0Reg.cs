using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

//http://www.eecg.toronto.edu/~yuan/teaching/ece344/mips.html
using System.Reflection;

namespace UMipss
{

	public enum Cp0Reg
	{
		Index = 0,
		Random = 1,
		EntryLo0 = 2,
		EntryLo1 = 3,
		Context = 4,
		PageMask = 5,
		Wired = 6,
		HWREna = 7,
		BadVAddr = 8,
		Count = 9,
		EntryHi = 10,
		Compare = 11,
		Status = 12,
		Cause = 13,
		EPC = 14,
		PRId = 15,
		Config = 16,
		LLAddr = 17,
		WatchLo = 18,
		WatchHi = 19,
		Debug = 23,
		DEPC = 24,
		PerfCnt = 25,
		ErrCtl = 26,
		CacheErr = 27,
		TagLo = 28,
		TagHi = 29,
		ErrorEPC = 30,
		DESAVE = 31
	}
    
}
