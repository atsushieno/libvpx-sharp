using NUnit.Framework;
using System;
namespace LibVpxSharp.Tests
{
	[TestFixture]
	public class VpxCodecTest
	{
		[Test]
		public void StaticMembers ()
		{
			var c = VpxCodec.VP8;
			Assert.AreEqual("WebM Project VP8 Encoder " + Vpx.VersionString, c.Name, c + "#1");

			c = VpxCodec.VP9;
			Assert.AreEqual("WebM Project VP9 Encoder " + Vpx.VersionString, c.Name, c + "#1");
		}
	}
}
