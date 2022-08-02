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
        DataSet ds = new DataSet();
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

        private void btExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "XML|*.xml";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        DataTable dt = (DataTable)csvGridView.DataSource;
                        // dt.TableName = "Facturi";
                        // dt.WriteXml(sfd.FileName);

                        XElement xe = new XElement("Facturi",
                            from row in dt.AsEnumerable()
                            select new XElement("Factura",
                                    new XElement("Antet",
                                        new XElement(("FurnizorNume") ?? "ZERO SAPTE SERVICES S.R.L"),
                                        new XElement(("FurnizorCIF") ?? "45858226"),
                                        new XElement(("FurnizorNrRegCom") ?? "J13/1003/2022"),
                                        new XElement(("FurnizorCapital") ?? "200 RON"),
                                        new XElement(("FurnizorTara") ?? "Romania"),
                                        new XElement(("FurnizorLocalitate") ?? "Navodari"),
                                        new XElement(("FurnizorJudet") ?? "Constanta"),
                                        new XElement(("FurnizorAdresa"), row.Field<string>("Organization address")),
                                        new XElement(("FurnizorTelefon" ?? "")),
                                        new XElement(("FurnizorMail" ?? "client@07internet.ro")),
                                        new XElement(("FurnizorBanca" ?? "")),
                                        new XElement(("FurnizorIBAN" ?? "")),
                                        new XElement(("FurnizorInformatiiSuplimentare"),
                                            new XElement(("GUID_cod_client") ?? "")),
                                        new XElement(("ClientNume"), row.Field<string>("Client name")),
                                        new XElement(("ClientInformatiiSuplimentare") ?? ""),
                                        new XElement(("ClientCIF") ?? ""),
                                        new XElement(("ClientNrRegCom") ?? ""),
                                        new XElement(("ClientJudet") ?? ""),
                                        new XElement(("ClientTara") ?? "RO"),
                                        new XElement(("ClientLocalitate") ?? ""),
                                        new XElement(("ClientAdresa"), row.Field<string>("Client address")),
                                        new XElement(("ClientBanca") ?? ""),
                                        new XElement(("ClientIBAN") ?? ""),
                                        new XElement(("ClientTelefon") ?? ""),
                                        new XElement(("ClientMail") ?? ""),
                                        new XElement(("FacturaNumar"), row.Field<string>("Number")),
                                        new XElement(("FacturaData"), row.Field<string>("Created date")),
                                        new XElement(("FacturaScadenta"), row.Field<string>("Due date")),
                                        new XElement(("FacturaTaxareInversa") ?? ""),
                                        new XElement(("FacturaTVAIncasare") ?? ""),
                                        new XElement(("FacturaTip") ?? ""),
                                        new XElement(("FacturaInformatiiSuplimentare"),
                                            new XElement(("FacturaMoneda") ?? "RON")),
                                        new XElement(("FacturaGreutate") ?? ""),
                                        new XElement(("FacturaAccize") ?? ""),
                                        new XElement(("Cod") ?? "")),
                                    new XElement("Detalii",
                                        new XElement("Continut",
                                            new XElement("Linie",
                                                new XElement(("LinieNrCrt") ?? ""),
                                                new XElement(("Gestiune") ?? ""),
                                                new XElement(("Activitate") ?? ""),
                                                new XElement(("Descriere") ?? ""),
                                                new XElement(("CodArticolFurnizor") ?? ""),
                                                new XElement("CodArticolClient",
                                                    new XElement(("GUID_cod_articol") ?? ""),
                                                    new XElement(("CodBare") ?? "")),
                                                new XElement(("InformatiiSuplimentare") ?? ""),
                                                new XElement(("UM") ?? ""),
                                                new XElement(("Cantitate") ?? ""),
                                                new XElement("Pret", row.Field<string>("Total")),
                                                new XElement("Valoare", row.Field<string>("Total")),
                                                new XElement(("ProcTVA") ?? ""),
                                                new XElement(("TVA") ?? ""),
                                                new XElement(("Cont") ?? "",
                                                    new XElement(("TipDeducere") ?? ""),
                                                    new XElement(("PretVanzare") ?? ""))))),
                                    new XElement(("FacturaID") ?? "")));
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