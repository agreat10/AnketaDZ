using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AnketaDZ
{
     
    public partial class Form1 : Form
    {
        BindingList<Anketes> ankets = new BindingList<Anketes>();
        public Form1()
        {
            InitializeComponent();            
           
            listBox1.DataSource = ankets;
            listBox1.DisplayMember = "fulName";
        }
        public class Anketes
        {
            
            public string name { get; set; }
            public string lastName { get; set; }
            public string email { get; set; }
            public string phone { get; set; } 
            public string fulName { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(IsTxtBoxEmpty())
            {
                MessageBox.Show("Нельзя добавить пустые значения!",
                "Внимание",
                MessageBoxButtons.OK,
                MessageBoxIcon.Hand); 
            }
            else
            { 
                Anketes anketes = new Anketes();
                anketes.name = txtName.Text;
                anketes.lastName = txtLname.Text;
                anketes.email = txtEmail.Text;
                anketes.phone = txtPhone.Text;
                anketes.fulName =$"{txtName.Text} {txtLname.Text} {txtEmail.Text} {txtPhone.Text}";
                ankets.Add(anketes);
                listBox1.SelectedIndex = -1;
                ItemIndexText();
            }  
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex != -1)
            { 
                Anketes anketes = (Anketes)listBox1.SelectedItem;                

                txtName.Text =anketes.name;
                txtName.Select();
                txtLname.Text = anketes.lastName;
                txtEmail.Text = anketes.email;
                txtPhone.Text = anketes.phone;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ankets.Add(new Anketes
            {
                name = "Иван",
                lastName = "Иванов",
                email = "ivan@mail.ru",
                phone = "8999123456",
                fulName = $"Иван Иванов ivan@mail.ru 8999123456"
            });
            listBox1.SelectedIndex = -1;
            lblCount.Text = ankets.Count().ToString();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                lblProv.Text = fileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog1.FileName;
                lblProv.Text = fileName;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Anketes ank = (Anketes)listBox1.SelectedItem;
            int selectedIndex = listBox1.SelectedIndex;
            ankets.Remove(ank);            
            //lblCount.Text = ankets.Count().ToString();
            ItemIndexText();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex == -1)
            { MessageBox.Show("Выберите нужную запись в списке!",
                "Внимание",
                MessageBoxButtons.OK,
                MessageBoxIcon.Hand);
            }
            else
            { 
                Anketes ank = (Anketes)listBox1.SelectedItem;
                int selectedIndex = listBox1.SelectedIndex;

                ank.name = txtName.Text;
                ank.lastName = txtLname.Text;
                ank.email = txtEmail.Text;
                ank.phone = txtPhone.Text;
                ank.fulName = $"{txtName.Text} {txtLname.Text} {txtEmail.Text} {txtPhone.Text}";
                ankets.Remove(ank);            
                ankets.Insert(selectedIndex, ank);
                lblCount.Text = ankets.Count().ToString();
                listBox1.SelectedIndex = -1;
            }
        }
        private void ItemIndexText()
        {
            if(listBox1.SelectedIndex == -1)
            {
                
                txtName.Text = String.Empty; txtName.Select();
                txtLname.Text = String.Empty;
                txtEmail.Text = String.Empty;
                txtPhone.Text = String.Empty;
            }
            lblCount.Text = ankets.Count().ToString();
        }
        private bool IsTxtBoxEmpty()
        {
            if (txtName.Text == String.Empty ||
                txtLname.Text == String.Empty ||
                txtEmail.Text == String.Empty ||
                txtPhone.Text == String.Empty)
                 return true;            
            else return false;
        }
    }
}
