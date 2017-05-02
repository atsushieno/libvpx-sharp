using System;
using System.Runtime.InteropServices;

static partial class VpxMarshal
{
	public const string LibraryName = "vpx";

	// These are defined in the native library (namely vpx_image.h, in v1.5.0)
	public const int ImageAbiVersion = 3;
	public const int CodecAbiVersion = 6;
	public const int DecoderAbiVersion = 9;
	public const int EncoderAbiVersion = 11;

	public const int VPX_TS_MAX_PERIODICITY = 16;
	public const int VPX_TS_MAX_LAYERS       = 5;
	public const int MAX_PERIODICITY = VPX_TS_MAX_PERIODICITY;
	public const int VPX_MAX_LAYERS  = 12;
	public const int MAX_LAYERS    = VPX_MAX_LAYERS;
	public const int VPX_SS_MAX_LAYERS       = 5;
	public const int VPX_SS_DEFAULT_LAYERS       = 1;

	[DllImport (LibraryName)] public static extern Pointer<vpx_codec_iface> vpx_codec_vp8_cx_algo();
}

class VpxCodecCtxConfig
{
	/**< Decoder Configuration Pointer */
	Pointer<vpx_codec_dec_cfg> dec;
	/**< Encoder Configuration Pointer */
	Pointer<vpx_codec_enc_cfg> enc;
	IntPtr raw;
}

[Flags]
enum VpxCodecCapabilities
{
	Decoder = 1,
	Encoder = 2,
}

namespace LibVpxSharp
{
	[StructLayout (LayoutKind.Sequential)]
	public struct VpxFixedBuffer
	{
		public VpxFixedBuffer (IntPtr buffer, int size)
		{
			Buffer = buffer;
			Size = size;
		}

		public readonly IntPtr Buffer;
		public readonly int Size;
	}

	public enum VpxCodecFlags
	{
		None = 0,
		UsePostProcess =   0x10000, /**< Postprocess decoded frame */
		UseErrorConcealment = 0x20000, /**< Conceal errors in decoded frames */
		UseInputFragments = 0x40000, /**< The input frame should be passed to the decoder one fragment at a time */
		UseFrameThreading =   0x80000, /**< Enable frame-based multi-threading */
	}

	/*!\brief Algorithm return codes */
	public enum VpxCodecError // vpx_codec_err_t
	{
		/*!\brief Operation completed without error */
		OK,

		/*!\brief Unspecified error */
		Error,

		/*!\brief Memory operation failed */
		MemoryError,

		/*!\brief ABI version mismatch */
		AbiMismatch,

		/*!\brief Algorithm does not have required capability */
		Incapable,

		/*!\brief The given bitstream is not supported.
	     *
	     * The bitstream was unable to be parsed at the highest level. The decoder
	     * is unable to proceed. This error \ref SHOULD be treated as fatal to the
	     * stream. */
		UnsupportedBitStream,

		/*!\brief Encoded bitstream uses an unsupported feature
	     *
	     * The decoder does not implement a feature required by the encoder. This
	     * return code should only be used for features that prevent future
	     * pictures from being properly decoded. This error \ref MAY be treated as
	     * fatal to the stream or \ref MAY be treated as fatal to the current GOP.
	     */
		UnsupportedFeature,

		/*!\brief The coded data for this stream is corrupt or incomplete
	     *
	     * There was a problem decoding the current frame.  This return code
	     * should only be used for failures that prevent future pictures from
	     * being properly decoded. This error \ref MAY be treated as fatal to the
	     * stream or \ref MAY be treated as fatal to the current GOP. If decoding
	     * is continued for the current GOP, artifacts may be present.
	     */
		CorruptFrame,

		/*!\brief An application-supplied parameter is not valid.
	     *
	     */
		InvalidParameter,

		/*!\brief An iterator reached the end of list.
	     *
	     */
		ListEnd
	}

	public enum VpxEncoderFlags
	{
		None = 0,
		ForceKF = (1<<0),
	}

	public enum VpxImageFormat //line:40, column:16
	{
		None = 0,
		Rgb24 = 1,
		Rgb32 = 2,
		Rgb565 = 3,
		Rgb555 = 4,
		UYVY = 5,
		YUY2 = 6,
		YVYU = 7,
		Bgr24 = 8,
		Rgb32_LE = 9,
		Argb = 10,
		ArgbLE = 11,
		Rgb565LE = 12,
		Rgb555LE = 13,
		YV12 = 769,
		I420 = 258,
		VpxYV12 = 771,
		VpxI420 = 260,
		I422 = 261,
		I444 = 262,
		I440 = 263,
		I444A = 1286,
		I42016 = 2306,
		I42216 = 2309,
		I44416 = 2310,
		I44016 = 2311,
	}

	public enum VpxDeadline
	{
		Realtime = 1,
		GoodQuality = 1000000,
		BestQuality = 0,
	}
}
