using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace DMSys.NativeMethods
{
    #region Class Documentation
    /// <summary>
    ///     Kernel binding for .NET, implementing Windows-specific psapi functionality.
    /// </summary>
    /// <remarks>
    ///     Binds functions and definitions in psapi.dll.
    /// </remarks>
    #endregion Class Documentation

    public static class Psapi
    {
        // --- Fields ---
        #region Private Constants
        #region string KERNEL_NATIVE_LIBRARY
        /// <summary>
        ///     Specifies Psapi's native library archive.
        /// </summary>
        /// <remarks>
        ///     Specifies psapi.dll for Windows.
        /// </remarks>
        private const string KERNEL_NATIVE_LIBRARY = "psapi.dll";
        #endregion string KERNEL_NATIVE_LIBRARY

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

        // --- Public Externs ---
        #region IntPtr GetModuleFileNameEx( IntPtr hProcess, IntPtr hModule, StringBuilder lpBaseName, uint nSize)
        /// <summary>
        /// Retrieves the fully-qualified path for the file containing the specified module.
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process that contains the module.
        /// The handle must have the PROCESS_QUERY_INFORMATION and PROCESS_VM_READ access rights. For more information, see Process Security and Access Rights.
        /// The GetModuleFileNameEx function does not retrieve the path for modules that were loaded using the LOAD_LIBRARY_AS_DATAFILE flag. For more information, see LoadLibraryEx.
        /// </param>
        /// <param name="hModule">A handle to the module. If this parameter is NULL, GetModuleFileNameEx returns the path of the executable file of the process specified in hProcess.</param>
        /// <param name="lpFilename ">A pointer to a buffer that receives the fully-qualified path to the module. If the size of the file name is larger than the value of the nSize parameter, the function succeeds but the file name is truncated and null terminated.</param>
        /// <param name="nSize">The size of the lpFilename buffer, in characters.</param>
        /// <returns>
        /// If the function succeeds, the return value specifies the length of the string copied to the buffer.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(KERNEL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION, SetLastError = true), SuppressUnmanagedCodeSecurity]
        static extern IntPtr GetModuleFileNameEx([In] IntPtr hProcess,
                                               [In, Optional] IntPtr hModule,
                                               [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpFilename,
                                               [In, MarshalAs(UnmanagedType.U4)] uint nSize);
        #endregion IntPtr GetModuleFileNameEx( IntPtr hProcess, IntPtr hModule, StringBuilder lpBaseName, uint nSize)
    }
}
