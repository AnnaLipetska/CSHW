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

namespace Task5_2
{
    // Используя Visual Studio, создайте проект по шаблону Windows Forms Application. 
    // Создайте программу, в которой создайте пустую базу данных MyDatabase.
    // Создайте EDM (Entity Data Model) используя технику Model First.
    // Добавте на форму DataGridView и Button.
    // Реализуйте возможность вывода на экран информации в DataGridView по нажатию на Button. 

    public partial class Form1 : Form
    {

        Model1Container db;
        public Form1()
        {
            InitializeComponent();
            db = new Model1Container();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            db.MyEntitySet.Load();
            dgv.DataSource = db.MyEntitySet.Local.ToBindingList();
        }

    }
}
