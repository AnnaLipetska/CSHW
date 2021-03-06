﻿using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Xml;

namespace Task8_4
{
    class ConfigSetting : ISetting
    {
        public Brush BackColor { get; set; }
        public Brush TextColor { get; set; }
        public int TextSize { get; set; }
        public FontFamily TextFont { get; set; }

        XmlDocument doc;

        public ConfigSetting()
        {
            doc = LoadConfigDocument();
            ReadFromXMLorSetDefault();
        }

        public void SaveSettings()
        {
            XmlNode node = doc.SelectSingleNode("//appSettings");
            if (node == null)
            {
                node = doc.CreateNode(XmlNodeType.Element, "appSettings", "");
                XmlElement root = doc.DocumentElement;
                root.AppendChild(node);
            }

            string[] keys = new string[] {"BackColor",
                                          "TextColor",
                                          "TextSize",
                                          "TextFont"};

            string[] values = new string[] { BackColor.ToString(),
                                             TextColor.ToString(),
                                             TextSize.ToString(),
                                             TextFont.ToString() };

            for (int i = 0; i < keys.Length; i++)
            {
                XmlElement element = node.SelectSingleNode(string.Format("//add[@key='{0}']", keys[i])) as XmlElement;

                if (element != null) { element.SetAttribute("value", values[i]); }
                else
                {
                    element = doc.CreateElement("add");
                    element.SetAttribute("key", keys[i]);
                    element.SetAttribute("value", values[i]);
                    node.AppendChild(element);
                }
            }
            doc.Save(Assembly.GetExecutingAssembly().Location + ".config");
        }

        private void ReadFromXMLorSetDefault()
        {
            NameValueCollection allAppSettings = ConfigurationManager.AppSettings;


            var bc = new BrushConverter();
            string messageException = string.Empty;
            try
            {
                BackColor = (Brush)bc.ConvertFromString(allAppSettings["BackColor"]);
            }
            catch (Exception)
            {
                BackColor = (Brush)bc.ConvertFromString(Colors.AliceBlue.ToString());
                messageException += "Цвет фона не задан или задан не верно: " + allAppSettings["BackColor"] + Environment.NewLine;
            }

            try
            {
                TextColor = (Brush)bc.ConvertFromString(allAppSettings["TextColor"]);
            }
            catch (Exception)
            {
                TextColor = (Brush)bc.ConvertFromString(Colors.Black.ToString());
                messageException += "Цвет текста не задан или задан не верно: " + allAppSettings["TextColor"] + Environment.NewLine;
            }

            try
            {
                TextSize = int.Parse(allAppSettings["TextSize"]);
            }
            catch (Exception)
            {
                TextSize = 12;
                messageException += "Размер текста не задан или задан не верно: " + allAppSettings["TextSize"] + Environment.NewLine;
            }

            try
            {
                TextFont = new FontFamily(allAppSettings["TextFont"]);
            }
            catch (Exception)
            {
                TextFont = new FontFamily("Segoe UI");
            }


            if (!string.IsNullOrEmpty(messageException))
            {
                MessageBox.Show(messageException);
            }
        }

        private XmlDocument LoadConfigDocument()
        {
            XmlDocument doc = null;
            try
            {
                doc = new XmlDocument();
                doc.Load(Assembly.GetExecutingAssembly().Location + ".config");
                return doc;
            }
            catch (System.IO.FileNotFoundException e)
            {
                throw new Exception("No configuration file found.", e);
            }
        }
    }
}
