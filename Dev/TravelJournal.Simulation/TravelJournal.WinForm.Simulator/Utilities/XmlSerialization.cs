using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TravelJournal.WinForm.Simulator
{
    public static class XmlSerialization
    {
        public static void Serialize<T>(string path,T objectToSerialize)
        {
            DataContractSerializer dcs = new DataContractSerializer(typeof(T));
            using (Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                using (XmlDictionaryWriter writer =
                    XmlDictionaryWriter.CreateTextWriter(stream, Encoding.UTF8))
                {
                    writer.WriteStartDocument();
                    dcs.WriteObject(writer, objectToSerialize);
                }
            }
        }

        public static T Deserialize<T>(string path)
        {
            DataContractSerializer dcs = new DataContractSerializer(typeof(T));
            using (Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (XmlDictionaryReader reader =
                    XmlDictionaryReader.CreateTextReader(stream,Encoding.UTF8,new XmlDictionaryReaderQuotas(), null))
                {
                    return (T) dcs.ReadObject(reader);
                }
            }
        }

        public static string SerializeString<T>(T objectToSerialize)
        { 
            using (MemoryStream memoryStream = new MemoryStream())
            {
                DataContractSerializer dcs = new DataContractSerializer(typeof(T));
                dcs.WriteObject(memoryStream, objectToSerialize);
                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
        }

        public static T DeserializeString<T>(string xmlString)
        {
            using (MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(xmlString)))
            {
                XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(memoryStream,Encoding.UTF8, new XmlDictionaryReaderQuotas(),null);
                DataContractSerializer dcs = new DataContractSerializer(typeof(T));
                T obj = (T)dcs.ReadObject(reader, true);
                return obj;
            }
        }
    }
}
