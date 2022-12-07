using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace foldrajzForms
{
    public partial class Form1 : Form
    {
        static List<string> Kerdes = new List<string>();
        static List<string> Valasz = new List<string>();
        
        public static class Conn
        {
            public static readonly MySqlConnection conn = new MySqlConnection("server=localhost;user=root;port=3306;password=;database=foldrajz");
        }
        static void Beolvas(RichTextBox ad)
        {
            StreamReader sr = new StreamReader("feladatok.sql");
            int sorszam = 1;
            while (!sr.EndOfStream)
            {
                if (sorszam % 2 == 1)
                {
                    string sor = sr.ReadLine();
                    Kerdes.Add(sor);
                    sorszam++;
                }
                else
                {
                    string sor = sr.ReadLine();
                    Valasz.Add(sor);
                    sorszam++;
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Beolvas(Elsooldal);
            Elsooldal.ReadOnly = true;
            string connStr = "server=localhost;user=root;port=3306;password=";

            MySqlConnection adatbazistorles = new MySqlConnection(connStr);
            MySqlCommand drdatabase = new MySqlCommand("DROP DATABASE IF EXISTS foldrajz", adatbazistorles);
            adatbazistorles.Open();
            drdatabase.ExecuteNonQuery();
            adatbazistorles.Close();
            MySqlCommand crdatabase = new MySqlCommand("CREATE DATABASE foldrajz DEFAULT CHARACTER SET utf8 COLLATE utf8_hungarian_ci; ", adatbazistorles);
            adatbazistorles.Open();
            crdatabase.ExecuteNonQuery();
            adatbazistorles.Close();

            try
            {
                string sql = File.ReadAllText("tablak.sql");
                string sql2 = File.ReadAllText("adatok.sql");
                Conn.conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, Conn.conn);
                cmd.ExecuteNonQuery();
                MySqlCommand cmd2 = new MySqlCommand(sql2, Conn.conn);
                cmd2.ExecuteNonQuery();
                Elsooldal.Text += " Az adatbázis létrejött!\n";
                Elsooldal.Text += " Az adatok feltöltődtek\n";
                Elsooldal.Text += "Ha szeretné látni a lekérdezéseket nyomja meg a gombot";
            }
            catch (Exception err)
            {
                Elsooldal.Text += " \n " + err.ToString();
            }
        }
        public Form1()
        {
            InitializeComponent();
        }       

        Button[] gomb;
        private void Elkezdes_Click(object sender, EventArgs e)
        {
            Elkezdes.Location= new Point(2000, 2000);//Gombeltüntetése

            Elsooldal.Clear();//Text box ujra helyezése
            Elsooldal.Location=new Point(200,150);
            Elsooldal.Size = new Size(800, 400);


            this.Size = new Size(1200, 600);
            int szelesseg = this.ClientSize.Width;
            int magassag = this.ClientSize.Height;
            int szCount = szelesseg / 90;

            gomb = new Button[65];
            for (int i = 0; i < gomb.Length; i++)
            {
                gomb[i] = new Button();
                gomb[i].Location = new System.Drawing.Point(i % szCount * 90, (i / szCount) * 30);
                gomb[i].Name = (i + 1).ToString();
                gomb[i].Size = new System.Drawing.Size(90, 25);
                gomb[i].Text = (i + 1).ToString();
                gomb[i].UseVisualStyleBackColor = true;

                gomb[i].Click +=Katt;

                this.Controls.Add(gomb[i]);
            }             
        }
        private void Katt(object sender, EventArgs e)
        {
            
            Elsooldal.Clear();
            Button b = sender as Button;
            int i = 1;
            foreach (var item in Kerdes)
            {
                if (i == int.Parse(b.Text))
                {
                    Elsooldal.Text += item;
                    break;
                }
                i++;
            }
            i = 1;
            foreach (var item in Valasz)
            {
                if (i == int.Parse(b.Text))
                {
                    MySqlCommand f1 = new MySqlCommand(item, Conn.conn);
                    MySqlDataReader kiir1 = f1.ExecuteReader();
                    while (kiir1.Read())
                    {
                        Elsooldal.Text += " \n ";

                        for (int j = 0; j < kiir1.FieldCount; j++)
                        {
                            Elsooldal.Text += kiir1[j]+" ";
                        }
                        Elsooldal.Text += " \n ";
                    }

                    Elsooldal.Text += " \n ";
                    kiir1.Close();

                    break;
                }
                i++;
            }
        }
        
    }
}
