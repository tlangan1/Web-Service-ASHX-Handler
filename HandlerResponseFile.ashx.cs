using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Service_ASHX_Handler
{
    /// <summary>
    /// Summary description for Handler2
    /// </summary>
    public class Handler2 : IHttpHandler
    {
        string fileName = @"C:\XHD Backups\Do Not Back Up Anymore\BMW\DealerServer\inventory-20150223.csv";

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/CSV";
            context.Response.AddHeader("Content-disposition", "attachment; filename=\""
               + fileName + "\"");
            context.Response.Clear();
            context.Response.BinaryWrite(FileToByteArray(fileName));
            context.Response.Flush();
        }

        public byte[] FileToByteArray(string _FileName)
        {
            byte[] _Buffer = null;

            try
            {
                System.IO.FileStream _FileStream = new System.IO.FileStream(_FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                System.IO.BinaryReader _BinaryReader = new System.IO.BinaryReader(_FileStream);
                long _TotalBytes = new System.IO.FileInfo(_FileName).Length;
                _Buffer = _BinaryReader.ReadBytes((Int32)_TotalBytes);
                _FileStream.Close();
                _FileStream.Dispose();
                _BinaryReader.Close();
            }
            catch (Exception _Exception)
            {
                Console.WriteLine("Exception caught in process: {0}", _Exception.ToString());
            }
            return _Buffer;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}