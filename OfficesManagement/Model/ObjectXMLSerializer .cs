using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace OfficesManagement
{
    public static class ObjectXMLSerializer
    {
        public static void SerializeParams<T>(XDocument doc, List<T> paramList)
        {
            XmlSerializer serializer = new XmlSerializer(paramList.GetType());
            XmlWriter writer = doc.CreateWriter();
            serializer.Serialize(writer, paramList);
            writer.Close();
        }

        public static List<T> DeserializeParams<T>(XDocument doc)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            XmlReader reader = doc.CreateReader();
            List<T> result = (List<T>)serializer.Deserialize(reader);
            reader.Close();
            return result;
        }
    }
}
