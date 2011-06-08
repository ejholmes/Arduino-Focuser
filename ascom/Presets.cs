using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;
using System.ComponentModel;

namespace ASCOM.Arduino
{
    public class Preset
    {
        private string _name;
        private int _position;

        public Preset()
        {
        }

        public Preset(string name, int position)
        {
            this._name = name;
            this._position = position;
        }

        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public int Position
        {
            get { return this._position; }
            set { this._position = value; }
        }
    }

    [ComVisible(false)]
    public class Presets : List<Preset>
    {
        private static string xmlLocation = Config.XmlPresetsLocation;
        public delegate void ChangedEventHandler(object sender, EventArgs e);
        public event ChangedEventHandler Changed;

        public Presets()
        {
            this.Changed += new ChangedEventHandler(ListChanged);
        }

        protected virtual void OnChanged(EventArgs e)
        {
            if (Changed != null)
                Changed(this, e);
        }

        private void ListChanged(object sender, EventArgs e)
        {
            this.SaveToXml();
        }

        public new void Add(Preset item)
        {
            foreach (Preset p in this)
            {
                if (p.Name == item.Name)
                {
                    this.Remove(p);
                }
            }
            base.Add(item);
        }

        public void AddPreset(Preset item)
        {
            this.Add(item);
            this.SaveToXml();
        }

        public new void Remove(Preset p)
        {
            base.Remove(p);
            OnChanged(EventArgs.Empty);
        }

        public new void Clear()
        {
            base.Clear();
            OnChanged(EventArgs.Empty);
        }

        private static void CheckFilePaths()
        {
            string dir = Path.GetDirectoryName(xmlLocation);

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
        }

        public static Presets LoadFromXml()
        {
            try
            {
                Presets.CheckFilePaths();

                TextReader reader = new StreamReader(xmlLocation);

                XmlSerializer serializer = new XmlSerializer(typeof(Presets));

                Presets p = (Presets)serializer.Deserialize(reader);

                reader.Close();

                return p;
            }
            catch
            {
                return new Presets();
            }
        }

        public void SaveToXml()
        {
            try
            {
                Presets.CheckFilePaths();

                XmlSerializer serializer = new XmlSerializer(typeof(Presets));

                TextWriter writer = new StreamWriter(xmlLocation);
                serializer.Serialize(writer, this);
                writer.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }
    }
}
