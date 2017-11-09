using System;
using System.Runtime.InteropServices;
using System.Security;

using BYTE = System.Byte;
using WORD = System.UInt16;
using DWORD = System.UInt32;
using COLORREF = System.UInt32;

namespace DMSys.NativeMethods
{
    #region Class Documentation
    /// <summary>
    ///     GDI binding for .NET, implementing Windows-specific GDI functionality.
    /// </summary>
    /// <remarks>
    ///     Binds functions and definitions in gdi32.dll.
    /// </remarks>
    #endregion Class Documentation

    public static class Gdi32
    {
        // --- Fields ---
        #region Private Constants
        #region string GDI_NATIVE_LIBRARY
        /// <summary>
        ///     Specifies GDI's native library archive.
        /// </summary>
        /// <remarks>
        ///     Specifies gdi32.dll for Windows.
        /// </remarks>
        private const string GDI_NATIVE_LIBRARY = "gdi32.dll";
        #endregion string GDI_NATIVE_LIBRARY

        #region CallingConvention CALLING_CONVENTION
        /// <summary>
        ///     Specifies the calling convention.
        /// </summary>
        /// <remarks>
        ///     Specifies <see cref="CallingConvention.StdCall" />.
        /// </remarks>
        private const CallingConvention CALLING_CONVENTION = CallingConvention.StdCall;
        #endregion CallingConvention CALLING_CONVENTION
        #endregion Private Constants

        #region Public Constants
        #region LAYERPLANEDESCRIPTOR Pixel Types
        #region int LPD_TYPE_RGBA
        /// <summary>
        ///     RGBA pixels.  Each pixel has four components: red, green, blue, and alpha.
        /// </summary>
        // #define LPD_TYPE_RGBA        0
        public const int LPD_TYPE_RGBA = 0;
        #endregion int LPD_TYPE_RGBA

        #region int LPD_TYPE_COLORINDEX
        /// <summary>
        ///     Color-index pixels.  Each pixel uses a color-index value.
        /// </summary>
        // #define LPD_TYPE_COLORINDEX  1
        public const int LPD_TYPE_COLORINDEX = 1;
        #endregion int LPD_TYPE_COLORINDEX
        #endregion LAYERPLANEDESCRIPTOR Pixel Types

        #region LAYERPLANEDESCRIPTOR Flags
        #region int LPD_DOUBLEBUFFER
        /// <summary>
        ///     The layer plane is double-buffered.  A layer plane can be double-buffered
        ///     even when the main plane is single-buffered and vice versa.
        /// </summary>
        // #define LPD_DOUBLEBUFFER        0x00000001
        public const int LPD_DOUBLEBUFFER = 0x00000001;
        #endregion int LPD_DOUBLEBUFFER

        #region int LPD_STEREO
        /// <summary>
        ///     The layer plane is stereoscopic.  A layer plane can be stereoscopic even
        ///     when the main plane is monoscopic and vice versa.
        /// </summary>
        // #define LPD_STEREO              0x00000002
        public const int LPD_STEREO = 0x00000002;
        #endregion int LPD_STEREO

        #region int LPD_SUPPORT_GDI
        /// <summary>
        ///     The layer plane supports GDI drawing.  The current implementation of OpenGL
        ///     doesn't support this flag.
        /// </summary>
        // #define LPD_SUPPORT_GDI         0x00000010
        public const int LPD_SUPPORT_GDI = 0x00000010;
        #endregion int LPD_SUPPORT_GDI

        #region int LPD_SUPPORT_OPENGL
        /// <summary>
        ///     The layer plane supports OpenGL drawing.
        /// </summary>
        // #define LPD_SUPPORT_OPENGL      0x00000020
        public const int LPD_SUPPORT_OPENGL = 0x00000020;
        #endregion int LPD_SUPPORT_OPENGL

        #region int LPD_SHARE_DEPTH
        /// <summary>
        ///     The layer plane shares the depth buffer with the main plane.
        /// </summary>
        // #define LPD_SHARE_DEPTH         0x00000040
        public const int LPD_SHARE_DEPTH = 0x00000040;
        #endregion int LPD_SHARE_DEPTH

        #region int LPD_SHARE_STENCIL
        /// <summary>
        ///     The layer plane shares the stencil buffer with the main plane.
        /// </summary>
        // #define LPD_SHARE_STENCIL       0x00000080
        public const int LPD_SHARE_STENCIL = 0x00000080;
        #endregion int LPD_SHARE_STENCIL

        #region int LPD_SHARE_ACCUM
        /// <summary>
        ///     The layer plane shares the accumulation buffer with the main plane.
        /// </summary>
        // #define LPD_SHARE_ACCUM         0x00000100
        public const int LPD_SHARE_ACCUM = 0x00000100;
        #endregion int LPD_SHARE_ACCUM

        #region int LPD_SWAP_EXCHANGE
        /// <summary>
        ///     In a double-buffered layer plane, swapping the color buffer exchanges the
        ///     front buffer and back buffer contents.  The back buffer then contains the
        ///     contents of the front buffer before the swap. This flag is a hint only and
        ///     might not be provided by a driver.
        /// </summary>
        // #define LPD_SWAP_EXCHANGE       0x00000200
        public const int LPD_SWAP_EXCHANGE = 0x00000200;
        #endregion int LPD_SWAP_EXCHANGE

        #region int LPD_SWAP_COPY
        /// <summary>
        ///     In a double-buffered layer plane, swapping the color buffer copies the back
        ///     buffer contents to the front buffer.  The swap does not affect the back
        ///     buffer contents. This flag is a hint only and might not be provided by a driver.
        /// </summary>
        // #define LPD_SWAP_COPY           0x00000400
        public const int LPD_SWAP_COPY = 0x00000400;
        #endregion int LPD_SWAP_COPY

        #region int LPD_TRANSPARENT
        /// <summary>
        ///     Contains a transparent color or index value that enables underlying layers
        ///     to show through this layer.  All layer planes, except the lowest-numbered
        ///     underlay layer, have a transparent color or index.
        /// </summary>
        // #define LPD_TRANSPARENT         0x00001000
        public const int LPD_TRANSPARENT = 0x00001000;
        #endregion int LPD_TRANSPARENT
        #endregion LAYERPLANEDESCRIPTOR Flags

        #region PIXELFORMATDESCRIPTOR Pixel Types
        #region int PFD_TYPE_RGBA
        /// <summary>
        ///     RGBA pixels.  Each pixel has four components in this order: red, green, blue,
        ///     and alpha.
        /// </summary>
        // #define PFD_TYPE_RGBA        0
        public const int PFD_TYPE_RGBA = 0;
        #endregion int PFD_TYPE_RGBA

        #region int PFD_TYPE_COLORINDEX
        /// <summary>
        ///     Color-index pixels.  Each pixel uses a color-index value.
        /// </summary>
        // #define PFD_TYPE_COLORINDEX  1
        public const int PFD_TYPE_COLORINDEX = 1;
        #endregion int PFD_TYPE_COLORINDEX
        #endregion PIXELFORMATDESCRIPTOR Pixel Types

        #region PIXELFORMATDESCRIPTOR Layer Types
        #region int PFD_MAIN_PLANE
        /// <summary>
        ///     The layer is the main plane.
        /// </summary>
        // #define PFD_MAIN_PLANE       0
        public const int PFD_MAIN_PLANE = 0;
        #endregion int PFD_MAIN_PLANE

        #region int PFD_OVERLAY_PLANE
        /// <summary>
        ///     The layer is the overlay plane.
        /// </summary>
        // #define PFD_OVERLAY_PLANE    1
        public const int PFD_OVERLAY_PLANE = 1;
        #endregion int PFD_OVERLAY_PLANE

        #region int PFD_UNDERLAY_PLANE
        /// <summary>
        ///     The layer is the underlay plane.
        /// </summary>
        // #define PFD_UNDERLAY_PLANE   (-1)
        public const int PFD_UNDERLAY_PLANE = -1;
        #endregion int PFD_UNDERLAY_PLANE
        #endregion PIXELFORMATDESCRIPTOR Layer Types

        #region PIXELFORMATDESCRIPTOR Flags
        #region int PFD_DOUBLEBUFFER
        /// <summary>
        ///     <para>
        ///         The buffer is double-buffered.  This flag and <see cref="PFD_SUPPORT_GDI" />
        ///         are mutually exclusive in the current generic implementation.
        ///     </para>
        /// </summary>
        // #define PFD_DOUBLEBUFFER            0x00000001
        public const int PFD_DOUBLEBUFFER = 0x00000001;
        #endregion int PFD_DOUBLEBUFFER

