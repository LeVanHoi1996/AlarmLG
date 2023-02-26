using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace Baodongchem
{
    public partial class Report : DevExpress.XtraEditors.XtraForm
    {
        public Report()
        {
            InitializeComponent();
        }

        private void bt_forder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrEmpty(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);

                    //textBox1.Text = fbd.SelectedPath;
                }
            }
        }
        public DataTable CSVtoDataTable(string inputpath)
        {

            DataTable csvdt = new DataTable();
            string Fulltext;
            if (File.Exists(inputpath))
            {
                using (StreamReader sr = new StreamReader(inputpath))
                {
                    while (!sr.EndOfStream)
                    {
                        Fulltext = sr.ReadToEnd().ToString();//read full content
                        string[] rows = Fulltext.Split('\n');//split file content to get the rows
                        for (int i = 0; i < rows.Count() - 1; i++)
                        {
                            var regex = new Regex("\\\"(.*?)\\\"");
                            var output = regex.Replace(rows[i], m => m.Value.Replace(",", "\\c"));//replace commas inside quotes
                            string[] rowValues = output.Split(',');//split rows with comma',' to get the column values
                            {
                                if (i==0)
                                {
                                    for (int j = 0; j < rowValues.Count(); j++)
                                    {
                                        csvdt.Columns.Add("C" + (j + 1).ToString());//headers
                                    }
                                }
                                try
                                {
                                    DataRow dr = csvdt.NewRow();
                                    for (int k = 0; k < rowValues.Count(); k++)
                                    {
                                        if (k >= dr.Table.Columns.Count)// more columns may exist
                                        {
                                            csvdt.Columns.Add("clmn" + k);
                                            dr = csvdt.NewRow();
                                        }
                                        dr[k] = rowValues[k].Replace("\\c", ",");

                                    }
                                    csvdt.Rows.Add(dr);//add other rows
                                }
                                catch
                                {
                                    Console.WriteLine("error");
                                }
                            }
                        }
                    }
                }
            }
            return csvdt;
        }


        private void cb_select_EditValueChanged(object sender, EventArgs e)
        {

        }

        public static DataTable tb_mau = new DataTable();
        private void bt_Xem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                tb_mau.Clear();
                if (tb_mau.Columns.Count > 0)
                {
                    for (int i = tb_mau.Columns.Count - 1; i >= 0; i--)
                    {

                        tb_mau.Columns.RemoveAt(i);
                    }
                }


                if (cb_select.EditValue == "WATER PUMP")
                {
                    grv_report.Columns[0].Caption = "Thời gian";
                    grv_report.Columns[0].Width = 200;
                    grv_report.Columns[0].Visible = true;

                    grv_report.Columns[1].Caption = "No1 WATER PUMP";
                    grv_report.Columns[1].Width = 150;
                    grv_report.Columns[1].Visible = true;

                    grv_report.Columns[2].Caption = "No2 WATER PUMP";
                    grv_report.Columns[2].Width = 150;
                    grv_report.Columns[2].Visible = true;

                    grv_report.Columns[3].Caption = "No3 WATER PUMP";
                    grv_report.Columns[3].Width = 150;
                    grv_report.Columns[3].Visible = true;
                    grv_report.Columns[3].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                    grv_report.Columns[4].Caption = "No4 WATER PUMP";
                    grv_report.Columns[4].Width = 150;
                    grv_report.Columns[4].Visible = true;

                    grv_report.Columns[5].Caption = "No5 WATER PUMP";
                    grv_report.Columns[5].Width = 150;
                    grv_report.Columns[5].Visible = true;

                    grv_report.Columns[6].Caption = "No6 WATER PUMP";
                    grv_report.Columns[6].Width = 150;
                    grv_report.Columns[6].Visible = true;

                    grv_report.Columns[7].Caption = "No1 COOLING TOWER";
                    grv_report.Columns[7].Width = 150;
                    grv_report.Columns[7].Visible = true;

                    grv_report.Columns[8].Caption = "No2 COOLING TOWER";
                    grv_report.Columns[8].Width = 150;
                    grv_report.Columns[8].Visible = true;

                    grv_report.Columns[9].Caption = "WATER BATH TEMP";
                    grv_report.Columns[9].Width = 150;
                    grv_report.Columns[9].Visible = true;

                    grv_report.Columns[10].Caption = "WATER BATH TEMP AL";
                    grv_report.Columns[10].Width = 150;
                    grv_report.Columns[10].Visible = true;

                    grv_report.Columns[11].Visible = false;

                    grv_report.Columns[12].Visible = false;

                    grv_report.Columns[13].Visible = false;

                    grv_report.Columns[14].Visible = false;

                    grv_report.Columns[15].Visible = false;

                    grv_report.Columns[16].Visible = false;

                    grv_report.Columns[17].Visible = false;

                    grv_report.Columns[18].Visible = false;

                    grv_report.Columns[19].Visible = false;

                    grv_report.Columns[20].Visible = false;

                    grv_report.Columns[21].Visible = false;

                    grv_report.Columns[22].Visible = false;

                    grv_report.Columns[23].Visible = false;

                    grv_report.Columns[24].Visible = false;

                    grv_report.Columns[25].Visible = false;

                    grv_report.Columns[26].Visible = false;

                    grv_report.Columns[27].Visible = false;

                    grv_report.Columns[28].Visible = false;

                    grv_report.Columns[29].Visible = false;

                    grv_report.Columns[30].Visible = false;

                    grv_report.Columns[31].Visible = false;

                    grv_report.Columns[32].Visible = false;

                    grv_report.Columns[33].Visible = false;

                    grv_report.Columns[34].Visible = false;

                    grv_report.GroupPanelText = "REPORT FROM WATER PUMP";
                    DateTime Data_ngay = Convert.ToDateTime(bar_ngay.EditValue);
                    string newFileName = Application.StartupPath + @"\Log\Water_pump_log_" + Data_ngay.ToString("yyyyMMdd") + ".csv";
                    tb_mau = CSVtoDataTable(newFileName);

                    if (tb_mau.Rows.Count == 0)
                    {
                        gdv_report.DataSource = tb_mau;
                    }
                   else
                    {
                        DataTable dtCloned = tb_mau.Clone();
                        dtCloned.Columns[0].DataType = typeof(DateTime);
                        foreach (DataRow row in tb_mau.Rows)
                        {
                            if (row[0] == "")
                            {
                                row[0] = null;
                            }
                            dtCloned.ImportRow(row);
                        }
                        gdv_report.DataSource = dtCloned;
                    }
                   
                }
                else if (cb_select.EditValue == "VACCUM PUMP")
                {
                    grv_report.Columns[0].Caption = "Thời gian";
                    grv_report.Columns[0].Width = 200;
                    grv_report.Columns[0].Visible = true;

                    grv_report.Columns[1].Caption = "VACCUM PUMP A";
                    grv_report.Columns[1].Width = 150;
                    grv_report.Columns[1].Visible = true;

                    grv_report.Columns[2].Caption = "TEMP PUMP A";
                    grv_report.Columns[2].Width = 150;
                    grv_report.Columns[2].Visible = true;

                    grv_report.Columns[3].Caption = "TEMP PUMP A AL";
                    grv_report.Columns[3].Width = 150;
                    grv_report.Columns[3].Visible = true;
                    grv_report.Columns[3].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                    grv_report.Columns[4].Caption = "VACCUM PUMP B";
                    grv_report.Columns[4].Width = 150;
                    grv_report.Columns[4].Visible = true;

                    grv_report.Columns[5].Caption = "TEMP PUMP B";
                    grv_report.Columns[5].Width = 150;
                    grv_report.Columns[5].Visible = true;

                    grv_report.Columns[6].Caption = "TEMP PUMP B AL";
                    grv_report.Columns[6].Width = 150;
                    grv_report.Columns[6].Visible = true;

                    grv_report.Columns[7].Caption = "VACCUM PUMP C";
                    grv_report.Columns[7].Width = 150;
                    grv_report.Columns[7].Visible = true;

                    grv_report.Columns[8].Caption = "TEMP PUMP C";
                    grv_report.Columns[8].Width = 150;
                    grv_report.Columns[8].Visible = true;

                    grv_report.Columns[9].Caption = "TEMP PUMP C AL";
                    grv_report.Columns[9].Width = 150;
                    grv_report.Columns[9].Visible = true;

                    grv_report.Columns[10].Caption = "VACCUM PUMP D";
                    grv_report.Columns[10].Width = 150;
                    grv_report.Columns[10].Visible = true;

                    grv_report.Columns[11].Caption = "VACCUM PRESSURE ";
                    grv_report.Columns[11].Width = 150;
                    grv_report.Columns[11].Visible = true;

                    grv_report.Columns[12].Caption = "VACCUM PRESSURE AL";
                    grv_report.Columns[12].Width = 150;
                    grv_report.Columns[12].Visible = true;

                    grv_report.Columns[13].Visible = false;

                    grv_report.Columns[14].Visible = false;

                    grv_report.Columns[15].Visible = false;

                    grv_report.Columns[16].Visible = false;

                    grv_report.Columns[17].Visible = false;

                    grv_report.Columns[18].Visible = false;

                    grv_report.Columns[19].Visible = false;

                    grv_report.Columns[20].Visible = false;

                    grv_report.Columns[21].Visible = false;

                    grv_report.Columns[22].Visible = false;

                    grv_report.Columns[23].Visible = false;

                    grv_report.Columns[24].Visible = false;

                    grv_report.Columns[25].Visible = false;

                    grv_report.Columns[26].Visible = false;

                    grv_report.Columns[27].Visible = false;

                    grv_report.Columns[28].Visible = false;

                    grv_report.Columns[29].Visible = false;

                    grv_report.Columns[30].Visible = false;

                    grv_report.Columns[31].Visible = false;

                    grv_report.Columns[32].Visible = false;

                    grv_report.Columns[33].Visible = false;

                    grv_report.Columns[34].Visible = false;

                    grv_report.GroupPanelText = "REPORT FROM VACCUM PUMP";
                    DateTime Data_ngay = Convert.ToDateTime(bar_ngay.EditValue);
                    string newFileName = Application.StartupPath + @"\Log\Vaccum_pump_log_" + Data_ngay.ToString("yyyyMMdd") + ".csv";

                    tb_mau = CSVtoDataTable(newFileName);

                    if (tb_mau.Rows.Count == 0)
                    {
                        gdv_report.DataSource = tb_mau;
                    }
                    else
                    {
                        DataTable dtCloned = tb_mau.Clone();
                        dtCloned.Columns[0].DataType = typeof(DateTime);
                        foreach (DataRow row in tb_mau.Rows)
                        {
                            if (row[0] == "")
                            {
                                row[0] = null;
                            }
                            dtCloned.ImportRow(row);
                        }
                        gdv_report.DataSource = dtCloned;
                    }
                }
                else if (cb_select.EditValue == "AIR PRESSURE")
                {
                    grv_report.Columns[0].Caption = "Thời gian";
                    grv_report.Columns[0].Width = 200;
                    grv_report.Columns[0].Visible = true;

                    grv_report.Columns[1].Caption = "No1 AIR COMP";
                    grv_report.Columns[1].Width = 150;
                    grv_report.Columns[1].Visible = true;

                    grv_report.Columns[2].Caption = "No2 AIR COMP";
                    grv_report.Columns[2].Width = 150;
                    grv_report.Columns[2].Visible = true;

                    grv_report.Columns[3].Caption = "No1 AIR CHILER";
                    grv_report.Columns[3].Width = 150;
                    grv_report.Columns[3].Visible = true;
                    grv_report.Columns[3].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                    grv_report.Columns[4].Caption = "No2 AIR CHILER";
                    grv_report.Columns[4].Width = 150;
                    grv_report.Columns[4].Visible = true;

                    grv_report.Columns[5].Caption = "AIR PRESSURE ";
                    grv_report.Columns[5].Width = 150;
                    grv_report.Columns[5].Visible = true;

                    grv_report.Columns[6].Caption = "AIR PRESSURE AL";
                    grv_report.Columns[6].Width = 150;
                    grv_report.Columns[6].Visible = true;

                    grv_report.Columns[7].Visible = false;

                    grv_report.Columns[8].Visible = false;

                    grv_report.Columns[9].Visible = false;

                    grv_report.Columns[10].Visible = false;

                    grv_report.Columns[11].Visible = false;

                    grv_report.Columns[12].Visible = false;

                    grv_report.Columns[13].Visible = false;

                    grv_report.Columns[14].Visible = false;

                    grv_report.Columns[15].Visible = false;

                    grv_report.Columns[16].Visible = false;

                    grv_report.Columns[17].Visible = false;

                    grv_report.Columns[18].Visible = false;

                    grv_report.Columns[19].Visible = false;

                    grv_report.Columns[20].Visible = false;

                    grv_report.Columns[21].Visible = false;

                    grv_report.Columns[22].Visible = false;

                    grv_report.Columns[23].Visible = false;

                    grv_report.Columns[24].Visible = false;

                    grv_report.Columns[25].Visible = false;

                    grv_report.Columns[26].Visible = false;

                    grv_report.Columns[27].Visible = false;

                    grv_report.Columns[28].Visible = false;

                    grv_report.Columns[29].Visible = false;

                    grv_report.Columns[30].Visible = false;

                    grv_report.Columns[31].Visible = false;

                    grv_report.Columns[32].Visible = false;

                    grv_report.Columns[33].Visible = false;

                    grv_report.Columns[34].Visible = false;

                    grv_report.GroupPanelText = "REPORT FROM AIR PRESSURE";
                    DateTime Data_ngay = Convert.ToDateTime(bar_ngay.EditValue);
                    string newFileName = Application.StartupPath + @"\Log\Air_pressure_log_" + Data_ngay.ToString("yyyyMMdd") + ".csv";
                    tb_mau = CSVtoDataTable(newFileName);

                    if (tb_mau.Rows.Count == 0)
                    {
                        gdv_report.DataSource = tb_mau;
                    }
                    else
                    {
                        DataTable dtCloned = tb_mau.Clone();
                        dtCloned.Columns[0].DataType = typeof(DateTime);
                        foreach (DataRow row in tb_mau.Rows)
                        {
                            if (row[0] == "")
                            {
                                row[0] = null;
                            }
                            dtCloned.ImportRow(row);
                        }
                        gdv_report.DataSource = dtCloned;
                    }
                }
                else if (cb_select.EditValue == "FUME DUST")
                {
                    grv_report.Columns[0].Caption = "Thời gian";
                    grv_report.Columns[0].Width = 200;
                    grv_report.Columns[0].Visible = true;

                    grv_report.Columns[1].Caption = "FUME BLOWER A";
                    grv_report.Columns[1].Width = 150;
                    grv_report.Columns[1].Visible = true;

                    grv_report.Columns[2].Caption = "FUME BLOWER B";
                    grv_report.Columns[2].Width = 150;
                    grv_report.Columns[2].Visible = true;

                    grv_report.Columns[3].Caption = "DUST BLOWER A";
                    grv_report.Columns[3].Width = 150;
                    grv_report.Columns[3].Visible = true;
                    grv_report.Columns[3].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                    grv_report.Columns[4].Caption = "DUST BLOWER B";
                    grv_report.Columns[4].Width = 150;
                    grv_report.Columns[4].Visible = true;

                    grv_report.Columns[5].Caption = "DUST BLOWER C";
                    grv_report.Columns[5].Width = 150;
                    grv_report.Columns[5].Visible = true;

                    grv_report.Columns[6].Caption = "FUME PRESSURE ";
                    grv_report.Columns[6].Width = 150;
                    grv_report.Columns[6].Visible = true;

                    grv_report.Columns[7].Caption = "FUME PRESSURE AL";
                    grv_report.Columns[7].Width = 150;
                    grv_report.Columns[7].Visible = true;

                    grv_report.Columns[8].Caption = "DUST PRESSURE ";
                    grv_report.Columns[8].Width = 150;
                    grv_report.Columns[8].Visible = true;

                    grv_report.Columns[9].Caption = "DUST PRESSURE AL";
                    grv_report.Columns[9].Width = 150;
                    grv_report.Columns[9].Visible = true;

                    grv_report.Columns[10].Visible = false;

                    grv_report.Columns[11].Visible = false;

                    grv_report.Columns[12].Visible = false;

                    grv_report.Columns[13].Visible = false;

                    grv_report.Columns[14].Visible = false;

                    grv_report.Columns[15].Visible = false;

                    grv_report.Columns[16].Visible = false;

                    grv_report.Columns[17].Visible = false;

                    grv_report.Columns[18].Visible = false;

                    grv_report.Columns[19].Visible = false;

                    grv_report.Columns[20].Visible = false;

                    grv_report.Columns[21].Visible = false;

                    grv_report.Columns[22].Visible = false;

                    grv_report.Columns[23].Visible = false;

                    grv_report.Columns[24].Visible = false;

                    grv_report.Columns[25].Visible = false;

                    grv_report.Columns[26].Visible = false;

                    grv_report.Columns[27].Visible = false;

                    grv_report.Columns[28].Visible = false;

                    grv_report.Columns[29].Visible = false;

                    grv_report.Columns[30].Visible = false;

                    grv_report.Columns[31].Visible = false;

                    grv_report.Columns[32].Visible = false;

                    grv_report.Columns[33].Visible = false;

                    grv_report.Columns[34].Visible = false;

                    grv_report.GroupPanelText = "REPORT FROM FUME DUST";
                    DateTime Data_ngay = Convert.ToDateTime(bar_ngay.EditValue);
                    string newFileName = Application.StartupPath + @"\Log\Fume_dust_log_" + Data_ngay.ToString("yyyyMMdd") + ".csv";
                    tb_mau = CSVtoDataTable(newFileName);

                    if (tb_mau.Rows.Count == 0)
                    {
                        gdv_report.DataSource = tb_mau;
                    }
                    else
                    {
                        DataTable dtCloned = tb_mau.Clone();
                        dtCloned.Columns[0].DataType = typeof(DateTime);
                        foreach (DataRow row in tb_mau.Rows)
                        {
                            if (row[0] == "")
                            {
                                row[0] = null;
                            }
                            dtCloned.ImportRow(row);
                        }
                        gdv_report.DataSource = dtCloned;
                    }
                }
                else if (cb_select.EditValue == "RTO")
                {
                    grv_report.Columns[0].Caption = "Thời gian";
                    grv_report.Columns[0].Width = 200;
                    grv_report.Columns[0].Visible = true;

                    grv_report.Columns[1].Caption = "TE 1953A";
                    grv_report.Columns[1].Width = 150;
                    grv_report.Columns[1].Visible = true;

                    grv_report.Columns[2].Caption = "TE 1953A AL";
                    grv_report.Columns[2].Width = 150;
                    grv_report.Columns[2].Visible = true;

                    grv_report.Columns[3].Caption = "AVE TEMP";
                    grv_report.Columns[3].Width = 150;
                    grv_report.Columns[3].Visible = true;
                    grv_report.Columns[3].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                    grv_report.Columns[4].Caption = "AVE TEMP AL";
                    grv_report.Columns[4].Width = 150;
                    grv_report.Columns[4].Visible = true;

                    grv_report.Columns[5].Caption = "TE 1953B";
                    grv_report.Columns[5].Width = 150;
                    grv_report.Columns[5].Visible = true;

                    grv_report.Columns[6].Caption = "TE 1953B AL";
                    grv_report.Columns[6].Width = 150;
                    grv_report.Columns[6].Visible = true;

                    grv_report.Columns[7].Caption = "TE 1952A";
                    grv_report.Columns[7].Width = 150;
                    grv_report.Columns[7].Visible = true;

                    grv_report.Columns[8].Caption = "TE 1952A AL";
                    grv_report.Columns[8].Width = 150;
                    grv_report.Columns[8].Visible = true;

                    grv_report.Columns[9].Caption = "TE 1952B";
                    grv_report.Columns[9].Width = 150;
                    grv_report.Columns[9].Visible = true;

                    grv_report.Columns[10].Caption = "TE 1952B AL";
                    grv_report.Columns[10].Width = 150;
                    grv_report.Columns[10].Visible = true;

                    grv_report.Columns[11].Caption = "TE 1952C";
                    grv_report.Columns[11].Width = 150;
                    grv_report.Columns[11].Visible = true;

                    grv_report.Columns[12].Caption = "TE 1952C AL";
                    grv_report.Columns[12].Width = 150;
                    grv_report.Columns[12].Visible = true;

                    grv_report.Columns[13].Caption = "TE 1954";
                    grv_report.Columns[13].Width = 150;
                    grv_report.Columns[13].Visible = true;

                    grv_report.Columns[14].Caption = "TE 1954 AL";
                    grv_report.Columns[14].Width = 150;
                    grv_report.Columns[14].Visible = true;

                    grv_report.Columns[15].Caption = "TE 1951";
                    grv_report.Columns[15].Width = 150;
                    grv_report.Columns[15].Visible = true;

                    grv_report.Columns[16].Caption = "TE 1954 AL";
                    grv_report.Columns[16].Width = 150;
                    grv_report.Columns[16].Visible = true;

                    grv_report.Columns[17].Caption = "XV 1952";
                    grv_report.Columns[17].Width = 150;
                    grv_report.Columns[17].Visible = true;

                    grv_report.Columns[18].Caption = "XV 1951";
                    grv_report.Columns[18].Width = 150;
                    grv_report.Columns[18].Visible = true;

                    grv_report.Columns[19].Caption = "XV 1956";
                    grv_report.Columns[19].Width = 150;
                    grv_report.Columns[19].Visible = true;

                    grv_report.Columns[20].Caption = "BY PASS";
                    grv_report.Columns[20].Width = 150;
                    grv_report.Columns[20].Visible = true;

                    grv_report.Columns[21].Visible = false;

                    grv_report.Columns[22].Visible = false;

                    grv_report.Columns[23].Visible = false;

                    grv_report.Columns[24].Visible = false;

                    grv_report.Columns[25].Visible = false;

                    grv_report.Columns[26].Visible = false;

                    grv_report.Columns[27].Visible = false;

                    grv_report.Columns[28].Visible = false;

                    grv_report.Columns[29].Visible = false;

                    grv_report.Columns[30].Visible = false;

                    grv_report.Columns[31].Visible = false;

                    grv_report.Columns[32].Visible = false;

                    grv_report.Columns[33].Visible = false;

                    grv_report.Columns[34].Visible = false;

                    grv_report.GroupPanelText = "REPORT FROM RTO";
                    DateTime Data_ngay = Convert.ToDateTime(bar_ngay.EditValue);
                    string newFileName = Application.StartupPath + @"\Log\Rto_log_" + Data_ngay.ToString("yyyyMMdd") + ".csv";
                    tb_mau = CSVtoDataTable(newFileName);

                    if (tb_mau.Rows.Count == 0)
                    {
                        gdv_report.DataSource = tb_mau;
                    }
                    else
                    {
                        DataTable dtCloned = tb_mau.Clone();
                        dtCloned.Columns[0].DataType = typeof(DateTime);
                        foreach (DataRow row in tb_mau.Rows)
                        {
                            if (row[0] == "")
                            {
                                row[0] = null;
                            }
                            dtCloned.ImportRow(row);
                        }
                        gdv_report.DataSource = dtCloned;
                    }
                }
                else if (cb_select.EditValue == "MCC ROOM")
                {
                    grv_report.Columns[0].Caption = "Thời gian";
                    grv_report.Columns[0].Width = 200;
                    grv_report.Columns[0].Visible = true;

                    grv_report.Columns[1].Caption = "1 MIXER 1";
                    grv_report.Columns[1].Width = 150;
                    grv_report.Columns[1].Visible = true;

                    grv_report.Columns[2].Caption = "2 QA TEST";
                    grv_report.Columns[2].Width = 150;
                    grv_report.Columns[2].Visible = true;

                    grv_report.Columns[3].Caption = "3 Ex2 MCCB";
                    grv_report.Columns[3].Width = 150;
                    grv_report.Columns[3].Visible = true;
                    grv_report.Columns[3].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                    grv_report.Columns[4].Caption = "4 Ex1 MCCB";
                    grv_report.Columns[4].Width = 150;
                    grv_report.Columns[4].Visible = true;

                    grv_report.Columns[5].Caption = "5 MIXER 2";
                    grv_report.Columns[5].Width = 150;
                    grv_report.Columns[5].Visible = true;

                    grv_report.Columns[6].Caption = "6 MIXER 3";
                    grv_report.Columns[6].Width = 150;
                    grv_report.Columns[6].Visible = true;

                    grv_report.Columns[7].Caption = "7 AIR COND 3";
                    grv_report.Columns[7].Width = 150;
                    grv_report.Columns[7].Visible = true;

                    grv_report.Columns[8].Caption = "8 PLC POWER";
                    grv_report.Columns[8].Width = 150;
                    grv_report.Columns[8].Visible = true;

                    grv_report.Columns[9].Caption = "9 PACKER";
                    grv_report.Columns[9].Width = 150;
                    grv_report.Columns[9].Visible = true;

                    grv_report.Columns[10].Caption = "10 PNEUMATIC";
                    grv_report.Columns[10].Width = 150;
                    grv_report.Columns[10].Visible = true;

                    grv_report.Columns[11].Caption = "11 HOIST";
                    grv_report.Columns[11].Width = 150;
                    grv_report.Columns[11].Visible = true;

                    grv_report.Columns[12].Caption = "12 RTO HEATER";
                    grv_report.Columns[12].Width = 150;
                    grv_report.Columns[12].Visible = true;

                    grv_report.Columns[13].Caption = "13 Ex2 INVETER";
                    grv_report.Columns[13].Width = 150;
                    grv_report.Columns[13].Visible = true;

                    grv_report.Columns[14].Caption = "14 CS KHO TP";
                    grv_report.Columns[14].Width = 150;
                    grv_report.Columns[14].Visible = true;

                    grv_report.Columns[15].Caption = "15 CS KHO SX";
                    grv_report.Columns[15].Width = 150;
                    grv_report.Columns[15].Visible = true;

                    grv_report.Columns[16].Caption = "16 CS KHO NL";
                    grv_report.Columns[16].Width = 150;
                    grv_report.Columns[16].Visible = true;

                    grv_report.Columns[17].Caption = "17 AIR COND 1";
                    grv_report.Columns[17].Width = 150;
                    grv_report.Columns[17].Visible = true;

                    grv_report.Columns[18].Caption = "18 EX PILOT MCCB";
                    grv_report.Columns[18].Width = 150;
                    grv_report.Columns[18].Visible = true;

                    grv_report.Columns[19].Caption = "19 EX PILOT INVT";
                    grv_report.Columns[19].Width = 150;
                    grv_report.Columns[19].Visible = true;

                    grv_report.Columns[20].Caption = "20 Ex1 INVT";
                    grv_report.Columns[20].Width = 150;
                    grv_report.Columns[20].Visible = true;

                    grv_report.Columns[21].Caption = "21 MAINTENANCE";
                    grv_report.Columns[21].Width = 150;
                    grv_report.Columns[21].Visible = true;

                    grv_report.Columns[22].Caption = "22 DB PANEL";
                    grv_report.Columns[22].Width = 150;
                    grv_report.Columns[22].Visible = true;

                    grv_report.Columns[23].Caption = "23 Ex3 MCCB";
                    grv_report.Columns[23].Width = 150;
                    grv_report.Columns[23].Visible = true;

                    grv_report.Columns[24].Caption = "24 AIR COND 2";
                    grv_report.Columns[24].Width = 150;
                    grv_report.Columns[24].Visible = true;

                    grv_report.Columns[25].Caption = "25 ULTILITY PANEL";
                    grv_report.Columns[25].Width = 150;
                    grv_report.Columns[25].Visible = true;

                    grv_report.Columns[26].Caption = "26 Ex3 INVT";
                    grv_report.Columns[26].Width = 150;
                    grv_report.Columns[26].Visible = true;

                    grv_report.Columns[27].Caption = "T.R. ROOM TEMP";
                    grv_report.Columns[27].Width = 150;
                    grv_report.Columns[27].Visible = true;

                    grv_report.Columns[28].Caption = "T.R. ROOM TEMP AL";
                    grv_report.Columns[28].Width = 150;
                    grv_report.Columns[28].Visible = true;

                    grv_report.Columns[29].Caption = "T.R. ROOM MUMIDITY";
                    grv_report.Columns[29].Width = 150;
                    grv_report.Columns[29].Visible = true;

                    grv_report.Columns[30].Caption = "T.R. ROOM MUMIDITY AL";
                    grv_report.Columns[30].Width = 150;
                    grv_report.Columns[30].Visible = true;

                    grv_report.Columns[31].Caption = "MCC ROOM TEMP";
                    grv_report.Columns[31].Width = 150;
                    grv_report.Columns[31].Visible = true;

                    grv_report.Columns[32].Caption = "MCC ROOM TEMP AL";
                    grv_report.Columns[32].Width = 150;
                    grv_report.Columns[32].Visible = true;

                    grv_report.Columns[33].Caption = "MCC ROOM MUMIDITY";
                    grv_report.Columns[33].Width = 150;
                    grv_report.Columns[33].Visible = true;

                    grv_report.Columns[34].Caption = "MCC ROOM MUMIDITY AL";
                    grv_report.Columns[34].Width = 150;
                    grv_report.Columns[34].Visible = true;

                    grv_report.GroupPanelText = "REPORT FROM MCC";
                    DateTime Data_ngay = Convert.ToDateTime(bar_ngay.EditValue);
                    string newFileName = Application.StartupPath + @"\Log\MCC_log_" + Data_ngay.ToString("yyyyMMdd") + ".csv";
                    tb_mau = CSVtoDataTable(newFileName);

                    if (tb_mau.Rows.Count == 0)
                    {
                        gdv_report.DataSource = tb_mau;
                    }
                    else
                    {
                        DataTable dtCloned = tb_mau.Clone();
                        dtCloned.Columns[0].DataType = typeof(DateTime);
                        foreach (DataRow row in tb_mau.Rows)
                        {
                            if (row[0] == "")
                            {
                                row[0] = null;
                            }
                            dtCloned.ImportRow(row);
                        }
                        gdv_report.DataSource = dtCloned;
                    }
                }
                else if (cb_select.EditValue == "ALARM")
                {
                    grv_report.Columns[0].Caption = "Thời gian bắt đầu";
                    grv_report.Columns[0].Width = 200;
                    grv_report.Columns[0].Visible = true;
                    grv_report.Columns[0].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
                    grv_report.Columns[0].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

                    grv_report.Columns[1].Caption = "Thời gian kết thúc";
                    grv_report.Columns[1].Width = 200;
                    grv_report.Columns[1].Visible = true;
                    grv_report.Columns[1].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
                    grv_report.Columns[1].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

                    grv_report.Columns[2].Caption = "Khu vực";
                    grv_report.Columns[2].Width = 300;
                    grv_report.Columns[2].Visible = true;

                    grv_report.Columns[3].Caption = "Lỗi";
                    grv_report.Columns[3].Width = 500;
                    grv_report.Columns[3].Visible = true;
                    grv_report.Columns[3].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;

                    grv_report.Columns[4].Visible = false;

                    grv_report.Columns[5].Visible = false;

                    grv_report.Columns[6].Visible = false;

                    grv_report.Columns[7].Visible = false;

                    grv_report.Columns[8].Visible = false;

                    grv_report.Columns[9].Visible = false;

                    grv_report.Columns[10].Visible = false;

                    grv_report.Columns[11].Visible = false;

                    grv_report.Columns[12].Visible = false;

                    grv_report.Columns[13].Visible = false;

                    grv_report.Columns[14].Visible = false;

                    grv_report.Columns[15].Visible = false;

                    grv_report.Columns[16].Visible = false;

                    grv_report.Columns[17].Visible = false;

                    grv_report.Columns[18].Visible = false;

                    grv_report.Columns[19].Visible = false;

                    grv_report.Columns[20].Visible = false;

                    grv_report.Columns[21].Visible = false;

                    grv_report.Columns[22].Visible = false;

                    grv_report.Columns[23].Visible = false;

                    grv_report.Columns[24].Visible = false;

                    grv_report.Columns[25].Visible = false;

                    grv_report.Columns[26].Visible = false;

                    grv_report.Columns[27].Visible = false;

                    grv_report.Columns[28].Visible = false;

                    grv_report.Columns[29].Visible = false;

                    grv_report.Columns[30].Visible = false;

                    grv_report.Columns[31].Visible = false;

                    grv_report.Columns[32].Visible = false;

                    grv_report.Columns[33].Visible = false;

                    grv_report.Columns[34].Visible = false;

                    grv_report.GroupPanelText = "REPORT FROM ALARM";
                    DateTime Data_ngay = Convert.ToDateTime(bar_ngay.EditValue);
                    string newFileName = Application.StartupPath + @"\Error_Log\Log_" + Data_ngay.ToString("yyyyMMdd") + ".csv";
                    tb_mau = CSVtoDataTable(newFileName);

                    if (tb_mau.Rows.Count == 0)
                    {
                        gdv_report.DataSource = tb_mau;
                    }
                    else
                    {
                        DataTable dtCloned = tb_mau.Clone();
                        dtCloned.Columns[0].DataType = typeof(DateTime);
                        dtCloned.Columns[1].DataType = typeof(DateTime);
                        foreach (DataRow row in tb_mau.Rows)
                        {
                            if (row[0] == "")
                            {
                                row[0] = null;
                            }
                            if (row[1] == "")
                            {
                                row[1] = null;
                            }
                            dtCloned.ImportRow(row);
                        }
                        gdv_report.DataSource = dtCloned;
                    }
                }
                else if (cb_select.EditValue == "PACKERLINEA")
                {
                  
                    grv_report.Columns[0].Visible = false;

                    grv_report.Columns[1].Caption = "Ngày";
                    grv_report.Columns[1].Width = 150;
                    grv_report.Columns[1].Visible = true;

                    grv_report.Columns[2].Caption = "Giờ";
                    grv_report.Columns[2].Width = 150;
                    grv_report.Columns[2].Visible = true;

                    grv_report.Columns[3].Caption = "Weight";
                    grv_report.Columns[3].Width = 150;
                    grv_report.Columns[3].Visible = true;
                    grv_report.Columns[3].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    grv_report.Columns[4].Caption = "Temperature";
                    grv_report.Columns[4].Width = 150;
                    grv_report.Columns[4].Visible = true;
                    grv_report.Columns[4].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                    
                    grv_report.Columns[5].Visible = false;
                    grv_report.Columns[6].Visible = false;
                    grv_report.Columns[7].Visible = false;
                    grv_report.Columns[8].Visible = false;
                    grv_report.Columns[9].Visible = false;
                    grv_report.Columns[10].Visible = false;
                    grv_report.Columns[11].Visible = false;

                    grv_report.Columns[12].Visible = false;

                    grv_report.Columns[13].Visible = false;

                    grv_report.Columns[14].Visible = false;

                    grv_report.Columns[15].Visible = false;

                    grv_report.Columns[16].Visible = false;

                    grv_report.Columns[17].Visible = false;

                    grv_report.Columns[18].Visible = false;

                    grv_report.Columns[19].Visible = false;

                    grv_report.Columns[20].Visible = false;

                    grv_report.Columns[21].Visible = false;

                    grv_report.Columns[22].Visible = false;

                    grv_report.Columns[23].Visible = false;

                    grv_report.Columns[24].Visible = false;

                    grv_report.Columns[25].Visible = false;

                    grv_report.Columns[26].Visible = false;

                    grv_report.Columns[27].Visible = false;

                    grv_report.Columns[28].Visible = false;

                    grv_report.Columns[29].Visible = false;

                    grv_report.Columns[30].Visible = false;

                    grv_report.Columns[31].Visible = false;

                    grv_report.Columns[32].Visible = false;

                    grv_report.Columns[33].Visible = false;

                    grv_report.Columns[34].Visible = false;

                    grv_report.GroupPanelText = "REPORT FROM PACKERLINEA";
                    DateTime Data_ngay = Convert.ToDateTime(bar_ngay.EditValue);
                    string newFileName = Application.StartupPath + @"\Log\PACKA_log_" + Data_ngay.ToString("yyyyMMdd") + ".csv";
                    tb_mau = CSVtoDataTable(newFileName);

                    if (tb_mau.Rows.Count == 0)
                    {
                        gdv_report.DataSource = tb_mau;
                    }
                    else
                    {
                        DataTable dtCloned = tb_mau;
                        dtCloned.DefaultView.Sort = "C3 DESC";
                        gdv_report.DataSource = dtCloned;
                    }
                }
                else if (cb_select.EditValue == "PACKERLINEB") {

                    grv_report.Columns[0].Visible = false;

                    grv_report.Columns[1].Caption = "Ngày";
                    grv_report.Columns[1].Width = 150;
                    grv_report.Columns[1].Visible = true;

                    grv_report.Columns[2].Caption = "Giờ";
                    grv_report.Columns[2].Width = 150;
                    grv_report.Columns[2].Visible = true;

                    grv_report.Columns[3].Caption = "Weight";
                    grv_report.Columns[3].Width = 150;
                    grv_report.Columns[3].Visible = true;
                    grv_report.Columns[3].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    grv_report.Columns[4].Caption = "Temperature";
                    grv_report.Columns[4].Width = 150;
                    grv_report.Columns[4].Visible = true;
                    grv_report.Columns[4].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;


                    grv_report.Columns[5].Visible = false;
                    grv_report.Columns[6].Visible = false;
                    grv_report.Columns[7].Visible = false;
                    grv_report.Columns[8].Visible = false;
                    grv_report.Columns[9].Visible = false;
                    grv_report.Columns[10].Visible = false;
                    grv_report.Columns[11].Visible = false;

                    grv_report.Columns[12].Visible = false;

                    grv_report.Columns[13].Visible = false;

                    grv_report.Columns[14].Visible = false;

                    grv_report.Columns[15].Visible = false;

                    grv_report.Columns[16].Visible = false;

                    grv_report.Columns[17].Visible = false;

                    grv_report.Columns[18].Visible = false;

                    grv_report.Columns[19].Visible = false;

                    grv_report.Columns[20].Visible = false;

                    grv_report.Columns[21].Visible = false;

                    grv_report.Columns[22].Visible = false;

                    grv_report.Columns[23].Visible = false;

                    grv_report.Columns[24].Visible = false;

                    grv_report.Columns[25].Visible = false;

                    grv_report.Columns[26].Visible = false;

                    grv_report.Columns[27].Visible = false;

                    grv_report.Columns[28].Visible = false;

                    grv_report.Columns[29].Visible = false;

                    grv_report.Columns[30].Visible = false;

                    grv_report.Columns[31].Visible = false;

                    grv_report.Columns[32].Visible = false;

                    grv_report.Columns[33].Visible = false;

                    grv_report.Columns[34].Visible = false;

                    grv_report.GroupPanelText = "REPORT FROM PACKERLINEB";
                    DateTime Data_ngay = Convert.ToDateTime(bar_ngay.EditValue);
                    string newFileName = Application.StartupPath + @"\Log\PACKB_log_" + Data_ngay.ToString("yyyyMMdd") + ".csv";
                    tb_mau = CSVtoDataTable(newFileName);

                    if (tb_mau.Rows.Count == 0)
                    {
                        gdv_report.DataSource = tb_mau;
                    }
                    else
                    {
                        DataTable dtCloned = tb_mau;
                        dtCloned.DefaultView.Sort = "C3 DESC";
                        gdv_report.DataSource = dtCloned;
                    }
                }
                else if (cb_select.EditValue == "PACKERLINEC")
                {

                    grv_report.Columns[0].Visible = false;

                    grv_report.Columns[1].Caption = "Ngày";
                    grv_report.Columns[1].Width = 150;
                    grv_report.Columns[1].Visible = true;

                    grv_report.Columns[2].Caption = "Giờ";
                    grv_report.Columns[2].Width = 150;
                    grv_report.Columns[2].Visible = true;

                    grv_report.Columns[3].Caption = "Weight";
                    grv_report.Columns[3].Width = 150;
                    grv_report.Columns[3].Visible = true;
                    grv_report.Columns[3].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    grv_report.Columns[4].Caption = "Temperature";
                    grv_report.Columns[4].Width = 150;
                    grv_report.Columns[4].Visible = true;
                    grv_report.Columns[4].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                    grv_report.Columns[5].Visible = false;
                    grv_report.Columns[6].Visible = false;
                    grv_report.Columns[7].Visible = false;
                    grv_report.Columns[8].Visible = false;
                    grv_report.Columns[9].Visible = false;
                    grv_report.Columns[10].Visible = false;
                    grv_report.Columns[11].Visible = false;

                    grv_report.Columns[12].Visible = false;

                    grv_report.Columns[13].Visible = false;

                    grv_report.Columns[14].Visible = false;

                    grv_report.Columns[15].Visible = false;

                    grv_report.Columns[16].Visible = false;

                    grv_report.Columns[17].Visible = false;

                    grv_report.Columns[18].Visible = false;

                    grv_report.Columns[19].Visible = false;

                    grv_report.Columns[20].Visible = false;

                    grv_report.Columns[21].Visible = false;

                    grv_report.Columns[22].Visible = false;

                    grv_report.Columns[23].Visible = false;

                    grv_report.Columns[24].Visible = false;

                    grv_report.Columns[25].Visible = false;

                    grv_report.Columns[26].Visible = false;

                    grv_report.Columns[27].Visible = false;

                    grv_report.Columns[28].Visible = false;

                    grv_report.Columns[29].Visible = false;

                    grv_report.Columns[30].Visible = false;

                    grv_report.Columns[31].Visible = false;

                    grv_report.Columns[32].Visible = false;

                    grv_report.Columns[33].Visible = false;

                    grv_report.Columns[34].Visible = false;

                    grv_report.GroupPanelText = "REPORT FROM PACKERLINEC";
                    DateTime Data_ngay = Convert.ToDateTime(bar_ngay.EditValue);
                    string newFileName = Application.StartupPath + @"\Log\PACKC_log_" + Data_ngay.ToString("yyyyMMdd") + ".csv";
                    tb_mau = CSVtoDataTable(newFileName);

                    if (tb_mau.Rows.Count == 0)
                    {
                        gdv_report.DataSource = tb_mau;
                    }
                    else
                    {
                        DataTable dtCloned = tb_mau;
                        dtCloned.DefaultView.Sort = "C3 DESC";
                        gdv_report.DataSource = dtCloned;
                    }
                }
            }
            catch (Exception ex)
            {
                KN.Showalert(ex.Message);
            }
}

        private void Report_Load(object sender, EventArgs e)
        {
            cb_select.EditValue = "WATER PUMP";
            bar_ngay.EditValue = DateTime.Now;
        }


        private void bt_excel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string path = "";
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = @"C:\";      
                saveFileDialog1.Title = "Save Files";
                //saveFileDialog1.CheckFileExists = true;
                //saveFileDialog1.CheckPathExists = true;
                saveFileDialog1.DefaultExt = "xlsx";
                saveFileDialog1.Filter = "Files type (*.xlsx)|*.xlsx";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;
                if (cb_select.EditValue == "WATER PUMP")
                {
                    saveFileDialog1.FileName = "WATER PUMP_" + Convert.ToDateTime(bar_ngay.EditValue).ToString("dd-MM-yyyy") + ".xlsx";
                }
                else  if (cb_select.EditValue == "VACCUM PUMP")
                    {
                    saveFileDialog1.FileName = "VACCUM PUMP_" + Convert.ToDateTime(bar_ngay.EditValue).ToString("dd-MM-yyyy") + ".xlsx";
                    }
                else if (cb_select.EditValue == "AIR PRESSURE")
                {
                    saveFileDialog1.FileName = "AIR PRESSURE_" + Convert.ToDateTime(bar_ngay.EditValue).ToString("dd-MM-yyyy") + ".xlsx";
                }
                else if (cb_select.EditValue == "FUME DUST")
                {
                    saveFileDialog1.FileName = "FUME DUST_" + Convert.ToDateTime(bar_ngay.EditValue).ToString("dd-MM-yyyy") + ".xlsx";
                }
                else if (cb_select.EditValue == "RTO")
                {
                    saveFileDialog1.FileName = "RTO_" + Convert.ToDateTime(bar_ngay.EditValue).ToString("dd-MM-yyyy") + ".xlsx";
                }
                else if (cb_select.EditValue == "MCC ROOM")
                {
                    saveFileDialog1.FileName = "MCC ROOM_" + Convert.ToDateTime(bar_ngay.EditValue).ToString("dd-MM-yyyy") + ".xlsx";
                }
                else if (cb_select.EditValue == "ALARM")
                {
                    saveFileDialog1.FileName = "ALARM_" + Convert.ToDateTime(bar_ngay.EditValue).ToString("dd-MM-yyyy") + ".xlsx";
                }
                else if (cb_select.EditValue == "PACKERLINEA")
                {
                    saveFileDialog1.FileName = "PACKERLINEA_" + Convert.ToDateTime(bar_ngay.EditValue).ToString("dd-MM-yyyy") + ".xlsx";
                }
                else if (cb_select.EditValue == "PACKERLINEB")
                {
                    saveFileDialog1.FileName = "PACKERLINEB_" + Convert.ToDateTime(bar_ngay.EditValue).ToString("dd-MM-yyyy") + ".xlsx";
                }
                else if (cb_select.EditValue == "PACKERLINEC")
                {
                    saveFileDialog1.FileName = "PACKERLINEC_" + Convert.ToDateTime(bar_ngay.EditValue).ToString("dd-MM-yyyy") + ".xlsx";
                }

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    gdv_report.ExportToXlsx(saveFileDialog1.FileName);
                    Process.Start(saveFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                KN.Showalert(ex.Message);
            }
        }
    }
}