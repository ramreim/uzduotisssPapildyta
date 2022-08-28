using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Threads002
{
    public partial class Form1 : Form
    {


        Button btnStart = new Button();
        Button btnStop = new Button();
        Button btnExit = new Button();

        TextBox txtbThreadNr = new TextBox();


        Label lblThreadNr = new Label();




        ListView ListViewDisplay = new ListView();



        public Form1()
        {



            this.btnExit.Click += new System.EventHandler(this.btnExit_click);



            InitializeComponent();
            this.Size = new Size(1400,700);
            this.Text = "Pratimo atlikimas";
            this.ControlBox = false;

            #region labels_buttons_coordinates

            btnExit.Left = 1200;
            btnExit.Top = 20;
            btnExit.Height = 20;
            btnExit.Width = 100;
            btnExit.Text = "Close";
            btnExit.Enabled = true;
            this.Controls.Add(btnExit);

            btnStart.Left = 50;
            btnStart.Top = 120;
            btnStart.Height = 20;
            btnStart.Width = 100;
            btnStart.Text = "Start";
            btnStart.Enabled = true;
            this.Controls.Add(btnStart);

            btnStop.Left = 50;
            btnStop.Top = 160;
            btnStop.Height = 20;
            btnStop.Width = 100;
            btnStop.Text = "Stop";
            btnStop.Enabled = false;
            this.Controls.Add(btnStop);


            txtbThreadNr.Left = 200;
            txtbThreadNr.Top = 40;
            txtbThreadNr.Height = 20;
            txtbThreadNr.Width = 50;
            txtbThreadNr.Text = "2";
            txtbThreadNr.Enabled = true;
            this.Controls.Add(txtbThreadNr);



            lblThreadNr.Left = 140;
            lblThreadNr.Top = 40;
            lblThreadNr.Height = 20;
            lblThreadNr.Width = 60;
            lblThreadNr.Text = "Saku sk.:";
            lblThreadNr.Enabled = true;
            this.Controls.Add(lblThreadNr);




            ColumnHeader trIdCol = new ColumnHeader();
            trIdCol.Text = "Thread ID";
            trIdCol.Width = 70;
            trIdCol.TextAlign = HorizontalAlignment.Left;

            ColumnHeader eiluteCol = new ColumnHeader();
            eiluteCol.Text = "Sugeneruota eilute";
            eiluteCol.Width = 180;
            eiluteCol.TextAlign = HorizontalAlignment.Left;


            ListViewDisplay.View = View.Details;
            ListViewDisplay.LabelEdit = true;
            ListViewDisplay.CheckBoxes = false;
            ListViewDisplay.FullRowSelect = true;
            ListViewDisplay.GridLines = true;
            ListViewDisplay.Sorting = System.Windows.Forms.SortOrder.None;


            ListViewDisplay.Left = 850;
            ListViewDisplay.Top = 20;
            ListViewDisplay.Height = 500;
            ListViewDisplay.Width = 250;

            ListViewDisplay.Columns.Add(trIdCol);
            ListViewDisplay.Columns.Add(eiluteCol);
            this.Controls.Add(ListViewDisplay);





            #endregion labels_buttons_coordinates

        }

        private void btnExit_click(object sender, EventArgs e)
        {

            System.Windows.Forms.Application.Exit();

        }

    }
}
