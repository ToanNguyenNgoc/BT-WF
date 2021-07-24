using B_7.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B_7
{
    public partial class Form1 : Form
    {
        studentTable student = new studentTable();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StudentContextDB context = new StudentContextDB();
            refreshData();

            List<facultyTable> listFaculty = context.facultyTables.ToList();
            cmbFa.DataSource = listFaculty;
            cmbFa.ValueMember = "facultyId";
            cmbFa.DisplayMember = "facultyName";
        }
        private void refreshData()
        {
            StudentContextDB context = new StudentContextDB();
            List<studentTable> listStudents = context.studentTables.ToList();
            dgStudent.DataSource = listStudents;
        }
        private void dgStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                btnDel.Enabled = true;
                DataGridViewRow dgvRow = dgStudent.Rows[e.RowIndex];
                student.id = Convert.ToInt32(dgvRow.Cells[0].Value.ToString());
                txtId.Text = dgvRow.Cells[1].Value.ToString();
                txtName.Text = dgvRow.Cells[2].Value.ToString();
                txtCore.Text = dgvRow.Cells[3].Value.ToString();
                cmbFa.SelectedValue = dgvRow.Cells[4].Value;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            student.studentId = txtId.Text.Trim();
            student.fullName = txtName.Text.Trim();
            student.averageScore = txtCore.Text.Trim();
            student.facultyId = Convert.ToInt32(cmbFa.SelectedValue);
            using(StudentContextDB db = new StudentContextDB())
            {
                if (student.id == 0)
                {
                    db.studentTables.Add(student);
                    MessageBox.Show("Create Success !");
                }
                else
                {
                    db.Entry(student).State = EntityState.Modified;
                    MessageBox.Show("Update Success !");
                }
                db.SaveChanges();
            }
            refreshData();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            using (StudentContextDB db = new StudentContextDB())
            {
                var entry = db.Entry(student);
                if (entry.State == EntityState.Detached)
                    db.studentTables.Attach(student);
                db.studentTables.Remove(student);
                db.SaveChanges();
            }
            refreshData();
            MessageBox.Show("Delete Success!");
        }
    }
}
