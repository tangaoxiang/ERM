using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Security;
using System.ComponentModel;
using System.Drawing.Printing;
namespace ERM.UI
{
    public class CustomPaperSize
    {
        public void AddCustomPaperSize(string printerName, string paperName, float widthMm, float heightMm)
        {
            if (PlatformID.Win32NT == Environment.OSVersion.Platform)
            {
                const int PRINTER_ACCESS_USE = 0x00000008;
                const int PRINTER_ACCESS_ADMINISTER = 0x00000004;
                const int FORM_PRINTER = 0x00000002;
                structPrinterDefaults defaults = new structPrinterDefaults();
                defaults.pDatatype = null;
                defaults.pDevMode = IntPtr.Zero;
                //defaults.DesiredAccess = PRINTER_ACCESS_ADMINISTER | PRINTER_ACCESS_USE;
                IntPtr hPrinter = IntPtr.Zero;
                if (OpenPrinter(printerName, out hPrinter, ref defaults))
                {
                    try
                    {
                        //DeleteForm(hPrinter, paperName);
                        //FormInfo1 formInfo = new FormInfo1();
                        //formInfo.Flags = 0;
                        //formInfo.pName = paperName;
                        //formInfo.Size.width = (int)(widthMm * 1000.0);
                        //formInfo.Size.height = (int)(heightMm * 1000.0);
                        //formInfo.ImageableArea.left = 0;
                        //formInfo.ImageableArea.right = formInfo.Size.width;
                        //formInfo.ImageableArea.top = 0;
                        //formInfo.ImageableArea.bottom = formInfo.Size.height;
                        //if (!AddForm(hPrinter, 1, ref formInfo))
                        //{
                        //    StringBuilder strBuilder = new StringBuilder();
                        //    strBuilder.AppendFormat("Failed to add the custom paper size {0} to the printer {1}, System error number: {2}",
                        //        paperName, printerName, GetLastError());
                        //    throw new ApplicationException(strBuilder.ToString());
                        //}
                        const int DM_OUT_BUFFER = 2;
                        const int DM_IN_BUFFER = 8;
                        structDevMode devMode = new structDevMode();
                        IntPtr hPrinterInfo, hDummy;
                        PRINTER_INFO_9 printerInfo;
                        printerInfo.pDevMode = IntPtr.Zero;
                        int iPrinterInfoSize, iDummyInt;
                        int iDevModeSize = DocumentProperties(IntPtr.Zero, hPrinter, printerName, IntPtr.Zero, IntPtr.Zero, 0);
                        if (iDevModeSize < 0)
                            throw new ApplicationException("Cannot get the size of the DEVMODE structure.");
                        IntPtr hDevMode = Marshal.AllocCoTaskMem(iDevModeSize + 100);
                        int iRet = DocumentProperties(IntPtr.Zero, hPrinter, printerName, hDevMode, IntPtr.Zero, DM_OUT_BUFFER);
                        if (iRet < 0)
                            throw new ApplicationException("Cannot get the DEVMODE structure.");
                        devMode = (structDevMode)Marshal.PtrToStructure(hDevMode, devMode.GetType());
                        devMode.dmFields = 0x10000; // DM_FORMNAME 
                        devMode.dmFormName = paperName;
                        Marshal.StructureToPtr(devMode, hDevMode, true);
                        iRet = DocumentProperties(IntPtr.Zero, hPrinter, printerName,
                                 printerInfo.pDevMode, printerInfo.pDevMode, DM_IN_BUFFER | DM_OUT_BUFFER);
                        if (iRet < 0)
                            throw new ApplicationException("Unable to set the orientation setting for this printer.");
                        GetPrinter(hPrinter, 9, IntPtr.Zero, 0, out iPrinterInfoSize);
                        if (iPrinterInfoSize == 0)
                            throw new ApplicationException("GetPrinter failed. Couldn't get the # bytes needed for shared PRINTER_INFO_9 structure");
                        hPrinterInfo = Marshal.AllocCoTaskMem(iPrinterInfoSize + 100);
                        bool bSuccess = GetPrinter(hPrinter, 9, hPrinterInfo, iPrinterInfoSize, out iDummyInt);
                        if (!bSuccess)
                            throw new ApplicationException("GetPrinter failed. Couldn't get the shared PRINTER_INFO_9 structure");
                        printerInfo = (PRINTER_INFO_9)Marshal.PtrToStructure(hPrinterInfo, printerInfo.GetType());
                        printerInfo.pDevMode = hDevMode;
                        Marshal.StructureToPtr(printerInfo, hPrinterInfo, true);
                        bSuccess = SetPrinter(hPrinter, 9, hPrinterInfo, 0);
                        if (!bSuccess)
                            throw new Win32Exception(Marshal.GetLastWin32Error(), "SetPrinter() failed.  Couldn't set the printer settings");
                        SendMessageTimeout(
                           new IntPtr(HWND_BROADCAST),
                           WM_SETTINGCHANGE,
                           IntPtr.Zero,
                           IntPtr.Zero,
                           SendMessageTimeoutFlags.SMTO_NORMAL,
                           1000,
                           out hDummy);
                    }
                    finally
                    {
                        ClosePrinter(hPrinter);
                    }
                }
                else
                {
                    StringBuilder strBuilder = new StringBuilder();
                    strBuilder.AppendFormat("Failed to open the {0} printer, System error number: {1}",
                        printerName, GetLastError());
                    throw new ApplicationException(strBuilder.ToString());
                }
            }
            else
            {
                structDevMode pDevMode = new structDevMode();
                IntPtr hDC = CreateDC(null, printerName, null, ref pDevMode);
                if (hDC != IntPtr.Zero)
                {
                    const long DM_PAPERSIZE = 0x00000002L;
                    const long DM_PAPERLENGTH = 0x00000004L;
                    const long DM_PAPERWIDTH = 0x00000008L;
                    pDevMode.dmFields = (int)(DM_PAPERSIZE | DM_PAPERWIDTH | DM_PAPERLENGTH);
                    pDevMode.dmPaperSize = 256;
                    pDevMode.dmPaperWidth = (short)(widthMm * 1000.0);
                    pDevMode.dmPaperLength = (short)(heightMm * 1000.0);
                    ResetDC(hDC, ref pDevMode);
                    DeleteDC(hDC);
                }
            }
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct structPrinterDefaults
        {
            [MarshalAs(UnmanagedType.LPTStr)]
            public String pDatatype;
            public IntPtr pDevMode;
            [MarshalAs(UnmanagedType.I4)]
            public int DesiredAccess;
        };
        [DllImport("winspool.Drv", EntryPoint = "OpenPrinter", SetLastError = true,
             CharSet = CharSet.Unicode, ExactSpelling = false, CallingConvention = CallingConvention.StdCall),
        SuppressUnmanagedCodeSecurityAttribute()]
        internal static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPTStr)]
			string printerName,
            out IntPtr phPrinter,
            ref structPrinterDefaults pd);
        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true,
             CharSet = CharSet.Unicode, ExactSpelling = false,
             CallingConvention = CallingConvention.StdCall), SuppressUnmanagedCodeSecurityAttribute()]
        internal static extern bool ClosePrinter(IntPtr phPrinter);
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct structSize
        {
            public Int32 width;
            public Int32 height;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct structRect
        {
            public Int32 left;
            public Int32 top;
            public Int32 right;
            public Int32 bottom;
        }
        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
        internal struct FormInfo1
        {
            [FieldOffset(0), MarshalAs(UnmanagedType.I4)]
            public uint Flags;
            [FieldOffset(4), MarshalAs(UnmanagedType.LPWStr)]
            public String pName;
            [FieldOffset(8)]
            public structSize Size;
            [FieldOffset(16)]
            public structRect ImageableArea;
        };
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi/* changed from CharSet=CharSet.Auto */)]
        internal struct structDevMode
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public String dmDeviceName;
            [MarshalAs(UnmanagedType.U2)]
            public short dmSpecVersion;
            [MarshalAs(UnmanagedType.U2)]
            public short dmDriverVersion;
            [MarshalAs(UnmanagedType.U2)]
            public short dmSize;
            [MarshalAs(UnmanagedType.U2)]
            public short dmDriverExtra;
            [MarshalAs(UnmanagedType.U4)]
            public int dmFields;
            [MarshalAs(UnmanagedType.I2)]
            public short dmOrientation;
            [MarshalAs(UnmanagedType.I2)]
            public short dmPaperSize;
            [MarshalAs(UnmanagedType.I2)]
            public short dmPaperLength;
            [MarshalAs(UnmanagedType.I2)]
            public short dmPaperWidth;
            [MarshalAs(UnmanagedType.I2)]
            public short dmScale;
            [MarshalAs(UnmanagedType.I2)]
            public short dmCopies;
            [MarshalAs(UnmanagedType.I2)]
            public short dmDefaultSource;
            [MarshalAs(UnmanagedType.I2)]
            public short dmPrintQuality;
            [MarshalAs(UnmanagedType.I2)]
            public short dmColor;
            [MarshalAs(UnmanagedType.I2)]
            public short dmDuplex;
            [MarshalAs(UnmanagedType.I2)]
            public short dmYResolution;
            [MarshalAs(UnmanagedType.I2)]
            public short dmTTOption;
            [MarshalAs(UnmanagedType.I2)]
            public short dmCollate;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public String dmFormName;
            [MarshalAs(UnmanagedType.U2)]
            public short dmLogPixels;
            [MarshalAs(UnmanagedType.U4)]
            public int dmBitsPerPel;
            [MarshalAs(UnmanagedType.U4)]
            public int dmPelsWidth;
            [MarshalAs(UnmanagedType.U4)]
            public int dmPelsHeight;
            [MarshalAs(UnmanagedType.U4)]
            public int dmNup;
            [MarshalAs(UnmanagedType.U4)]
            public int dmDisplayFrequency;
            [MarshalAs(UnmanagedType.U4)]
            public int dmICMMethod;
            [MarshalAs(UnmanagedType.U4)]
            public int dmICMIntent;
            [MarshalAs(UnmanagedType.U4)]
            public int dmMediaType;
            [MarshalAs(UnmanagedType.U4)]
            public int dmDitherType;
            [MarshalAs(UnmanagedType.U4)]
            public int dmReserved1;
            [MarshalAs(UnmanagedType.U4)]
            public int dmReserved2;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct PRINTER_INFO_9
        {
            public IntPtr pDevMode;
        }
        [DllImport("winspool.Drv", EntryPoint = "AddFormW", SetLastError = true,
             CharSet = CharSet.Unicode, ExactSpelling = true,
             CallingConvention = CallingConvention.StdCall), SuppressUnmanagedCodeSecurityAttribute()]
        internal static extern bool AddForm(
         IntPtr phPrinter,
            [MarshalAs(UnmanagedType.I4)] int level,
         ref FormInfo1 form);
        /*    This method is not used
                [DllImport("winspool.Drv", EntryPoint="SetForm", SetLastError=true,
                     CharSet=CharSet.Unicode, ExactSpelling=false,
                     CallingConvention=CallingConvention.StdCall), SuppressUnmanagedCodeSecurityAttribute()]
                internal static extern bool SetForm(IntPtr phPrinter, string paperName,
                    [MarshalAs(UnmanagedType.I4)] int level, ref FormInfo1 form);
        */
        [DllImport("winspool.Drv", EntryPoint = "DeleteForm", SetLastError = true,
             CharSet = CharSet.Unicode, ExactSpelling = false, CallingConvention = CallingConvention.StdCall),
        SuppressUnmanagedCodeSecurityAttribute()]
        internal static extern bool DeleteForm(
         IntPtr phPrinter,
            [MarshalAs(UnmanagedType.LPTStr)] string pName);
        [DllImport("kernel32.dll", EntryPoint = "GetLastError", SetLastError = false,
             ExactSpelling = true, CallingConvention = CallingConvention.StdCall),
        SuppressUnmanagedCodeSecurityAttribute()]
        internal static extern Int32 GetLastError();
        [DllImport("GDI32.dll", EntryPoint = "CreateDC", SetLastError = true,
             CharSet = CharSet.Unicode, ExactSpelling = false,
             CallingConvention = CallingConvention.StdCall),
        SuppressUnmanagedCodeSecurityAttribute()]
        internal static extern IntPtr CreateDC([MarshalAs(UnmanagedType.LPTStr)]
			string pDrive,
            [MarshalAs(UnmanagedType.LPTStr)] string pName,
            [MarshalAs(UnmanagedType.LPTStr)] string pOutput,
            ref structDevMode pDevMode);
        [DllImport("GDI32.dll", EntryPoint = "ResetDC", SetLastError = true,
             CharSet = CharSet.Unicode, ExactSpelling = false,
             CallingConvention = CallingConvention.StdCall),
        SuppressUnmanagedCodeSecurityAttribute()]
        internal static extern IntPtr ResetDC(
         IntPtr hDC,
         ref structDevMode
            pDevMode);
        [DllImport("GDI32.dll", EntryPoint = "DeleteDC", SetLastError = true,
             CharSet = CharSet.Unicode, ExactSpelling = false,
             CallingConvention = CallingConvention.StdCall),
        SuppressUnmanagedCodeSecurityAttribute()]
        internal static extern bool DeleteDC(IntPtr hDC);
        [DllImport("winspool.Drv", EntryPoint = "SetPrinterA", SetLastError = true,
            CharSet = CharSet.Auto, ExactSpelling = true,
            CallingConvention = CallingConvention.StdCall), SuppressUnmanagedCodeSecurityAttribute()]
        internal static extern bool SetPrinter(
           IntPtr hPrinter,
           [MarshalAs(UnmanagedType.I4)] int level,
           IntPtr pPrinter,
           [MarshalAs(UnmanagedType.I4)] int command);
        /*
         LONG DocumentProperties(
           HWND hWnd,               // handle to parent window 
           HANDLE hPrinter,         // handle to printer object
           LPTSTR pDeviceName,      // device name
           PDEVMODE pDevModeOutput, // modified device mode
           PDEVMODE pDevModeInput,  // original device mode
           DWORD fMode              // mode options
           );
         */
        [DllImport("winspool.Drv", EntryPoint = "DocumentPropertiesA", SetLastError = true,
        ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern int DocumentProperties(
           IntPtr hwnd,
           IntPtr hPrinter,
           [MarshalAs(UnmanagedType.LPStr)] string pDeviceName /* changed from String to string */,
           IntPtr pDevModeOutput,
           IntPtr pDevModeInput,
           int fMode
           );
        [DllImport("winspool.Drv", EntryPoint = "GetPrinterA", SetLastError = true,
        ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool GetPrinter(
           IntPtr hPrinter,
           int dwLevel /* changed type from Int32 */,
           IntPtr pPrinter,
           int dwBuf /* chagned from Int32*/,
           out int dwNeeded /* changed from Int32*/
           );
        [Flags]
        public enum SendMessageTimeoutFlags : uint
        {
            SMTO_NORMAL = 0x0000,
            SMTO_BLOCK = 0x0001,
            SMTO_ABORTIFHUNG = 0x0002,
            SMTO_NOTIMEOUTIFNOTHUNG = 0x0008
        }
        const int WM_SETTINGCHANGE = 0x001A;
        const int HWND_BROADCAST = 0xffff;
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessageTimeout(
           IntPtr windowHandle,
           uint Msg,
           IntPtr wParam,
           IntPtr lParam,
           SendMessageTimeoutFlags flags,
           uint timeout,
           out IntPtr result
           );
    }
    public class PrintSet
    {
        public enum PageOrientation
        {
            DMORIENT_PORTRAIT = 1,
            DMORIENT_LANDSCAPE = 2
        }
        public enum PaperSize
        {
            DMPAPER_LETTER = 1, // Letter 8 1/2 x 11 in
            DMPAPER_LETTERSMALL = 2, // Letter Small 8 1/2 x 11 in
            DMPAPER_TABLOID = 3, // Tabloid 11 x 17 in
            DMPAPER_LEDGER = 4, // Ledger 17 x 11 in
            DMPAPER_LEGAL = 5, // Legal 8 1/2 x 14 in
            DMPAPER_STATEMENT = 6, // Statement 5 1/2 x 8 1/2 in
            DMPAPER_EXECUTIVE = 7, // Executive 7 1/4 x 10 1/2 in
            DMPAPER_A3 = 8, // A3 297 x 420 mm
            DMPAPER_A4 = 9, // A4 210 x 297 mm
            DMPAPER_A4SMALL = 10, // A4 Small 210 x 297 mm
            DMPAPER_A5 = 11, // A5 148 x 210 mm
            DMPAPER_B4 = 12, // B4 250 x 354
            DMPAPER_B5 = 13, // B5 182 x 257 mm
            DMPAPER_FOLIO = 14, // Folio 8 1/2 x 13 in
            DMPAPER_QUARTO = 15, // Quarto 215 x 275 mm
            DMPAPER_10X14 = 16, // 10x14 in
            DMPAPER_11X17 = 17, // 11x17 in
            DMPAPER_NOTE = 18, // Note 8 1/2 x 11 in
            DMPAPER_ENV_9 = 19, // Envelope #9 3 7/8 x 8 7/8
            DMPAPER_ENV_10 = 20, // Envelope #10 4 1/8 x 9 1/2
            DMPAPER_ENV_11 = 21, // Envelope #11 4 1/2 x 10 3/8
            DMPAPER_ENV_12 = 22, // Envelope #12 4 "276 x 11
            DMPAPER_ENV_14 = 23, // Envelope #14 5 x 11 1/2
            DMPAPER_CSHEET = 24, // C size sheet
            DMPAPER_DSHEET = 25, // D size sheet
            DMPAPER_ESHEET = 26, // E size sheet
            DMPAPER_ENV_DL = 27, // Envelope DL 110 x 220mm
            DMPAPER_ENV_C5 = 28, // Envelope C5 162 x 229 mm
            DMPAPER_ENV_C3 = 29, // Envelope C3 324 x 458 mm
            DMPAPER_ENV_C4 = 30, // Envelope C4 229 x 324 mm
            DMPAPER_ENV_C6 = 31, // Envelope C6 114 x 162 mm
            DMPAPER_ENV_C65 = 32, // Envelope C65 114 x 229 mm
            DMPAPER_ENV_B4 = 33, // Envelope B4 250 x 353 mm
            DMPAPER_ENV_B5 = 34, // Envelope B5 176 x 250 mm
            DMPAPER_ENV_B6 = 35, // Envelope B6 176 x 125 mm
            DMPAPER_ENV_ITALY = 36, // Envelope 110 x 230 mm
            DMPAPER_ENV_MONARCH = 37, // Envelope Monarch 3.875 x 7.5 in
            DMPAPER_ENV_PERSONAL = 38, // 6 3/4 Envelope 3 5/8 x 6 1/2 in
            DMPAPER_FANFOLD_US = 39, // US Std Fanfold 14 7/8 x 11 in
            DMPAPER_FANFOLD_STD_GERMAN = 40, // German Std Fanfold 8 1/2 x 12 in
            DMPAPER_FANFOLD_LGL_GERMAN = 41, // German Legal Fanfold 8 1/2 x 13 in
            DMPAPER_USER = 256,
            DMPAPER_FIRST = DMPAPER_LETTER,
            DMPAPER_LAST = DMPAPER_USER,
        }
        public enum PageDuplex
        {
            DMDUP_HORIZONTAL = 3,
            DMDUP_SIMPLEX = 1,
            DMDUP_VERTICAL = 2
        }
        public enum PaperSource
        {
            DMBIN_UPPER = 1,
            DMBIN_LOWER = 2,
            DMBIN_MIDDLE = 3,
            DMBIN_MANUAL = 4,
            DMBIN_ENVELOPE = 5,
            DMBIN_ENVMANUAL = 6,
            DMBIN_AUTO = 7,
            DMBIN_TRACTOR = 8,
            DMBIN_SMALLFMT = 9,
            DMBIN_LARGEFMT = 10,
            DMBIN_LARGECAPACITY = 11,
            DMBIN_CASSETTE = 14,
            DMBIN_FORMSOURCE = 15,
            DMRES_DRAFT = -1,
            DMRES_LOW = -2,
            DMRES_MEDIUM = -3,
            DMRES_HIGH = -4
        }
        public enum DmFields
        {
            DM_ORIENTATION = 0x1,
            DM_PAPERSIZE = 0x2,
            DM_PAPERLENGTH = 0x4,
            DM_PAPERWIDTH = 0x8,
            DM_SCALE = 0x10,
            DM_COPIES = 0x100,
            DM_DEFAULTSOURCE = 0x200,
            DM_PRINTQUALITY = 0x400,
            DM_COLOR = 0x800,
            DM_DUPLEX = 0x1000,
            DM_YRESOLUTION = 0x2000,
            DM_TTOPTION = 0x4000,
            DM_COLLATE = 0x8000,
            DM_FORMNAME = 0x10000,
            DM_LOGPIXELS = 0x20000,
            DM_BITSPERPEL = 0x40000,
            DM_PELSWIDTH = 0x80000,
            DM_PELSHEIGHT = 0x100000,
            DM_DISPLAYFLAGS = 0x200000,
            DM_DISPLAYFREQUENCY = 0x400000,
            DM_ICMMETHOD = 0x800000,
            DM_ICMINTENT = 0x1000000,
            DM_MEDIATYPE = 0x2000000,
            DM_DITHERTYPE = 0x4000000,
            DM_PANNINGWIDTH = 0x20000000,
            DM_PANNINGHEIGHT = 0x40000000,
        }
        public struct PrinterData
        {
            public PageOrientation Orientation;
            public PaperSize Size;
            public PaperSource source;
            public PageDuplex Duplex;
            public int pLength;
            public int pWidth;
            public int pmFields;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct PRINTER_DEFAULTS
        {
            public int pDatatype;
            public int pDevMode;
            public int DesiredAccess;
        }
        /*[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
        public struct PRINTER_DEFAULTS
        {
        public int pDataType;
        public IntPtr pDevMode;
        public ACCESS_MASK DesiredAccess;
        }*/
        [StructLayout(LayoutKind.Sequential)]
        struct PRINTER_INFO_2
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pServerName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pPrinterName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pShareName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pPortName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDriverName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pComment;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pLocation;
            public IntPtr pDevMode;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pSepFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pPrintProcessor;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDatatype;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pParameters;
            public IntPtr pSecurityDescriptor;
            public Int32 Attributes;
            public Int32 Priority;
            public Int32 DefaultPriority;
            public Int32 StartTime;
            public Int32 UntilTime;
            public Int32 Status;
            public Int32 cJobs;
            public Int32 AveragePPM;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct DEVMODE
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string dmDeviceName;
            public short dmSpecVersion;
            public short dmDriverVersion;
            public short dmSize;
            public short dmDriverExtra;
            public int dmFields;
            public short dmOrientation;
            public short dmPaperSize;
            public short dmPaperLength;
            public short dmPaperWidth;
            public short dmScale;
            public short dmCopies;
            public short dmDefaultSource;
            public short dmPrintQuality;
            public short dmColor;
            public short dmDuplex;
            public short dmYResolution;
            public short dmTTOption;
            public short dmCollate;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string dmFormName;
            public short dmUnusedPadding;
            public short dmBitsPerPel;
            public int dmPelsWidth;
            public int dmPelsHeight;
            public int dmDisplayFlags;
            public int dmDisplayFrequency;
        }
        public class PrinterSetting
        {
            private IntPtr hPrinter = new System.IntPtr();
            private PRINTER_DEFAULTS PrinterValues = new PRINTER_DEFAULTS();
            private PRINTER_INFO_2 pinfo = new PRINTER_INFO_2();
            private DEVMODE dm;
            private IntPtr ptrDM;
            private IntPtr ptrPrinterInfo;
            private int sizeOfDevMode = 0;
            private int lastError;
            private int nBytesNeeded;
            private long nRet;
            private int intError;
            private System.Int32 nJunk;
            private IntPtr yDevModeData;
            [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true,
              ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            private static extern bool ClosePrinter(IntPtr hPrinter);
            [DllImport("winspool.Drv", EntryPoint = "DocumentPropertiesA", SetLastError = true,
              ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            private static extern int DocumentProperties(IntPtr hwnd, IntPtr hPrinter,
             [MarshalAs(UnmanagedType.LPStr)] string pDeviceNameg,
             IntPtr pDevModeOutput, ref IntPtr pDevModeInput, int fMode);
            [DllImport("winspool.Drv", EntryPoint = "GetPrinterA", SetLastError = true, CharSet = CharSet.Ansi,
              ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            private static extern bool GetPrinter(IntPtr hPrinter, Int32 dwLevel,
             IntPtr pPrinter, Int32 dwBuf, out Int32 dwNeeded);
            /*[DllImport("winspool.Drv", EntryPoint="OpenPrinterA", SetLastError=true, CharSet=CharSet.Ansi,
            ExactSpelling=true, CallingConvention=CallingConvention.StdCall)]
            static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter,
            out IntPtr hPrinter, ref PRINTER_DEFAULTS pd)
            [ DllImport( "winspool.drv",CharSet=CharSet.Unicode,ExactSpelling=false,
            CallingConvention=CallingConvention.StdCall )]
            public static extern long OpenPrinter(string pPrinterName,ref IntPtr phPrinter, int pDefault);*/
            /*[DllImport("winspool.Drv", EntryPoint="OpenPrinterA", SetLastError=true, CharSet=CharSet.Ansi,
            ExactSpelling=true, CallingConvention=CallingConvention.StdCall)]
            static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter,
            out IntPtr hPrinter, ref PRINTER_DEFAULTS pd);
            */
            [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi,
              ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            private static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter,
             out IntPtr hPrinter, ref PRINTER_DEFAULTS pd);
            [DllImport("winspool.drv", CharSet = CharSet.Ansi, SetLastError = true)]
            private static extern bool SetPrinter(IntPtr hPrinter, int Level, IntPtr
             pPrinter, int Command);
            /*[DllImport("winspool.drv", CharSet=CharSet.Ansi, SetLastError=true)]
            private static extern bool SetPrinter(IntPtr hPrinter, int Level, IntPtr
            pPrinter, int Command);*/
            /*[DllImport("kernel32.dll", CharSet=System.Runtime.InteropServices.CharSet.Auto)]
            private unsafe static extern int FormatMessage( int dwFlags,
            ref IntPtr pMessageSource,
            int dwMessageID,
            int dwLanguageID,
            ref string lpBuffer,
            int nSize,
            IntPtr* pArguments);*/
            private const int DM_OUT_BUFFER = 2;
            private const int STANDARD_RIGHTS_REQUIRED = 0xF0000;
            public bool ChangePrinterSetting(string printerName, ref PrinterData PS, bool bl)
            {
                if ((((int)PS.Duplex < 1) || ((int)PS.Duplex > 3)) && bl)
                {
                    throw new ArgumentOutOfRangeException("nDuplexSetting", "nDuplexSetting is incorrect.");
                }
                else
                {
                    PrintDocument pd = new PrintDocument();
                    dm = this.GetPrinterSettings(printerName);
                    if (bl)
                    {
                        /*dm.dmFields |= (int)DmFields.DM_DUPLEX | (int)DmFields.DM_ORIENTATION
                         | (int)DmFields.DM_DEFAULTSOURCE | (int)DmFields.DM_PAPERSIZE
                         | (int)DmFields.DM_PAPERLENGTH | (int)DmFields.DM_PAPERWIDTH;
                        */
                        dm.dmDuplex = (short)PS.Duplex;
                        dm.dmOrientation = (short)PS.Orientation;
                    }
                    else
                    {
                        PS.pmFields = dm.dmFields;
                        PS.Duplex = (PageDuplex)dm.dmDuplex;
                        PS.Orientation = (PageOrientation)dm.dmOrientation;
                        PS.source = (PaperSource)dm.dmDefaultSource;
                        PS.Size = (PaperSize)dm.dmPaperSize;
                        PS.pLength = dm.dmPaperLength;
                        PS.pWidth = dm.dmPaperWidth;
                    }
                    Marshal.StructureToPtr(dm, yDevModeData, true);
                    pinfo.pDevMode = yDevModeData;
                    pinfo.pSecurityDescriptor = IntPtr.Zero;
                    /*update driver dependent part of the DEVMODE
                    1 = DocumentProperties(IntPtr.Zero, hPrinter, sPrinterName, yDevModeData
                    , ref pinfo.pDevMode, (DM_IN_BUFFER | DM_OUT_BUFFER));*/
                    Marshal.StructureToPtr(pinfo, ptrPrinterInfo, true);
                    lastError = Marshal.GetLastWin32Error();
                    nRet = Convert.ToInt16(SetPrinter(hPrinter, 2, ptrPrinterInfo, 0));
                    if (nRet == 0)
                    {
                        lastError = Marshal.GetLastWin32Error();
                        throw new Win32Exception(Marshal.GetLastWin32Error());
                    }
                    if (hPrinter != IntPtr.Zero)
                        ClosePrinter(hPrinter);
                    return Convert.ToBoolean(nRet);
                }
            }
            private DEVMODE GetPrinterSettings(string PrinterName)
            {
                DEVMODE dm;
                const int PRINTER_ACCESS_ADMINISTER = 0x4;
                const int PRINTER_ACCESS_USE = 0x8;
                const int PRINTER_ALL_ACCESS = (STANDARD_RIGHTS_REQUIRED | PRINTER_ACCESS_ADMINISTER | PRINTER_ACCESS_USE);
                PrinterValues.pDatatype = 0;
                PrinterValues.pDevMode = 0;
                PrinterValues.DesiredAccess = PRINTER_ALL_ACCESS;
                nRet = MyCommon.ToInt(OpenPrinter(PrinterName, out hPrinter, ref PrinterValues));
                if (nRet == 0)
                {
                    lastError = Marshal.GetLastWin32Error();
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }
                GetPrinter(hPrinter, 2, IntPtr.Zero, 0, out nBytesNeeded);
                if (nBytesNeeded <= 0)
                {
                    throw new System.Exception("Unable to allocate memory");
                }
                else
                {
                    ptrPrinterInfo = Marshal.AllocHGlobal(nBytesNeeded);
                    nRet = MyCommon.ToInt(GetPrinter(hPrinter, 2, ptrPrinterInfo, nBytesNeeded, out nJunk));
                    if (nRet == 0)
                    {
                        lastError = Marshal.GetLastWin32Error();
                        throw new Win32Exception(Marshal.GetLastWin32Error());
                    }
                    pinfo = (PRINTER_INFO_2)Marshal.PtrToStructure(ptrPrinterInfo, typeof(PRINTER_INFO_2));
                    IntPtr Temp = new IntPtr();
                    if (pinfo.pDevMode == IntPtr.Zero)
                    {
                        IntPtr ptrZero = IntPtr.Zero;
                        sizeOfDevMode = DocumentProperties(IntPtr.Zero, hPrinter, PrinterName, ptrZero, ref ptrZero, 0);
                        ptrDM = Marshal.AllocCoTaskMem(sizeOfDevMode);
                        int i;
                        i = DocumentProperties(IntPtr.Zero, hPrinter, PrinterName, ptrDM,
                         ref ptrZero, DM_OUT_BUFFER);
                        if ((i < 0) || (ptrDM == IntPtr.Zero))
                        {
                            throw new System.Exception("Cannot get DEVMODE data");
                        }
                        pinfo.pDevMode = ptrDM;
                    }
                    intError = DocumentProperties(IntPtr.Zero, hPrinter, PrinterName, IntPtr.Zero, ref Temp, 0);
                    yDevModeData = Marshal.AllocHGlobal(intError);
                    intError = DocumentProperties(IntPtr.Zero, hPrinter, PrinterName, yDevModeData, ref Temp, 2);
                    dm = (DEVMODE)Marshal.PtrToStructure(yDevModeData, typeof(DEVMODE));
                    if ((nRet == 0) || (hPrinter == IntPtr.Zero))
                    {
                        lastError = Marshal.GetLastWin32Error();
                        throw new Win32Exception(Marshal.GetLastWin32Error());
                    }
                    return dm;
                }
            }
        }
    }
}
