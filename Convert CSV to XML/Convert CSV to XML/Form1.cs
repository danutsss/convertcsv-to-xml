using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace Convert_CSV_to_XML
{ 
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            // To list only csv files, we need to add this filter
            openFileDialog.Filter = "|*.csv";
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                csvPath.Text = openFileDialog.FileName;
            }
        }

        private void btUpload_Click(object sender, EventArgs e)
        {
            try
            {
                csvGridView.DataSource = GetDataTableFromCSVFile(csvPath.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Import CSV File", MessageBoxButtons.OK,
  MessageBoxIcon.Error);
            }
        }

        private void btExport_Click(object sender, EventArgs e) {
            try
            {
                DataTable dt = (DataTable)csvGridView.DataSource;
                dt.TableName = "Facturi";
                dt.WriteXml(@"C:\Users\Public\CSV.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Export CSV File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static DataTable GetDataTableFromCSVFile(string csvfilePath)
        {
            DataTable csvData = new();
            using (TextFieldParser csvReader = new(csvfilePath))
            {
                csvReader.SetDelimiters(new string[] { "," });
                csvReader.HasFieldsEnclosedInQuotes = true;

                //Read columns from CSV file, remove this line if columns not exits  
                string[] colFields = csvReader.ReadFields();

                foreach(string column in colFields)
                {
                    if (column == "Number" || column == "Status" || column == "Created date" || column == "Due date" || column == "Total" || column == "Taxes" || column == "Discount" || column == "Amount paid" || column == "Amount due" || column == "Organization name" || column == "Client name" || column == "Organization address" || column == "Client address" || column == "Organization registration number" || column == "Organization tax id")
                    {
                        DataColumn datecolumn = new DataColumn(column);
                        datecolumn.AllowDBNull = true;
                        csvData.Columns.Add(datecolumn);
                    }
                }

                while (!csvReader.EndOfData)
                {
                    string[] fieldData = csvReader.ReadFields();
                    //Making empty value as null
                    for (int i = 0; i < fieldData.Length; i++)
                    {
                        if (fieldData[i] == "")
                        {
                            fieldData[i] = null;
                        }
                    }
                    csvData.Rows.Add(fieldData);
                }
            }
            return csvData;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}