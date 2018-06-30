using System;
//using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace hello
{


    public class XElementContainer
    {
        public XElement member;

        //public XElementContainer()
        //{
        //}

        public override string ToString()
        {
            return member.ToString();
        }
    }


    class XLinqTest
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating a document with utf-8 encoding");
            XDocument encodedDoc8 = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("Root", "Content")
            );
            encodedDoc8.Save("EncodedUtf8.xml");
            Console.WriteLine("Encoding is:{0}", encodedDoc8.Declaration.Encoding);
            Console.WriteLine();

            XDocument newDoc8 = XDocument.Load("EncodedUtf8.xml");
            Console.WriteLine("Encoded document:");
            Console.WriteLine(File.ReadAllText("EncodedUtf8.xml"));
            Console.WriteLine();
            Console.WriteLine("Encoding of loaded document is:{0}", newDoc8.Declaration.Encoding);
            Console.WriteLine();

            var root = CreateRoot();
            var doc = new XElementContainer();
            doc.member = root;
            var ser = Serialize<XElementContainer>(doc);
            Console.WriteLine("TOSTRING: " + ser.ToString());

        }

        public static XElement CreateRoot()
        {
            //XNamespace ns = "http://acme.com";
            //var el = new XElement();
            //return new XElement(ns + "aw");
            XElement root = new XElement("Root",
                new XElement("foo", "bar"),
                new XElement("bax", 42)
            );
            return root;
        }

        static String Serialize<T>(T obj)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                XmlSerializer s = new XmlSerializer(typeof(T));
                s.Serialize(XmlWriter.Create(stream), obj);
                stream.Flush();
                return stream.ToString();
            }
        }

        static T Deserialize<T>(String xml)
        {
            byte[] bytes = Encoding.Convert
                                   
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                XmlSerializer s = new XmlSerializer(typeof(T));
                object o = s.Deserialize(XmlReader.Create(stream));
                return (T)o;
            }
        }


    }



}
