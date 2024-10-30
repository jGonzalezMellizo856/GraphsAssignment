using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graphsAssignment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            dataGridView1.ColumnCount = 0;

            AddColumn_btn.Click += AddColumn_btn_Click;

        }

        private void upload_Click(object sender, EventArgs e)
        {

        }

        private void AddColumn_btn_Click(object sender, EventArgs e)
        {
            string columnName = columnNameTextBox.Text;

            if (!string.IsNullOrEmpty(columnName))
            {
                dataGridView1.Columns.Add(columnName, columnName);
                columnNameTextBox.Clear();
            }
        }
    }
}
