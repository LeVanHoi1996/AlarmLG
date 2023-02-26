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
    public partial class FumeDust : DevExpress.XtraEditors.XtraForm
    {
        public FumeDust()
        {
            InitializeComponent();
        }

        private void timer_Data_Fume_Tick(object sender, EventArgs e)
        {
            Main.Chang_status_start(lb_fume_A, DATA_PLC_SI.On_fume_collector_A_Pos);
            Main.Chang_status_start(lb_fume_B, DATA_PLC_SI.On_fume_collector_B_Pos);
            Main.Chang_status_start(lb_dust_A, DATA_PLC_SI.On_dust_collector_A_Pos);
            Main.Chang_status_start(lb_dust_B, DATA_PLC_SI.On_dust_collector_B_Pos);
            Main.Chang_status_data(fume_pressure, DATA_PLC_SI.FUME_PRESSURE_fault);
            Main.Chang_status_data(dust_pressure, DATA_PLC_SI.DUST_PRESSURE_fault);
            fume_pressure.Text = DATA_Calibration.v2_out.ToString();
            dust_pressure.Text = DATA_Calibration.v3_out.ToString();
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

        private void fume_pressureAL_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    DATA_PLC_SI.FUME_PRESSURE_alarm = Convert.ToDouble(fume_pressureAL.Text);
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

        private void FumeDust_Load(object sender, EventArgs e)
        {
            fume_pressureAL.Text = DATA_PLC_SI.FUME_PRESSURE_alarm.ToString();
            dust_pressureAL.Text = DATA_PLC_SI.DUST_PRESSURE_alarm.ToString();
            label2.Focus();
        }

        private void dust_pressureAL_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    DATA_PLC_SI.DUST_PRESSURE_alarm = Convert.ToDouble(dust_pressureAL.Text);
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