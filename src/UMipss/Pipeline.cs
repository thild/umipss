using System;

namespace UMipss
{

	public static class Pipeline
	{
		static	Pipeline() {
			Clock.Tick += (sender, e) => {
			};
		}

		public static void Start() {
			
		}

		public static IInstruction If ()
		{
			throw new NotImplementedException ();
		}

		public static IInstruction Id ()
		{
			throw new NotImplementedException ();

		}

		public static IInstruction Ex ()
		{
			throw new NotImplementedException ();

		}

		public static IInstruction Mem ()
		{
			throw new NotImplementedException ();

		}

		public static IInstruction Wb ()
		{
			throw new NotImplementedException ();

		}

		//if/id, id/ex, ex/mem, mem/wb
	}
}