        #region int PFD_STEREO
        /// <summary>
        ///     <para>
        ///         The buffer is stereoscopic.  This flag is not supported in the current
        ///         generic implementation.
        ///     </para>
        /// </summary>
        // #define PFD_STEREO                  0x00000002
        public const int PFD_STEREO = 0x00000002;
        #endregion int PFD_STEREO

        #region int PFD_DRAW_TO_WINDOW
        /// <summary>
        ///     <para>
        ///         The buffer can draw to a window or device surface.
        ///     </para>
        /// </summary>
        // #define PFD_DRAW_TO_WINDOW          0x00000004
        public const int PFD_DRAW_TO_WINDOW = 0x00000004;
        #endregion int PFD_DRAW_TO_WINDOW

        #region int PFD_DRAW_TO_BITMAP
        /// <summary>
        ///     <para>
        ///         The buffer can draw to a memory bitmap.
        ///     </para>
        /// </summary>
        // #define PFD_DRAW_TO_BITMAP          0x00000008
        public const int PFD_DRAW_TO_BITMAP = 0x00000008;
        #endregion int PFD_DRAW_TO_BITMAP

        #region int PFD_SUPPORT_GDI
        /// <summary>
        ///     <para>
        ///         The buffer supports GDI drawing.  This flag and
        ///         <see cref="PFD_DOUBLEBUFFER" /> are mutually exclusive in the current generic
        ///         implementation.
        ///     </para>
        /// </summary>
        // #define PFD_SUPPORT_GDI             0x00000010
        public const int PFD_SUPPORT_GDI = 0x00000010;
        #endregion int PFD_SUPPORT_GDI

        #region int PFD_SUPPORT_OPENGL
        /// <summary>
        ///     <para>
        ///         The buffer supports OpenGL drawing.
        ///     </para>
        /// </summary>
        // #define PFD_SUPPORT_OPENGL          0x00000020
        public const int PFD_SUPPORT_OPENGL = 0x00000020;
        #endregion int PFD_SUPPORT_OPENGL

        #region int PFD_GENERIC_FORMAT
        /// <summary>
        ///     <para>
        ///         The pixel format is supported by the GDI software implementation, which is
        ///         also known as the generic implementation.  If this bit is clear, the pixel
        ///         format is supported by a device driver or hardware.
        ///     </para>
        /// </summary>
        // #define PFD_GENERIC_FORMAT          0x00000040
        public const int PFD_GENERIC_FORMAT = 0x00000040;
        #endregion int PFD_GENERIC_FORMAT

        #region int PFD_NEED_PALETTE
        /// <summary>
        ///     <para>
        ///         The buffer uses RGBA pixels on a palette-managed device.  A logical palette
        ///         is required to achieve the best results for this pixel type.  Colors in the
        ///         palette should be specified according to the values of the <b>cRedBits</b>,
        ///         <b>cRedShift</b>, <b>cGreenBits</b>, <b>cGreenShift</b>, <b>cBluebits</b>,
        ///         and <b>cBlueShift</b> members.  The palette should be created and realized in
        ///         the device context before calling <see cref="Wgl.wglMakeCurrent" />.
        ///     </para>
        /// </summary>
        // #define PFD_NEED_PALETTE            0x00000080
        public const int PFD_NEED_PALETTE = 0x00000080;
        #endregion int PFD_NEED_PALETTE

        #region int PFD_NEED_SYSTEM_PALETTE
        /// <summary>
        ///     <para>
        ///         Defined in the pixel format descriptors of hardware that supports one
        ///         hardware palette in 256-color mode only.  For such systems to use
        ///         hardware acceleration, the hardware palette must be in a fixed order
        ///         (for example, 3-3-2) when in RGBA mode or must match the logical palette
        ///         when in color-index mode.
        ///     </para>
        ///     <para>
        ///         When this flag is set, you must call see cref="SetSystemPaletteUse" /> in
        ///         your program to force a one-to-one mapping of the logical palette and the
        ///         system palette.  If your OpenGL hardware supports multiple hardware palettes
        ///         and the device driver can allocate spare hardware palettes for OpenGL, this
        ///         flag is typically clear.
        ///     </para>
        ///     <para>
        ///         This flag is not set in the generic pixel formats.
        ///     </para>
        /// </summary>
        // #define PFD_NEED_SYSTEM_PALETTE     0x00000100
        public const int PFD_NEED_SYSTEM_PALETTE = 0x00000100;
        #endregion int PFD_NEED_SYSTEM_PALETTE

        #region int PFD_SWAP_EXCHANGE
        /// <summary>
        ///     <para>
        ///         Specifies the content of the back buffer in the double-buffered main color
        ///         plane following a buffer swap.  Swapping the color buffers causes the
        ///         exchange of the back buffer's content with the front buffer's content.
        ///         Following the swap, the back buffer's content contains the front buffer's
        ///         content before the swap. <b>PFD_SWAP_EXCHANGE</b> is a hint only and might
        ///         not be provided by a driver.
        ///     </para>
        /// </summary>
        // #define PFD_SWAP_EXCHANGE           0x00000200
        public const int PFD_SWAP_EXCHANGE = 0x00000200;
        #endregion int PFD_SWAP_EXCHANGE

        #region int PFD_SWAP_COPY
        /// <summary>
        ///     <para>
        ///         Specifies the content of the back buffer in the double-buffered main color
        ///         plane following a buffer swap.  Swapping the color buffers causes the content
        ///         of the back buffer to be copied to the front buffer.  The content of the back
        ///         buffer is not affected by the swap.  <b>PFD_SWAP_COPY</b> is a hint only and
        ///         might not be provided by a driver.
        ///     </para>
        /// </summary>
        // #define PFD_SWAP_COPY               0x00000400
        public const int PFD_SWAP_COPY = 0x00000400;
        #endregion int PFD_SWAP_COPY

        #region int PFD_SWAP_LAYER_BUFFERS
        /// <summary>
        ///     <para>
        ///         Indicates whether a device can swap individual layer planes with pixel
        ///         formats that include double-buffered overlay or underlay planes.
        ///         Otherwise all layer planes are swapped together as a group.  When this
        ///         flag is set, <see cref="Wgl.wglSwapLayerBuffers" /> is supported.
        ///     </para>
        /// </summary>
        // #define PFD_SWAP_LAYER_BUFFERS      0x00000800
        public const int PFD_SWAP_LAYER_BUFFERS = 0x00000800;
        #endregion int PFD_SWAP_LAYER_BUFFERS

        #region int PFD_GENERIC_ACCELERATED
        /// <summary>
        ///     <para>
        ///         The pixel format is supported by a device driver that accelerates the generic
        ///         implementation.  If this flag is clear and the
        ///         <see cref="PFD_GENERIC_FORMAT" /> flag is set, the pixel format is supported
        ///         by the generic implementation only.
        ///     </para>
        /// </summary>
        // #define PFD_GENERIC_ACCELERATED     0x00001000
        public const int PFD_GENERIC_ACCELERATED = 0x00001000;
        #endregion int PFD_GENERIC_ACCELERATED

        #region int PFD_SUPPORT_DIRECTDRAW
        /// <summary>
        ///     <para>
        ///         The buffer supports DirectDraw drawing.
        ///     </para>
        /// </summary>
        // #define PFD_SUPPORT_DIRECTDRAW      0x00002000
        public const int PFD_SUPPORT_DIRECTDRAW = 0x00002000;
        #endregion int PFD_SUPPORT_DIRECTDRAW
        #endregion PIXELFORMATDESCRIPTOR Flags

        #region PIXELFORMATDESCRIPTOR Flags For Use In ChoosePixelFormat Only
        #region int PFD_DEPTH_DONTCARE
        /// <summary>
        ///     <para>
        ///         The requested pixel format can either have or not have a depth buffer.  To
        ///         select a pixel format without a depth buffer, you must specify this flag.
        ///         The requested pixel format can be with or without a depth buffer.  Otherwise,
        ///         only pixel formats with a depth buffer are considered.
        ///     </para>
        /// </summary>
        // #define PFD_DEPTH_DONTCARE          0x20000000
        public const int PFD_DEPTH_DONTCARE = 0x20000000;
        #endregion int PFD_DEPTH_DONTCARE

        #region int PFD_DOUBLEBUFFER_DONTCARE
        /// <summary>
        ///     <para>
        ///         The requested pixel format can be either single- or double-buffered.
        ///     </para>
        /// </summary>
        // #define PFD_DOUBLEBUFFER_DONTCARE   0x40000000
        public const int PFD_DOUBLEBUFFER_DONTCARE = 0x40000000;
        #endregion int PFD_DOUBLEBUFFER_DONTCARE

