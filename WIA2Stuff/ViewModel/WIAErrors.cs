using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WIA2Stuff.ViewModel
{
    public class WiaError
    {
        public static string LibraryNotInstalled = "0x80040154";
        public static string OutputFileExists = "0x80070050";
        public static string ScannerNotAvailable = "0x80210015";
        public static string OperationCancelled = "0x80210064";
    }
}
