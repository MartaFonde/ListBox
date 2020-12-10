using ListBox.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListBox
{
    public partial class Form1 : Form
    {
        static string titulo = "Listas dinámicas";
        int l = titulo.Length - 1;
        bool rep = true;
        bool vuelta = true;

        public Form1()
        {
            InitializeComponent();
            label2.Text = listBox1.Items.Count.ToString();
            label3.Text = "";
            this.Text = "";
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)  //añadir
        {
            if(textBox1.Text.Trim().Length > 0 && !listBox1.Items.Contains(textBox1.Text))
            {
                listBox1.Items.Add(textBox1.Text.Trim());
                label2.Text = listBox1.Items.Count.ToString();
                textBox1.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                eliminarItemsSeleccionados();
            }
        }

        private void eliminarItemsSeleccionados()
        {            
            int cantSelectItems = listBox1.SelectedItems.Count;
            while (cantSelectItems > 0)
            {
                listBox1.Items.Remove(listBox1.SelectedItems[0]);
                cantSelectItems--;
            }
            label2.Text = listBox1.Items.Count.ToString();           
        }

        private void button3_Click(object sender, EventArgs e)
        {            
            if(listBox1.SelectedIndex >= 0)
            {
                for (int i = 0; i < listBox1.SelectedItems.Count; i++)
                {
                    listBox2.Items.Insert(i, listBox1.SelectedItems[i]);                    
                }
                eliminarItemsSeleccionados();
                toolTip1.SetToolTip(listBox2, listBox2.Items.Count.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex >= 0)
            {
                listBox1.Items.Insert(0, listBox2.SelectedItem);
                listBox2.Items.Remove(listBox2.SelectedItem);
                label2.Text = listBox1.Items.Count.ToString();
                toolTip1.SetToolTip(listBox2, listBox2.Items.Count.ToString());
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label3.Text = "";
            if (listBox1.SelectedIndices.Count > 0)
            {
                for (int i = 0; i < listBox1.SelectedIndices.Count; i++)
                {
                    label3.Text += listBox1.SelectedIndices[i]+"\n";
                }                
            }            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {            
            if(this.Text.Length < titulo.Length)
            {
                this.Text = this.Text.Insert(0, titulo[l].ToString());
                //this.Text = titulo[l] + this.Text;
                l--;
                if(vuelta)
                {                 
                    this.Icon = rep? Resources.icon1 : Resources.icon2;
                    rep = !rep;                               
                }                
            }
            else
            {
                this.Text = "";
                l = titulo.Length - 1;
            }
            vuelta = !vuelta;
        }

        //private void listBox2_MouseEnter(object sender, EventArgs e)
        //{
        //    //ListBox listB = (ListBox)sender;
        //    toolTip1.SetToolTip(listBox2, listBox2.Items.Count.ToString());
        //}
        //ASI NON FUNCIONA COMO TOOLTIP --> RESPONDE A EVENTOS DE RATON
    }
}
