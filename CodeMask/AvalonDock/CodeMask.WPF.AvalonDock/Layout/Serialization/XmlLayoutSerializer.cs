﻿/************************************************************************

   AvalonDock

   




 


   

  **********************************************************************/

using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace CodeMask.WPF.AvalonDock.Layout.Serialization
{
    public class XmlLayoutSerializer : LayoutSerializer
    {
        public XmlLayoutSerializer(DockingManager manager)
            : base(manager)
        {
        }

        public void Serialize(XmlWriter writer)
        {
            var serializer = new XmlSerializer(typeof (LayoutRoot));
            serializer.Serialize(writer, Manager.Layout);
        }

        public void Serialize(TextWriter writer)
        {
            var serializer = new XmlSerializer(typeof (LayoutRoot));
            serializer.Serialize(writer, Manager.Layout);
        }

        public void Serialize(Stream stream)
        {
            var serializer = new XmlSerializer(typeof (LayoutRoot));
            serializer.Serialize(stream, Manager.Layout);
        }

        public void Serialize(string filepath)
        {
            using (var stream = new StreamWriter(filepath))
                Serialize(stream);
        }

        public void Deserialize(Stream stream)
        {
            try
            {
                StartDeserialization();
                var serializer = new XmlSerializer(typeof (LayoutRoot));
                var layout = serializer.Deserialize(stream) as LayoutRoot;
                FixupLayout(layout);
                Manager.Layout = layout;
            }
            finally
            {
                EndDeserialization();
            }
        }

        public void Deserialize(TextReader reader)
        {
            try
            {
                StartDeserialization();
                var serializer = new XmlSerializer(typeof (LayoutRoot));
                var layout = serializer.Deserialize(reader) as LayoutRoot;
                FixupLayout(layout);
                Manager.Layout = layout;
            }
            finally
            {
                EndDeserialization();
            }
        }

        public void Deserialize(XmlReader reader)
        {
            try
            {
                StartDeserialization();
                var serializer = new XmlSerializer(typeof (LayoutRoot));
                var layout = serializer.Deserialize(reader) as LayoutRoot;
                FixupLayout(layout);
                Manager.Layout = layout;
            }
            finally
            {
                EndDeserialization();
            }
        }

        public void Deserialize(string filepath)
        {
            using (var stream = new StreamReader(filepath))
                Deserialize(stream);
        }
    }
}