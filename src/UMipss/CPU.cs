using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

//http://www.eecg.toronto.edu/~yuan/teaching/ece344/mips.html
using System.Reflection;

namespace UMipss
{

    public static class CPU
    {
        public static int[] DataMemory = new int[100000];
		public static int[] InstructionMemory = new int[100000];

        /// <summary>
        /// Gets or sets the P.
        /// Program counter.
        /// </summary>
        /// <value>The P.</value>
        public static int PC { get; set; }

        /// <summary>
        /// Gets or sets the H.
        /// High-order word of 64-bit multiply result, or remainder of divide result.
        /// </summary>
        /// <value>The H.</value>
        public static int HI { get; set; }

        /// <summary>
        /// Gets or sets the L.
        /// Low-order word of 64-bit multiply result, or quotient of divide result.
        /// </summary>
        /// <value>The L.</value>
        public static int LO { get; set; }

        #region Register file

        public static int zero { get; set; }

        public static int at { get; set; }

        public static int v0 { get; set; }

        public static int v1 { get; set; }

        public static int a0 { get; set; }

        public static int a1 { get; set; }

        public static int a2 { get; set; }

        public static int a3 { get; set; }

        public static int t0 { get; set; }

        public static int t1 { get; set; }

        public static int t2 { get; set; }

        public static int t3 { get; set; }

        public static int t4 { get; set; }

        public static int t5 { get; set; }

        public static int t6 { get; set; }

        public static int t7 { get; set; }

        public static int s0 { get; set; }

        public static int s1 { get; set; }

        public static int s2 { get; set; }

        public static int s3 { get; set; }

        public static int s4 { get; set; }

        public static int s5 { get; set; }

        public static int s6 { get; set; }

        public static int s7 { get; set; }

        public static int t8 { get; set; }

        public static int t9 { get; set; }

        public static int k0 { get; set; }

        public static int k1 { get; set; }

        public static int gp { get; set; }

        public static int sp { get; set; }

        public static int fp { get; set; }

        public static int ra { get; set; }

        #endregion

        public static int GetRegister (int r)
        {
            return GetRegister ((CpuReg)r);
        }

        public static void SetRegister (int r, int value)
        {
            SetRegister ((CpuReg)r, value);
        }

        public static int GetRegister (CpuReg r)
        {
            var propertyInfo = GetPropertyInfo (r); 
            return (int)propertyInfo.GetValue (null, null);
        }

        public static void SetRegister (CpuReg r, int value)
        {
            var propertyInfo = GetPropertyInfo (r); 
            propertyInfo.SetValue (null, value);
        }

        static PropertyInfo GetPropertyInfo (CpuReg r)
        {
            var propertyInfo = typeof(CPU).GetProperty (r.ToString (), BindingFlags.Public | BindingFlags.Static);
            return propertyInfo;
        }

    }
}