        #region int PFD_STEREO_DONTCARE
        /// <summary>
        ///     <para>
        ///         The requested pixel format can be either monoscopic or stereoscopic.
        ///     </para>
        /// </summary>
        // #define PFD_STEREO_DONTCARE         0x80000000
        public const int PFD_STEREO_DONTCARE = unchecked((int)0x80000000);
        #endregion int PFD_STEREO_DONTCARE
        #endregion PIXELFORMATDESCRIPTOR Flags For Use In ChoosePixelFormat Only

        /// <summary>
        /// 
        /// </summary>
        public const int DM_BITSPERPEL = 0x00040000;
        /// <summary>
        /// 
        /// </summary>
        public const int DM_PELSWIDTH = 0x00080000;
        /// <summary>
        /// 
        /// </summary>
        public const int DM_PELSHEIGHT = 0x00100000;
        /// <summary>
        /// 
        /// </summary>
        public const int DM_DISPLAYFLAGS = 0x00200000;
        /// <summary>
        /// 
        /// </summary>
        public const int DM_DISPLAYFREQUENCY = 0x00400000;

        /// <summary>
        /// 
        /// </summary>
        // #define OUT_TT_PRECIS 4
        public const int OUT_TT_PRECIS = 4;


        /// <summary>
        /// 
        /// </summary>
        // #define CLIP_DEFAULT_PRECIS 0
        public const int CLIP_DEFAULT_PRECIS = 0;

        /// <summary>
        /// 
        /// </summary>
        // #define DEFAULT_QUALITY 0
        public const int DEFAULT_QUALITY = 0;

        /// <summary>
        /// 
        /// </summary>
        // #define DRAFT_QUALITY 1
        public const int DRAFT_QUALITY = 1;

        /// <summary>
        /// 
        /// </summary>
        // #define PROOF_QUALITY 2
        public const int PROOF_QUALITY = 2;

        /// <summary>
        /// 
        /// </summary>
        // #define NONANTIALIASED_QUALITY 3
        public const int NONANTIALIASED_QUALITY = 3;

        /// <summary>
        /// 
        /// </summary>
        // #define ANTIALIASED_QUALITY 4
        public const int ANTIALIASED_QUALITY = 4;

        /// <summary>
        /// 
        /// </summary>
        // #define CLEARTYPE_QUALITY 5
        public const int CLEARTYPE_QUALITY = 5;

        /// <summary>
        /// 
        /// </summary>
        // #define CLEARTYPE_NATURAL_QUALITY 6
        public const int CLEARTYPE_NATURAL_QUALITY = 6;

        /// <summary>
        /// 
        /// </summary>
        // #define DEFAULT_PITCH 0
        public const int DEFAULT_PITCH = 0;

        /// <summary>
        /// 
        /// </summary>
        // #define FIXED_PITCH 1
        public const int FIXED_PITCH = 1;

        /// <summary>
        /// 
        /// </summary>
        // #define VARIABLE_PITCH 2
        public const int VARIABLE_PITCH = 2;

        /// <summary>
        /// 
        /// </summary>
        // #define MONO_FONT 8
        public const int MONO_FONT = 8;

        /// <summary>
        /// 
        /// </summary>
        // #define ANSI_CHARSET 0
        public const int ANSI_CHARSET = 0;

        /// <summary>
        /// 
        /// </summary>
        // #define DEFAULT_CHARSET 1
        public const int DEFAULT_CHARSET = 1;

        /// <summary>
        /// 
        /// </summary>
        // #define SYMBOL_CHARSET 2
        public const int SYMBOL_CHARSET = 2;

        /// <summary>
        /// 
        /// </summary>
        // #define SHIFTJIS_CHARSET 128
        public const int SHIFTJIS_CHARSET = 128;

        /// <summary>
        /// 
        /// </summary>
        // #define FF_DONTCARE (0<<4)
        public const int FF_DONTCARE = (0 << 4);

        /// <summary>
        /// 
        /// </summary>
        // #define FW_BOLD 700
        public const int FW_BOLD = 700;
        #endregion Public Constants

        // --- Public Structs ---
        #region DEVMODE Struct
        /// <summary>
        ///     <para>
        ///         The <b>DEVMODE</b> data structure contains information about the
        ///         initialization and environment of a printer or a display device.
        ///     </para>
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         A device driver's private data follows the public portion of the
        ///         <b>DEVMODE</b> structure.  The size of the public data can vary for different
        ///         versions of the structure.  The <i>dmSize</i> member specifies the number of
        ///         bytes of public data, and the <i>dmDriverExtra</i> member specifies the
        ///         number of bytes of private data.
        ///     </para>
        /// </remarks>
        /// <seealso cref="User.ChangeDisplaySettings(ref Tao.Platform.Windows.Gdi.DEVMODE, int)" />
        /// <seealso cref="User.EnumDisplaySettings" />
        // <seealso cref="AdvancedDocumentProperties" />
        // <seealso cref="CreateDC" />
        // <seealso cref="CreateIC" />
        // <seealso cref="DeviceCapabilities" />
        // <seealso cref="DocumentProperties" />
        // <seealso cref="OpenPrinter" />
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct DEVMODE
        {
            /// <summary>
            /// A zero-terminated character array that specifies the "friendly" name of the printer or display; for example, "PCL/HP LaserJet" in the case of PCL/HP LaserJet. This string is unique among device drivers. Note that this name may be truncated to fit in the dmDeviceName array.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string dmDeviceName;

            /// <summary>
            /// The version number of the initialization data specification on which the structure is based. To ensure the correct version is used for any operating system, use DM_SPECVERSION.
            /// </summary>
            public short dmSpecVersion;

            /// <summary>
            /// The driver version number assigned by the driver developer.
            /// </summary>
            public short dmDriverVersion;

            /// <summary>
            /// Specifies the size, in bytes, of the DEVMODE structure, not including any private driver-specific data that might follow the structure's public members. Set this member to sizeof (DEVMODE) to indicate the version of the DEVMODE structure being used. 
            /// </summary>
            public short dmSize;

            /// <summary>
            /// Contains the number of bytes of private driver-data that follow this structure. If a device driver does not use device-specific information, set this member to zero.
            /// </summary>
            public short dmDriverExtra;

            /// <summary>
            /// Specifies whether certain members of the DEVMODE structure have been initialized. If a member is initialized, its corresponding bit is set, otherwise the bit is clear. A driver supports only those DEVMODE members that are appropriate for the printer or display technology.
            /// </summary>
            public int dmFields;

            /// <summary>
            /// For printer devices only, selects the orientation of the paper. This member can be either DMORIENT_PORTRAIT (1) or DMORIENT_LANDSCAPE (2).
            /// </summary>
            public short dmOrientation;

            /// <summary>
            /// For printer devices only, selects the size of the paper to print on. This member can be set to zero if the length and width of the paper are both set by the dmPaperLength and dmPaperWidth members. Otherwise, the dmPaperSize member can be set to a device specific value greater than or equal to DMPAPER_USER or to one of the following predefined values.
            /// </summary>
            public short dmPaperSize;

            /// <summary>
            /// For printer devices only, overrides the length of the paper specified by the dmPaperSize member, either for custom paper sizes or for devices such as dot-matrix printers that can print on a page of arbitrary length. These values, along with all other values in this structure that specify a physical length, are in tenths of a millimeter.
            /// </summary>
            public short dmPaperLength;

            /// <summary>
            /// For printer devices only, overrides the width of the paper specified by the dmPaperSize member. 
            /// </summary>
            public short dmPaperWidth;

            /// <summary>
            /// Specifies the factor by which the printed output is to be scaled. The apparent page size is scaled from the physical page size by a factor of dmScale /100. For example, a letter-sized page with a dmScale value of 50 would contain as much data as a page of 17- by 22-inches because the output text and graphics would be half their original height and width.
            /// </summary>
            public short dmScale;

            /// <summary>
            /// Selects the number of copies printed if the device supports multiple-page copies.
            /// </summary>
            public short dmCopies;

            /// <summary>
            /// Specifies the paper source. To retrieve a list of the available paper sources for a printer, use the DeviceCapabilities function with the DC_BINS flag.
            /// </summary>
            public short dmDefaultSource;

            /// <summary>
            /// Specifies the printer resolution. There are four predefined device-independent values:v
            /// </summary>
            public short dmPrintQuality;

            /// <summary>
            /// Switches between color and monochrome on color printers. The following are the possible values:
            /// </summary>
            public short dmColor;

            /// <summary>
            /// Selects duplex or double-sided printing for printers capable of duplex printing. Following are the possible values.
            /// </summary>
            public short dmDuplex;

            /// <summary>
            /// Specifies the y-resolution, in dots per inch, of the printer. If the printer initializes this member, the dmPrintQuality member specifies the x-resolution, in dots per inch, of the printer.
            /// </summary>
            public short dmYResolution;

            /// <summary>
            /// Specifies how TrueType fonts should be printed.
            /// </summary>
            public short dmTTOption;

            /// <summary>
            /// Specifies whether collation should be used when printing multiple copies. (This member is ignored unless the printer driver indicates support for collation by setting the dmFields member to DM_COLLATE.)
            /// </summary>
            public short dmCollate;

            /// <summary>
            /// A zero-terminated character array that specifies the name of the form to use; for example, "Letter" or "Legal". A complete set of names can be retrieved by using the EnumForms function.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string dmFormName;

            /// <summary>
            /// The number of pixels per logical inch. Printer drivers do not use this member.
            /// </summary>
            public short dmLogPixels;

            /// <summary>
            /// Specifies the color resolution, in bits per pixel, of the display device (for example: 4 bits for 16 colors, 8 bits for 256 colors, or 16 bits for 65,536 colors). Display drivers use this member, for example, in the ChangeDisplaySettings function. Printer drivers do not use this member.
            /// </summary>
            public int dmBitsPerPel;

            /// <summary>
            /// Specifies the width, in pixels, of the visible device surface. Display drivers use this member, for example, in the ChangeDisplaySettings function. Printer drivers do not use this member.
            /// </summary>
            public int dmPelsWidth;

            /// <summary>
            /// Specifies the height, in pixels, of the visible device surface. Display drivers use this member, for example, in the ChangeDisplaySettings function. Printer drivers do not use this member.
            /// </summary>
            public int dmPelsHeight;

            /// <summary>
            /// Specifies the device's display mode.
            /// </summary>
            public int dmDisplayFlags;

            /// <summary>
            /// Specifies the frequency, in hertz (cycles per second), of the display device in a particular mode. This value is also known as the display device's vertical refresh rate. Display drivers use this member. It is used, for example, in the ChangeDisplaySettings function. Printer drivers do not use this member.
            /// </summary>
            public int dmDisplayFrequency;

            /// <summary>
            /// Specifies how ICM is handled. For a non-ICM application, this member determines if ICM is enabled or disabled. For ICM applications, the system examines this member to determine how to handle ICM support. This member can be one of the following predefined values, or a driver-defined value greater than or equal to the value of DMICMMETHOD_USER.
            /// </summary>
            public int dmICMMethod;

            /// <summary>
            /// Specifies which color matching method, or intent, should be used by default. This member is primarily for non-ICM applications. ICM applications can establish intents by using the ICM functions. This member can be one of the following predefined values, or a driver defined value greater than or equal to the value of DMICM_USER.
            /// </summary>
            public int dmICMIntent;

            /// <summary>
            /// Specifies the type of media being printed on. The member can be one of the following predefined values, or a driver-defined value greater than or equal to the value of DMMEDIA_USER.
            /// </summary>
            public int dmMediaType;

            /// <summary>
            /// Specifies how dithering is to be done. The member can be one of the following predefined values, or a driver-defined value greater than or equal to the value of DMDITHER_USER.
            /// </summary>
            public int dmDitherType;

            /// <summary>
            /// Not used; must be zero.
            /// </summary>
            public int dmReserved1;

            /// <summary>
            /// Not used; must be zero.
            /// </summary>
            public int dmReserved2;

            /// <summary>
            /// This member must be zero.
            /// </summary>
            public int dmPanningWidth;

            /// <summary>
            /// This member must be zero.
            /// </summary>
            public int dmPanningHeight;
        }
        #endregion DEVMODE Struct

