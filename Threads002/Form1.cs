using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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


        Thread[] ThreadArr = new Thread[16];
        Random rnd = new Random();




        List<GeneratedDataClass> GeneratedDataList = new List<GeneratedDataClass>();


        public static int ivesrasSakuSk = 0;


        public Form1()
        {

            this.btnStart.Click += new System.EventHandler(this.btnStart_click);
            this.btnStop.Click += new System.EventHandler(this.btnStop_click);


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




        void Method1(object param)
        {
            while (true)
            {
                int SleepTime = rnd.Next(500, 2000);


                object[] parameters = (object[])param;
                int ThreadNrParam = (int)parameters[0];
                string param2 = (string)parameters[1];
                int laikas1 = (int)parameters[2];
                Thread.Sleep(SleepTime);



            }


        }



        void funkcija(int GetThreadNr, int GetSleepTime)
        {
            string RandString = "";
            for (int i = 0; i <= rnd.Next(5, 10); i++)
            {
                RandString += (char)rnd.Next(49,121);                
            }

            ListViewItem item = new ListViewItem();
            item = new ListViewItem(new string[] { GetThreadNr.ToString(), RandString });


            string datee = "";
            string timee = "";

            datee = DateTime.Now.ToString("yyyy-MM-dd");
            timee = DateTime.Now.ToString("HH:mm:ss.fff");





            GeneratedDataList.Add(new GeneratedDataClass { ThreadID = GetThreadNr, GeneratedString = RandString, Timee = timee, Datee = datee, ThreadSleepTime = GetSleepTime});





            if (GetThreadNr > 0)
            {
                ListViewDisplay.Invoke((MethodInvoker)delegate ()
                {
                    ListViewDisplay.Items.Add(item);
                    if (ListViewDisplay.Items.Count > 20)
                    {
                        ListViewDisplay.Items.RemoveAt(0);
                    }
                });

               


            }


        }

        private void btnExit_click(object sender, EventArgs e)
        {

            System.Windows.Forms.Application.Exit();

        }

        private void btnStart_click(object sender, EventArgs e)
        {

            txtbThreadNr.Enabled = false;
            btnStart.Enabled = false;
            btnStop.Enabled = true;



            try
            {
                ivesrasSakuSk = Convert.ToInt16(txtbThreadNr.Text);

                if (ivesrasSakuSk >= 2 && ivesrasSakuSk <= 15)
                {
                    btnStart.Enabled = false;
                    btnStop.Enabled = true;
                    for (int ThreadNr = 0; ThreadNr <= ivesrasSakuSk; ThreadNr++)
                    {
                        ThreadArr[ThreadNr] = new Thread(new ParameterizedThreadStart(Method1));
                        ThreadArr[ThreadNr].Start(new object[] { ThreadNr, "sakos nr: ", ThreadNr * 1000 + 1000 });

                    }
                }

            }
            catch (Exception ee)
            {
                btnStart.Enabled = true;
                btnStop.Enabled = false;
                txtbThreadNr.Enabled = true;
                txtbThreadNr.Text = "2";
                ivesrasSakuSk = 2;

                MessageBox.Show("Klaida, neteisingas saku skaicius\nTuri buti nuo 2 iki 15   \n\n\n  " + ee.ToString());
            }

            if(ivesrasSakuSk < 2 || ivesrasSakuSk > 15)
            {
                btnStart.Enabled = true;
                btnStop.Enabled = false;
                txtbThreadNr.Enabled = true;
                txtbThreadNr.Text = "2";
                ivesrasSakuSk = 2;
                MessageBox.Show("Klaida, neteisingas saku skaicius\nTuri buti nuo 2 iki 15   \n\n\n  ");

            }

        }
        private void btnStop_click(object sender, EventArgs e)
        {

            txtbThreadNr.Enabled = true;
            btnStart.Enabled = true;
            btnStop.Enabled = false;


        }

    }
}
