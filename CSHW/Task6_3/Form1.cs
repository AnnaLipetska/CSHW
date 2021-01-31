using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Task6_3
{
    public partial class Form1 : Form
    {
        Assembly assembly = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                // Строка приема полного имени загружаемой сборки.
                string path = openFileDialog.FileName;

                try
                {
                    assembly = Assembly.LoadFile(path);
                    textBox.Text += "СБОРКА    " + path + "  -  УСПЕШНО ЗАГРУЖЕНА" + Environment.NewLine + Environment.NewLine;
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                // Вывод информации о всех типах в сборке.
                textBox.Text += "СПИСОК ВСЕХ ТИПОВ В СБОРКЕ:     " + assembly.FullName + Environment.NewLine + Environment.NewLine;

                Type[] types = assembly.GetTypes();
                int typesCounter = 0;

                foreach (Type type in types)
                {
                    typesCounter += 1;
                    textBox.Text += Environment.NewLine + "Тип " + typesCounter + ": " + type + Environment.NewLine;
                    MethodInfo[] methods = type.GetMethods();
                    if (methods != null)
                    {
                        foreach (MethodInfo method in methods)
                        {
                            string methStr = "Метод:" + method.Name + "\n";
                            var methodBody = method.GetMethodBody();
                            if (methodBody != null)
                            {
                                var byteArray = methodBody.GetILAsByteArray();

                                foreach (var b in byteArray)
                                {
                                    methStr += b + ":";
                                }
                            }
                            textBox.Text += methStr + Environment.NewLine;
                        }
                    }

                    PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic);
                    if (properties != null)
                    {
                        foreach (PropertyInfo property in properties)
                        {
                            textBox.Text += "Свойство:" + property.Name + "\n" + Environment.NewLine;
                        }
                    }

                    FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.NonPublic);
                    if (fields != null)
                    {
                        foreach (FieldInfo field in fields)
                        {
                            textBox.Text += "Поле:" + field.Name + (field.IsPrivate ? " is private" : " is not private") + "\n" + Environment.NewLine;
                        }
                    }
                }
            }
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
