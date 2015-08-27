//
// Clock.cs
//
// Author:
//       Tony Alexander Hild <tony_hild@yahoo.com>
//
// Copyright (c) 2015 Tony Alexander Hild
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
using System.Timers;

namespace UMipss
{
	public static class Clock
	{	
		static Timer _clock;

		public static event EventHandler Tick;

		static	Clock() {
			_clock = new System.Timers.Timer();
			_clock.Enabled = false;
			_clock.Elapsed += (sender, e) => {
				OnTick ();
			};
		}

		public static bool Enabled { get; private set; }

		public static void Start() {
			Enabled = true;
			_clock.Start ();
		}

		public static void Stop() {
			Enabled = false;
			_clock.Stop ();
		}

		static int frequency;
		/// <summary>
		/// Gets or sets the frequency in miliseconds.
		/// </summary>
		/// <value>The frequency.</value>
		public static int Frequency {
			get {
				return frequency;
			}
			set {
				frequency = value;
				_clock.Interval = frequency;
			}
		}

		static void OnTick ()
		{
			Tick.Invoke (null, new EventArgs ());
		}
	}
}

