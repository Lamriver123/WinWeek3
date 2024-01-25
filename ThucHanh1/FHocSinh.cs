using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
namespace ThucHanh1
{
    public partial class FHocSinh : Form
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        public FHocSinh()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string sqlStr = string.Format("SELECT *FROM HocSinh");
               
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                DataTable dtSinhVien = new DataTable();
                adapter.Fill(dtSinhVien);
                gvHsinh.DataSource = dtSinhVien; /// gvHsinh = name cua data gridview
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Ket noi
                conn.Open();
                string sqlStr = string.Format("INSERT INTO HocSinh(ID, Ten , Diachi, Cmnd, ngaySinh) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')", txtID.Text, txtName.Text, txtAddress.Text, txtCMND.Text, dateTimePicker1.Value.ToString());
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("them thanh cong");
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("them that bai" + ex);
            }
            finally
            {
                conn.Close();
                Form1_Load(sender, e);
            }

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                // Ket noi
                conn.Open();
                string SQL = string.Format("DELETE FROM HocSinh WHERE id = '{0}'", txtID.Text);
                SqlCommand cmd = new SqlCommand(SQL, conn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Remove thanh cong");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Remove that bai" + ex);
            }
            finally
            {
                conn.Close();
                Form1_Load(sender, e);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                // Ket noi
                conn.Open();
                string SQL = string.Format("UPDATE HocSinh SET Ten = '{0}', Diachi ='{1}', Cmnd = '{2}', ngaySinh = '{3}' WHERE ID = '{4}'", txtName.Text, txtAddress.Text , txtCMND.Text, dateTimePicker1.Value.ToString(), txtID.Text); 
                SqlCommand cmd = new SqlCommand(SQL, conn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Update thanh cong");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update that bai" + ex);
            }
            finally
            {
                conn.Close();
                Form1_Load(sender, e);
            }
        }

        private void btnGiaoVien_Click(object sender, EventArgs e)
        {
            this.Hide();
            FGiaoVien form2 = new FGiaoVien();
            form2.ShowDialog();
            this.Show();
        }

        private void gvHsinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {
                string value1 = gvHsinh.Rows[e.RowIndex].Cells[0].Value.ToString();
                string value2 = gvHsinh.Rows[e.RowIndex].Cells[1].Value.ToString();
                string value3 = gvHsinh.Rows[e.RowIndex].Cells[2].Value.ToString();
                string value4 = gvHsinh.Rows[e.RowIndex].Cells[3].Value.ToString();
                DateTime value5 = DateTime.Parse(gvHsinh.Rows[e.RowIndex].Cells[4].Value.ToString());

                txtID.Text = value1;
                txtName.Text = value2;
                txtAddress.Text = value3;
                txtCMND.Text = value4;
                dateTimePicker1.Value = value5;
            }
            catch(Exception ex) { }
        }
    }
}
