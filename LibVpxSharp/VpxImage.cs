using System;
using System.Runtime.InteropServices;

namespace LibVpxSharp
{
	public class VpxImage : IDisposable
	{
		public VpxImage (VpxImageFormat format, int width, int height, int align)
		{
			Handle = VpxMarshal.vpx_img_alloc (new Pointer<vpx_image> (IntPtr.Zero), format, (uint) width, (uint) height, (uint) align);
			release = true;
		}

		public VpxImage (VpxImageFormat format, int width, int height, int align, Pointer<byte> imageData)
		{
			Handle = VpxMarshal.vpx_img_wrap (new Pointer<vpx_image> (IntPtr.Zero), format, (uint) width, (uint) height, (uint) align, imageData);
			ImageData = imageData;
			release = true;
		}

		bool release;

		public void Dispose ()
		{
			if (release) {
				release = false;
				if (ImageData.Handle == IntPtr.Zero)
					VpxMarshal.vpx_img_free (Handle);
				Marshal.FreeHGlobal (Handle.Handle);
			}
		}

		internal Pointer<vpx_image> Handle { get; set; }

		public Pointer<byte> ImageData { get; private set; }

		public void SetRect (int x, int y, int width, int height)
		{
			var error = VpxMarshal.vpx_img_set_rect (Handle, (uint) x, (uint) y, (uint) width, (uint) height);
		}

		public void Flip ()
		{
			VpxMarshal.vpx_img_flip (Handle);
		}
	}
}
