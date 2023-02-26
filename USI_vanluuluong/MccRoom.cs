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
using System.Threading;

namespace Baodongchem
{
    public partial class MccRoom : DevExpress.XtraEditors.XtraForm
    {
        public MccRoom()
        {
            InitializeComponent();
        }

        private void timer_Data_RTO_Tick(object sender, EventArgs e)
        {
            lb_ND1.Text = DATA_PLC_SI.ND1.ToString();
            lb_DO1.Text = DATA_PLC_SI.DO1.ToString();

            lb_ND2.Text = DATA_PLC_SI.ND2.ToString();
            lb_DO2.Text = DATA_PLC_SI.DO2.ToString();

            for (int i_mcc = 1; i_mcc <= 26; i_mcc++)
            {
                Chang_status_MCC(labels[i_mcc], DATA_PLC_OM.om_fault[i_mcc]);
            }
            

            Main.Chang_status_data(lb_ND1, DATA_PLC_SI.ND1_fault);
            Main.Chang_status_data(lb_DO1, DATA_PLC_SI.DO1_fault);
            Main.Chang_status_data(lb_ND2, DATA_PLC_SI.ND2_fault);
            Main.Chang_status_data(lb_DO2, DATA_PLC_SI.DO2_fault);

            if (DATA_PLC_OM.om_mute)
            {
                bt_mute.Image = Properties.Resources.mute_18px;
            }
            else
            {
                bt_mute.Image = Properties.Resources.audio_18px;
            }
        }

        public static void Chang_status_MCC(LabelControl lb, bool pump_fault)
        {
            if (pump_fault == false)
            {
                lb.BackColor = Color.LimeGreen;
            }
            else
            {
                lb.BackColor = Color.Orange;
            }
        }


        private void bt_mute_Click(object sender, EventArgs e)
        {
            if (DATA_PLC_OM.om_mute)
            {
                Data.OM_mute = false;
            }
            else
            {
                Data.OM_mute = true;
            }
            Data.write = true;
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

        LabelControl[] labels = new LabelControl[30];
        private void MccRoom_Load(object sender, EventArgs e)
        {
            labels[1] = N1;
            labels[2] = N2;
            labels[3] = N3;
            labels[4] = N4;
            labels[5] = N5;
            labels[6] = N6;
            labels[7] = N7;
            labels[8] = N8;
            labels[9] = N9;
            labels[10] = N10;
            labels[11] = N11;
            labels[12] = N12;
            labels[13] = N13;
            labels[14] = N14;
            labels[15] = N15;
            labels[16] = N16;
            labels[17] = N17;
            labels[18] = N18;
            labels[19] = N19;
            labels[20] = N20;
            labels[21] = N21;
            labels[22] = N22;
            labels[23] = N23;
            labels[24] = N24;
            labels[25] = N25;
            labels[26] = N26;

            lb_ND1_AL.Text = DATA_PLC_SI.ND1_alarm.ToString();
            lb_DO1_AL.Text = DATA_PLC_SI.DO1_alarm.ToString();
            lb_ND2_AL.Text = DATA_PLC_SI.ND2_alarm.ToString();
            lb_DO2_AL.Text = DATA_PLC_SI.DO2_alarm.ToString();
            label2.Focus();

          
        }

        private void lb_ND1_AL_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    DATA_PLC_SI.ND1_alarm = Convert.ToDouble(lb_ND1_AL.Text);
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

        private void lb_DO1_AL_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    DATA_PLC_SI.DO1_alarm = Convert.ToDouble(lb_DO1_AL.Text);
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

        private void lb_ND2_AL_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    DATA_PLC_SI.ND2_alarm = Convert.ToDouble(lb_ND2_AL.Text);
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

        private void lb_DO2_AL_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    DATA_PLC_SI.DO2_alarm = Convert.ToDouble(lb_DO2_AL.Text);
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