using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace Task5_1
{
    // Используя Visual Studio, создайте проект по шаблону Windows Forms Application. 
    // Создайте программу, в которой создайте базу данных MyDatabase с таблицей MyTable. 
    // Создайте модель сущностей созданной базы данных, т.е. Entity Data Model 
    // с именем по умолчанию (Model1.edmx) используя технику Database First. 
    // Добавьте на форму DataGridView и Button. 
    // Релизуйте возможность вывода информации в DataGridView по нажатию на Button
    public partial class Form1 : Form
    {
        MyDatabaseEntities db;
        public Form1()
        {
            InitializeComponent();
            db = new MyDatabaseEntities();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            db.MyTables.Load();
            dgv.DataSource = db.MyTables.Local.ToBindingList();
        }
    }
}
