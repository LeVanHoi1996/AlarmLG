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

namespace Baodongchem
{
    public partial class Calibration : DevExpress.XtraEditors.XtraForm
    {
        public Calibration()
        {
            InitializeComponent();
        }

        private void timer_DataL_Tick(object sender, EventArgs e)
        {
            //1
            if (lb_v1_int_min.Text == "" || lb_v1_int_min.Text == ".")
            {
                lb_v1_int_min.Text = "0";
            }
            if (lb_v1_int_max.Text == "" || lb_v1_int_max.Text == ".")
            {
                lb_v1_int_max.Text = "0";
            }
            if (lb_v1_real_min.Text == "" || lb_v1_real_min.Text == ".")
            {
                lb_v1_real_min.Text = "0";
            }
            if (lb_v1_real_max.Text == "" || lb_v1_real_max.Text == ".")
            {
                lb_v1_real_max.Text = "0";
            }
            //2
            if (lb_v2_int_min.Text == "" || lb_v2_int_min.Text == ".")
            {
                lb_v2_int_min.Text = "0";
            }
            if (lb_v2_int_max.Text == "" || lb_v2_int_max.Text == ".")
            {
                lb_v2_int_max.Text = "0";
            }
            if (lb_v2_real_min.Text == "" || lb_v2_real_min.Text == ".")
            {
                lb_v2_real_min.Text = "0";
            }
            if (lb_v2_real_max.Text == "" || lb_v2_real_max.Text == ".")
            {
                lb_v2_real_max.Text = "0";
            }
            //3
            if (lb_v3_int_min.Text == "" || lb_v3_int_min.Text == ".")
            {
                lb_v3_int_min.Text = "0";
            }
            if (lb_v3_int_max.Text == "" || lb_v3_int_max.Text == ".")
            {
                lb_v3_int_max.Text = "0";
            }
            if (lb_v3_real_min.Text == "" || lb_v3_real_min.Text == ".")
            {
                lb_v3_real_min.Text = "0";
            }
            if (lb_v3_real_max.Text == "" || lb_v3_real_max.Text == ".")
            {
                lb_v3_real_max.Text = "0";
            }
            //4
            if (lb_v4_int_min.Text == "" || lb_v4_int_min.Text == ".")
            {
                lb_v4_int_min.Text = "0";
            }
            if (lb_v4_int_max.Text == "" || lb_v4_int_max.Text == ".")
            {
                lb_v4_int_max.Text = "0";
            }
            if (lb_v4_real_min.Text == "" || lb_v4_real_min.Text == ".")
            {
                lb_v4_real_min.Text = "0";
            }
            if (lb_v4_real_max.Text == "" || lb_v4_real_max.Text == ".")
            {
                lb_v4_real_max.Text = "0";
            }
            //5
            if (lb_v5_int_min.Text == "" || lb_v5_int_min.Text == ".")
            {
                lb_v5_int_min.Text = "0";
            }
            if (lb_v5_int_max.Text == "" || lb_v5_int_max.Text == ".")
            {
                lb_v5_int_max.Text = "0";
            }
            if (lb_v5_real_min.Text == "" || lb_v5_real_min.Text == ".")
            {
                lb_v5_real_min.Text = "0";
            }
            if (lb_v5_real_max.Text == "" || lb_v5_real_max.Text == ".")
            {
                lb_v5_real_max.Text = "0";
            }

            lb_v1_in.Text = DATA_Calibration.v1_in.ToString();
            lb_v2_in.Text = DATA_Calibration.v2_in.ToString();
            lb_v3_in.Text = DATA_Calibration.v3_in.ToString();
            lb_v4_in.Text = DATA_Calibration.v4_in.ToString();
            lb_v5_in.Text = DATA_Calibration.v5_in.ToString();

            lb_v1_out.Text = DATA_Calibration.v1_out.ToString();
            lb_v2_out.Text = DATA_Calibration.v2_out.ToString();
            lb_v3_out.Text = DATA_Calibration.v3_out.ToString();
            lb_v4_out.Text = DATA_Calibration.v4_out.ToString();
            lb_v5_out.Text = DATA_Calibration.v5_out.ToString();
        }
        private void nhap(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '-') && ((sender as TextEdit).Text.Length > 0))
            {
                (sender as TextEdit).Text = "";
            }
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextEdit).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void lb_V1_int_min_KeyPress(object sender, KeyPressEventArgs e)
        {
            nhap(sender, e);
        }

        private void lb_V1_int_max_KeyPress(object sender, KeyPressEventArgs e)
        {
            nhap(sender, e);
        }

        private void lb_V1_real_min_KeyPress(object sender, KeyPressEventArgs e)
        {
            nhap(sender, e);
        }

        private void lb_V1_real_max_KeyPress(object sender, KeyPressEventArgs e)
        {
            nhap(sender, e);
        }

        private void lb_v2_int_min_KeyPress(object sender, KeyPressEventArgs e)
        {
            nhap(sender, e);
        }

        private void lb_v2_int_max_KeyPress(object sender, KeyPressEventArgs e)
        {
            nhap(sender, e);
        }

        private void lb_v2_real_min_KeyPress(object sender, KeyPressEventArgs e)
        {
            nhap(sender, e);
        }

        private void lb_v2_real_max_KeyPress(object sender, KeyPressEventArgs e)
        {
            nhap(sender, e);
        }

        private void lb_V3_int_min_KeyPress(object sender, KeyPressEventArgs e)
        {
            nhap(sender, e);
        }

        private void lb_V3_int_max_KeyPress(object sender, KeyPressEventArgs e)
        {
            nhap(sender, e);
        }

        private void lb_V3_real_min_KeyPress(object sender, KeyPressEventArgs e)
        {
            nhap(sender, e);
        }

        private void lb_V3_real_max_KeyPress(object sender, KeyPressEventArgs e)
        {
            nhap(sender, e);
        }

        private void lb_v4_int_min_KeyPress(object sender, KeyPressEventArgs e)
        {
            nhap(sender, e);
        }

        private void lb_v4_int_max_KeyPress(object sender, KeyPressEventArgs e)
        {
            nhap(sender, e);
        }

        private void lb_v4_real_min_KeyPress(object sender, KeyPressEventArgs e)
        {
            nhap(sender, e);
        }

        private void lb_v4_real_max_KeyPress(object sender, KeyPressEventArgs e)
        {
            nhap(sender, e);
        }

        private void lb_v5_int_min_KeyPress(object sender, KeyPressEventArgs e)
        {
            nhap(sender, e);
        }

        private void lb_v5_int_max_KeyPress(object sender, KeyPressEventArgs e)
        {
            nhap(sender, e);
        }

        private void lb_v5_real_min_KeyPress(object sender, KeyPressEventArgs e)
        {
            nhap(sender, e);
        }

        private void lb_v5_real_max_KeyPress(object sender, KeyPressEventArgs e)
        {
            nhap(sender, e);
        }

        private void Calibration_Load(object sender, EventArgs e)
        {
            Load_data();
        }

        private void Load_data()
        {
            lb_v1_int_min.Text = DATA_Calibration.v1_int_min.ToString();
            lb_v1_int_max.Text = DATA_Calibration.v1_int_max.ToString();
            lb_v1_real_min.Text = DATA_Calibration.v1_real_min.ToString();
            lb_v1_real_max.Text = DATA_Calibration.v1_real_max.ToString();

            lb_v2_int_min.Text = DATA_Calibration.v2_int_min.ToString();
            lb_v2_int_max.Text = DATA_Calibration.v2_int_max.ToString();
            lb_v2_real_min.Text = DATA_Calibration.v2_real_min.ToString();
            lb_v2_real_max.Text = DATA_Calibration.v2_real_max.ToString();

            lb_v3_int_min.Text = DATA_Calibration.v3_int_min.ToString();
            lb_v3_int_max.Text = DATA_Calibration.v3_int_max.ToString();
            lb_v3_real_min.Text = DATA_Calibration.v3_real_min.ToString();
            lb_v3_real_max.Text = DATA_Calibration.v3_real_max.ToString();

            lb_v4_int_min.Text = DATA_Calibration.v4_int_min.ToString();
            lb_v4_int_max.Text = DATA_Calibration.v4_int_max.ToString();
            lb_v4_real_min.Text = DATA_Calibration.v4_real_min.ToString();
            lb_v4_real_max.Text = DATA_Calibration.v4_real_max.ToString();

            lb_v5_int_min.Text = DATA_Calibration.v5_int_min.ToString();
            lb_v5_int_max.Text = DATA_Calibration.v5_int_max.ToString();
            lb_v5_real_min.Text = DATA_Calibration.v5_real_min.ToString();
            lb_v5_real_max.Text = DATA_Calibration.v5_real_max.ToString();
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            try
            {
                DATA_Calibration.v1_int_min = Math.Round(Convert.ToDouble(lb_v1_int_min.Text), 0);
                DATA_Calibration.v1_int_max = Math.Round(Convert.ToDouble(lb_v1_int_max.Text), 0);
                DATA_Calibration.v1_real_min = Math.Round(Convert.ToDouble(lb_v1_real_min.Text), 1);
                DATA_Calibration.v1_real_max = Math.Round(Convert.ToDouble(lb_v1_real_max.Text), 1);

                DATA_Calibration.v2_int_min = Math.Round(Convert.ToDouble(lb_v2_int_min.Text), 0);
                DATA_Calibration.v2_int_max = Math.Round(Convert.ToDouble(lb_v2_int_max.Text), 0);
                DATA_Calibration.v2_real_min = Math.Round(Convert.ToDouble(lb_v2_real_min.Text), 1);
                DATA_Calibration.v2_real_max = Math.Round(Convert.ToDouble(lb_v2_real_max.Text), 1);

                DATA_Calibration.v3_int_min = Math.Round(Convert.ToDouble(lb_v3_int_min.Text), 0);
                DATA_Calibration.v3_int_max = Math.Round(Convert.ToDouble(lb_v3_int_max.Text), 0);
                DATA_Calibration.v3_real_min = Math.Round(Convert.ToDouble(lb_v3_real_min.Text), 1);
                DATA_Calibration.v3_real_max = Math.Round(Convert.ToDouble(lb_v3_real_max.Text), 1);

                DATA_Calibration.v4_int_min = Math.Round(Convert.ToDouble(lb_v4_int_min.Text), 0);
                DATA_Calibration.v4_int_max = Math.Round(Convert.ToDouble(lb_v4_int_max.Text), 0);
                DATA_Calibration.v4_real_min = Math.Round(Convert.ToDouble(lb_v4_real_min.Text), 1);
                DATA_Calibration.v4_real_max = Math.Round(Convert.ToDouble(lb_v4_real_max.Text), 1);

                DATA_Calibration.v5_int_min = Math.Round(Convert.ToDouble(lb_v5_int_min.Text), 0);
                DATA_Calibration.v5_int_max = Math.Round(Convert.ToDouble(lb_v5_int_max.Text), 0);
                DATA_Calibration.v5_real_min = Math.Round(Convert.ToDouble(lb_v5_real_min.Text), 1);
                DATA_Calibration.v5_real_max = Math.Round(Convert.ToDouble(lb_v5_real_max.Text), 1);
                Communication.WriteCommon();
                Load_data();
                KN.Showalert("Data saved");

            }
            catch (Exception ex)
            {
                KN.Showalert(ex.Message);
                Load_data();
            }
        }
    }
}