using System;

namespace LibVpxSharp.Samples
{
	class MainClass
	{
		public static void Main (string [] args)
		{
			var e = new VpxEncoder (VpxCodec.VP8, null, VpxCodecFlags.None);
			var buf = e.GetGlobalHeaders ();
			Console.WriteLine (buf.Size);
		}
	}
}
