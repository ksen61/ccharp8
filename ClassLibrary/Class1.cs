using System;
using System.IO;
using System.Xml.Serialization;

namespace ClassLibrary
{
    public static class Serial
    {
        public class TextBoxx
        {
            public string Text1 { get; set; }
            public string Text2 { get; set; }
            public string Text3 { get; set; }

        }

        public static void Serialize<T>(T data, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fileStream, data);
            }
        }

        public static T Deserialize<T>(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                return (T)serializer.Deserialize(fileStream);
            }
        }
    }
}
