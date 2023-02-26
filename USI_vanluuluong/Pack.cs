using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baodongchem
{
    public partial class Pack :  DevExpress.XtraEditors.XtraForm
    {
        public Pack()
        {
            InitializeComponent();
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
                                if (i == 0)
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
        public static DataTable tb_mauA = new DataTable();
        public static DataTable tb_mauB = new DataTable();
        public static DataTable tb_mauC = new DataTable();

        private void timerLoadGr_Tick(object sender, EventArgs e)
        {
            try
            {
                DateTime Data_ngay = DateTime.Now;
                string newFileNameA = Application.StartupPath + @"\Log\PACKA_log_" + Data_ngay.ToString("yyyyMMdd") + ".csv";
                tb_mauA = CSVtoDataTable(newFileNameA);

                if (tb_mauA.Rows.Count == 0)
                {
                    //   dgA.DataSource = tb_mauA;
                }
                else
                {
                    tb_mauA.DefaultView.Sort = "C3 DESC";
                    DataTable dtCloned = tb_mauA.Select().Take(7).CopyToDataTable();
                    dtCloned.DefaultView.Sort = "C3 DESC";
                    dgA.DataSource = dtCloned;
                }

                string newFileNameB = Application.StartupPath + @"\Log\PACKB_log_" + Data_ngay.ToString("yyyyMMdd") + ".csv";
                tb_mauB = CSVtoDataTable(newFileNameB);

                if (tb_mauB.Rows.Count == 0)
                {
                    // dgB.DataSource = tb_mauB;
                }
                else
                {
                    tb_mauB.DefaultView.Sort = "C3 DESC";
                    DataTable dtCloned = tb_mauB.Select().Take(7).CopyToDataTable();
                    dtCloned.DefaultView.Sort = "C3 DESC";
                    dgB.DataSource = dtCloned;
                }

                string newFileNameC = Application.StartupPath + @"\Log\PACKC_log_" + Data_ngay.ToString("yyyyMMdd") + ".csv";
                tb_mauC = CSVtoDataTable(newFileNameC);

                if (tb_mauC.Rows.Count == 0)
                {
                    //  dgC.DataSource = tb_mauC;
                }
                else
                {
                    tb_mauC.DefaultView.Sort = "C3 DESC";
                    DataTable dtCloned = tb_mauC.Select().Take(7).CopyToDataTable();
                    dtCloned.DefaultView.Sort = "C3 DESC";
                    dgC.DataSource = dtCloned;
                }

                LoadData();
            }

            catch (Exception)
            {
            }
        }
        private void LoadData()
        {
            try
            {
                lbICA_KG.Text = DATA_PLC_SIPACK.wLineA_IC.ToString("0.00") + " Kg";
                lbICA_C.Text = DATA_PLC_SIPACK.tLineA_IC.ToString("0.0") + " ℃";

                lbICB_KG.Text = DATA_PLC_SIPACK.wLineB_IC.ToString("0.00") + " Kg";
                lbICB_C.Text = DATA_PLC_SIPACK.tLineB_IC.ToString("0.0") + " ℃";

                lbICC_KG.Text = DATA_PLC_SIPACK.wLineC_IC.ToString("0.00") + " Kg";
                lbICC_C.Text = DATA_PLC_SIPACK.tLineC_IC.ToString("0.0") + " ℃";

                lbLVA_KG.Text = DATA_PLC_SIPACK.wLineA_LV.ToString("0.00") + " Kg";
                lbLVA_C.Text = DATA_PLC_SIPACK.tLineA_LV.ToString("0.0") + " ℃";

                lbLVB_KG.Text = DATA_PLC_SIPACK.wLineB_LV.ToString("0.00") + " Kg";
                lbLVB_C.Text = DATA_PLC_SIPACK.tLineB_LV.ToString("0.0") + " ℃";

                lbLVC_KG.Text = DATA_PLC_SIPACK.wLineC_LV.ToString("0.00") + " Kg";
                lbLVC_C.Text = DATA_PLC_SIPACK.tLineC_LV.ToString("0.0") + " ℃";

                if (DATA_PLC_SIPACK.isWLineA == 1)
                {
                    PLA.BackColor = Color.Green;
                }
                else
                {
                    PLA.BackColor = Color.DarkOrange;
                }

                if (DATA_PLC_SIPACK.isWLineB == 1)
                {
                    PLB.BackColor = Color.Green;
                }
                else
                {
                    PLB.BackColor = Color.DarkOrange;
                }
                if (DATA_PLC_SIPACK.isWLineC == 1)
                {
                    PLC.BackColor = Color.Green;
                }
                else
                {
                    PLC.BackColor = Color.DarkOrange;
                }
            }
            catch (Exception)
            {
            }
        }

        private void Pack_Load(object sender, EventArgs e)
        {

        }
    }
}
