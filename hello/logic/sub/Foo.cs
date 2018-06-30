using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace logic.sub
{
    public static class Foo
    {
        public static string Bar(Encoding encoding, byte[] byteArray)
        {
            return encoding.GetString(byteArray, 0, byteArray.Length);
        }
    }
}
