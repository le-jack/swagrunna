using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Helper
{
    class Program
    {
        public static byte[] encoder(byte[] buf, int offset, byte key)
        {
            byte[] encoded = new byte[buf.Length];
            for (int i = 0; i < buf.Length; i++)
            {
                encoded[i] = (byte)(((uint)buf[i] + offset) ^ key); // SHIFT BY 2 AND 0xFF
            }
            return encoded;
        }

        public static void Main(string[] args)
        {
            string filename = @"shell.txt";
            FileInfo fi = new FileInfo(filename);
            byte[] buf = File.ReadAllBytes(filename); 
            byte[] xcoded = encoder(buf, 2, 0xFF);

            StringBuilder hex = new StringBuilder(xcoded.Length * 2);
            foreach (byte b in xcoded)
            {
                hex.AppendFormat("0x{0:x2}, ", b);
            }
            Console.WriteLine("\t\tbyte[] buf = new byte[" + fi.Length + "] {" + hex.ToString().TrimEnd(',') + "};");
        }
    }
}
