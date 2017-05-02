using System;
using System.Runtime.InteropServices;

namespace LibVpxSharp
{
	public static class Vpx
	{
		public static int Version {
			get { return VpxMarshal.vpx_codec_version (); }
		}

		public static string VersionString
		{
			get { return Marshal.PtrToStringAuto (VpxMarshal.vpx_codec_version_str ()); }
		}

		public static string Config
		{
			get { return Marshal.PtrToStringAuto (VpxMarshal.vpx_codec_build_config ()); }
		}

		public static IntPtr VpxCodexVP8Cx { 
			get { return VpxMarshal.vpx_codec_vp8_cx (); }
		}

		public static IntPtr VpxCodexVP9Cx
		{
			get { return VpxMarshal.vpx_codec_vp9_cx (); }
		}

		//public static IntPtr VpxCodexVP10Cx
		//{
		//	get { return VpxMarshal.vpx_codec_vp10_cx (); }
		//}

		public static Pointer<T> AllocateHGlobalPointerOfStruct<T> (T value)
		{
			var handle = Marshal.AllocHGlobal (Marshal.SizeOf (value));
			Marshal.StructureToPtr (value, handle, false);
			return new Pointer<T> (handle);
		}
	}
}
