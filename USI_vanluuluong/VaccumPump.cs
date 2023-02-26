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
    public partial class VaccumPump : DevExpress.XtraEditors.XtraForm
    {
        public VaccumPump()
        {
            InitializeComponent();
        }

        private void timer1_VC_load_Tick(object sender, EventArgs e)
        {
            Main.Chang_status_stop_true(lb_NoA, DATA_PLC_LS.VACCUM_PUMP_A, DATA_PLC_LS.VACCUM_PUMP_A_fault);
            Main.Chang_status_stop_true(lb_NoB, DATA_PLC_LS.VACCUM_PUMP_B, DATA_PLC_LS.VACCUM_PUMP_B_fault);
            Main.Chang_status_stop_true(lb_NoC, DATA_PLC_LS.VACCUM_PUMP_C, DATA_PLC_LS.VACCUM_PUMP_C_fault);
            Main.Chang_status_stop_true(lb_NoD, DATA_PLC_LS.VACCUM_PUMP_D, DATA_PLC_LS.VACCUM_PUMP_D_fault);
            Main.Chang_status_data(vc_pressure, DATA_PLC_SI.VACCUM_PRESSURE_fault);
            Main.Chang_status_data(ND_PUMP_A, DATA_PLC_SI.Pump_A_fault);
            Main.Chang_status_data(ND_PUMP_B, DATA_PLC_SI.Pump_B_fault);
            Main.Chang_status_data(ND_PUMP_C, DATA_PLC_SI.Pump_C_fault);
            vc_pressure.Text = DATA_Calibration.v4_out.ToString();
            ND_PUMP_A.Text = DATA_PLC_LS.Pump_A.ToString();
            ND_PUMP_B.Text = DATA_PLC_LS.Pump_B.ToString();
            ND_PUMP_C.Text = DATA_PLC_LS.Pump_C.ToString();
            if (DATA_PLC_SI.Man_pump_cmd)
            {
                lb_Mode.Text = "AUTO MODE";
                lb_Mode.BackColor = Color.LimeGreen;
            }
            else
            {
                lb_Mode.Text = "MANUAL MODE";
                lb_Mode.BackColor = Color.FromArgb(255, 128, 0);
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

        private void vc_pressureAL_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    DATA_PLC_SI.VACCUM_PRESSURE_alarm = Convert.ToDouble(vc_pressureAL.Text);
                    lb_Mode.Focus();
                    KN.ShowalertThanhCong("Giá trị được cập nhật");
                }
                nhap(sender, e);
            }
            catch (Exception ex)
            {
                KN.Showalert(ex.Message);
            }
        }

        private void VaccumPump_Load(object sender, EventArgs e)
        {
            vc_pressureAL.Text = DATA_PLC_SI.VACCUM_PRESSURE_alarm.ToString();
            ND_PUMP_A_AL.Text = DATA_PLC_SI.Pump_A_alarm.ToString();
            ND_PUMP_B_AL.Text = DATA_PLC_SI.Pump_B_alarm.ToString();
            ND_PUMP_C_AL.Text = DATA_PLC_SI.Pump_C_alarm.ToString();
            lb_Mode.Focus();
        }

        private void ND_PUMP_A_AL_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    DATA_PLC_SI.Pump_A_alarm = Convert.ToDouble(ND_PUMP_A_AL.Text);
                    lb_Mode.Focus();
                    KN.ShowalertThanhCong("Giá trị được cập nhật");
                }
                nhap(sender, e);
            }
            catch (Exception ex)
            {
                KN.Showalert(ex.Message);
            }
        }

        private void ND_PUMP_B_AL_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    DATA_PLC_SI.Pump_B_alarm = Convert.ToDouble(ND_PUMP_B_AL.Text);
                    lb_Mode.Focus();
                    KN.ShowalertThanhCong("Giá trị được cập nhật");
                }
                nhap(sender, e);
            }
            catch (Exception ex)
            {
                KN.Showalert(ex.Message);
            }
        }

        private void ND_PUMP_C_AL_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    DATA_PLC_SI.Pump_C_alarm = Convert.ToDouble(ND_PUMP_C_AL.Text);
                    lb_Mode.Focus();
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