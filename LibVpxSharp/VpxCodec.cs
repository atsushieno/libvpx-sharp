using System;
using System.Runtime.InteropServices;

namespace LibVpxSharp
{
	public class VpxCodec : IDisposable
	{
		public static VpxCodec VP8 = new VpxCodec (VpxMarshal.vpx_codec_vp8_cx ());
		public static VpxCodec VP9 = new VpxCodec (VpxMarshal.vpx_codec_vp9_cx ());
		//public static VpxCodec VP10 = new VpxCodec (VpxMarshal.vpx_codec_vp10_cx ());

		internal IntPtr Handle { get; private set; }

		VpxCodec (IntPtr handle)
		{
			this.Handle = handle;
		}

		public void Dispose ()
		{
		}

		public string Name {
			get { return Marshal.PtrToStringAuto (VpxMarshal.vpx_codec_iface_name (Handle)); }
		}
	}
}