        #region GLYPHMETRICSFLOAT Struct
        /// <summary>
        /// The <b>GLYPHMETRICSFLOAT</b> structure contains information about the placement and orientation of a glyph in a
        /// character cell.
        /// </summary>
        /// <remarks>The values of <b>GLYPHMETRICSFLOAT</b> are specified as notional units.</remarks>
        /// <seealso cref="POINTFLOAT" />
        /// <seealso cref="Wgl.wglUseFontOutlines" />
        [StructLayout(LayoutKind.Sequential)]
        public struct GLYPHMETRICSFLOAT
        {
            /// <summary>
            /// Specifies the width of the smallest rectangle (the glyph's black box) that completely encloses the glyph.
            /// </summary>
            public float gmfBlackBoxX;

            /// <summary>
            /// Specifies the height of the smallest rectangle (the glyph's black box) that completely encloses the glyph.
            /// </summary>
            public float gmfBlackBoxY;

            /// <summary>
            /// Specifies the x and y coordinates of the upper-left corner of the smallest rectangle that completely encloses the glyph.
            /// </summary>
            public POINTFLOAT gmfptGlyphOrigin;

            /// <summary>
            /// Specifies the horizontal distance from the origin of the current character cell to the origin of the next character cell.
            /// </summary>
            public float gmfCellIncX;

            /// <summary>
            /// Specifies the vertical distance from the origin of the current character cell to the origin of the next character cell.
            /// </summary>
            public float gmfCellIncY;
        };
        #endregion GLYPHMETRICSFLOAT Struct

        #region PIXELFORMATDESCRIPTOR Struct
        /// <summary>
        ///     The <b>PIXELFORMATDESCRIPTOR</b> structure describes the pixel format of a drawing surface.
        /// </summary>
        /// <remarks>
        ///     Please notice carefully, as documented in the members, that certain pixel format properties are not supported
        ///     in the current generic implementation. The generic implementation is the Microsoft GDI software
        ///     implementation of OpenGL. Hardware manufacturers may enhance parts of OpenGL, and may support some
        ///     pixel format properties not supported by the generic implementation.
        /// </remarks>
        /// <seealso cref="ChoosePixelFormat" />
        /// seealso cref="DescribePixelFormat" />
        /// seealso cref="GetPixelFormat" />
        /// <seealso cref="SetPixelFormat" />
        [StructLayout(LayoutKind.Sequential)]
        public struct PIXELFORMATDESCRIPTOR
        {
            /// <summary>
            /// Specifies the size of this data structure. This value should be set to <c>sizeof(PIXELFORMATDESCRIPTOR)</c>.
            /// </summary>
            public Int16 nSize;

            /// <summary>
            /// Specifies the version of this data structure. This value should be set to 1.
            /// </summary>
            public Int16 nVersion;

