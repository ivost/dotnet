using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace logic
{
    public static class Utility
    {
        public static string ByteArrayToString(Encoding encoding, byte[] byteArray)
        {
            return encoding.GetString(byteArray, 0, byteArray.Length);
        }

        public static string SerializeObject<T>(Encoding encoding, T obj)
        {
            try
            {
                MemoryStream memoryStream = new MemoryStream();
                using (XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, encoding))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    xmlSerializer.Serialize(xmlTextWriter, obj);
                    memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                }
                return ByteArrayToString(encoding, memoryStream.ToArray());
            }
            catch { return string.Empty; }
        }
    }
}
