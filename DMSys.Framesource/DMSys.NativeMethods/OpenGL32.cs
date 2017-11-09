using System;
using System.Runtime.InteropServices;
using System.Security;

using LPLAYERPLANEDESCRIPTOR = DMSys.NativeMethods.Gdi32.LAYERPLANEDESCRIPTOR;

namespace DMSys.NativeMethods
{
    #region Class Documentation
    /// <summary>
    ///     <para>
    ///         WGL binding for .NET, implementing Windows-specific OpenGL functionality.
    ///     </para>
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Binds the wgl functions and definitions in opengl32.dll.
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public static class OpenGL32
    {
        // --- Fields ---
        #region Private Constants
        #region string WGL_NATIVE_LIBRARY
        /// <summary>
        ///     <para>
        ///         Specifies WGL's native library archive.
        ///     </para>
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Specifies opengl32.dll for Windows.
        ///     </para>
        /// </remarks>
        private const string WGL_NATIVE_LIBRARY = "opengl32.dll";
        #endregion string WGL_NATIVE_LIBRARY

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
        #region wglSwapLayerBuffers Flags
        #region int WGL_SWAP_MAIN_PLANE
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the main plane.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_MAIN_PLANE     0x00000001
        public const int WGL_SWAP_MAIN_PLANE = 0x00000001;
        #endregion int WGL_SWAP_MAIN_PLANE

        #region int WGL_SWAP_OVERLAY1
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the overlay plane 1.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_OVERLAY1       0x00000002
        public const int WGL_SWAP_OVERLAY1 = 0x00000002;
        #endregion int WGL_SWAP_OVERLAY1

        #region int WGL_SWAP_OVERLAY2
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the overlay plane 2.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_OVERLAY2       0x00000004
        public const int WGL_SWAP_OVERLAY2 = 0x00000004;
        #endregion int WGL_SWAP_OVERLAY2

        #region int WGL_SWAP_OVERLAY3
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the overlay plane 3.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_OVERLAY3       0x00000008
        public const int WGL_SWAP_OVERLAY3 = 0x00000008;
        #endregion int WGL_SWAP_OVERLAY3

        #region int WGL_SWAP_OVERLAY4
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the overlay plane 4.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_OVERLAY4       0x00000010
        public const int WGL_SWAP_OVERLAY4 = 0x00000010;
        #endregion int WGL_SWAP_OVERLAY4

        #region int WGL_SWAP_OVERLAY5
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the overlay plane 5.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_OVERLAY5       0x00000020
        public const int WGL_SWAP_OVERLAY5 = 0x00000020;
        #endregion int WGL_SWAP_OVERLAY5

        #region int WGL_SWAP_OVERLAY1
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the overlay plane 6.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_OVERLAY6       0x00000040
        public const int WGL_SWAP_OVERLAY6 = 0x00000040;
        #endregion int WGL_SWAP_OVERLAY6

        #region int WGL_SWAP_OVERLAY7
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the overlay plane 7.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_OVERLAY7       0x00000080
        public const int WGL_SWAP_OVERLAY7 = 0x00000080;
        #endregion int WGL_SWAP_OVERLAY7

        #region int WGL_SWAP_OVERLAY8
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the overlay plane 8.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_OVERLAY8       0x00000100
        public const int WGL_SWAP_OVERLAY8 = 0x00000100;
        #endregion int WGL_SWAP_OVERLAY8

        #region int WGL_SWAP_OVERLAY9
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the overlay plane 9.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_OVERLAY9       0x00000200
        public const int WGL_SWAP_OVERLAY9 = 0x00000200;
        #endregion int WGL_SWAP_OVERLAY9

        #region int WGL_SWAP_OVERLAY10
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the overlay plane 10.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_OVERLAY10      0x00000400
        public const int WGL_SWAP_OVERLAY10 = 0x00000400;
        #endregion int WGL_SWAP_OVERLAY10

        #region int WGL_SWAP_OVERLAY11
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the overlay plane 11.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_OVERLAY11      0x00000800
        public const int WGL_SWAP_OVERLAY11 = 0x00000800;
        #endregion int WGL_SWAP_OVERLAY11

        #region int WGL_SWAP_OVERLAY12
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the overlay plane 12.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_OVERLAY12      0x00001000
        public const int WGL_SWAP_OVERLAY12 = 0x00001000;
        #endregion int WGL_SWAP_OVERLAY12

        #region int WGL_SWAP_OVERLAY13
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the overlay plane 13.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_OVERLAY13      0x00002000
        public const int WGL_SWAP_OVERLAY13 = 0x00002000;
        #endregion int WGL_SWAP_OVERLAY13

        #region int WGL_SWAP_OVERLAY14
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the overlay plane 14.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_OVERLAY14      0x00004000
        public const int WGL_SWAP_OVERLAY14 = 0x00004000;
        #endregion int WGL_SWAP_OVERLAY14

        #region int WGL_SWAP_OVERLAY15
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the overlay plane 15.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_OVERLAY15      0x00008000
        public const int WGL_SWAP_OVERLAY15 = 0x00008000;
        #endregion int WGL_SWAP_OVERLAY15

        #region int WGL_SWAP_UNDERLAY1
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the underlay plane 1.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_UNDERLAY1      0x00010000
        public const int WGL_SWAP_UNDERLAY1 = 0x00010000;
        #endregion int WGL_SWAP_UNDERLAY1

        #region int WGL_SWAP_UNDERLAY2
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the underlay plane 2.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_UNDERLAY2      0x00020000
        public const int WGL_SWAP_UNDERLAY2 = 0x00020000;
        #endregion int WGL_SWAP_UNDERLAY2

        #region int WGL_SWAP_UNDERLAY3
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the underlay plane 3.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_UNDERLAY3      0x00040000
        public const int WGL_SWAP_UNDERLAY3 = 0x00040000;
        #endregion int WGL_SWAP_UNDERLAY3

        #region int WGL_SWAP_UNDERLAY4
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the underlay plane 4.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_UNDERLAY4      0x00080000
        public const int WGL_SWAP_UNDERLAY4 = 0x00080000;
        #endregion int WGL_SWAP_UNDERLAY4

        #region int WGL_SWAP_UNDERLAY5
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the underlay plane 5.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_UNDERLAY5      0x00100000
        public const int WGL_SWAP_UNDERLAY5 = 0x00100000;
        #endregion int WGL_SWAP_UNDERLAY5

        #region int WGL_SWAP_UNDERLAY6
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the underlay plane 6.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_UNDERLAY6      0x00200000
        public const int WGL_SWAP_UNDERLAY6 = 0x00200000;
        #endregion int WGL_SWAP_UNDERLAY6

        #region int WGL_SWAP_UNDERLAY7
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the underlay plane 7.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_UNDERLAY7      0x00400000
        public const int WGL_SWAP_UNDERLAY7 = 0x00400000;
        #endregion int WGL_SWAP_UNDERLAY7

        #region int WGL_SWAP_UNDERLAY8
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the underlay plane 8.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_UNDERLAY8      0x00800000
        public const int WGL_SWAP_UNDERLAY8 = 0x00800000;
        #endregion int WGL_SWAP_UNDERLAY8

        #region int WGL_SWAP_UNDERLAY9
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the underlay plane 9.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_UNDERLAY9      0x01000000
        public const int WGL_SWAP_UNDERLAY9 = 0x01000000;
        #endregion int WGL_SWAP_UNDERLAY9

        #region int WGL_SWAP_UNDERLAY10
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the underlay plane 10.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_UNDERLAY10     0x02000000
        public const int WGL_SWAP_UNDERLAY10 = 0x02000000;
        #endregion int WGL_SWAP_UNDERLAY10

        #region int WGL_SWAP_UNDERLAY11
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the underlay plane 11.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_UNDERLAY11     0x04000000
        public const int WGL_SWAP_UNDERLAY11 = 0x04000000;
        #endregion int WGL_SWAP_UNDERLAY11

        #region int WGL_SWAP_UNDERLAY12
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the underlay plane 12.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_UNDERLAY12     0x08000000
        public const int WGL_SWAP_UNDERLAY12 = 0x08000000;
        #endregion int WGL_SWAP_UNDERLAY12

        #region int WGL_SWAP_UNDERLAY13
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the underlay plane 13.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_UNDERLAY13     0x10000000
        public const int WGL_SWAP_UNDERLAY13 = 0x10000000;
        #endregion int WGL_SWAP_UNDERLAY13

        #region int WGL_SWAP_UNDERLAY14
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the underlay plane 14.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_UNDERLAY14     0x20000000
        public const int WGL_SWAP_UNDERLAY14 = 0x20000000;
        #endregion int WGL_SWAP_UNDERLAY14

        #region int WGL_SWAP_UNDERLAY15
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the underlay plane 15.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_UNDERLAY15     0x40000000
        public const int WGL_SWAP_UNDERLAY15 = 0x40000000;
        #endregion int WGL_SWAP_UNDERLAY15
        #endregion wglSwapLayerBuffers Flags

        #region wglUseFontOutlines Formats
        #region int WGL_FONT_LINES
        /// <summary>
        ///     <para>
        ///         Fonts with line segments.
        ///     </para>
        /// </summary>
        // #define WGL_FONT_LINES      0
        public const int WGL_FONT_LINES = 0;
        #endregion int WGL_FONT_LINES

        #region int WGL_FONT_POLYGONS
        /// <summary>
        ///     <para>
        ///         Fonts with polygons.
        ///     </para>
        /// </summary>
        // #define WGL_FONT_POLYGONS   1
        public const int WGL_FONT_POLYGONS = 1;
        #endregion int WGL_FONT_POLYGONS
        #endregion wglUseFontOutlines Formats
        #endregion Public Constants

        // --- Public Externs ---
        #region bool wglCopyContext(IntPtr source, IntPtr destination, int mask)
        /// <summary>
        ///     <para>
        ///         The <b>wglCopyContext</b> function copies selected groups of rendering
        ///         states from one OpenGL rendering context to another.
        ///     </para>
        /// </summary>
        /// <param name="source">
        ///     <para>
        ///         Specifies the source OpenGL rendering context whose state information is to
        ///         be copied.
        ///     </para>
        /// </param>
        /// <param name="destination">
        ///     <para>
        ///         Specifies the destination OpenGL rendering context to which state information
        ///         is to be copied.
        ///     </para>
        /// </param>
        /// <param name="mask">
        ///     <para>
        ///         Specifies which groups of the <i>source</i> rendering state are to be copied
        ///         to <i>destination</i>.  It contains the bitwise-OR of the same symbolic names
        ///         that are passed to the <see cref="Tao.OpenGl.Gl.glPushAttrib" /> function.
        ///         You can use <see cref="Tao.OpenGl.Gl.GL_ALL_ATTRIB_BITS" /> to copy all the
        ///         rendering state information.
        ///     </para>
        /// </param>
        /// <returns>
        ///     <para>
        ///         If the function succeeds, the return value is true.  If the function fails,
        ///         the return value is false.  To get extended error information, call
        ///         <see cref="Marshal.GetLastWin32Error" />.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         Using the <b>wglCopyContext</b> function, you can synchronize the rendering
        ///         state of two rendering contexts.  You can only copy the rendering state
        ///         between two rendering contexts within the same process.  The rendering
        ///         contexts must be from the same OpenGL implementation.  For example, you can
        ///         always copy a rendering state between two rendering contexts with identical
        ///         pixel format in the same process.
        ///     </para>
        ///     <para>
        ///         You can copy the same state information available only with the
        ///         <see cref="Tao.OpenGl.Gl.glPushAttrib" /> function.  You cannot copy some
        ///         state information, such as pixel pack/unpack state, render mode state, select
        ///         state, and feedback state.  When you call <b>wglCopyContext</b>, make sure
        ///         that the destination rendering context, <i>destination</i>, is not current to
        ///         any thread.
        ///     </para>
        /// </remarks>
        /// <seealso cref="Tao.OpenGl.Gl.glPushAttrib" />
        /// <seealso cref="wglCreateContext" />
        /// <seealso cref="wglCreateLayerContext" />
        /// <seealso cref="wglShareLists" />
        // WINGDIAPI BOOL  WINAPI wglCopyContext(HGLRC, HGLRC, UINT);
        [DllImport(WGL_NATIVE_LIBRARY, SetLastError = true), SuppressUnmanagedCodeSecurity]
        public static extern bool wglCopyContext(IntPtr source, IntPtr destination, int mask);
        #endregion bool wglCopyContext(IntPtr source, IntPtr destination, int mask)

        #region IntPtr wglCreateContext(IntPtr deviceContext)
        /// <summary>
        ///     <para>
        ///         The <b>wglCreateContext</b> function creates a new OpenGL rendering context,
        ///         which is suitable for drawing on the device referenced by
        ///         <i>deviceContext</i>.  The rendering context has the same pixel format as
        ///         the device context.
        ///     </para>
        /// </summary>
        /// <param name="deviceContext">
        ///     <para>
        ///         Handle to a device context for which the function creates a suitable OpenGL
        ///         rendering context.
        ///     </para>
        /// </param>
        /// <returns>
        ///     <para>
        ///         If the function succeeds, the return value is a valid handle to an OpenGL
        ///         rendering context.
        ///     </para>
        ///     <para>
        ///         If the function fails, the return value is <see cref="IntPtr.Zero"/>.  To get
        ///         extended error information, call <see cref="Marshal.GetLastWin32Error" />.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         A rendering context is not the same as a device context.  Set the pixel
        ///         format of the device context before creating a rendering context.  For more
        ///         information on setting the device context's pixel format, see the
        ///         <see cref="Gdi.SetPixelFormat" /> function.
        ///     </para>
        ///     <para>
        ///         To use OpenGL, you create a rendering context, select it as a thread's
        ///         current rendering context, and then call OpenGL functions.  When you are
        ///         finished with the rendering context, you dispose of it by calling the
        ///         <see cref="wglDeleteContext" /> function.
        ///     </para>
        ///     <para>
        ///         The following code example shows <b>wglCreateContext</b> usage:
        ///     </para>
        ///     <para>
        ///         <code>
        ///             IntPtr hdc;
        ///             IntPtr hglrc;
        ///
        ///             // create a device context
        ///
        ///             // create a rendering context
        ///             hglrc = Wgl.wglCreateContext(hdc);
        ///
        ///             // make it the calling thread's current rendering context
        ///             Wgl.wglMakeCurrent(hdc, hglrc);
        ///
        ///             // call OpenGL APIs as desired...
        ///
        ///             // when the rendering context is no longer needed...
        ///
        ///             // make the rendering context not current
        ///             Wgl.wglMakeCurrent(IntPtr.Zero, IntPtr.Zero);
        ///
        ///             // delete the rendering context
        ///             Wgl.wglDeleteContext(hglrc);
        ///         </code>
        ///     </para>
        /// </remarks>
        /// <seealso cref="Gdi.SetPixelFormat" />
        /// <seealso cref="wglDeleteContext" />
        /// <seealso cref="wglGetCurrentContext" />
        /// <seealso cref="wglGetCurrentDC" />
        /// <seealso cref="wglMakeCurrent" />
        // WINGDIAPI HGLRC WINAPI wglCreateContext(HDC);
        [DllImport(WGL_NATIVE_LIBRARY, SetLastError = true), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr wglCreateContext(IntPtr deviceContext);
        #endregion IntPtr wglCreateContext(IntPtr deviceContext)

        #region IntPtr wglCreateLayerContext(IntPtr deviceContext, int layerPlane)
        /// <summary>
        ///     <para>
        ///         The <b>wglCreateLayerContext</b> function creates a new OpenGL rendering
        ///         context for drawing to a specified layer plane on a device context.
        ///     </para>
        /// </summary>
        /// <param name="deviceContext">
        ///     <para>
        ///         Specifies the device context for a new rendering context.
        ///     </para>
        /// </param>
        /// <param name="layerPlane">
        ///     <para>
        ///         Specifies the layer plane to which you want to bind a rendering context.  The
        ///         value 0 identifies the main plane.  Positive values of <i>layerPlane</i>
        ///         identify overlay planes, where 1 is the first overlay plane over the main
        ///         plane, 2 is the second overlay plane over the first overlay plane, and so on.
        ///         Negative values identify underlay planes, where 1 is the first underlay
        ///         plane under the main plane, 2 is the second underlay plane under the first
        ///         underlay plane, and so on.  The number of overlay and underlay planes is
        ///         given in the <b>bReserved</b> member of the
        ///         <see cref="Gdi.PIXELFORMATDESCRIPTOR" /> structure.
        ///     </para>
        /// </param>
        /// <returns>
        ///     <para>
        ///         If the function succeeds, the return value is a handle to an OpenGL rendering
        ///         context.
        ///     </para>
        ///     <para>
        ///         If the function fails, the return value is <see cref="IntPtr.Zero"/>.  To get
        ///         extended error information, call <see cref="Marshal.GetLastWin32Error" />.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         A rendering context is a port through which all OpenGL commands pass.  Every
        ///         thread that makes OpenGL calls must have one current, active rendering
        ///         context.  A rendering context is not the same as a device context; a
        ///         rendering context contains information specific to OpenGL, while a device
        ///         context contains information specific to GDI.
        ///     </para>
        ///     <para>
        ///         Before you create a rendering context, set the pixel format of the device
        ///         context with the <see cref="Gdi.SetPixelFormat" /> function.  You can use a
        ///         rendering context in a specified layer plane of a window with identical pixel
        ///         formats only.
        ///     </para>
        ///     <para>
        ///         With OpenGL applications that use multiple threads, you create a rendering
        ///         context, select it as the current rendering context of a thread, and make
        ///         OpenGL calls for the specified thread.  When you are finished with the
        ///         rendering context of the thread, call the
        ///         <see cref="Wgl.wglDeleteContext" /> function.
        ///     </para>
        ///     <para>
        ///         The following code example shows how to use <b>wglCreateLayerContext</b>.
        ///     </para>
        ///     <para>
        ///         <code>
        ///             // The following code fragment shows how to render to overlay 1
        ///             // This example assumes that the pixel format of hdc includes
        ///             // overlay plane 1
        ///
        ///             IntPtr hdc;
        ///             IntPtr hglrc;
        ///
        ///             // create a rendering context for overlay plane 1
        ///             hglrc = Wgl.wglCreateLayerContext(hdc, 1);
        ///
        ///             // make it the calling thread's current rendering context
        ///             Wgl.wglMakeCurrent(hdc, hglrc);
        ///
        ///             // call OpenGL functions here...
        ///
        ///             // when the rendering context is no longer needed...
        ///
        ///             // make the rendering context not current
        ///             Wgl.wglMakeCurrent(IntPtr.Zero, IntPtr.Zero);
        ///
        ///             // delete the rendering context
        ///             Wgl.wglDeleteContext(hglrc);
        ///         </code>
        ///     </para>
        /// </remarks>
        /// <seealso cref="Gdi.PIXELFORMATDESCRIPTOR" />
        /// <seealso cref="Gdi.SetPixelFormat" />
        /// <seealso cref="wglCreateContext" />
        /// <seealso cref="wglDeleteContext" />
        /// <seealso cref="wglGetCurrentContext" />
        /// <seealso cref="wglGetCurrentDC" />
        /// <seealso cref="wglMakeCurrent" />
        // WINGDIAPI HGLRC WINAPI wglCreateLayerContext(HDC, int);
        [DllImport(WGL_NATIVE_LIBRARY, SetLastError = true), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr wglCreateLayerContext(IntPtr deviceContext, int layerPlane);
        #endregion IntPtr wglCreateLayerContext(IntPtr deviceContext, int layerPlane)

        #region bool wglDeleteContext(IntPtr renderingContext)
        /// <summary>
        ///     <para>
        ///         The <b>wglDeleteContext</b> function deletes a specified OpenGL rendering
        ///         context.
        ///     </para>
        /// </summary>
        /// <param name="renderingContext">
        ///     <para>
        ///         Handle to an OpenGL rendering context that the function will delete.
        ///     </para>
        /// </param>
        /// <returns>
        ///     <para>
        ///         If the function succeeds, the return value is true.
        ///     </para>
        ///     <para>
        ///         If the function fails, the return value is false.  To get extended error
        ///         information, call <see cref="Marshal.GetLastWin32Error" />.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         It is an error to delete an OpenGL rendering context that is the current
        ///         context of another thread.  However, if a rendering context is the calling
        ///         thread's current context, the <b>wglDeleteContext</b> function changes the
        ///         rendering context to being not current before deleting it.
        ///     </para>
        ///     <para>
        ///         The <b>wglDeleteContext</b> function does not delete the device context
        ///         associated with the OpenGL rendering context when you call the
        ///         <b>wglMakeCurrent</b> function.  After calling <b>wglDeleteContext</b>, you
        ///         must call see cref="Gdi.DeleteDC"  to delete the associated device context.
        ///     </para>
        /// </remarks>
        /// seealso cref="Gdi.DeleteDC" 
        /// <seealso cref="wglCreateContext" />
        /// <seealso cref="wglGetCurrentContext" />
        /// <seealso cref="wglGetCurrentDC" />
        /// <seealso cref="wglMakeCurrent" />
        // WINGDIAPI BOOL WINAPI wglDeleteContext(HGLRC);
        [DllImport(WGL_NATIVE_LIBRARY, SetLastError = true), SuppressUnmanagedCodeSecurity]
        public static extern bool wglDeleteContext(IntPtr renderingContext);
        #endregion bool wglDeleteContext(IntPtr renderingContext)

        #region bool wglDescribeLayerPlane(IntPtr deviceContext, int pixelFormat, int layerPlane, int size, ref Gdi.LAYERPLANEDESCRIPTOR layerPlaneDescriptor)
        /// <summary>
        ///     <para>
        ///         The <b>wglDescribeLayerPlane</b> function obtains information about the layer
        ///         planes of a given pixel format.
        ///     </para>
        /// </summary>
        /// <param name="deviceContext">
        ///     <para>
        ///         Specifies the device context of a window whose layer planes are to be described.
        ///     </para>
        /// </param>
        /// <param name="pixelFormat">
        ///     <para>
        ///         Specifies which layer planes of a pixel format are being described.
        ///     </para>
        /// </param>
        /// <param name="layerPlane">
        ///     <para>
        ///         Specifies the overlay or underlay plane.  Positive values of
        ///         <i>layerPlane</i> identify overlay planes, where 1 is the first overlay plane
        ///         over the main plane, 2 is the second overlay plane over the first overlay
        ///         plane, and so on.  Negative values identify underlay planes, where 1 is the
        ///         first underlay plane under the main plane, 2 is the second underlay plane
        ///         under the first underlay plane, and so on.  The number of overlay and
        ///         underlay planes is given in the <b>bReserved</b> member of the
        ///         <see cref="Gdi.PIXELFORMATDESCRIPTOR" /> structure.
        ///     </para>
        /// </param>
        /// <param name="size">
        ///     <para>
        ///         Specifies the size, in bytes, of the structure pointed to by
        ///         <i>layerPlaneDescriptor</i>.  The <b>wglDescribeLayerPlane</b> function
        ///         stores layer plane data in a <see cref="Gdi.LAYERPLANEDESCRIPTOR" />
        ///         structure, and stores no more than <i>size</i> of data.  Set the value of
        ///         <i>size</i> to the size of <see cref="Gdi.LAYERPLANEDESCRIPTOR" />.
        ///     </para>
        /// </param>
        /// <param name="layerPlaneDescriptor">
        ///     <para>
        ///         Points to a <see cref="Gdi.LAYERPLANEDESCRIPTOR" /> structure.  The
        ///         <b>wglDescribeLayerPlane</b> function sets the value of the structure's data
        ///         members.  The function stores the number of bytes of data copied to the
        ///         structure in the <b>nSize</b> member.
        ///     </para>
        /// </param>
        /// <returns>
        ///     <para>
        ///         If the function succeeds, the return value is true.  In addition, the
        ///         <b>wglDescribeLayerPlane</b> function sets the members of the
        ///         <see cref="Gdi.LAYERPLANEDESCRIPTOR" /> structure pointed to by
        ///         <i>layerPlaneDescriptor</i> according to the specified layer plane
        ///         (<i>layerPlane</i>) of the specified pixel format (<i>pixelFormat</i>).
        ///     </para>
        ///     <para>
        ///         If the function fails, the return value is false.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         The numbering of planes (<i>layerPlane</i>) determines their order.
        ///         Higher-numbered planes overlay lower-numbered planes.
        ///     </para>
        /// </remarks>
        /// <seealso cref="Gdi.DescribePixelFormat" />
        /// <seealso cref="Gdi.LAYERPLANEDESCRIPTOR" />
        /// <seealso cref="Gdi.PIXELFORMATDESCRIPTOR" />
        /// <seealso cref="Wgl.wglCreateLayerContext" />
        // WINGDIAPI BOOL  WINAPI wglDescribeLayerPlane(HDC, int, int, UINT, LPLAYERPLANEDESCRIPTOR);
        [DllImport(WGL_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
        public static extern bool wglDescribeLayerPlane(IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nBytes, ref LPLAYERPLANEDESCRIPTOR plpd );
        #endregion bool wglDescribeLayerPlane(IntPtr deviceContext, int pixelFormat, int layerPlane, int size, ref Gdi.LAYERPLANEDESCRIPTOR layerPlaneDescriptor)

        #region IntPtr wglGetCurrentContext()
        /// <summary>
        ///     <para>
        ///         The <b>wglGetCurrentContext</b> function obtains a handle to the current
        ///         OpenGL rendering context of the calling thread.
        ///     </para>
        /// </summary>
        /// <returns>
        ///     <para>
        ///         If the calling thread has a current OpenGL rendering context,
        ///         <b>wglGetCurrentContext</b> returns a handle to that rendering context.
        ///         Otherwise, the return value is <see cref="IntPtr.Zero" />.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         The current OpenGL rendering context of a thread is associated with a device
        ///         context by means of the <see cref="wglMakeCurrent" /> function.  You can use
        ///         the <see cref="wglGetCurrentDC" /> function to obtain a handle to the device
        ///         context associated with the current OpenGL rendering context.
        ///     </para>
        /// </remarks>
        /// <seealso cref="wglCreateContext" />
        /// <seealso cref="wglDeleteContext" />
        /// <seealso cref="wglGetCurrentDC" />
        /// <seealso cref="wglMakeCurrent" />
        // WINGDIAPI HGLRC WINAPI wglGetCurrentContext(VOID);
        [DllImport(WGL_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr wglGetCurrentContext();
        #endregion IntPtr wglGetCurrentContext()

        #region IntPtr wglGetCurrentDC()
        /// <summary>
        ///     <para>
        ///         The <b>wglGetCurrentDC</b> function obtains a handle to the device context
        ///         that is associated with the current OpenGL rendering context of the calling
        ///         thread.
        ///     </para>
        /// </summary>
        /// <returns>
        ///     <para>
        ///         If the calling thread has a current OpenGL rendering context, the function
        ///         returns a handle to the device context associated with that rendering context
        ///         by means of the <see cref="wglMakeCurrent" /> function.  Otherwise, the
        ///         return value is <see cref="IntPtr.Zero" />.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         You associate a device context with an OpenGL rendering context when it calls
        ///         the <see cref="wglMakeCurrent" /> function.  You can use the
        ///         <see cref="wglGetCurrentContext" /> function to obtain a handle to the
        ///         calling thread's current OpenGL rendering context.
        ///     </para>
        /// </remarks>
        /// <seealso cref="wglCreateContext" />
        /// <seealso cref="wglDeleteContext" />
        /// <seealso cref="wglGetCurrentContext" />
        /// <seealso cref="wglMakeCurrent" />
        // WINGDIAPI HDC   WINAPI wglGetCurrentDC(VOID);
        [DllImport(WGL_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr wglGetCurrentDC();
        #endregion IntPtr wglGetCurrentDC()

        #region int wglGetLayerPaletteEntries(IntPtr deviceContext, int layerPlane, int start, int entries, int[] colors)
        /// <summary>
        ///     <para>
        ///         The <b>wglGetLayerPaletteEntries</b> function retrieves the palette entries
        ///         from a given color-index layer plane for a specified device context.
        ///     </para>
        /// </summary>
        /// <param name="deviceContext">
        ///     <para>
        ///         Specifies the device context of a window whose layer planes are to be
        ///         described.
        ///     </para>
        /// </param>
        /// <param name="layerPlane">
        ///     <para>
        ///         Specifies the overlay or underlay plane.  Positive values of
        ///         <i>layerPlane</i> identify overlay planes, where 1 is the first overlay plane
        ///         over the main plane, 2 is the second overlay plane over the first overlay
        ///         plane, and so on.  Negative values identify underlay planes, where 1 is the
        ///         first underlay plane under the main plane, 2 is the second underlay plane
        ///         under the first underlay plane, and so on.  The number of overlay and
        ///         underlay planes is given in the <b>bReserved</b> member of the
        ///         <see cref="Gdi.PIXELFORMATDESCRIPTOR" /> structure.
        ///     </para>
        /// </param>
        /// <param name="start">
        ///     <para>
        ///         Specifies the first palette entry to be retrieved.
        ///     </para>
        /// </param>
        /// <param name="entries">
        ///     <para>
        ///         Specifies the number of palette entries to be retrieved.
        ///     </para>
        /// </param>
        /// <param name="colors">
        ///     <para>
        ///         Points to an array of <see cref="int" />'s that contain palette RGB color
        ///         values.  The array must contain at least as many structures as specified by
        ///         <i>entries</i>.
        ///     </para>
        ///     <para>
        ///         The color values should be a RGB value as an int in the hexidecimal form
        ///         of 0x00bbggrr.  The low-order byte contains a value for the relative
        ///         intensity of red; the second byte contains a value for green; and the third
        ///         byte contains a value for blue.  The high-order byte must be zero.  The
        ///         maximum value for a single byte is 0xFF.
        ///     </para>
        /// </param>
        /// <returns>
        ///     <para>
        ///         If the function succeeds, the return value is the number of entries that were
        ///         set in the palette in the specified layer plane of the window.
        ///     </para>
        ///     <para>
        ///         If the function fails or when no pixel format is selected, the return value
        ///         is zero.  To get extended error information, call
        ///         <see cref="Marshal.GetLastWin32Error" />.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         Each color-index layer plane in a window has a palette with a size 2^n, where
        ///         n is the number of bit planes in the layer plane.  You cannot modify the
        ///         transparent index of a palette.
        ///     </para>
        ///     <para>
        ///         Use the <see cref="wglRealizeLayerPalette" /> function to realize the layer
        ///         palette.  Initially the layer palette contains only entries for white.
        ///     </para>
        ///     <para>
        ///         The <see cref="wglSetLayerPaletteEntries" /> function doesn't set the palette
        ///         entries of the main plane palette.  To update the main plane palette, use
        ///         GDI palette functions.
        ///     </para>
        /// </remarks>
        /// seealso cref="Gdi.LAYERPLANEDESCRIPTOR"
        /// <seealso cref="Gdi.PIXELFORMATDESCRIPTOR" />
        /// seealso cref="wglDescribeLayerPlane"
        /// <seealso cref="wglRealizeLayerPalette" />
        /// <seealso cref="wglSetLayerPaletteEntries" />
        // WINGDIAPI int WINAPI wglGetLayerPaletteEntries(HDC, int, int, int, COLORREF *);
        [DllImport(WGL_NATIVE_LIBRARY, SetLastError = true), SuppressUnmanagedCodeSecurity]
        public static extern int wglGetLayerPaletteEntries(IntPtr deviceContext, int layerPlane, int start, int entries, int[] colors);
        #endregion int wglGetLayerPaletteEntries(IntPtr deviceContext, int layerPlane, int start, int entries, int[] colors)

        #region IntPtr wglGetProcAddress(string extension)
        /// <summary>
        ///     <para>
        ///         The <b>wglGetProcAddress</b> function returns the address of an OpenGL
        ///         extension function for use with the current OpenGL rendering context.
        ///     </para>
        /// </summary>
        /// <param name="extension">
        ///     <para>
        ///         Points to a null-terminated string that is the name of the extension
        ///         function.  The name of the extension function must be identical to a
        ///         corresponding function implemented by OpenGL.
        ///     </para>
        /// </param>
        /// <returns>
        ///     <para>
        ///         When the function succeeds, the return value is the address of the extension
        ///         function.
        ///     </para>
        ///     <para>
        ///         When no current rendering context exists or the function fails, the return
        ///         value is <see cref="IntPtr.Zero" />.  To get extended error information, call
        ///         <see cref="Marshal.GetLastWin32Error" />.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         The OpenGL library supports multiple implementations of its functions.
        ///         Extension functions supported in one rendering context are not necessarily
        ///         available in a separate rendering context.  Thus, for a given rendering
        ///         context in an application, use the function addresses returned by the
        ///         <b>wglGetProcAddress</b> function only.
        ///     </para>
        ///     <para>
        ///         The spelling and the case of the extension function pointed to by
        ///         <i>extension</i> must be identical to that of a function supported and
        ///         implemented by OpenGL.  Because extension functions are not exported by
        ///         OpenGL, you must use <b>wglGetProcAddress</b> to get the addresses of
        ///         vendor-specific extension functions.
        ///     </para>
        ///     <para>
        ///         The extension function addresses are unique for each pixel format.  All
        ///         rendering contexts of a given pixel format share the same extension function
        ///         addresses.
        ///     </para>
        /// </remarks>
        /// <seealso cref="Tao.OpenGl.Gl.glGetString" />
        /// <seealso cref="wglMakeCurrent" />
        // WINGDIAPI PROC  WINAPI wglGetProcAddress(LPCSTR);
        [DllImport(WGL_NATIVE_LIBRARY, SetLastError = true), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr wglGetProcAddress(string extension);
        #endregion IntPtr wglGetProcAddress(string extension)

        #region bool wglMakeCurrent(IntPtr deviceContext, IntPtr renderingContext)
        /// <summary>
        ///     <para>
        ///         The <b>wglMakeCurrent</b> function makes a specified OpenGL rendering context
        ///         the calling thread's current rendering context.  All subsequent OpenGL calls
        ///         made by the thread are drawn on the device identified by <i>deviceContext</i>.
        ///         You can also use <b>wglMakeCurrent</b> to change the calling thread's current
        ///         rendering context so it's no longer current.
        ///     </para>
        /// </summary>
        /// <param name="deviceContext">
        ///     <para>
        ///         Handle to a device context.  Subsequent OpenGL calls made by the calling
        ///         thread are drawn on the device identified by <i>deviceContext</i>.
        ///     </para>
        /// </param>
        /// <param name="renderingContext">
        ///     <para>
        ///         Handle to an OpenGL rendering context that the function sets as the calling
        ///         thread's rendering context.
        ///     </para>
        ///     <para>
        ///         If <i>rendingContext</i> is <see cref="IntPtr.Zero" />, the function makes
        ///         the calling thread's current rendering context no longer current, and
        ///         releases the device context that is used by the rendering context.  In this
        ///         case, <i>deviceContext</i> is ignored.
        ///     </para>
        /// </param>
        /// <returns>
        ///     <para>
        ///         When the <b>wglMakeCurrent</b> function succeeds, the return value is true;
        ///         otherwise the return value is false.  To get extended error information,
        ///         call <see cref="Marshal.GetLastWin32Error" />.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         The <i>deviceContext</i> parameter must refer to a drawing surface supported
        ///         by OpenGL.  It need not be the same <i>deviceContext</i> that was passed to
        ///         <see cref="wglCreateContext" /> when <i>renderingContext</i> was created, but
        ///         it must be on the same device and have the same pixel format.  GDI
        ///         transformation and clipping in <i>deviceContext</i> are not supported by the
        ///         rendering context.  The current rendering context uses the
        ///         <i>deviceContext</i> device context until the rendering context is no longer
        ///         current.
        ///     </para>
        ///     <para>
        ///         Before switching to the new rendering context, OpenGL flushes any previous
        ///         rendering context that was current to the calling thread.
        ///     </para>
        ///     <para>
        ///         A thread can have one current rendering context.  A process can have multiple
        ///         rendering contexts by means of multithreading.  A thread must set a current
        ///         rendering context before calling any OpenGL functions.  Otherwise, all OpenGL
        ///         calls are ignored.
        ///     </para>
        ///     <para>
        ///         A rendering context can be current to only one thread at a time.  You cannot
        ///         make a rendering context current to multiple threads.
        ///     </para>
        ///     <para>
        ///         An application can perform multithread drawing by making different rendering
        ///         contexts current to different threads, supplying each thread with its own
        ///         rendering context and device context.
        ///     </para>
        ///     <para>
        ///         If an error occurs, the <b>wglMakeCurrent</b> function makes the thread's
        ///         current rendering context not current before returning.
        ///     </para>
        /// </remarks>
        /// <seealso cref="wglCreateContext" />
        /// <seealso cref="wglDeleteContext" />
        /// <seealso cref="wglGetCurrentContext" />
        /// <seealso cref="wglGetCurrentDC" />
        // WINGDIAPI BOOL WINAPI wglMakeCurrent(HDC, HGLRC);
        [DllImport(WGL_NATIVE_LIBRARY, SetLastError = true), SuppressUnmanagedCodeSecurity]
        public static extern bool wglMakeCurrent(IntPtr deviceContext, IntPtr renderingContext);
        #endregion bool wglMakeCurrent(IntPtr deviceContext, IntPtr renderingContext)

        #region bool wglRealizeLayerPalette(IntPtr deviceContext, int layerPlane, bool realize)
        /// <summary>
        ///     <para>
        ///         The <b>wglRealizeLayerPalette</b> function maps palette entries from a given
        ///         color-index layer plane into the physical palette or initializes the palette
        ///         of an RGBA layer plane.
        ///     </para>
        /// </summary>
        /// <param name="deviceContext">
        ///     <para>
        ///         Specifies the device context of a window whose layer plane palette is to be
        ///         realized into the physical palette.
        ///     </para>
        /// </param>
        /// <param name="layerPlane">
        ///     <para>
        ///         Specifies the overlay or underlay plane.  Positive values of
        ///         <i>layerPlane</i> identify overlay planes, where 1 is the first overlay plane
        ///         over the main plane, 2 is the second overlay plane over the first overlay
        ///         plane, and so on.  Negative values identify underlay planes, where 1 is the
        ///         first underlay plane under the main plane, 2 is the second underlay plane
        ///         under the first underlay plane, and so on.  The number of overlay and
        ///         underlay planes is given in the <b>bReserved</b> member of the
        ///         <see cref="Gdi.PIXELFORMATDESCRIPTOR" /> structure.
        ///     </para>
        /// </param>
        /// <param name="realize">
        ///     <para>
        ///         Indicates whether the palette is to be realized into the physical palette.
        ///         When <i>realize</i> is true, the palette entries are mapped into the physical
        ///         palette where available.  When <i>realize</i> is false, the palette entries
        ///         for the layer plane of the window are no longer needed and might be released
        ///         for use by another foreground window.
        ///     </para>
        /// </param>
        /// <returns>
        ///     <para>
        ///         If the function succeeds, the return value is true, even if <i>realize</i> is
        ///         true and the physical palette is not available.  If the function fails or
        ///         when no pixel format is selected, the return value is false.  To get extended
        ///         error information, call <see cref="Marshal.GetLastWin32Error" />.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         The physical palette for a layer plane is a shared resource among windows
        ///         with layer planes.  When more than one window attempts to realize a palette
        ///         for a given physical layer plane, only one palette at a time is realized.
        ///         When you call the <b>wglRealizeLayerPalette</b> function, the layer palette
        ///         of a foreground window is always realized first.
        ///     </para>
        ///     <para>
        ///         When a window's layer palette is realized, its palette entries are always
        ///         mapped one-to-one into the physical palette.  Unlike GDI logical palettes,
        ///         with <b>wglRealizeLayerPalette</b> there is no mapping of other windows'
        ///         layer palettes to the current physical palette.
        ///     </para>
        ///     <para>
        ///         Whenever a window becomes the foreground window, call
        ///         <b>wglRealizeLayerPalette</b> to realize its layer palettes again, even if
        ///         the pixel type of the layer plane is RGBA.
        ///     </para>
        ///     <para>
        ///         Because <b>wglRealizeLayerPalette</b> doesn't realize the palette of the
        ///         main plane, use GDI palette functions to realize the main plane palette.
        ///     </para>
        /// </remarks>
        /// seealso cref="Gdi.LAYERPLANEDESCRIPTOR" 
        /// <seealso cref="Gdi.PIXELFORMATDESCRIPTOR" />
        /// seealso cref="wglDescribeLayerPlane" 
        /// <seealso cref="wglGetLayerPaletteEntries" />
        /// <seealso cref="wglSetLayerPaletteEntries" />
        // WINGDIAPI BOOL  WINAPI wglRealizeLayerPalette(HDC, int, BOOL);
        [DllImport(WGL_NATIVE_LIBRARY, SetLastError = true), SuppressUnmanagedCodeSecurity]
        public static extern bool wglRealizeLayerPalette(IntPtr deviceContext, int layerPlane, bool realize);
        #endregion bool wglRealizeLayerPalette(IntPtr deviceContext, int layerPlane, bool realize)

        #region int wglSetLayerPaletteEntries(IntPtr deviceContext, int layerPlane, int start, int entries, int[] colors)
        /// <summary>
        ///     <para>
        ///         The <b>wglSetLayerPaletteEntries</b> function sets the palette entries in a
        ///         given color-index layer plane for a specified device context.
        ///     </para>
        /// </summary>
        /// <param name="deviceContext">
        ///     <para>
        ///         Specifies the device context of a window whose layer palette is to be set.
        ///     </para>
        /// </param>
        /// <param name="layerPlane">
        ///     <para>
        ///         Specifies an overlay or underlay plane.  Positive values of <i>layerPlane</i>
        ///         identify overlay planes, where 1 is the first overlay plane over the main
        ///         plane, 2 is the second overlay plane over the first overlay plane, and so on.
        ///         Negative values identify underlay planes, where 1 is the first underlay
        ///         plane under the main plane, 2 is the second underlay plane under the first
        ///         underlay plane, and so on.  The number of overlay and underlay planes is
        ///         given in the <b>bReserved</b> member of the
        ///         <see cref="Gdi.PIXELFORMATDESCRIPTOR" /> structure.
        ///     </para>
        /// </param>
        /// <param name="start">
        ///     <para>
        ///         Specifies the first palette entry to be set.
        ///     </para>
        /// </param>
        /// <param name="entries">
        ///     <para>
        ///         Specifies the number of palette entries to be set.
        ///     </para>
        /// </param>
        /// <param name="colors">
        ///     <para>
        ///         Points to an array of <see cref="int" />'s that contain palette RGB color
        ///         values.  The array must contain at least as many structures as specified by
        ///         <i>entries</i>.
        ///     </para>
        ///     <para>
        ///         The color values should be a RGB value as an int in the hexidecimal form
        ///         of 0x00bbggrr.  The low-order byte contains a value for the relative
        ///         intensity of red; the second byte contains a value for green; and the third
        ///         byte contains a value for blue.  The high-order byte must be zero.  The
        ///         maximum value for a single byte is 0xFF.
        ///     </para>
        /// </param>
        /// <returns>
        ///     <para>
        ///         If the function succeeds, the return value is the number of entries that were
        ///         set in the palette in the specified layer plane of the window.  If the
        ///         function fails or no pixel format is selected, the return value is zero.  To
        ///         get extended error information, call
        ///         <see cref="Marshal.GetLastWin32Error" />.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         Each color-index plane in a window has a palette with a size 2^n, where n is
        ///         the number of bit planes in the layer plane.  You cannot modify the
        ///         transparent index of a palette.
        ///     </para>
        ///     <para>
        ///         Use the <see cref="wglRealizeLayerPalette" /> function to realize the layer
        ///         palette.  Initially the layer palette contains only entries for white.
        ///     </para>
        ///     <para>
        ///         The <b>wglSetLayerPaletteEntries</b> function doesn't set the palette entries
        ///         of the main plane palette.  To update the main plane palette, use GDI palette
        ///         functions.
        ///     </para>
        /// </remarks>
        /// seealso cref="Gdi.LAYERPLANEDESCRIPTOR" 
        /// <seealso cref="Gdi.PIXELFORMATDESCRIPTOR" />
        /// seealso cref="wglDescribeLayerPlane" 
        /// <seealso cref="wglGetLayerPaletteEntries" />
        /// <seealso cref="wglRealizeLayerPalette" />
        // WINGDIAPI int WINAPI wglSetLayerPaletteEntries(HDC, int, int, int, CONST COLORREF *);
        [DllImport(WGL_NATIVE_LIBRARY, SetLastError = true), SuppressUnmanagedCodeSecurity]
        public static extern int wglSetLayerPaletteEntries(IntPtr deviceContext, int layerPlane, int start, int entries, int[] colors);
        #endregion int wglSetLayerPaletteEntries(IntPtr deviceContext, int layerPlane, int start, int entries, int[] colors)

        #region bool wglShareLists(IntPtr source, IntPtr destination)
        /// <summary>
        ///     <para>
        ///         The <b>wglShareLists</b> function enables multiple OpenGL rendering contexts
        ///         to share a single display-list space.
        ///     </para>
        /// </summary>
        /// <param name="source">
        ///     <para>
        ///         Specifies the OpenGL rendering context with which to share display lists.
        ///     </para>
        /// </param>
        /// <param name="destination">
        ///     <para>
        ///         Specifies the OpenGL rendering context to share display lists with
        ///         <i>source</i>.  The <i>destination</i> parameter should not contain any
        ///         existing display lists when <b>wglShareLists</b> is called.
        ///     </para>
        /// </param>
        /// <returns>
        ///     <para>
        ///         When the function succeeds, the return value is true.
        ///     </para>
        ///     <para>
        ///         When the function fails, the return value is false and the display lists are
        ///         not shared.  To get extended error information, call
        ///         <see cref="Marshal.GetLastWin32Error" />.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         When you create an OpenGL rendering context, it has its own display-list
        ///         space.  The <b>wglShareLists</b> function enables a rendering context to
        ///         share the display-list space of another rendering context; any number of
        ///         rendering contexts can share a single display-list space.  Once a rendering
        ///         context shares a display-list space, the rendering context always uses the
        ///         display-list space until the rendering context is deleted.  When the last
        ///         rendering context of a shared display-list space is deleted, the shared
        ///         display-list space is deleted.  All the indexes and definitions of display
        ///         lists in a shared display-list space are shared.
        ///     </para>
        ///     <para>
        ///         You can only share display lists with rendering contexts within the same
        ///         process.  However, not all rendering contexts in a process can share display
        ///         lists.  Rendering contexts can share display lists only if they use the same
        ///         implementation of OpenGL functions.  All client rendering contexts of a given
        ///         pixel format can always share display lists.
        ///     </para>
        ///     <para>
        ///         All rendering contexts of a shared display list must use an identical pixel
        ///         format.  Otherwise the results depend on the implementation of OpenGL used.
        ///     </para>
        ///     <para>
        ///         <b>NOTE</b>
        ///     </para>
        ///     <para>
        ///         The <b>wglShareLists</b> function is only available with OpenGL version 1.01
        ///         or later.  To determine the version number of the implementation of OpenGL,
        ///         call <see cref="Tao.OpenGl.Gl.glGetString" />.
        ///     </para>
        /// </remarks>
        /// <seealso cref="Tao.OpenGl.Gl.glGetString" />
        // WINGDIAPI BOOL  WINAPI wglShareLists(HGLRC, HGLRC);
        [DllImport(WGL_NATIVE_LIBRARY, SetLastError = true), SuppressUnmanagedCodeSecurity]
        public static extern bool wglShareLists(IntPtr source, IntPtr destination);
        #endregion bool wglShareLists(IntPtr source, IntPtr destination)

        #region bool wglSwapLayerBuffers(IntPtr deviceContext, int planes)
        /// <summary>
        ///     <para>
        ///         The <b>wglSwapLayerBuffers</b> function swaps the front and back buffers in
        ///         the overlay, underlay, and main planes of the window referenced by a
        ///         specified device context.
        ///     </para>
        /// </summary>
        /// <param name="deviceContext">
        ///     <para>
        ///         Specifies the device context of a window whose layer plane palette is to be
        ///         realized into the physical palette.
        ///     </para>
        /// </param>
        /// <param name="planes">
        ///     <para>
        ///         Specifies the overlay, underlay, and main planes whose front and back buffers
        ///         are to be swapped.  The <b>bReserved</b> member of the
        ///         <see cref="Gdi.PIXELFORMATDESCRIPTOR" /> structure specifies the number of
        ///         overlay and underlay planes.  The <i>planes</i> parameter is a bitwise
        ///         combination of the following values:
        ///     </para>
        ///     <para>
        ///         <list type="table">
        ///             <listheader>
        ///                 <term>Value</term>
        ///                 <description>Meaning</description>
        ///             </listheader>
        ///             <item>
        ///                 <term>WGL_SWAP_MAIN_PLANE</term>
        ///                 <description>
        ///                     Swaps the front and back buffers of the main plane.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>WGL_SWAP_OVERLAYi</term>
        ///                 <description>
        ///                     Swaps the front and back buffers of the overlay plane i, where
        ///                     i is an integer between 1 and 15.  WGL_SWAP_OVERLAY1 identifies
        ///                     the first overlay plane over the main plane, WGL_SWAP_OVERLAY2
        ///                     identifies the second overlay plane over the first overlay plane,
        ///                     and so on.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>WGL_SWAP_UNDERLAYi</term>
        ///                 <description>
        ///                     Swaps the front and back buffers of the underlay plane i, where i
        ///                     is an integer between 1 and 15.  WGL_SWAP_UNDERLAY1 identifies
        ///                     the first underlay plane under the main plane, WGL_SWAP_UNDERLAY2
        ///                     identifies the second underlay plane under the first underlay
        ///                     plane, and so on.
        ///                 </description>
        ///             </item>
        ///         </list>
        ///     </para>
        /// </param>
        /// <returns>
        ///     <para>
        ///         If the function succeeds, the return value is true.  If the function fails,
        ///         the return value is false.  To get extended error information, call
        ///         <see cref="Marshal.GetLastWin32Error" />.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         When a layer plane doesn't include a back buffer, calling the
        ///         <b>wglSwapLayerBuffers</b> function has no effect on that layer plane.  After
        ///         you call <b>wglSwapLayerBuffers</b>, the state of the back buffer content is
        ///         given in the corresponding /* see cref="Gdi.LAYERPLANEDESCRIPTOR" /> */ structure
        ///         of the layer plane or in the <see cref="Gdi.PIXELFORMATDESCRIPTOR" />
        ///         structure of the main plane.  The <b>wglSwapLayerBuffers</b> function swaps
        ///         the front and back buffers in the specified layer planes simultaneously.
        ///     </para>
        ///     <para>
        ///         Some devices don't support swapping layer planes individually; they swap all
        ///         layer planes as a group.  When the <b>PFD_SWAP_LAYER_BUFFERS</b> flag of the
        ///         <see cref="Gdi.PIXELFORMATDESCRIPTOR" /> structure is set, it indicates that
        ///         a device can swap individual layer planes and that you can call
        ///         <b>wglSwapLayerBuffers</b>.
        ///     </para>
        ///     <para>
        ///         With applications that use multiple threads, before calling
        ///         <b>wglSwapLayerBuffers</b>, clear all drawing commands in all threads drawing
        ///         to the same window.
        ///     </para>
        /// </remarks>
        /// /* seealso cref="Gdi.LAYERPLANEDESCRIPTOR" />*/
        /// <seealso cref="Gdi.PIXELFORMATDESCRIPTOR" />
        /// <seealso cref="Gdi.SwapBuffers" />
        // WINGDIAPI BOOL  WINAPI wglSwapLayerBuffers(HDC, UINT);
        [DllImport(WGL_NATIVE_LIBRARY, SetLastError = true), SuppressUnmanagedCodeSecurity]
        public static extern bool wglSwapLayerBuffers(IntPtr deviceContext, int planes);
        #endregion bool wglSwapLayerBuffers(IntPtr deviceContext, int planes)

        #region bool wglUseFontBitmaps(IntPtr deviceContext, int first, int count, int listBase)
        /// <summary>
        ///     <para>
        ///         The <b>wglUseFontBitmaps</b> function creates a set of bitmap display lists
        ///         for use in the current OpenGL rendering context.  The set of bitmap display
        ///         lists is based on the glyphs in the currently selected font in the device
        ///         context.  You can then use bitmaps to draw characters in an OpenGL image.
        ///     </para>
        ///     <para>
        ///         The <b>wglUseFontBitmaps</b> function creates <i>count</i> display lists,
        ///         one for each of a run of <i>count</i> glyphs that begins with the
        ///         <i>first</i> glyph in the <i>deviceContext</i> parameter's selected fonts.
        ///     </para>
        /// </summary>
        /// <param name="deviceContext">
        ///     <para>
        ///         Specifies the device context whose currently selected font will be used to
        ///         form the glyph bitmap display lists in the current OpenGL rendering context.
        ///     </para>
        /// </param>
        /// <param name="first">
        ///     <para>
        ///         Specifies the first glyph in the run of glyphs that will be used to form
        ///         glyph bitmap display lists.
        ///     </para>
        /// </param>
        /// <param name="count">
        ///     <para>
        ///         Specifies the number of glyphs in the run of glyphs that will be used to
        ///         form glyph bitmap display lists.  The function creates <i>count</i> display
        ///         lists, one for each glyph in the run.
        ///     </para>
        /// </param>
        /// <param name="listBase">
        ///     <para>
        ///         Specifies a starting display list.
        ///     </para>
        /// </param>
        /// <returns>
        ///     <para>
        ///         If the function succeeds, the return value is true.
        ///     </para>
        ///     <para>
        ///         If the function fails, the return value is false.  To get extended error
        ///         information, call <see cref="Marshal.GetLastWin32Error" />.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         The <b>wglUseFontBitmaps</b> function defines <i>count</i> display lists in
        ///         the current OpenGL rendering context.  Each display list has an identifying
        ///         number, starting at <i>listBase</i>.  Each display list consists of a single
        ///         call to <see cref="Tao.OpenGl.Gl.glBitmap(int, int, float, float, float, float, object)" />.  The definition of bitmap
        ///         <i>listBase + i</i> is taken from the glyph <i>first + i</i> of the font
        ///         currently selected in the device context specified by <i>deviceContext</i>.
        ///         If a glyph is not defined, then the function defines an empty display list
        ///         for it.
        ///     </para>
        ///     <para>
        ///         The <b>wglUseFontBitmaps</b> function creates bitmap text in the plane of the
        ///         screen.  It enables the labeling of objects in OpenGL.
        ///     </para>
        ///     <para>
        ///         In the current version of Microsoft's implementation of OpenGL in Windows NT
        ///         and Windows 95, you cannot make GDI calls to a device context that has a
        ///         double-buffered pixel format.  Therefore, you cannot use the GDI fonts and
        ///         text functions with such device contexts.  You can use the
        ///         <b>wglUseFontBitmaps</b> function to circumvent this limitation and draw text
        ///         in a double-buffered device context.
        ///     </para>
        ///     <para>
        ///         The function determines the parameters of each call to
        ///         <see cref="Tao.OpenGl.Gl.glBitmap(int, int, float, float, float, float, object)" /> as follows:
        ///     </para>
        ///     <para>
        ///         <list type="table">
        ///             <listheader>
        ///                 <term>glBitmap Parameter</term>
        ///                 <description>Meaning</description>
        ///             </listheader>
        ///             <item>
        ///                 <term>width</term>
        ///                 <description>
        ///                     The width of the glyph's bitmap, as returned in the
        ///                     <b>gmBlackBoxX</b> member of the glyph's
        ///                  /*   see cref="Gdi.GLYPHMETRICS"  */structure.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>height</term>
        ///                 <description>
        ///                     The height of the glyph's bitmap, as returned in the
        ///                     <b>gmBlackBoxY</b> member of the glyph's
        ///                 /*    see cref="Gdi.GLYPHMETRICS"  */structure.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>xorig</term>
        ///                 <description>
        ///                     The x offset of the glyph's origin, as returned in the
        ///                     <b>gmptGlyphOrigin.x</b> member of the glyph's
        ///                    /* see cref="Gdi.GLYPHMETRICS" /> */ structure.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>yorig</term>
        ///                 <description>
        ///                     The y offset of the glyph's origin, as returned in the
        ///                     <b>gmptGlyphOrigin.y</b> member of the glyph's
        ///                     /* see cref="Gdi.GLYPHMETRICS" /> */structure.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>xmove</term>
        ///                 <description>
        ///                     The horizontal distance to the origin of the next character cell,
        ///                     as returned in the <b>gmCellIncX</b> member of the glyph's
        ///                    /* see cref="Gdi.GLYPHMETRICS" /> */structure.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>ymove</term>
        ///                 <description>
        ///                     The vertical distance to the origin of the next character cell as
        ///                     returned in the <b>gmCellIncY</b> member of the glyph's
        ///                     /* see cref="Gdi.GLYPHMETRICS" /> */structure.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>bitmap</term>
        ///                 <description>
        ///                     The bitmap for the glyph, as returned by
        ///                    /* see cref="Gdi.GetGlyphOutline" />*/  with <i>uFormat</i> equal to 1.
        ///                 </description>
        ///             </item>
        ///         </list>
        ///     </para>
        ///     <para>
        ///         The following code example shows how to use <b>wglUseFontBitmaps</b> to draw
        ///         some text:
        ///     </para>
        ///     <para>
        ///         <code>
        ///             IntPtr hdc;
        ///             IntPtr hglrc;
        ///
        ///             // create a rendering context
        ///             hglrc = Wgl.wglCreateContext(hdc);
        ///
        ///             // make it the calling thread's current rendering context
        ///             Wgl.wglMakeCurrent(hdc, hglrc);
        ///
        ///             // now we can call OpenGL API
        ///
        ///             // make the system font the device context's selected font
        ///             Gdi.SelectObject(hdc, Gdi.GetStockObject(SYSTEM_FONT));
        ///
        ///             // create the bitmap display lists
        ///             // we're making images of glyphs 0 thru 255
        ///             // the display list numbering starts at 1000, an arbitrary choice
        ///             Wgl.wglUseFontBitmaps(hdc, 0, 255, 1000);
        ///
        ///             // display a string:
        ///             // indicate start of glyph display lists
        ///             GL.glListBase(1000);
        ///
        ///             z/ now draw the characters in a string
        ///             GL.glCallLists(24, GL.GL_UNSIGNED_SHORT, "Hello Win32 OpenGL World");
        ///         </code>
        ///     </para>
        /// </remarks>
        /// /* seealso cref="Gdi.GetGlyphOutline" />*/
        /// <seealso cref="Tao.OpenGl.Gl.glBitmap(int, int, float, float, float, float, object)" />
        /// <seealso cref="Tao.OpenGl.Gl.glCallLists(int, int, object)" />
        /// <seealso cref="Tao.OpenGl.Gl.glListBase" />
        /// /* seealso cref="Gdi.GLYPHMETRICS" />*/
        /// <seealso cref="Wgl.wglUseFontOutlines" />
        // WINGDIAPI BOOL WINAPI wglUseFontBitmapsA(HDC, DWORD, DWORD, DWORD);
        // WINGDIAPI BOOL WINAPI wglUseFontBitmapsW(HDC, DWORD, DWORD, DWORD);
        [DllImport(WGL_NATIVE_LIBRARY, SetLastError = true), SuppressUnmanagedCodeSecurity]
        public static extern bool wglUseFontBitmaps(IntPtr deviceContext, int first, int count, int listBase);
        #endregion bool wglUseFontBitmaps(IntPtr deviceContext, int first, int count, int listBase)

        #region bool wglUseFontOutlines(IntPtr deviceContext, int first, int count, int listBase, float deviation, float extrusion, int format, [Out, MarshalAs(UnmanagedType.LPArray)] Gdi.GLYPHMETRICSFLOAT[] glyphMetrics)
        /// <summary>
        ///     <para>
        ///         The <b>wglUseFontOutlines</b> function creates a set of display lists, one
        ///         for each glyph of the currently selected outline font of a device context,
        ///         for use with the current rendering context.  The display lists are used to
        ///         draw 3-D characters of TrueType fonts.  Each display list describes a glyph
        ///         outline in floating-point coordinates.
        ///     </para>
        ///     <para>
        ///         The run of glyphs begins with the <i>first</i> glyph of the font of the
        ///         specified device context.  The em square size of the font, the notional grid
        ///         size of the original font outline from which the font is fitted, is mapped to
        ///         1.0 in the x- and y-coordinates in the display lists.  The <i>extrusion</i>
        ///         parameter sets how much depth the font has in the z direction.
        ///     </para>
        ///     <para>
        ///         The <i>glyphMetrics</i> parameter returns a
        ///         <see cref="Gdi.GLYPHMETRICSFLOAT" /> structure that contains information
        ///         about the placement and orientation of each glyph in a character cell.
        ///     </para>
        /// </summary>
        /// <param name="deviceContext">
        ///     <para>
        ///         Specifies the device context with the desired outline font.  The outline font
        ///         of <i>deviceContext</i> is used to create the display lists in the current
        ///         rendering context.
        ///     </para>
        /// </param>
        /// <param name="first">
        ///     <para>
        ///         Specifies the first of the set of glyphs that form the font outline display
        ///         lists.
        ///     </para>
        /// </param>
        /// <param name="count">
        ///     <para>
        ///         Specifies the number of glyphs in the set of glyphs used to form the font
        ///         outline display lists.  The <b>wglUseFontOutlines</b> function creates
        ///         <i>count</i> display lists, one display list for each glyph in a set of
        ///         glyphs.
        ///     </para>
        /// </param>
        /// <param name="listBase">
        ///     <para>
        ///         Specifies a starting display list.
        ///     </para>
        /// </param>
        /// <param name="deviation">
        ///     <para>
        ///         Specifies the maximum chordal deviation from the original outlines.  When
        ///         <i>deviation</i> is zero, the chordal deviation is equivalent to one design
        ///         unit of the original font.  The value of <i>deviation</i> must be equal to
        ///         or greater than 0.
        ///     </para>
        /// </param>
        /// <param name="extrusion">
        ///     <para>
        ///         Specifies how much a font is extruded in the negative z direction.  The
        ///         value must be equal to or greater than 0.  When <i>extrusion</i> is 0, the
        ///         display lists are not extruded.
        ///     </para>
        /// </param>
        /// <param name="format">
        ///     <para>
        ///         Specifies the format, either <see cref="WGL_FONT_LINES" /> or
        ///         <see cref="WGL_FONT_POLYGONS" />, to use in the display lists.  When
        ///         <i>format</i> is <see cref="WGL_FONT_LINES" />, the
        ///         <b>wglUseFontOutlines</b> function creates fonts with line segments.  When
        ///         <i>format</i> is <see cref="WGL_FONT_POLYGONS" />, <b>wglUseFontOutlines</b>
        ///         creates fonts with polygons.
        ///     </para>
        /// </param>
        /// <param name="glyphMetrics">
        ///     <para>
        ///         Points to an array of <i>count</i> <see cref="Gdi.GLYPHMETRICSFLOAT" />
        ///         structures that is to receive the metrics of the glyphs.  When
        ///         <i>glyphMetrics</i> is null, no glyph metrics are returned.
        ///     </para>
        /// </param>
        /// <returns>
        ///     <para>
        ///         When the function succeeds, the return value is true.
        ///     </para>
        ///     <para>
        ///         When the function fails, the return value is false and no display lists are
        ///         generated.  To get extended error information, call
        ///         <see cref="Marshal.GetLastWin32Error" />.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         The <b>wglUseFontOutlines</b> function defines the glyphs of an outline font
        ///         with display lists in the current rendering context.  The
        ///         <b>wglUseFontOutlines</b> function works with TrueType fonts only; stroke and
        ///         raster fonts are not supported.
        ///     </para>
        ///     <para>
        ///         Each display list consists of either line segments or polygons, and has a
        ///         unique identifying number starting with the <i>listBase</i> number.
        ///     </para>
        ///     <para>
        ///         The <b>wglUseFontOutlines</b> function approximates glyph outlines by
        ///         subdividing the quadratic B-spline curves of the outline into line segments,
        ///         until the distance between the outline and the interpolated midpoint is
        ///         within the value specified by <i>deviation</i>.  This is the final format
        ///         used when <i>format</i> is <see cref="WGL_FONT_LINES" />.  When you specify
        ///         <see cref="WGL_FONT_LINES" />, the display lists created don't contain any
        ///         normals; thus lighting doesn't work properly.  To get the correct lighting of
        ///         lines use <see cref="WGL_FONT_POLYGONS" /> and set
        ///         <c>Gl.glPolygonMode(Gl.GL_FRONT, Gl.GL_LINE)</c>.  When you specify
        ///         <i>format</i> as <see cref="WGL_FONT_POLYGONS" /> the outlines are further
        ///         tessellated into separate triangles, triangle fans, triangle strips, or
        ///         quadrilateral strips to create the surface of each glyph.  With
        ///         <see cref="WGL_FONT_POLYGONS" />, the created display lists call
        ///         <c>Gl.glFrontFace(Gl.GL_CW)</c> or <c>Gl.glFrontFace(Gl.GL_CCW)</c>; thus
        ///         the current front-face value might be altered.  For the best appearance of
        ///         text with <see cref="WGL_FONT_POLYGONS" />, cull the back faces as follows:
        ///     </para>
        ///     <para>
        ///         <code>
        ///             Gl.glCullFace(Gl.GL_BACK);
        ///             Gl.glEnable(Gl.GL_CULL_FACE);
        ///         </code>
        ///     </para>
        ///     <para>
        ///         A <see cref="Gdi.GLYPHMETRICSFLOAT" /> structure contains information about
        ///         the placement and orientation of each glyph in a character cell.  The
        ///         <i>glyphMetrics</i> parameter is an array of
        ///         <see cref="Gdi.GLYPHMETRICSFLOAT" /> structures holding the entire set of
        ///         glyphs for a font.  Each display list ends with a translation specified with
        ///         the <b>gmfCellIncX</b> and <b>gmfCellIncY</b> members of the corresponding
        ///         <see cref="Gdi.GLYPHMETRICSFLOAT" /> structure.  The translation enables the
        ///         drawing of successive characters in their natural direction with a single
        ///         call to <see cref="Tao.OpenGl.Gl.glCallLists(int, int, object)" />.
        ///     </para>
        ///     <para>
        ///         <b>NOTE</b>
        ///     </para>
        ///     <para>
        ///         With the current release of OpenGL for Windows NT and Windows 95, you cannot
        ///         make GDI calls to a device context when a pixel format is double-buffered.
        ///         You can work around this limitation by using <b>wglUseFontOutlines</b> and
        ///         <see cref="wglUseFontBitmaps" />, when using double-buffered device contexts.
        ///     </para>
        ///     <para>
        ///         The following code example shows how to draw text using
        ///         <b>wglUseFontOutlines</b>:
        ///     </para>
        ///     <para>
        ///         <code>
        ///             IntPtr hdc;  // A TrueType font has already been selected
        ///             IntPtr hglrc;
        ///             Gdi.GLYPHMETRICSFLOAT[] agmf = new Gdi.GLYPHMETRICSFLOAT[256];
        ///
        ///             // Make hglrc the calling thread's current rendering context
        ///             Wgl.wglMakeCurrent(hdc, hglrc);
        ///
        ///             // create display lists for glyphs 0 through 255 with 0.1 extrusion
        ///             // and default deviation. The display list numbering starts at 1000
        ///             // (it could be any number)
        ///             Wgl.wglUseFontOutlines(hdc, 0, 255, 1000, 0.0f, 0.1f, Wgl.WGL_FONT_POLYGONS, ref agmf);
        ///
        ///             // Set up transformation to draw the string
        ///             Gl.glLoadIdentity();
        ///             Gl.glTranslate(0.0f, 0.0f, -5.0f)
        ///             Gl.glScalef(2.0f, 2.0f, 2.0f);
        ///
        ///             // Display a string
        ///             Gl.glListBase(1000); // Indicates the start of display lists for the glyphs
        ///
        ///             // Draw the characters in a string
        ///             Gl.glCallLists(24, Gl.GL_UNSIGNED_SHORT, "Hello Win32 OpenGL World.");
        ///         </code>
        ///     </para>
        /// </remarks>
        /// <seealso cref="Gdi.GLYPHMETRICSFLOAT" />
        /// <seealso cref="Tao.OpenGl.Gl.glCallLists(int, int, object)" />
        /// <seealso cref="Tao.OpenGl.Gl.glListBase" />
        /// <seealso cref="Tao.OpenGl.Gl.glTexGenf" />
        /// <seealso cref="wglUseFontBitmaps" />
        // WINGDIAPI BOOL WINAPI wglUseFontOutlinesA(HDC, DWORD, DWORD, DWORD, FLOAT, FLOAT, int, LPGLYPHMETRICSFLOAT);
        // WINGDIAPI BOOL WINAPI wglUseFontOutlinesW(HDC, DWORD, DWORD, DWORD, FLOAT, FLOAT, int, LPGLYPHMETRICSFLOAT);
        [DllImport(WGL_NATIVE_LIBRARY, SetLastError = true), SuppressUnmanagedCodeSecurity]
        public static extern bool wglUseFontOutlines(IntPtr deviceContext, int first, int count, int listBase, float deviation, float extrusion, int format, [Out, MarshalAs(UnmanagedType.LPArray)] Gdi32.GLYPHMETRICSFLOAT[] glyphMetrics);
        #endregion bool wglUseFontOutlines(IntPtr deviceContext, int first, int count, int listBase, float deviation, float extrusion, int format, [Out, MarshalAs(UnmanagedType.LPArray)] Gdi.GLYPHMETRICSFLOAT[] glyphMetrics)

      
    }
}