            /// <summary>
            /// A set of bit flags that specify properties of the pixel buffer. The properties are generally not mutually exclusive;
            /// you can set any combination of bit flags, with the exceptions noted.
            /// </summary>
            /// <remarks>
            ///     <para>The following bit flag constants are defined:</para>
            ///     <list type="table">
            ///			<listheader>
            ///				<term>Value</term>
            ///				<description>Meaning</description>
            ///			</listheader>
            ///			<item>
            ///				<term>PFD_DRAW_TO_WINDOW</term>
            ///				<description>The buffer can draw to a window or device surface.</description>
            ///			</item>
            ///			<item>
            ///				<term>PFD_DRAW_TO_BITMAP</term>
            ///				<description>The buffer can draw to a memory bitmap.</description>
            ///			</item>
            ///			<item>
            ///				<term>PFD_SUPPORT_GDI</term>
            ///				<description>
            ///					The buffer supports GDI drawing. This flag and PFD_DOUBLEBUFFER are mutually exclusive
            ///					in the current generic implementation.
            ///				</description>
            ///			</item>
            ///			<item>
            ///				<term>PFD_SUPPORT_OPENGL</term>
            ///				<description>The buffer supports OpenGL drawing.</description>
            ///			</item>
            ///			<item>
            ///				<term>PFD_GENERIC_ACCELERATED</term>
            ///				<description>
            ///					The pixel format is supported by a device driver that accelerates the generic implementation.
            ///					If this flag is clear and the PFD_GENERIC_FORMAT flag is set, the pixel format is supported by
            ///					the generic implementation only.
            ///				</description>
            ///			</item>
            ///			<item>
            ///				<term>PFD_GENERIC_FORMAT</term>
            ///				<description>
            ///					The pixel format is supported by the GDI software implementation, which is also known as the
            ///					generic implementation. If this bit is clear, the pixel format is supported by a device
            ///					driver or hardware.
            ///				</description>
            ///			</item>
            ///			<item>
            ///				<term>PFD_NEED_PALETTE</term>
            ///				<description>
            ///					The buffer uses RGBA pixels on a palette-managed device. A logical palette is required to achieve
            ///					the best results for this pixel type. Colors in the palette should be specified according to the
            ///					values of the <b>cRedBits</b>, <b>cRedShift</b>, <b>cGreenBits</b>, <b>cGreenShift</b>,
            ///					<b>cBluebits</b>, and <b>cBlueShift</b> members. The palette should be created and realized in
            ///					the device context before calling <see cref="Wgl.wglMakeCurrent" />.
            ///				</description>
            ///			</item>
            ///			<item>
            ///				<term>PFD_NEED_SYSTEM_PALETTE</term>
            ///				<description>
            ///					Defined in the pixel format descriptors of hardware that supports one hardware palette in
            ///					256-color mode only. For such systems to use hardware acceleration, the hardware palette must be in
            ///					a fixed order (for example, 3-3-2) when in RGBA mode or must match the logical palette when in
            ///					color-index mode.
            ///					
            ///					When this flag is set, you must call SetSystemPaletteUse in your program to force a one-to-one
            ///					mapping of the logical palette and the system palette. If your OpenGL hardware supports multiple
            ///					hardware palettes and the device driver can allocate spare hardware palettes for OpenGL, this
            ///					flag is typically clear.
            ///					
            ///					This flag is not set in the generic pixel formats.
            ///				</description>
            ///			</item>
            ///			<item>
            ///				<term>PFD_DOUBLEBUFFER</term>
            ///				<description>
            ///					The buffer is double-buffered. This flag and PFD_SUPPORT_GDI are mutually exclusive in the
            ///					current generic implementation.
            ///				</description>
            ///			</item>
            ///			<item>
            ///				<term>PFD_STEREO</term>
            ///				<description>
            ///					The buffer is stereoscopic. This flag is not supported in the current generic implementation.
            ///				</description>
            ///			</item>
            ///			<item>
            ///				<term>PFD_SWAP_LAYER_BUFFERS</term>
            ///				<description>
            ///					Indicates whether a device can swap individual layer planes with pixel formats that include
            ///					double-buffered overlay or underlay planes. Otherwise all layer planes are swapped together
            ///					as a group. When this flag is set, <b>wglSwapLayerBuffers</b> is supported.
            ///				</description>
            ///			</item>
            ///		</list>
            ///		<para>You can specify the following bit flags when calling <see cref="ChoosePixelFormat" />.</para>
            ///		<list type="table">
            ///			<listheader>
            ///				<term>Value</term>
            ///				<description>Meaning</description>
            ///			</listheader>
            ///			<item>
            ///				<term>PFD_DEPTH_DONTCARE</term>
            ///				<description>
            ///					The requested pixel format can either have or not have a depth buffer. To select
            ///					a pixel format without a depth buffer, you must specify this flag. The requested pixel format
            ///					can be with or without a depth buffer. Otherwise, only pixel formats with a depth buffer
            ///					are considered.
            ///				</description>
            ///			</item>
            ///			<item>
            ///				<term>PFD_DOUBLEBUFFER_DONTCARE</term>
            ///				<description>The requested pixel format can be either single- or double-buffered.</description>
            ///			</item>
            ///			<item>
            ///				<term>PFD_STEREO_DONTCARE</term>
            ///				<description>The requested pixel format can be either monoscopic or stereoscopic.</description>
            ///			</item>
            ///		</list>
            ///		<para>
            ///			With the <b>glAddSwapHintRectWIN</b> extension function, two new flags are included for the
            ///			<b>PIXELFORMATDESCRIPTOR</b> pixel format structure.
            ///		</para>
            ///		<list type="table">
            ///			<listheader>
            ///				<term>Value</term>
            ///				<description>Meaning</description>
            ///			</listheader>
            ///			<item>
            ///				<term>PFD_SWAP_COPY</term>
            ///				<description>
            ///					Specifies the content of the back buffer in the double-buffered main color plane following
            ///					a buffer swap. Swapping the color buffers causes the content of the back buffer to be copied
            ///					to the front buffer. The content of the back buffer is not affected by the swap. PFD_SWAP_COPY
            ///					is a hint only and might not be provided by a driver.
            ///				</description>
            ///			</item>
            ///			<item>
            ///				<term>PFD_SWAP_EXCHANGE</term>
            ///				<description>
            ///					Specifies the content of the back buffer in the double-buffered main color plane following a
            ///					buffer swap. Swapping the color buffers causes the exchange of the back buffer's content
            ///					with the front buffer's content. Following the swap, the back buffer's content contains the
            ///					front buffer's content before the swap. PFD_SWAP_EXCHANGE is a hint only and might not be
            ///					provided by a driver.
            ///				</description>
            ///			</item>
            ///		</list>
            /// </remarks>
            public Int32 dwFlags;

            /// <summary>
            /// Specifies the type of pixel data. The following types are defined.
            /// </summary>
            /// <remarks>
            ///		<list type="table">
            ///			<listheader>
            ///				<term>Value</term>
            ///				<description>Meaning</description>
            ///			</listheader>
            ///			<item>
            ///				<term>PFD_TYPE_RGBA</term>
            ///				<description>
            ///					RGBA pixels. Each pixel has four components in this order: red, green, blue, and alpha.
            ///				</description>
            ///			</item>
            ///			<item>
            ///				<term>PFD_TYPE_COLORINDEX</term>
            ///				<description>Color-index pixels. Each pixel uses a color-index value.</description>
            ///			</item>
            ///		</list>
            /// </remarks>
            public Byte iPixelType;

            /// <summary>
            /// Specifies the number of color bitplanes in each color buffer. For RGBA pixel types, it is the size
            /// of the color buffer, excluding the alpha bitplanes. For color-index pixels, it is the size of the
            /// color-index buffer.
            /// </summary>
            public Byte cColorBits;

            /// <summary>
            /// Specifies the number of red bitplanes in each RGBA color buffer.
            /// </summary>
            public Byte cRedBits;

            /// <summary>
            /// Specifies the shift count for red bitplanes in each RGBA color buffer.
            /// </summary>
            public Byte cRedShift;

            /// <summary>
            /// Specifies the number of green bitplanes in each RGBA color buffer.
            /// </summary>
            public Byte cGreenBits;

            /// <summary>
            /// Specifies the shift count for green bitplanes in each RGBA color buffer.
            /// </summary>
            public Byte cGreenShift;

            /// <summary>
            /// Specifies the number of blue bitplanes in each RGBA color buffer.
            /// </summary>
            public Byte cBlueBits;

            /// <summary>
            /// Specifies the shift count for blue bitplanes in each RGBA color buffer.
            /// </summary>
            public Byte cBlueShift;

            /// <summary>
            /// Specifies the number of alpha bitplanes in each RGBA color buffer. Alpha bitplanes are not supported.
            /// </summary>
            public Byte cAlphaBits;

            /// <summary>
            /// Specifies the shift count for alpha bitplanes in each RGBA color buffer. Alpha bitplanes are not supported.
            /// </summary>
            public Byte cAlphaShift;

            /// <summary>
            /// Specifies the total number of bitplanes in the accumulation buffer.
            /// </summary>
            public Byte cAccumBits;

            /// <summary>
            /// Specifies the number of red bitplanes in the accumulation buffer.
            /// </summary>
            public Byte cAccumRedBits;

            /// <summary>
            /// Specifies the number of green bitplanes in the accumulation buffer.
            /// </summary>
            public Byte cAccumGreenBits;

            /// <summary>
            /// Specifies the number of blue bitplanes in the accumulation buffer.
            /// </summary>
            public Byte cAccumBlueBits;

            /// <summary>
            /// Specifies the number of alpha bitplanes in the accumulation buffer.
            /// </summary>
            public Byte cAccumAlphaBits;

            /// <summary>
            /// Specifies the depth of the depth (z-axis) buffer.
            /// </summary>
            public Byte cDepthBits;

            /// <summary>
            /// Specifies the depth of the stencil buffer.
            /// </summary>
            public Byte cStencilBits;

            /// <summary>
            /// Specifies the number of auxiliary buffers. Auxiliary buffers are not supported.
            /// </summary>
            public Byte cAuxBuffers;

            /// <summary>
            /// Ignored. Earlier implementations of OpenGL used this member, but it is no longer used.
            /// </summary>
            /// <remarks>Specifies the type of layer.</remarks>
            public Byte iLayerType;

            /// <summary>
            /// Specifies the number of overlay and underlay planes. Bits 0 through 3 specify up to 15 overlay planes and
            /// bits 4 through 7 specify up to 15 underlay planes.
            /// </summary>
            public Byte bReserved;

            /// <summary>
            /// Ignored. Earlier implementations of OpenGL used this member, but it is no longer used.
            /// </summary>
            /// <remarks>
            ///		Specifies the layer mask. The layer mask is used in conjunction with the visible mask to determine
            ///		if one layer overlays another.
            /// </remarks>
            public Int32 dwLayerMask;

            /// <summary>
            /// Specifies the transparent color or index of an underlay plane. When the pixel type is RGBA, <b>dwVisibleMask</b>
            /// is a transparent RGB color value. When the pixel type is color index, it is a transparent index value.
            /// </summary>
            public Int32 dwVisibleMask;

