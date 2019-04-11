using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;
using MyModel;

namespace MyProject
{
   

    public partial class Form1 : Form
    {
        ClientController cc ;
        Client client;
        public Form1()
        {
            InitializeComponent();

            cc = new ClientController();


        }

        private void InsertBtn_Click(object sender, EventArgs e)
        {
            client = new Client();
            client.Firstname = FirstNameTB.Text;
            client.Lastname = LastNameTB.Text;
            cc.Insert(client);




        }

        private void FillBtn_Click(object sender, EventArgs e)
        {
            cmbClient.DataSource = cc.FillClient();

        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            Client newC = new Client();
            Client oldC = new Client();
            oldC = cmbClient.SelectedItem as Client;
            newC.Firstname = NewFirst.Text;
            newC.Lastname = NewLast.Text;
            cc.Update(oldC, newC);

        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            Client c = new Client();
            c = cmbClient.SelectedItem as Client;
            cc.Delete(c);

        }
    }
}
