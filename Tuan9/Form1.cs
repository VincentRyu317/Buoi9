﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Tuan9
{
    public partial class frm1: Form
    {
        public frm1()
        {
            InitializeComponent();
            connsql = kn.connect;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public class KetNoi
        {
            public SqlConnection connect;
            public KetNoi()
            {
                connect = new SqlConnection("Data Source=A209PC27;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
            }
            public KetNoi(string strcn)
            {
                connect = new SqlConnection(strcn);
            }
        }
        KetNoi kn = new KetNoi();
        SqlConnection connsql;
        private void frm1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                e.Cancel = true;
        }

        private void cbb_Khoa_Load(object sender, EventArgs e)
        {
            cbb_Khoa.Items.Clear();
            DataSet ds = new DataSet();

            string strselect = "Select * from Khoa";
            using (SqlDataAdapter da = new SqlDataAdapter())
            {
                da.SelectCommand.CommandText = strselect;
                da.SelectCommand.Connection = connsql;
                da.Fill(ds, "Khoa");
            }

            cbb_Khoa.DataSource = ds.Tables[0];
            cbb_Khoa.DisplayMember = "TenKhoa";
            cbb_Khoa.ValueMember = "MaKhoa";
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (connsql.State == ConnectionState.Closed)
            //    {
            //        connsql.Open();
            //    }
            //    if (connsql.State == ConnectionState.Open)
            //        {
            //            connsql.Close();
            //        }
            //    MessageBox.Show("Thanh cong");
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show("That bai");
            //}
            DataSet ds = new DataSet();

            // Tạo một SqlDataAdapter object
            if (connsql.State == ConnectionState.Closed)
            {
                connsql.Open();
            }
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand.CommandText = "Select TenKhoa from Khoa";
            da.SelectCommand.Connection = connsql;

            // Sử dụng Fill() method để điền dữ liệu từ bảng Khoa vào DataSet object
            da.Fill(ds, "Khoa");

            // Lấy dữ liệu từ DataSet object
            DataTable dt = ds.Tables["Khoa"];

            // Hiển thị dữ liệu lên màn hình
            foreach (DataRow dr in dt.Rows)
            {
                txt_TenLop.Text += dr["TenKhoa"].ToString() + " ";
            }
        }


        public SqlConnection cn { get; set; }
    }
}