            /// <summary>
            /// Ignored. Earlier implementations of OpenGL used this member, but it is no longer used.
            /// </summary>
            /// <remarks>
            ///		Specifies whether more than one pixel format shares the same frame buffer. If the result of the bitwise
            ///		AND of the damage masks between two pixel formats is nonzero, then they share the same buffers.
            /// </remarks>
            public Int32 dwDamageMask;
        };
        #endregion PIXELFORMATDESCRIPTOR Struct

        #region POINTFLOAT Struct
        /// <summary>
        /// The <b>POINTFLOAT</b> structure contains the x and y coordinates of a point.
        /// </summary>
        /// <seealso cref="GLYPHMETRICSFLOAT" />
        [StructLayout(LayoutKind.Sequential)]
        public struct POINTFLOAT
        {
            /// <summary>
            /// Specifies the horizontal (x) coordinate of a point.
            /// </summary>
            public float X;

            /// <summary>
            /// Specifies the vertical (y) coordinate of a point.
            /// </summary>
            public float Y;
        };
        #endregion POINTFLOAT Struct

        #region LAYERPLANEDESCRIPTOR Struct
        /// <summary>
        /// The LAYERPLANEDESCRIPTOR structure describes the pixel format of a drawing surface.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct LAYERPLANEDESCRIPTOR
        {
            public WORD nSize;
            public WORD nVersion;
            public DWORD dwFlags;
            public BYTE iPixelType;
            public BYTE cColorBits;
            public BYTE cRedBits;
            public BYTE cRedShift;
            public BYTE cGreenBits;
            public BYTE cGreenShift;
            public BYTE cBlueBits;
            public BYTE cBlueShift;
            public BYTE cAlphaBits;
            public BYTE cAlphaShift;
            public BYTE cAccumBits;
            public BYTE cAccumRedBits;
            public BYTE cAccumGreenBits;
            public BYTE cAccumBlueBits;
            public BYTE cAccumAlphaBits;
            public BYTE cDepthBits;
            public BYTE cStencilBits;
            public BYTE cAuxBuffers;
            public BYTE iLayerType;
            public BYTE bReserved;
            public COLORREF crTransparent;
        }
        #endregion LAYERPLANEDESCRIPTOR Struct

        // --- Public Externs ---
        #region int ChoosePixelFormat(HDC hdc, PIXELFORMATDESCRIPTOR* ppfd)
        /// <summary>
        /// The <b>ChoosePixelFormat</b> function attempts to match an appropriate pixel format supported by a device context
        /// to a given pixel format specification.
        /// </summary>
        /// <param name="deviceContext">
        /// Specifies the device context that the function examines to determine the best match for the pixel format
        /// descriptor pointed to by <i>ppfd</i>.
        /// </param>
        /// <param name="pixelFormatDescriptor">
        /// <para>
        ///		Pointer to a <see cref="Gdi.PIXELFORMATDESCRIPTOR" /> structure that specifies the requested pixel format.
        ///		In this context, the members of the <b>PIXELFORMATDESCRIPTOR</b> structure that <i>ppfd</i>
        ///		points to are used as follows:
        ///	</para>
        ///	<para>
        ///		<b>nSize</b><br />
        ///		Specifies the size of the <b>PIXELFORMATDESCRIPTOR</b> data structure. Set this member to
        ///		<c>sizeof(PIXELFORMATDESCRIPTOR)</c>.
        ///	</para>
        ///	<para>
        ///		<b>nVersion</b><br />
        ///		Specifies the version number of the <b>PIXELFORMATDESCRIPTOR</b> data structure. Set this member to 1.
        ///	</para>
        ///	<para>
        ///		<b>dwFlags</b><br />
        ///		A set of bit flags that specify properties of the pixel buffer. You can combine the following bit
        ///		flag constants by using bitwise-OR.<br /><br />
        ///		If any of the following flags are set, the <b>ChoosePixelFormat</b> function attempts to match pixel
        ///		formats that also have that flag or flags set. Otherwise, <b>ChoosePixelFormat</b> ignores that flag
        ///		in the pixel formats:<br /><br />
        ///		PFD_DRAW_TO_WINDOW<br />
        ///		PFD_DRAW_TO_BITMAP<br />
        ///		PFD_SUPPORT_GDI<br />
        ///		PFD_SUPPORT_OPENGL<br /><br />
        ///		If any of the following flags are set, <b>ChoosePixelFormat</b> attempts to match pixel formats that
        ///		also have that flag or flags set. Otherwise, it attempts to match pixel formats without that flag set:<br /><br />
        ///		PFD_DOUBLEBUFFER<br />
        ///		PFD_STEREO<br /><br />
        ///		If the following flag is set, the function ignores the PFD_DOUBLEBUFFER flag in the pixel formats:<br /><br />
        ///		PFD_DOUBLEBUFFER_DONTCARE<br /><br />
        ///		If the following flag is set, the function ignores the PFD_STEREO flag in the pixel formats:<br /><br />
        ///		PFD_STEREO_DONTCARE<br />
        ///	</para>
        ///	<para>
        ///		<b>iPixelType</b><br />
        ///		Specifies the type of pixel format for the function to consider:<br /><br />
        ///		PFD_TYPE_RGBA<br />
        ///		PFD_TYPE_COLORINDEX<br />
        ///	</para>
        ///	<para>
        ///		<b>cColorBits</b><br />
        ///		Zero or greater.
        ///	</para>
        ///	<para>
        ///		<b>cRedBits</b><br />
        ///		Not used.
        ///	</para>
        ///	<para>
        ///		<b>cRedShift</b><br />
        ///		Not used.
        ///	</para>
        ///	<para>
        ///		<b>cGreenBits</b><br />
        ///		Not used.
        ///	</para>
        ///	<para>
        ///		<b>cGreenShift</b><br />
        ///		Not used.
        ///	</para>
        ///	<para>
        ///		<b>cBlueBits</b><br />
        ///		Not used.
        ///	</para>
        ///	<para>
        ///		<b>cBlueShift</b><br />
        ///		Not used.
        ///	</para>
        ///	<para>
        ///		<b>cAlphaBits</b><br />
        ///		Zero or greater.
        ///	</para>
        ///	<para>
        ///		<b>cAlphaShift</b><br />
        ///		Not used.
        ///	</para>
        ///	<para>
        ///		<b>cAccumBits</b><br />
        ///		Zero or greater.
        ///	</para>
        ///	<para>
        ///		<b>cAccumRedBits</b><br />
        ///		Not used.
        ///	</para>
        ///	<para>
        ///		<b>cAccumGreenBits</b><br />
        ///		Not used.
        ///	</para>
        ///	<para>
        ///		<b>cAccumBlueBits</b><br />
        ///		Not used.
        ///	</para>
        ///	<para>
        ///		<b>cAccumAlphaBits</b><br />
        ///		Not used.
        ///	</para>
        ///	<para>
        ///		<b>cDepthBits</b><br />
        ///		Zero or greater.
        ///	</para>
        ///	<para>
        ///		<b>cStencilBits</b><br />
        ///		Zero or greater.
        ///	</para>
        ///	<para>
        ///		<b>cAuxBuffers</b><br />
        ///		Zero or greater.
        ///	</para>
        ///	<para>
        ///		<b>iLayerType</b><br />
        ///		Specifies one of the following layer type values:<br /><br />
        ///		PFD_MAIN_PLANE<br />
        ///		PFD_OVERLAY_PLANE<br />
        ///		PFD_UNDERLAY_PLANE<br />
        ///	</para>
        ///	<para>
        ///		<b>bReserved</b><br />
        ///		Not used.
        ///	</para>
        ///	<para>
        ///		<b>dwLayerMask</b><br />
        ///		Not used.
        ///	</para>
        ///	<para>
        ///		<b>dwVisibleMask</b><br />
        ///		Not used.
        ///	</para>
        ///	<para>
        ///		<b>dwDamageMask</b><br />
        ///		Not used.
        ///	</para>
        /// </param>
        /// <returns>
        ///		If the function succeeds, the return value is a pixel format index (one-based) that is the closest match
        ///		to the given pixel format descriptor.<br /><br />
        ///		If the function fails, the return value is zero. To get extended error information,
        ///		call see cref="Kernel.GetLastError" />.
        /// </returns>
        /// <remarks>
        ///		You must ensure that the pixel format matched by the <b>ChoosePixelFormat</b> function satisfies your
        ///		requirements. For example, if you request a pixel format with a 24-bit RGB color buffer but the device
        ///		context offers only 8-bit RGB color buffers, the function returns a pixel format with an 8-bit RGB color
        ///		buffer.<br /><br />
        ///		The following code sample shows how to use <b>ChoosePixelFormat</b> to match a specified pixel
        ///		format:<br /><br />
        ///		<code>
        ///			HDC hdc;
        ///			int pixelFormat;
        ///			Gdi.PIXELFORMATDESCRIPTOR pfd;
        ///
        ///			// size of this pfd
        ///			pfd.nSize = (ushort) sizeof(Gdi.PIXELFORMATDESCRIPTOR);
        ///
        ///			// version number
        ///			pfd.nVersion = 1;
        ///
        ///			// support window, support OpenGL, double buffered
        ///			pfd.dwFlags = Gdi.PFD_DRAW_TO_WINDOW | Gdi.PFD_SUPPORT_OPENGL | Gdi.PFD_DOUBLEBUFFER;
        ///
        ///			// RGBA type
        ///			pfd.iPixelType = Gdi.PFD_TYPE_RGBA;
        ///
        ///			// 24-bit color depth
        ///			pfd.cColorBits = 24;
        ///
        ///			// color bits and shift bits ignored
        ///			pfd.cRedBits = 0;
        ///			pfd.cRedShift = 0;
        ///			pfd.cGreenBits = 0;
        ///			pfd.cGreenShift = 0;
        ///			pfd.cBlueBits = 0;
        ///			pfd.cBlueShift = 0;
        ///			pfd.cAlphaBits = 0;
        ///			pfd.cAlphaShift = 0;
        ///
        ///			// no accumulation buffer, accum bits ignored
        ///			pfd.cAccumBits = 0;
        ///			pfd.cAccumRedBits = 0;
        ///			pfd.cAccumGreenBits = 0;
        ///			pfd.cAccumBlueBits = 0;
        ///			pfd.cAccumAlphaBits = 0;
        ///
        ///			// no stencil buffer
        ///			pfd.cStencilBits = 0;
        ///
        ///			// no auxiliary buffer
        ///			pfd.cAuxBuffers = 0;
        ///
        ///			// main layer
        ///			pfd.iLayerType = Gdi.PFD_MAIN_PLANE;
        ///
        ///			// reserved
        ///			pfd.bReserved = 0;
        ///
        ///			// layer masks ignored
        ///			pfd.dwLayerMask = 0;
        ///			pfd.dwVisibleMask = 0;
        ///			pfd.dwDamageMask = 0;
        ///
        ///			pixelFormat = Gdi.ChoosePixelFormat(hdc, &amp;pfd);
        ///		</code>
        /// </remarks>
        /// seealso cref="DescribePixelFormat" />
        /// seealso cref="GetPixelFormat" />
        /// <seealso cref="SetPixelFormat" />
        [DllImport(GDI_NATIVE_LIBRARY, SetLastError = true), SuppressUnmanagedCodeSecurity]
        public static extern int ChoosePixelFormat(IntPtr deviceContext, ref PIXELFORMATDESCRIPTOR pixelFormatDescriptor);
        #endregion int ChoosePixelFormat(HDC hdc, PIXELFORMATDESCRIPTOR* ppfd)

