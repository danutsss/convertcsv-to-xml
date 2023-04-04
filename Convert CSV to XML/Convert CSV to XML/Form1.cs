using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

using Microsoft.VisualBasic.FileIO;

namespace Convert_CSV_to_XML
{ 
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new()
            {
                // To list only csv files, we need to add this filter
                Filter = "|*.csv"
            };
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                csvPath.Text = openFileDialog.FileName;
            }
        }

        private void BtnUpload_Click(object sender, EventArgs e)
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

        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new()
                {
                    Filter = "XML|*.xml"
                };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        DataTable dt = (DataTable)csvGridView.DataSource;

                        // numar_iesire, data, scadent, total, denumire, inf_suplm, TVA (19% din total), CNP

                        XElement xe = new("Facturi",
                            from row in dt.AsEnumerable()
                            select new XElement("Factura",
                                    new XElement("Antet",
                                        new XElement("FurnizorNume", "Zero Sapte Services Srl"),
                                        new XElement("FurnizorCIF", "45858226"),
                                        new XElement("FurnizorNrRegCom", "J13/1003/2022"),
                                        new XElement("FurnizorCapital", "200.00"),
                                        new XElement("FurnizorAdresa", "Navodari str. Bv Mamaia Nord nr. 6 bl. Centrul eAfaceri ap. 01-05 jud. CONSTANTA"),
                                        new XElement("FurnizorBanca"),
                                        new XElement("FurnizorIBAN"),
                                        new XElement("FurnizorInformatiiSuplimentare", "Tel. 0241700000 Email stefan@sel.ro"),
                                        new XElement("ClientNume", row.Field<string>("denumire")),
                                        new XElement("ClientInformatiiSuplimentare", row.Field<string>("inf_suplm")),
                                        new XElement("ClientCIF", row.Field<string>("CNP / CUI")),
                                        new XElement("ClientNrRegCom"),
                                        new XElement("ClientTara", "RO"),
                                        new XElement("ClientAdresa"),
                                        new XElement("ClientBanca"),
                                        new XElement("ClientIBAN"),
                                        new XElement("FacturaNumar", row.Field<string>("nr_iesire")),
                                        new XElement("FacturaData", row.Field<string>("data")),
                                        new XElement("FacturaScadenta", row.Field<string>("scadent")),
                                        new XElement("FacturaTaxareInversa", "Nu"),
                                        new XElement("FacturaTVAIncasare", "Nu"),
                                        new XElement("FacturaInformatiiSuplimentare"),
                                        new XElement("FacturaMoneda", "RON")),
                                    new XElement("Detalii",
                                        new XElement("Continut",
                                            new XElement("Linie",
                                                new XElement("LinieNrCrt", row.Field<string>("nr_iesire")),
                                                new XElement("Descriere", row.Field<string>("denumire")),
                                                new XElement("CodArticolFurnizor"),
                                                new XElement("CodArticolClient"),
                                                new XElement("CodBare"),
                                                new XElement("InformatiiSuplimentare"),
                                                new XElement("UM", "BUC"),
                                                new XElement("Cantitate", "1"),
                                                new XElement("Pret", row.Field<string>("total")),
                                                new XElement("Valoare", row.Field<string>("total")),
                                                new XElement("ProcTVA", "19%"),
                                                new XElement("TVA", row.Field<string>("TVA"))))),
                                    new XElement("Sumar",
                                        new XElement("TotalValoare", row.Field<string>("total")),
                                        new XElement("TotalTVA", row.Field<string>("TVA")),
                                        new XElement("Total", row.Field<string>("total"))),
                                    new XElement("Observatii",
                                        new XElement("txtObservatii"),
                                        new XElement("SoldClient"))));
                        xe.Save(sfd.FileName);

                        MessageBox.Show("File saved successfully", "Export to XML", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message, "Export CSV File", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
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
                string[] colFields = csvReader.ReadFields() ?? throw new Exception("null");

                for (int i = 0; i < colFields.Length; i++)
                {
                    string column = colFields[i];
                    DataColumn datecolumn = new(column)
                    {
                        AllowDBNull = true
                    };
                    csvData.Columns.Add(datecolumn);
                }

                while (!csvReader.EndOfData)
                {
                    string[] fieldData = csvReader.ReadFields() ?? throw new Exception("null");
                    //Making empty value as null

                    if(fieldData is not null) {
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = "";
                            }
                        }
                        csvData.Rows.Add(fieldData);
                    }
                }
            }
            return csvData;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
