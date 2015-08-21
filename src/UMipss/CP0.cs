using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;

//http://www.eecg.toronto.edu/~yuan/teaching/ece344/mips.html

namespace UMipss
{


    public static class CP0
	{

		/// <summary>
		/// The cp0.
		/// http://en.wikichip.org/wiki/Coprocessor_0_-_MIPS
		/// https://books.google.com.br/books?id=-DG18Nf7jLcC&pg=PA344&lpg=PA344&dq=mips+%22coprocessor+0%22+cause&source=bl&ots=QgsJpEnFLP&sig=2GNpSTWsgcHT_zRxT8s8U0gawok&hl=pt-BR&sa=X&ved=0CEoQ6AEwBjgKahUKEwiAys_vgrbHAhXLhpAKHdlNB3A#v=onepage&q=mips%20%22coprocessor%200%22%20cause&f=false
		/// </summary>

		public static int Index { get; set; }

		public static int Random { get; set; }

		public static int EntryLo0 { get; set; }

		public static int EntryLo1 { get; set; }

		public static int Context { get; set; }

		public static int PageMask { get; set; }

		public static int Wired { get; set; }

		public static int HWREna { get; set; }

		public static int BadVAddr { get; set; }

		public static int Count { get; set; }

		public static int EntryHi { get; set; }

		public static int Compare { get; set; }

		public static int Status { get; set; }

		public static int Cause { get; set; }

		public static int EPC { get; set; }

		public static int PRId { get; set; }

		public static int Config { get; set; }

		public static int LLAddr { get; set; }

		public static int WatchLo { get; set; }

		public static int WatchHi { get; set; }

		public static int Debug { get; set; }

		public static int DEPC { get; set; }

		public static int PerfCnt { get; set; }

		public static int ErrCtl { get; set; }

		public static int CacheErr { get; set; }

		public static int TagLo { get; set; }

		public static int TagHi { get; set; }

		public static int ErrorEPC { get; set; }

		public static int DESAVE { get; set; }
		
        public static int GetRegister(int r)
        {
            return GetRegister ((Cp0Reg)r);
        }

        public static void SetRegister(int r, int value)
        {
            SetRegister ((Cp0Reg)r, value);
        }

        public static int GetRegister(Cp0Reg r)
        {
            var propertyInfo = GetPropertyInfo (r); 
            return (int) propertyInfo.GetValue(null, null);
        }

        public static void SetRegister(Cp0Reg r, int value)
        {
            var propertyInfo = GetPropertyInfo (r); 
            propertyInfo.SetValue(null, value);
        }

        static PropertyInfo GetPropertyInfo (Cp0Reg r)
        {
            var propertyInfo = typeof(CP0).GetProperty (r.ToString (), BindingFlags.Public | BindingFlags.Static);
            return propertyInfo;
        }
	}
}
