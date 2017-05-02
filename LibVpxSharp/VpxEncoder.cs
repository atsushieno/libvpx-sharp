using System;
using System.Runtime.InteropServices;

namespace LibVpxSharp
{
	public class VpxEncoder : IDisposable
	{
		public VpxEncoder (VpxCodec codec, VpxCodecEncoderConfiguration config, VpxCodecFlags flags)
		{
			if (codec == null)
				throw new ArgumentNullException (nameof (codec));
			config = config ?? VpxCodecEncoderConfiguration.CreateDefault (codec);
			vpx_codec_ctx enc;
			var error = VpxMarshal.vpx_codec_enc_init_ver (out enc, codec.Handle, config.Handle, flags, VpxMarshal.EncoderAbiVersion);
			if (error != VpxCodecError.OK)
				throw new VpxInteropException (error);
			ctx = Vpx.AllocateHGlobalPointerOfStruct (enc);
		}

		Pointer<vpx_codec_ctx> ctx;

		public void Dispose ()
		{
			if (ctx.Handle != IntPtr.Zero) {
				Marshal.FreeHGlobal (ctx.Handle);
				ctx.Handle = IntPtr.Zero;
			}
		}

		public VpxFixedBuffer GetGlobalHeaders ()
		{
			var ptr = VpxMarshal.vpx_codec_get_global_headers (ctx);
			return (ptr.Handle == IntPtr.Zero) ? default (VpxFixedBuffer) : (VpxFixedBuffer) Marshal.PtrToStructure (VpxMarshal.vpx_codec_get_global_headers (ctx), typeof (VpxFixedBuffer));
		}

		public void SetConfiguration (VpxCodecEncoderConfiguration config)
		{
			if (config == null)
				throw new ArgumentNullException (nameof (config));
			VpxMarshal.vpx_codec_enc_config_set (ctx, config.Handle);
		}

		public void Encode (VpxImage image, int presentationTimestamp, ulong duration, VpxEncoderFlags flags, VpxDeadline deadline)
		{
			var err = VpxMarshal.vpx_codec_encode (ctx, image.Handle, presentationTimestamp, duration, flags, deadline);
			if (err != VpxCodecError.OK)
				throw new VpxInteropException (err);
		}

		public void SetCxDataBuffer (Pointer<VpxFixedBuffer> buffer, int padBefore, int padAfter)
		{
			VpxMarshal.vpx_codec_set_cx_data_buf (ctx, buffer, (uint) padBefore, (uint) padAfter);
		}
	}
}
