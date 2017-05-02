using NUnit.Framework;
using System;

namespace LibVpxSharp.Tests
{
	[TestFixture]
	public class VpxEncoderTest
	{
		[Test]
		public void SimpleTests ()
		{
			var e = new VpxEncoder (VpxCodec.VP8, null, VpxCodecFlags.None);
			var buf = e.GetGlobalHeaders ();
			Assert.AreEqual (IntPtr.Zero, buf.Buffer, "there should be no global headers.");
		}
	}
}
