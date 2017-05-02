using System;
using System.Runtime.InteropServices;

namespace LibVpxSharp
{
	public class VpxInteropException : Exception
	{
		public VpxInteropException (VpxCodecError error)
			: this (null, error, null)
		{
		}

		public VpxInteropException (VpxCodecError error, Exception innerException)
			: this (null, error, innerException)
		{
		}

		public VpxInteropException (string message, VpxCodecError error)
			: this (message, error, null)
		{
		}

		public VpxInteropException (string message, Exception innerException)
			: this (message, VpxCodecError.OK, innerException)
		{
		}

		public VpxInteropException (string message, VpxCodecError error, Exception innerException)
			: base (message + ToMessageAddendum (error), innerException)
		{
		}

		static string ToMessageAddendum (VpxCodecError error)
		{
			return error == VpxCodecError.OK ? null : " : " + Marshal.PtrToStringAuto (VpxMarshal.vpx_codec_err_to_string (error));
		}
	}
}
