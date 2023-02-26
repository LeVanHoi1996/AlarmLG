using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAA___GMES___Client
{
    public class Communication
    {
        //khai báo config file path
        public static string Common = Application.StartupPath + @"\Communication\Common.ini";
        //GMES
        public static string GMES_IP;
        public static string GMES_Port;
        public static string GMES_TimeOut;
        //PLC
        public static string PLC_IP;
        public static string PLC_Port;
        //Barcode
        public static string Barcode_Port;
        public static string Barcode_Baurate;
        public static string Barcode_DataBits;
        public static string Barcode_Parity;
        public static string Barcode_StopBit;
        public static string Barcode_Char_Count;
        //Camera
        public static string Camera_CurrentJob;
        public static string Camera_Link;

        public static void ReadCommon()
        {
            GMES_IP = INI.ReadIni(Common, "GMES", "IP", "");
            GMES_Port = INI.ReadIni(Common, "GMES", "Port", "");
            GMES_TimeOut = INI.ReadIni(Common, "GMES", "TimeOut", "");

            PLC_IP = INI.ReadIni(Common, "PLC", "IP", "");
            PLC_Port = INI.ReadIni(Common, "PLC", "Port", "");

            Barcode_Port = INI.ReadIni(Common, "Barcode", "Port", "");
            Barcode_Baurate = INI.ReadIni(Common, "Barcode", "Baudrate", "");
            Barcode_DataBits = INI.ReadIni(Common, "Barcode", "DataBits", "");
            Barcode_Parity = INI.ReadIni(Common, "Barcode", "Parity", "");
            Barcode_StopBit = INI.ReadIni(Common, "Barcode", "StopBit", "");
            Barcode_Char_Count = INI.ReadIni(Common, "Barcode", "Number", "");

            Camera_CurrentJob = INI.ReadIni(Common, "Camera", "CurrentJob", "");
            Camera_Link = INI.ReadIni(Common, "Camera", "Link", "");
        }
    }
}
