using System;
using System.IO;
using System.Text;

namespace TurmixLog
{
	public class CustomXmlWriter : System.Xml.XmlTextWriter
	{

		private Encoding utfencoder = UTF8Encoding.GetEncoding("UTF-8", new EncoderReplacementFallback(""),
            new DecoderReplacementFallback(""));

        public CustomXmlWriter(string file) : base(new FileStream(file, FileMode.Create, FileAccess.Write, FileShare.Read),
            Encoding.UTF8)
        {
        }

        public override void WriteString(string text)
        {           
            base.WriteString(Encode(text));
        }

        public override void WriteCData(string text)
        {
            base.WriteCData(Encode(text));
        }

        private string Encode(string text)
        {
            byte[] bytText = utfencoder.GetBytes(text);
            return utfencoder.GetString(bytText);
        }

	}
}
