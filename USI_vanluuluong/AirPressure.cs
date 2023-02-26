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
    public partial class AirPressure : DevExpress.XtraEditors.XtraForm
    {
        public AirPressure()
        {
            InitializeComponent();
        }

        private void timer_AirL_Tick(object sender, EventArgs e)
        {
            Main.Chang_status_stop_false(lb_Air_No1, DATA_PLC_LS.No1_AIR_COMP, DATA_PLC_LS.No1_AIR_COMP_fault);
            Main.Chang_status_stop_false(lb_Air_No2, DATA_PLC_LS.No2_AIR_COMP, DATA_PLC_LS.No2_AIR_COMP_fault);
            Main.Chang_status_stop_false(lb_AirC_No1, DATA_PLC_SI.On_air_chiller_pos_1, DATA_PLC_SI.On_air_chiller_pos_1_fault);
            Main.Chang_status_stop_false(lb_AirC_No2, DATA_PLC_SI.On_air_chiller_pos_2, DATA_PLC_SI.On_air_chiller_pos_2_fault);
            Main.Chang_status_data(Air_Pressure, DATA_PLC_SI.AIR_PRESSURE_Mpa_fault);
            Air_Pressure.Text = DATA_Calibration.v1_out.ToString();
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

        private void Air_PressureAL_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                if (e.KeyChar == (char)Keys.Enter)
                {
                    DATA_PLC_SI.AIR_PRESSURE_Mpa_alarm = Convert.ToDouble(Air_PressureAL.Text);
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

        private void AirPressure_Load(object sender, EventArgs e)
        {
            Air_PressureAL.Text = DATA_PLC_SI.AIR_PRESSURE_Mpa_alarm.ToString();
            lb_Mode.Focus();
        }
    }
}