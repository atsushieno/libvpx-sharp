using NUnit.Framework;
using System;
namespace LibVpxSharp.Tests
{
	[TestFixture]
	public class VpxTest
	{
		[Test]
		public void VpxVersions ()
		{
			Assert.AreEqual (66816, Vpx.Version, "#1");
			Assert.AreEqual ("v1.5.0", Vpx.VersionString, "#2");
			// It is rather to detect crasher. The actual value should be environment dependent.
			Assert.IsNotNull (Vpx.Config, "#3");
		}

		[Test]
		public void CodecInstances ()
		{
			Assert.IsNotNull (Vpx.VpxCodexVP8Cx, "#1");
			Assert.IsNotNull (Vpx.VpxCodexVP9Cx, "#2");
			//Assert.IsNotNull (Vpx.VpxCodexVP10Cx, "#3");
		}
	}
}
