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
    public partial class RTO : DevExpress.XtraEditors.XtraForm
    {
        public RTO()
        {
            InitializeComponent();
        }

        private void timer_data_RTO_Tick(object sender, EventArgs e)
        {
            lb_1953A.Text = DATA_PLC_RW.TE_1953A.ToString();
            lb_Ave.Text = DATA_PLC_RW.AVE_TEMP.ToString();
            lb_1953B.Text = DATA_PLC_RW.TE_1953B.ToString();
            lb_1952A.Text = DATA_PLC_RW.TE_1952A.ToString();
            lb_1952B.Text = DATA_PLC_RW.TE_1952B.ToString();
            lb_1952C.Text = DATA_PLC_RW.TE_1952C.ToString();
            lb_1951.Text = DATA_PLC_RW.TE_1951.ToString();
            lb_1954.Text = DATA_PLC_RW.TE_1954.ToString();

            Main.Chang_status_data(lb_1953A, DATA_PLC_SI.TE_1953A_fault);
            Main.Chang_status_data(lb_Ave, DATA_PLC_SI.AVE_TEMP_fault);
            Main.Chang_status_data(lb_1953B, DATA_PLC_SI.TE_1953B_fault);
            Main.Chang_status_data(lb_1952A, DATA_PLC_SI.TE_1952A_fault);
            Main.Chang_status_data(lb_1952B, DATA_PLC_SI.TE_1952B_fault);
            Main.Chang_status_data(lb_1952C, DATA_PLC_SI.TE_1952C_fault);
            Main.Chang_status_data(lb_1951, DATA_PLC_SI.TE_1951_fault);
            Main.Chang_status_data(lb_1954, DATA_PLC_SI.TE_1954_fault);

            Main.Chang_status_only(lb_xv1952, DATA_PLC_RW.XV1952);
            
            if (DATA_PLC_SI.TE_1951_1956_fault)
            {
                lb_xv1951.Text = "ALARM";
                lb_xv1951.BackColor = Color.Orange;
                lb_xv1956.Text = "ALARM";
                lb_xv1956.BackColor = Color.Orange;
            }
            else
            {
                Main.Chang_status_only(lb_xv1951, DATA_PLC_RW.XV1951);
                Main.Chang_status_only(lb_xv1956, DATA_PLC_RW.XV1956);
            }
            //
            if (DATA_PLC_SI.TE_FC_fault)
            {
                lb_FC.Text = "ALARM";
                lb_FC.BackColor = Color.Orange;
            }
            else
            {
                Main.Chang_status_only(lb_FC, DATA_PLC_RW.XXXXXX);
            }
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

        private void lb_1953A_AL_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    DATA_PLC_SI.TE_1953A_alarm = Convert.ToDouble(lb_1953A_AL.Text);
                    label2.Focus();
                    KN.ShowalertThanhCong("Giá trị được cập nhật");
                }
                nhap(sender, e);
            }
            catch (Exception ex)
            {
                KN.Showalert(ex.Message);
            }
        }

        private void RTO_Load(object sender, EventArgs e)
        {
            lb_1953A_AL.Text = DATA_PLC_SI.TE_1953A_alarm.ToString();
            lb_Ave_AL.Text = DATA_PLC_SI.AVE_TEMP_alarm.ToString();
            lb_1953B_AL.Text = DATA_PLC_SI.TE_1953B_alarm.ToString();
            lb_1954_AL.Text = DATA_PLC_SI.TE_1954_alarm.ToString();
            lb_1952A_AL.Text = DATA_PLC_SI.TE_1952A_alarm.ToString();
            lb_1952B_AL.Text = DATA_PLC_SI.TE_1952B_alarm.ToString();
            lb_1952C_AL.Text = DATA_PLC_SI.TE_1952C_alarm.ToString();
            lb_1951_AL.Text = DATA_PLC_SI.TE_1951_alarm.ToString();
            label2.Focus();
        }

        private void lb_Ave_AL_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    DATA_PLC_SI.AVE_TEMP_alarm = Convert.ToDouble(lb_Ave_AL.Text);
                    label2.Focus();
                    KN.ShowalertThanhCong("Giá trị được cập nhật");
                }
                nhap(sender, e);
            }
            catch (Exception ex)
            {
                KN.Showalert(ex.Message);
            }
        }

        private void lb_1953B_AL_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    DATA_PLC_SI.TE_1953B_alarm = Convert.ToDouble(lb_1953B_AL.Text);
                    label2.Focus();
                    KN.ShowalertThanhCong("Giá trị được cập nhật");
                }
                nhap(sender, e);
            }
            catch (Exception ex)
            {
                KN.Showalert(ex.Message);
            }
        }

        private void lb_1954_AL_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    DATA_PLC_SI.TE_1954_alarm = Convert.ToDouble(lb_1954_AL.Text);
                    label2.Focus();
                    KN.ShowalertThanhCong("Giá trị được cập nhật");
                }
                nhap(sender, e);
            }
            catch (Exception ex)
            {
                KN.Showalert(ex.Message);
            }
        }

        private void lb_1952A_AL_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    DATA_PLC_SI.TE_1952A_alarm = Convert.ToDouble(lb_1952A_AL.Text);
                    label2.Focus();
                    KN.ShowalertThanhCong("Giá trị được cập nhật");
                }
                nhap(sender, e);
            }
            catch (Exception ex)
            {
                KN.Showalert(ex.Message);
            }
        }

        private void lb_1952B_AL_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    DATA_PLC_SI.TE_1952B_alarm = Convert.ToDouble(lb_1952B_AL.Text);
                    label2.Focus();
                    KN.ShowalertThanhCong("Giá trị được cập nhật");
                }
                nhap(sender, e);
            }
            catch (Exception ex)
            {
                KN.Showalert(ex.Message);
            }
        }

        private void lb_1952C_AL_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    DATA_PLC_SI.TE_1952C_alarm = Convert.ToDouble(lb_1952C_AL.Text);
                    label2.Focus();
                    KN.ShowalertThanhCong("Giá trị được cập nhật");
                }
                nhap(sender, e);
            }
            catch (Exception ex)
            {
                KN.Showalert(ex.Message);
            }
        }

        private void lb_1951_AL_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    DATA_PLC_SI.TE_1951_alarm = Convert.ToDouble(lb_1951_AL.Text);
                    label2.Focus();
                    KN.ShowalertThanhCong("Giá trị được cập nhật");
                }
                nhap(sender, e);
            }
            catch (Exception ex)
            {
                KN.Showalert(ex.Message);
            }
        }
    }
}