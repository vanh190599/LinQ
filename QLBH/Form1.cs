using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Windows.Forms;
using System.Data.Entity;

namespace QLBH
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadData();
            loadCombo();
        }

        public void loadData() {
            DataClasses1DataContext data = new DataClasses1DataContext();

            var sp = from p in data.SanPhams
                    select p;
            list.DataSource = sp;
        }

        public void loadCombo()
        {
            DataClasses1DataContext data = new DataClasses1DataContext();

            var sp = from p in data.LoaiSPs
                     select p;
            cbLoaiSP.DataSource = sp;
            cbLoaiSP.DisplayMember = "tenLoai";
            cbLoaiSP.ValueMember = "maLoai";


            var a = from p in data.LoaiSPs
                     select p;
            

            //dua du lieu len combo trong dgv
     /*       (list.Columns["maLoai"] as DataGridViewComboBoxColumn).DataSource =  a;
            (list.Columns["maLoai"] as DataGridViewComboBoxColumn).DisplayMember = "tenLoai";
            (list.Columns["maLoai"] as DataGridViewComboBoxColumn).ValueMember = "maLoai";*/

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext data = new DataClasses1DataContext();
            SanPham them = new SanPham();
            them.maSP = txtMaSP.Text.Trim()+"";
            them.maLoai = cbLoaiSP.SelectedValue.ToString();
            them.donGia = txtDonGia.Text;
            them.TenSP = txtTenSP.Text;

            data.SanPhams.InsertOnSubmit(them);
            data.SubmitChanges();
            loadData(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("are you sure?" , "tb", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (tb == DialogResult.Yes)
            {
                int dong = list.CurrentRow.Index;
                //lay ma
                string ma = list.Rows[dong].Cells[0].Value.ToString();


                DataClasses1DataContext data = new DataClasses1DataContext();
                var xoa = from sp in data.SanPhams
                          where sp.maSP == ma
                          select sp;
                foreach (var i in xoa)
                {
                    data.SanPhams.DeleteOnSubmit(i);
                    data.SubmitChanges();
                }
                loadData();
            }
            else {
                return;
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext data = new DataClasses1DataContext();
            var capnhat = data.SanPhams.Single(sp => sp.maSP == txtMaSP.Text);

            capnhat.TenSP = txtTenSP.Text;
            capnhat.maSP = txtMaSP.Text;
            capnhat.donGia = txtDonGia.Text;

            data.SubmitChanges();
            loadData();

        }

        private void list_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int dong = list.CurrentRow.Index;
           

            //hien thi len panel
            txtMaSP.Text = list.Rows[dong].Cells[0].Value.ToString(); 
            txtTenSP.Text = list.Rows[dong].Cells[1].Value.ToString();
            cbLoaiSP.SelectedValue = list.Rows[dong].Cells[3].Value.ToString();
            txtDonGia.Text = list.Rows[dong].Cells[2].Value.ToString();
            
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext data = new DataClasses1DataContext();

            var sp = from p in data.SanPhams
                     where p.maLoai == cbLoaiSP.SelectedValue
                     select p;
            list.DataSource = sp;
            //loadData();
        }
    }
}