        #region BOOL SetPixelFormat(HDC hdc, int iPixelFormat, PIXELFORMATDESCRIPTOR* ppfd)
        /// <summary>
        /// The <b>SetPixelFormat</b> function sets the pixel format of the specified device context to the format
        /// specified by the <i>iPixelFormat</i> index.
        /// </summary>
        /// <param name="deviceContext">
        ///		Specifies the device context whose pixel format the function attempts to set.
        /// </param>
        /// <param name="pixelFormat">
        ///		Index that identifies the pixel format to set. The various pixel formats supported by a device
        ///		context are identified by one-based indexes.
        /// </param>
        /// <param name="pixelFormatDescriptor">
        ///		Pointer to a <see cref="Gdi.PIXELFORMATDESCRIPTOR" /> structure that contains the logical pixel
        ///		format specification. The system's metafile component uses this structure to record the logical
        ///		pixel format specification. The structure has no other effect upon the behavior of the
        ///		<b>SetPixelFormat</b> function.
        /// </param>
        /// <returns>
        ///		If the function succeeds, the return value is true.<br /><br />
        ///		If the function fails, the return value is false. To get extended error information, call
        ///		see cref="Kernel.GetLastError" />.
        /// </returns>
        /// <remarks>
        ///		If <i>hdc</i> references a window, calling the <b>SetPixelFormat</b> function also changes the pixel format
        ///		of the window. Setting the pixel format of a window more than once can lead to significant complications
        ///		for the Window Manager and for multithread applications, so it is not allowed. An application can only set
        ///		the pixel format of a window one time. Once a window's pixel format is set, it cannot be changed.<br /><br />
        ///
        ///		You should select a pixel format in the device context before calling the <see cref="Wgl.wglCreateContext" />
        ///		function. The <b>wglCreateContext</b> function creates a rendering context for drawing on the device in the
        ///		selected pixel format of the device context.<br /><br />
        ///
        ///		An OpenGL window has its own pixel format. Because of this, only device contexts retrieved for the client
        ///		area of an OpenGL window are allowed to draw into the window. As a result, an OpenGL window should be created
        ///		with the WS_CLIPCHILDREN and WS_CLIPSIBLINGS styles. Additionally, the window class attribute should not
        ///		include the CS_PARENTDC style.<br /><br />
        ///
        ///		The following code example shows <b>SetPixelFormat</b> usage:<br /><br />
        ///
        ///		<code>
        ///			HDC hdc;
        ///			int pixelFormat;
        ///			Gdi.PIXELFORMATDESCRIPTOR pfd;
        ///
        ///			// size of this pfd
        ///			pfd.nSize = (ushort) sizeof(Gdi.PIXELFORMATDESCRIPTOR);
        ///
        ///			// version number
        ///			pfd.nVersion = 1;
        ///
        ///			// support window, support OpenGL, double buffered
        ///			pfd.dwFlags = Gdi.PFD_DRAW_TO_WINDOW | Gdi.PFD_SUPPORT_OPENGL | Gdi.PFD_DOUBLEBUFFER;
        ///
        ///			// RGBA type
        ///			pfd.iPixelType = Gdi.PFD_TYPE_RGBA;
        ///
        ///			// 24-bit color depth
        ///			pfd.cColorBits = 24;
        ///
        ///			// color bits and shift bits ignored
        ///			pfd.cRedBits = 0;
        ///			pfd.cRedShift = 0;
        ///			pfd.cGreenBits = 0;
        ///			pfd.cGreenShift = 0;
        ///			pfd.cBlueBits = 0;
        ///			pfd.cBlueShift = 0;
        ///			pfd.cAlphaBits = 0;
        ///			pfd.cAlphaShift = 0;
        ///
        ///			// no accumulation buffer, accum bits ignored
        ///			pfd.cAccumBits = 0;
        ///			pfd.cAccumRedBits = 0;
        ///			pfd.cAccumGreenBits = 0;
        ///			pfd.cAccumBlueBits = 0;
        ///			pfd.cAccumAlphaBits = 0;
        ///
        ///			// no stencil buffer
        ///			pfd.cStencilBits = 0;
        ///
        ///			// no auxiliary buffer
        ///			pfd.cAuxBuffers = 0;
        ///
        ///			// main layer
        ///			pfd.iLayerType = Gdi.PFD_MAIN_PLANE;
        ///
        ///			// reserved
        ///			pfd.bReserved = 0;
        ///
        ///			// layer masks ignored
        ///			pfd.dwLayerMask = 0;
        ///			pfd.dwVisibleMask = 0;
        ///			pfd.dwDamageMask = 0;
        ///
        ///			pixelFormat = Gdi.ChoosePixelFormat(hdc, &amp;pfd);
        ///			
        ///			// make that the pixel format of the device context
        ///			Gdi.SetPixelFormat(hdc, pixelFormat, &amp;pfd);
        ///		</code>
        /// </remarks>
        /// <seealso cref="ChoosePixelFormat" />
        /// seealso cref="DescribePixelFormat" />
        /// seealso cref="GetPixelFormat" />
        [DllImport(GDI_NATIVE_LIBRARY, EntryPoint = "SetPixelFormat", SetLastError = true), SuppressUnmanagedCodeSecurity]
        public static extern bool SetPixelFormat(IntPtr deviceContext, int pixelFormat, ref PIXELFORMATDESCRIPTOR pixelFormatDescriptor);
        #endregion BOOL SetPixelFormat(HDC hdc, int iPixelFormat, PIXELFORMATDESCRIPTOR* ppfd)

