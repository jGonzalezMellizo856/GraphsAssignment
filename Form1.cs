using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace graphsAssignment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            dataGridView1.ColumnCount = 0;//column count starts at 0

            AddColumn_btn.Click += AddColumn_btn_Click;  //Adds columns into the data grid view when button is pressed


            upload.Click += upload_Click;  //uploads the data inside the data grid into the pie chart
        }

        //class that handles the uploading event for the data in the grid view into the pie chart
        private void upload_Click(object sender, EventArgs e)
        {
            List<string> columnName = new List<string>();
            List<double> rowValues = new List<double>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                {
                    string label = row.Cells[0].Value.ToString();
                    double value;

                    if (double.TryParse(row.Cells[1].Value.ToString(), out value))
                    {
                        columnName.Add(label);
                        rowValues.Add(value);
                        UpdatePieChart(columnName, rowValues);
                    }
                }
            }
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

        private void UpdatePieChart(List<string> labels, List<double> values)
        {
            chart1.Series.Clear();

            var series = new Series
            {
                Name = "PieSeries",
                ChartType = SeriesChartType.Pie
            };

            chart1.Series.Add(series);

            for(int i = 0; i < labels.Count; i++)
            {
                series.Points.AddXY(labels[i], values[i]);
            }

            series.IsValueShownAsLabel = true;
            chart1.Legends[0].Enabled = true;

        }
    }
}
