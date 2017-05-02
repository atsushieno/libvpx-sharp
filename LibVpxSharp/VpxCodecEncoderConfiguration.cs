using System;
using System.Runtime.InteropServices;
using vpx_codec_enc_cfg_ptr = System.IntPtr;

namespace LibVpxSharp
{
	public class VpxCodecEncoderConfiguration : IDisposable
	{
		public static VpxCodecEncoderConfiguration CreateDefault (VpxCodec codec)
		{
			vpx_codec_enc_cfg cfg;
			VpxCodecError error;
			error = VpxMarshal.vpx_codec_enc_config_default (codec.Handle, out cfg, 0);
			if (error != VpxCodecError.OK)
				throw new VpxInteropException (error);
			var ptr = Vpx.AllocateHGlobalPointerOfStruct (cfg);
			return new VpxCodecEncoderConfiguration (ptr, true);
		}

		internal VpxCodecEncoderConfiguration (Pointer<vpx_codec_enc_cfg> handle, bool release)
		{
			Handle = handle;
			this.release = release;
		}

		bool release;

		public void Dispose ()
		{
			if (release) {
				release = false;
				Marshal.FreeHGlobal (Handle.Handle);
			}
		}

		internal Pointer<vpx_codec_enc_cfg> Handle { get; private set; }
	}
}