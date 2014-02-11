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
            using (Stream stream = new FileStream(path, FileMode.Create, FileAccess.Read))
            {
                using (XmlDictionaryReader reader =
                    XmlDictionaryReader.CreateTextReader(stream,Encoding.UTF8,new XmlDictionaryReaderQuotas(), null))
                {
                    return (T) dcs.ReadObject(reader);
                }
            }
        }
    }
}