        #region bool SwapBuffers(IntPtr hdc)
        /// <summary>
        /// The SwapBuffers function exchanges the front and back buffers if the current pixel format for the window referenced by the specified device context includes a back buffer.
        /// </summary>
        /// <param name="hdc">Specifies a device context. If the current pixel format for the window referenced by this device context includes a back buffer, the function exchanges the front and back buffers.</param>
        /// <returns>
        ///     <para>If the function succeeds, the return value is TRUE.</para>
        ///     <para>If the function fails, the return value is FALSE. To get extended error information, call GetLastError.</para>
        /// </returns>
        [DllImport(GDI_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION, SetLastError = true), SuppressUnmanagedCodeSecurity]
        public static extern bool SwapBuffers(IntPtr hdc);
        #endregion bool SwapBuffers(IntPtr hdc)

        #region IntPtr CreateFont([In] Int32 nHeight, [In] Int32 nWidth, [In] Int32 nEscapement, [In] Int32 nOrientation, [In] Int32 fnWeight, [In] UInt32 fdwItalic, [In] UInt32 fdwUnderline, [In] UInt32 fdwStrikeOut, [In] UInt32 fdwCharSet, [In] UInt32 fdwOutputPrecision, [In] UInt32 fdwClipPrecision, [In] UInt32 fdwQuality, [In] UInt32 fdwPitchAndFamily, [In] string lpszFace)
        /// <summary>
        /// The CreateFont function creates a logical font with the specified characteristics. The logical font can subsequently be selected as the font for any device.
        /// </summary>
        /// <param name="nHeight">
        ///     <para>The height, in logical units, of the font's character cell or character. The character height value (also known as the em height) is the character cell height value minus the internal-leading value. The font mapper interprets the value specified in nHeight in the following manner.</para>
        ///     <para>
        ///         <list type="table">
        ///             <listheader>
        ///                 <term>Value</term>
        ///                 <description>Meaning</description>
        ///             </listheader>
        ///             <item>
        ///                 <term>> 0</term>
        ///                 <description>The font mapper transforms this value into device units and matches it against the cell height of the available fonts.</description>
        ///             </item>
        ///             <item>
        ///                 <term>0</term>
        ///                 <description>The font mapper uses a default height value when it searches for a match.</description>
        ///             </item>
        ///             <item>
        ///                 <term>< 0</term>
        ///                 <description>The font mapper transforms this value into device units and matches its absolute value against the character height of the available fonts.</description>
        ///             </item>
        ///         </list>
        ///     </para>
        /// </param>
        /// <param name="nWidth">The average width, in logical units, of characters in the requested font. If this value is zero, the font mapper chooses a closest match value. The closest match value is determined by comparing the absolute values of the difference between the current device's aspect ratio and the digitized aspect ratio of available fonts.</param>
        /// <param name="nEscapement">
        ///     <para>The angle, in tenths of degrees, between the escapement vector and the x-axis of the device. The escapement vector is parallel to the base line of a row of text.</para>
        ///     <para>When the graphics mode is set to GM_ADVANCED, you can specify the escapement angle of the string independently of the orientation angle of the string's characters.</para>
        ///     <para>When the graphics mode is set to GM_COMPATIBLE, nEscapement specifies both the escapement and orientation. You should set nEscapement and nOrientation to the same value.</para>
        /// </param>
        /// <param name="nOrientation">The angle, in tenths of degrees, between each character's base line and the x-axis of the device.</param>
        /// <param name="fnWeight">The weight of the font in the range 0 through 1000. For example, 400 is normal and 700 is bold. If this value is zero, a default weight is used.</param>
        /// <param name="fdwItalic">Specifies an italic font if set to TRUE.</param>
        /// <param name="fdwUnderline">Specifies an underlined font if set to TRUE.</param>
        /// <param name="fdwStrikeOut">A strikeout font if set to TRUE.</param>
        /// <param name="fdwCharSet">The character set.</param>
        /// <param name="fdwOutputPrecision">The output precision. The output precision defines how closely the output must match the requested font's height, width, character orientation, escapement, pitch, and font type. It can be one of the following values.</param>
        /// <param name="fdwClipPrecision">The clipping precision. The clipping precision defines how to clip characters that are partially outside the clipping region. It can be one or more of the following values.</param>
        /// <param name="fdwQuality">The output quality. The output quality defines how carefully GDI must attempt to match the logical-font attributes to those of an actual physical font. It can be one of the following values.</param>
        /// <param name="fdwPitchAndFamily">The pitch and family of the font.</param>
        /// <param name="lpszFace">
        ///     <para>A pointer to a null-terminated string that specifies the typeface name of the font. The length of this string must not exceed 32 characters, including the terminating null character. The EnumFontFamilies function can be used to enumerate the typeface names of all currently available fonts. For more information, see the Remarks.</para>
        ///     <para>If lpszFace is NULL or empty string, GDI uses the first font that matches the other specified attributes.</para>
        /// </param>
        /// <returns>
        ///     <para>If the function succeeds, the return value is a handle to a logical font.</para>
        ///     <para>If the function fails, the return value is NULL.</para>
        /// </returns>
        [DllImport(GDI_NATIVE_LIBRARY, SetLastError = true), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr CreateFont(
                  [In] Int32 nHeight
                , [In] Int32 nWidth
                , [In] Int32 nEscapement
                , [In] Int32 nOrientation
                , [In] Int32 fnWeight
                , [In] UInt32 fdwItalic
                , [In] UInt32 fdwUnderline
                , [In] UInt32 fdwStrikeOut
                , [In] UInt32 fdwCharSet
                , [In] UInt32 fdwOutputPrecision
                , [In] UInt32 fdwClipPrecision
                , [In] UInt32 fdwQuality
                , [In] UInt32 fdwPitchAndFamily
                , [In] string lpszFace );

        [DllImport(GDI_NATIVE_LIBRARY, SetLastError = true), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr CreateFont(
                  [In] Int32 nHeight
                , [In] Int32 nWidth
                , [In] Int32 nEscapement
                , [In] Int32 nOrientation
                , [In] FontWeight fnWeight
                , [In] Boolean fdwItalic
                , [In] Boolean fdwUnderline
                , [In] Boolean fdwStrikeOut
                , [In] FontCharSet fdwCharSet
                , [In] FontPrecision fdwOutputPrecision
                , [In] FontClipPrecision fdwClipPrecision
                , [In] FontQuality fdwQuality
                , [In] FontPitchAndFamily fdwPitchAndFamily
                , [In] string lpszFace);
        #endregion IntPtr CreateFont([In] Int32 nHeight, [In] Int32 nWidth, [In] Int32 nEscapement, [In] Int32 nOrientation, [In] Int32 fnWeight, [In] UInt32 fdwItalic, [In] UInt32 fdwUnderline, [In] UInt32 fdwStrikeOut, [In] UInt32 fdwCharSet, [In] UInt32 fdwOutputPrecision, [In] UInt32 fdwClipPrecision, [In] UInt32 fdwQuality, [In] UInt32 fdwPitchAndFamily, [In] string lpszFace)

        #region bool DeleteObject([In] IntPtr hObject)
        /// <summary>
        /// This function deletes a logical pen, brush, font, bitmap, region, or palette, freeing all system resources associated with the object. After the object is deleted, the specified handle is no longer valid.
        /// </summary>
        /// <param name="hObject">Handle to a logical pen, brush, font, bitmap, region, or palette.</param>
        /// <returns>
        ///     <para>Nonzero indicates success.</para>
        ///     <para>Zero indicates that the specified handle is not valid or that the handle is currently selected into a device context.</para>
        ///     <para>To get extended error information, call GetLastError.</para>
        /// </returns>
        [DllImport(GDI_NATIVE_LIBRARY, SetLastError = true), SuppressUnmanagedCodeSecurity]
        public static extern bool DeleteObject([In] IntPtr hObject);
        #endregion bool DeleteObject([In] IntPtr hObject)

        #region IntPtr SelectObject([In] IntPtr hdc, [In] IntPtr hgdiobj)
        /// <summary>
        /// The SelectObject function selects an object into the specified device context (DC). The new object replaces the previous object of the same type.
        /// </summary>
        /// <param name="hdc">A handle to the DC.</param>
        /// <param name="hgdiobj">A handle to the object to be selected. The specified object must have been created by using one of the following functions.</param>
        /// <returns>If the selected object is not a region and the function succeeds, the return value is a handle to the object being replaced. If the selected object is a region and the function succeeds, the return value is one of the following values.</returns>
        [DllImport(GDI_NATIVE_LIBRARY, ExactSpelling = true, PreserveSig = true, SetLastError = true), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr SelectObject([In] IntPtr hdc, [In] IntPtr hgdiobj);
        #endregion IntPtr SelectObject([In] IntPtr hdc, [In] IntPtr hgdiobj)
    }
}
