using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.OleDb;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using System.IO;

namespace SimpleDataBase
{
    public partial class mainForm : Form
    {
        Conn c = new Conn();
        int selectedFilmID;
        public mainForm()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            OleDbCommand command = new OleDbCommand();
            OleDbConnection connection;
            connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.15.0;Data Source=" + Path.GetDirectoryName(Application.ExecutablePath) + "/movieRentDataBase.accdb;Persist Security Info=False");
            OleDbDataAdapter adap = new OleDbDataAdapter();
            DataSet ds = new DataSet();
            command.Connection = connection;
            command.CommandText = "SELECT * from TFilms";
            connection.Open();
            adap.SelectCommand = command;
            adap.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            connection.Close();

            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Columns[0].Width = 35;
            dataGridView1.Columns[1].HeaderText = "Название фильма";
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].HeaderText = "Жанр";
            dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[3].HeaderText = "Страна";
            dataGridView1.Columns[3].Width = 80;
            dataGridView1.Columns[4].HeaderText = "Режиссер";
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].HeaderText = "Год выпуска";
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].HeaderText = "Состояние";
            dataGridView1.Columns[6].Width = 100;
            dataGridView1.Columns[7].HeaderText = "Дата выдачи";
            dataGridView1.Columns[7].Width = 115;
            dataGridView1.Columns[8].HeaderText = "Дата сдачи фильма";

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            cmbInfoRent.Items.Add("В наличии");
            cmbInfoRent.Items.Add("В прокате");
            cmbInfoRent2.Items.Add("В наличии");
            cmbInfoRent2.Items.Add("В прокате");
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Film f = new Film();
            f.FilmTitle = txtTitle.Text;
            f.FilmGenre = txtGenre.Text;
            f.FilmCountry = txtCountry.Text;
            f.FilmProducer = txtProducer.Text;
            f.FilmYear = txtYear.Text;
            f.InfoRent = cmbInfoRent.Text;
            f.InRent = txtInRent.Text;
            f.OverRent = txtOverRent.Text;

            c.Insert(f);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "";
            txtTitle.Clear();
            txtGenre.Text = "";
            txtGenre.Clear();
            txtCountry.Text = "";
            txtCountry.Clear();
            txtProducer.Text = "";
            txtProducer.Clear();
            txtYear.Text = "";
            txtYear.Clear();
            cmbInfoRent.Text = "";
            txtInRent.Text = "";
            txtInRent.Clear();
            txtOverRent.Text = "";
            txtOverRent.Clear();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            OleDbCommand command = new OleDbCommand();
            OleDbConnection connection;
            connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.15.0;Data Source=" + Path.GetDirectoryName(Application.ExecutablePath) + "/movieRentDataBase.accdb;Persist Security Info=False");
            OleDbDataAdapter adap = new OleDbDataAdapter();
            DataSet ds = new DataSet();
            command.Connection = connection;
            command.CommandText = "SELECT * from TFilms";
            connection.Open();
            adap.SelectCommand = command;
            adap.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            connection.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtTitle2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtGenre2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtCountry2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtProducer2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtYear2.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            cmbInfoRent2.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtInRent2.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtOverRent2.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

            if (e.RowIndex >= 0 && !string.IsNullOrEmpty(dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString()))
            {
                selectedFilmID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString());
            }
            else
            {
                selectedFilmID = -1;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Film f = new Film();
            f.ID = selectedFilmID;
            c.Delete(f);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Film f = new Film();

            f.FilmTitle = txtTitle2.Text;
            f.FilmGenre = txtGenre2.Text;
            f.FilmCountry = txtCountry2.Text;
            f.FilmProducer = txtProducer2.Text;
            f.FilmYear = txtYear2.Text;
            f.InfoRent = cmbInfoRent2.Text;
            f.InRent = txtInRent2.Text;
            f.OverRent = txtOverRent2.Text;

            f.ID = selectedFilmID;
            c.Update(f);
        }

        private void txtYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void txtYear2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Закрыть приложение?", "SimpleDataBase", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
