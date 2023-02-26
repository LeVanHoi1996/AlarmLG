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
    public partial class Main : DevExpress.XtraEditors.XtraForm
    {
        public Main()
        {
            InitializeComponent();
        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {

        }

        private void Load_data_Tick(object sender, EventArgs e)
        {
            Chang_status_stop_true(lb_No1, DATA_PLC_LS.No1_WATER_PUMP, DATA_PLC_LS.No1_WATER_PUMP_fault);
            Chang_status_stop_true(lb_No2, DATA_PLC_LS.No2_WATER_PUMP, DATA_PLC_LS.No2_WATER_PUMP_fault);
            Chang_status_stop_true(lb_No3, DATA_PLC_LS.No3_WATER_PUMP, DATA_PLC_LS.No3_WATER_PUMP_fault);
            Chang_status_stop_true(lb_No4, DATA_PLC_LS.No4_WATER_PUMP, DATA_PLC_LS.No4_WATER_PUMP_fault);
            Chang_status_stop_true(lb_No5, DATA_PLC_LS.No5_WATER_PUMP, DATA_PLC_LS.No5_WATER_PUMP_fault);
            Chang_status_stop_true(lb_No6, DATA_PLC_LS.No6_WATER_PUMP, DATA_PLC_LS.No6_WATER_PUMP_fault);
            Chang_status_stop_false(lb_TowerNo1, DATA_PLC_LS.No1_COLLING_TOWER, DATA_PLC_LS.No1_COLLING_TOWER_fault);
            Chang_status_stop_false(lb_TowerNo2, DATA_PLC_LS.No2_COLLING_TOWER, DATA_PLC_LS.No2_COLLING_TOWER_fault);
            Chang_status_data(lb_Nhietdo, DATA_PLC_SI.WATER_BATH_TEMP_fault);
            lb_Nhietdo.Text = DATA_Calibration.v5_out.ToString();
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

        public static void Chang_status_stop_true(LabelControl lb, bool pump, bool pump_fault)
        {
            if (pump_fault)
            {
                lb.Text = "ALARM";
                lb.BackColor = Color.Orange;
            }
            else
            {
                if (pump == false)
                {
                    lb.Text = "START";
                    lb.BackColor = Color.LimeGreen;
                }
                else
                {
                    lb.Text = "STOP";
                    lb.BackColor = Color.Red;
                }
            }
        }
        public static void Chang_status_stop_false(LabelControl lb, bool pump, bool pump_fault)
        {
            if (pump_fault)
            {
                lb.Text = "ALARM";
                lb.BackColor = Color.Orange;
            }
            else
            {
                if (pump == true)
                {
                    lb.Text = "START";
                    lb.BackColor = Color.LimeGreen;
                }
                else
                {
                    lb.Text = "STOP";
                    lb.BackColor = Color.Red;
                }
            }
        }
        public static void Chang_status_only(LabelControl lb, bool pump)
        {
            if (pump)
            {
                lb.Text = "OPEN";
                lb.BackColor = Color.LimeGreen;
            }
            else
            {
                lb.Text = "CLOSE";
                lb.BackColor = Color.Red;
            }
        }
        public static void Chang_status_start(LabelControl lb, bool pump)
        {
            if (pump == true)
            {
                lb.Text = "START";
                lb.BackColor = Color.LimeGreen;
            }
            else
            {
                lb.Text = "STOP";
                lb.BackColor = Color.Red;
            }
        }
        public static void Chang_status_data(LabelControl lb, bool pump)
        {
            if (pump == true)
            {
                lb.BackColor = Color.Orange;
            }
            else
            {
                lb.BackColor = Color.Gainsboro;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            lb_NhietdoAL.Text = DATA_PLC_SI.WATER_BATH_TEMP_alarm.ToString();
            lb_Mode.Focus();
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

        private void lb_NhietdoAL_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    DATA_PLC_SI.WATER_BATH_TEMP_alarm = Convert.ToDouble(lb_NhietdoAL.Text);
                    lb_Mode.Focus();
                    KN.ShowalertThanhCong("Thay đổi nhiệt độ cảnh báo");
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