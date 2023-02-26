using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using S7.Net;
using libplctag;
using libplctag.DataTypes;
using libplctag.NativeImport;
using System.IO;

namespace Baodongchem
{

    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
            modbusClient = new ModbusClient();
        }

        const string gateway = "192.168.1.10";
        const string path = "1,0";
        private ModbusClient modbusClient;
        public static SqlHelper db_form1 = new SqlHelper(KN.Chuoi);
        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                return;
            System.Reflection.PropertyInfo aProp = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered",
            System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance);
            aProp.SetValue(c, true, null);
        }

        public static int Tab_open_now = 0;

        public void OpenTab(string TieuDe, string Tag, Form frm, bool isOnly, Image img = null, string buttonTag = "")
        {
            try
            {
                string _strTieuDe = TieuDe;
                if (isOnly)
                {
                    if (checkOpenTabs(_strTieuDe) > -1)

                        return;
                }
                DevExpress.XtraTab.XtraTabPage t = new DevExpress.XtraTab.XtraTabPage();
                t.Text = _strTieuDe;
                t.Tag = buttonTag;
                if (t.Text == "Trang chính" || t.Text == "Giám sát")
                {
                    t.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
                }
                if ((frm) is DevExpress.XtraEditors.XtraForm)
                {
                    var withBlock = (DevExpress.XtraEditors.XtraForm)frm;
                    withBlock.Hide();
                    withBlock.Tag = Tag;
                    withBlock.Dock = DockStyle.Fill;
                    withBlock.FormBorderStyle = FormBorderStyle.None;

                    if (img != null)
                        t.Image = img;
                    withBlock.TopLevel = false;

                    t.Controls.Add(frm);

                    withBlock.Show();
                    tabMain.Invoke(new MethodInvoker(delegate { tabMain.TabPages.Add(t); }));
                    tabMain.SelectedTabPageIndex = tabMain.TabPages.Count - 1;
                }
            }
            catch (Exception ex)
            {
                KN.Showalert(ex.Message);
            }
        }
        public int checkOpenTabs(string name)
        {
            for (int i = 0; i <= tabMain.TabPages.Count - 1; i++)
            {
                if (tabMain.TabPages[i].Text == name)
                {
                    tabMain.SelectedTabPageIndex = i;
                    return i;
                }
            }
            return -1;
        }

        bool Maximum = false;
        int width_Dislay = 0;
        int heigh_Dislay = 0;


        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Communication.ReadCommon();
                Tab_open_now = 1;
                Open_home();

                Update_fault();
                Update_temp();

                Date_time_csv = DateTime.Now;
            }
            catch (Exception ex)
            {
                KN.Showalert(ex.Message);
            }
        }

        private void Update_temp()
        {
            for (int i1b = 1; i1b <= 90; i1b++)
            {
                Data.Error_temp[i1b] = Data.Error[i1b];
            }
        }

        private void Update_fault()
        {
            //VACCUMP PUMP fault
            Data.Error[1] = DATA_PLC_LS.No1_WATER_PUMP_fault;
            Data.Error[2] = DATA_PLC_LS.No2_WATER_PUMP_fault;
            Data.Error[3] = DATA_PLC_LS.No3_WATER_PUMP_fault;
            Data.Error[5] = DATA_PLC_LS.No5_WATER_PUMP_fault;
            Data.Error[4] = DATA_PLC_LS.No4_WATER_PUMP_fault;

            Data.Error[6] = DATA_PLC_LS.No6_WATER_PUMP_fault;
            Data.Error[7] = DATA_PLC_SI.WATER_BATH_TEMP_fault;
            Data.Error[8] = DATA_PLC_LS.No1_COLLING_TOWER_fault;
            Data.Error[9] = DATA_PLC_LS.No2_COLLING_TOWER_fault;

            //Vaccump pump
            Data.Error[10] = DATA_PLC_LS.VACCUM_PUMP_A_fault;
            Data.Error[11] = DATA_PLC_LS.VACCUM_PUMP_B_fault;
            Data.Error[12] = DATA_PLC_LS.VACCUM_PUMP_C_fault;
            Data.Error[13] = DATA_PLC_LS.VACCUM_PUMP_D_fault;
            Data.Error[14] = DATA_PLC_SI.VACCUM_PRESSURE_fault;
            Data.Error[15] = DATA_PLC_SI.Pump_A_fault;
            Data.Error[16] = DATA_PLC_SI.Pump_B_fault;
            Data.Error[17] = DATA_PLC_SI.Pump_C_fault;

            //Air compressure fault
            Data.Error[18] = DATA_PLC_LS.No1_AIR_COMP_fault;
            Data.Error[19] = DATA_PLC_LS.No2_AIR_COMP_fault;
            Data.Error[20] = DATA_PLC_SI.On_air_chiller_pos_1_fault;
            Data.Error[21] = DATA_PLC_SI.On_air_chiller_pos_2_fault;
            Data.Error[22] = DATA_PLC_SI.AIR_PRESSURE_Mpa_fault;

            //Fume dust fault
            Data.Error[23] = DATA_PLC_SI.FUME_PRESSURE_fault;
            Data.Error[24] = DATA_PLC_SI.DUST_PRESSURE_fault;

            //RTO fault
            Data.Error[25] = DATA_PLC_SI.TE_1953A_fault;
            Data.Error[26] = DATA_PLC_SI.AVE_TEMP_fault;
            Data.Error[27] = DATA_PLC_SI.TE_1953B_fault;
            Data.Error[28] = DATA_PLC_SI.TE_1954_fault;
            Data.Error[29] = DATA_PLC_SI.TE_1952A_fault;
            Data.Error[30] = DATA_PLC_SI.TE_1952B_fault;
            Data.Error[31] = DATA_PLC_SI.TE_1952C_fault;
            Data.Error[32] = DATA_PLC_SI.TE_1951_fault;
            Data.Error[33] = DATA_PLC_SI.Vale_close_fault;

            //RTO fault
            for (int i1a = 1; i1a <= 26; i1a++)
            {
                Data.Error[33 + i1a] = DATA_PLC_OM.om_fault[i1a];
            }

            Data.Error[60] = DATA_PLC_SI.ND1_fault;
            Data.Error[61] = DATA_PLC_SI.ND2_fault;
            Data.Error[62] = DATA_PLC_SI.DO1_fault;
            Data.Error[63] = DATA_PLC_SI.DO2_fault;
            Data.Error[64] = DATA_PLC_SI.TE_1951_1956_fault;
            Data.Error[65] = DATA_PLC_SI.TE_FC_fault;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Communication.WriteCommon();
            Environment.Exit(0);
        }


        public static void Check_earth(bool a, ref bool temp, ref bool fault)
        {
            if (a)
            {
                if (temp == false)
                {
                    temp = true;
                    triger();
                }
                fault = true;
            }
            else
            {
                temp = fault;
            }
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        private void Open_home()
        {
            Main f1 = new Main();
            OpenTab("VACCUMP PUMP", "VACCUMP PUMP", f1, true, Properties.Resources.BaoCao_24);
        }

        int Fault_water_pump = 0;
        int Fault_vaccum_pump = 0;
        int Fault_air_pressure = 0;
        int Fault_fume_dust = 0;
        int Fault_rto = 0;
        int Fault_mcc = 0;
        int Fault_mcc_earth = 0;

        int Fault_water_pump_temp = 0;
        int Fault_vaccum_pump_temp = 0;
        int Fault_air_pressure_temp = 0;
        int Fault_fume_dust_temp = 0;
        int Fault_rto_temp = 0;
        int Fault_mcc_temp = 0;

        int Count_flash = 0;


        public Thread th_error;
        private void error_check()
        {
            try
            {
                Update_fault();
                for (int i1b = 1; i1b <= 90; i1b++)
                {
                    if (Data.Error[i1b] && !Data.Error_temp[i1b])
                    {
                        ERR_CSV(i1b);
                    }
                }
                Update_temp();
            }
            catch
            {

            }
        }

        private void Timer_display_Tick(object sender, EventArgs e)
        {
            if (DATA_PLC.s7_connect && DATA_PLC.OM_connect)
            {
                st_PLCOM.ItemAppearance.Normal.BackColor = Color.LimeGreen;
            }
            else
            {
                st_PLCOM.ItemAppearance.Normal.BackColor = Color.Red;
            }

            if (DATA_PLC.s7_connect && DATA_PLC.THD_connect)
            {
                st_THD.ItemAppearance.Normal.BackColor = Color.LimeGreen;
            }
            else
            {
                st_THD.ItemAppearance.Normal.BackColor = Color.Red;
            }
            if (th_error is null)
            {
                th_error = new Thread(error_check);
                th_error.Start();
            }
            else
            {
                if (th_error.IsAlive == false)
                {
                    th_error = new Thread(error_check);
                    th_error.Start();
                }
            }
            if (Data.Tat_coi)
            {
                BT_TATCOI.BackColor = Color.Red;
            }
            else
            {
                BT_TATCOI.BackColor = Color.Gainsboro;
            }

            if (DATA_PLC.s7_connect == true)
            {
                DATA_Calibration.v1_out = Math.Round(Analog_cal(DATA_Calibration.v1_in, DATA_Calibration.v1_int_min, DATA_Calibration.v1_int_max, DATA_Calibration.v1_real_min, DATA_Calibration.v1_real_max), 1);
                DATA_Calibration.v2_out = Math.Round(Analog_cal(DATA_Calibration.v2_in, DATA_Calibration.v2_int_min, DATA_Calibration.v2_int_max, DATA_Calibration.v2_real_min, DATA_Calibration.v2_real_max), 1);
                DATA_Calibration.v3_out = Math.Round(Analog_cal(DATA_Calibration.v3_in, DATA_Calibration.v3_int_min, DATA_Calibration.v3_int_max, DATA_Calibration.v3_real_min, DATA_Calibration.v3_real_max), 1);
                DATA_Calibration.v4_out = Math.Round(Analog_cal(DATA_Calibration.v4_in, DATA_Calibration.v4_int_min, DATA_Calibration.v4_int_max, DATA_Calibration.v4_real_min, DATA_Calibration.v4_real_max), 1);
                DATA_Calibration.v5_out = Math.Round(Analog_cal(DATA_Calibration.v5_in, DATA_Calibration.v5_int_min, DATA_Calibration.v5_int_max, DATA_Calibration.v5_real_min, DATA_Calibration.v5_real_max), 1);

                //Bao loi
                Ghi_loi(DATA_Calibration.v5_out, DATA_PLC_SI.WATER_BATH_TEMP_alarm, ref DATA_PLC_SI.WATER_BATH_TEMP_temp, ref DATA_PLC_SI.WATER_BATH_TEMP_fault, ref start_fault[1], ref start_fault_bool[1]);
                Ghi_loi(DATA_Calibration.v1_out, DATA_PLC_SI.AIR_PRESSURE_Mpa_alarm, ref DATA_PLC_SI.AIR_PRESSURE_Mpa_temp, ref DATA_PLC_SI.AIR_PRESSURE_Mpa_fault, ref start_fault[2], ref start_fault_bool[2]);
                Ghi_loi(DATA_Calibration.v4_out, DATA_PLC_SI.VACCUM_PRESSURE_alarm, ref DATA_PLC_SI.VACCUM_PRESSURE_temp, ref DATA_PLC_SI.VACCUM_PRESSURE_fault, ref start_fault[3], ref start_fault_bool[3]);
                Ghi_loi_am(DATA_Calibration.v2_out, DATA_PLC_SI.FUME_PRESSURE_alarm, ref DATA_PLC_SI.FUME_PRESSURE_temp, ref DATA_PLC_SI.FUME_PRESSURE_fault, ref start_fault[4], ref start_fault_bool[4]);
                Ghi_loi(DATA_Calibration.v3_out, DATA_PLC_SI.DUST_PRESSURE_alarm, ref DATA_PLC_SI.DUST_PRESSURE_temp, ref DATA_PLC_SI.DUST_PRESSURE_fault, ref start_fault[5], ref start_fault_bool[5]);
            }


            Fault_water_pump_temp = 0;
            Fault_vaccum_pump_temp = 0;
            Fault_air_pressure_temp = 0;
            Fault_fume_dust_temp = 0;
            Fault_rto_temp = 0;
            Fault_mcc_temp = 0;

            //VACCUMP PUMP fault
            if (DATA_PLC_LS.No1_WATER_PUMP_fault)
            {
                Fault_water_pump_temp++;
            }
            if (DATA_PLC_LS.No2_WATER_PUMP_fault)
            {
                Fault_water_pump_temp++;
            }
            if (DATA_PLC_LS.No3_WATER_PUMP_fault)
            {
                Fault_water_pump_temp++;
            }
            if (DATA_PLC_LS.No4_WATER_PUMP_fault)
            {
                Fault_water_pump_temp++;
            }
            if (DATA_PLC_LS.No5_WATER_PUMP_fault)
            {
                Fault_water_pump_temp++;
            }
            if (DATA_PLC_LS.No6_WATER_PUMP_fault)
            {
                Fault_water_pump_temp++;
            }
            if (DATA_PLC_LS.No3_WATER_PUMP_fault)
            {
                Fault_water_pump_temp++;
            }
            if (DATA_PLC_LS.No3_WATER_PUMP_fault)
            {
                Fault_water_pump_temp++;
            }
            if (DATA_PLC_SI.WATER_BATH_TEMP_fault)
            {
                Fault_water_pump_temp++;
            }
            if (DATA_PLC_LS.No1_COLLING_TOWER_fault)
            {
                Fault_water_pump_temp++;
            }
            if (DATA_PLC_LS.No2_COLLING_TOWER_fault)
            {
                Fault_water_pump_temp++;
            }
            Fault_water_pump = Fault_water_pump_temp;

            //Vaccump pump
            if (DATA_PLC_LS.VACCUM_PUMP_A_fault)
            {
                Fault_vaccum_pump_temp++;
            }
            if (DATA_PLC_LS.VACCUM_PUMP_B_fault)
            {
                Fault_vaccum_pump_temp++;
            }
            if (DATA_PLC_LS.VACCUM_PUMP_C_fault)
            {
                Fault_vaccum_pump_temp++;
            }
            if (DATA_PLC_LS.VACCUM_PUMP_D_fault)
            {
                Fault_vaccum_pump_temp++;
            }
            if (DATA_PLC_SI.VACCUM_PRESSURE_fault)
            {
                Fault_vaccum_pump_temp++;
            }
            if (DATA_PLC_SI.Pump_A_fault)
            {
                Fault_vaccum_pump_temp++;
            }
            if (DATA_PLC_SI.Pump_B_fault)
            {
                Fault_vaccum_pump_temp++;
            }
            if (DATA_PLC_SI.Pump_C_fault)
            {
                Fault_vaccum_pump_temp++;
            }
            Fault_vaccum_pump = Fault_vaccum_pump_temp;

            //Air compressure fault
            if (DATA_PLC_LS.No1_AIR_COMP_fault)
            {
                Fault_air_pressure_temp++;
            }
            if (DATA_PLC_LS.No2_AIR_COMP_fault)
            {
                Fault_air_pressure_temp++;
            }
            if (DATA_PLC_SI.On_air_chiller_pos_1_fault)
            {
                Fault_air_pressure_temp++;
            }
            if (DATA_PLC_SI.On_air_chiller_pos_2_fault)
            {
                Fault_air_pressure_temp++;
            }
            if (DATA_PLC_SI.AIR_PRESSURE_Mpa_fault)
            {
                Fault_air_pressure_temp++;
            }
            Fault_air_pressure = Fault_air_pressure_temp;

            //Fume dust fault
            if (DATA_PLC_SI.FUME_PRESSURE_fault)
            {
                Fault_fume_dust_temp++;
            }
            if (DATA_PLC_SI.DUST_PRESSURE_fault)
            {
                Fault_fume_dust_temp++;
            }
            Fault_fume_dust = Fault_fume_dust_temp;

            //RTO fault
            if (DATA_PLC_SI.TE_1953A_fault)
            {
                Fault_rto_temp++;
            }
            if (DATA_PLC_SI.AVE_TEMP_fault)
            {
                Fault_rto_temp++;
            }
            if (DATA_PLC_SI.TE_1953B_fault)
            {
                Fault_rto_temp++;
            }
            if (DATA_PLC_SI.TE_1954_fault)
            {
                Fault_rto_temp++;
            }
            if (DATA_PLC_SI.TE_1952A_fault)
            {
                Fault_rto_temp++;
            }
            if (DATA_PLC_SI.TE_1952B_fault)
            {
                Fault_rto_temp++;
            }
            if (DATA_PLC_SI.TE_1952C_fault)
            {
                Fault_rto_temp++;
            }
            if (DATA_PLC_SI.TE_1951_fault)
            {
                Fault_rto_temp++;
            }
            if (DATA_PLC_SI.TE_1951_1956_fault)
            {
                Fault_rto_temp++;
            }
            if (DATA_PLC_SI.TE_FC_fault)
            {
                Fault_rto_temp++;
            }
            Fault_rto = Fault_rto_temp;

            //MCC fault


            for (int i_mcc_f = 1; i_mcc_f <= 26; i_mcc_f++)
            {
                if (DATA_PLC_OM.om_fault[i_mcc_f])
                {
                    Fault_mcc_temp++;
                }
            }
            Fault_mcc_earth = Fault_mcc_temp;

            if (DATA_PLC_SI.ND1_fault)
            {
                Fault_mcc_temp++;
            }
            if (DATA_PLC_SI.ND2_fault)
            {
                Fault_mcc_temp++;
            }
            if (DATA_PLC_SI.DO1_fault)
            {
                Fault_mcc_temp++;
            }
            if (DATA_PLC_SI.DO2_fault)
            {
                Fault_mcc_temp++;
            }
            Fault_mcc = Fault_mcc_temp;

            Count_flash++;
            if (Count_flash > 2)
            {
                Count_flash = 0;
            }

            if (Fault_water_pump > 0 || Fault_vaccum_pump > 0 || Fault_air_pressure > 0 || Fault_fume_dust > 0 || Fault_rto > 0 || Fault_mcc > 0)
            {
                Data.System_fault = true;
            }
            else
            {
                Data.System_fault = false;
            }

            //1
            if (Fault_water_pump > 0)
            {
                if (Tab_open_now == 1)
                {
                    if (Count_flash == 1)
                    {
                        bt_Waterpump.BackColor = Color.Orange;
                    }
                    else
                    {
                        bt_Waterpump.BackColor = Color.FromArgb(128, 128, 255);
                    }
                }
                else
                {
                    if (Count_flash == 1)
                    {
                        bt_Waterpump.BackColor = Color.Orange;
                    }
                    else
                    {
                        bt_Waterpump.BackColor = Color.Gainsboro;
                    }
                }
            }
            else
            {
                if (Tab_open_now == 1)
                {
                    bt_Waterpump.BackColor = Color.FromArgb(128, 128, 255);
                }
                else
                {
                    bt_Waterpump.BackColor = Color.Gainsboro;
                }
            }

            //2
            if (Fault_vaccum_pump > 0)
            {
                if (Tab_open_now == 2)
                {
                    if (Count_flash == 1)
                    {
                        bt_VaccumPump.BackColor = Color.Orange;
                    }
                    else
                    {
                        bt_VaccumPump.BackColor = Color.FromArgb(128, 128, 255);
                    }
                }
                else
                {
                    if (Count_flash == 1)
                    {
                        bt_VaccumPump.BackColor = Color.Orange;
                    }
                    else
                    {
                        bt_VaccumPump.BackColor = Color.Gainsboro;
                    }
                }
            }
            else
            {
                if (Tab_open_now == 2)
                {
                    bt_VaccumPump.BackColor = Color.FromArgb(128, 128, 255);
                }
                else
                {
                    bt_VaccumPump.BackColor = Color.Gainsboro;
                }
            }

            //3
            if (Fault_air_pressure > 0)
            {
                if (Tab_open_now == 3)
                {
                    if (Count_flash == 1)
                    {
                        bt_AirPressure.BackColor = Color.Orange;
                    }
                    else
                    {
                        bt_VaccumPump.BackColor = Color.FromArgb(128, 128, 255);
                    }
                }
                else
                {
                    if (Count_flash == 1)
                    {
                        bt_AirPressure.BackColor = Color.Orange;
                    }
                    else
                    {
                        bt_AirPressure.BackColor = Color.Gainsboro;
                    }
                }
            }
            else
            {
                if (Tab_open_now == 3)
                {
                    bt_AirPressure.BackColor = Color.FromArgb(128, 128, 255);
                }
                else
                {
                    bt_AirPressure.BackColor = Color.Gainsboro;
                }
            }

            //4
            if (Fault_fume_dust > 0)
            {
                if (Tab_open_now == 4)
                {
                    if (Count_flash == 1)
                    {
                        bt_FumeDust.BackColor = Color.Orange;
                    }
                    else
                    {
                        bt_FumeDust.BackColor = Color.FromArgb(128, 128, 255);
                    }
                }
                else
                {
                    if (Count_flash == 1)
                    {
                        bt_FumeDust.BackColor = Color.Orange;
                    }
                    else
                    {
                        bt_FumeDust.BackColor = Color.Gainsboro;
                    }
                }
            }
            else
            {
                if (Tab_open_now == 4)
                {
                    bt_FumeDust.BackColor = Color.FromArgb(128, 128, 255);
                }
                else
                {
                    bt_FumeDust.BackColor = Color.Gainsboro;
                }
            }
            //5
            if (Fault_rto > 0)
            {
                if (Tab_open_now == 5)
                {
                    if (Count_flash == 1)
                    {
                        bt_Rto.BackColor = Color.Orange;
                    }
                    else
                    {
                        bt_Rto.BackColor = Color.FromArgb(128, 128, 255);
                    }
                }
                else
                {
                    if (Count_flash == 1)
                    {
                        bt_Rto.BackColor = Color.Orange;
                    }
                    else
                    {
                        bt_Rto.BackColor = Color.Gainsboro;
                    }
                }
            }
            else
            {
                if (Tab_open_now == 5)
                {
                    bt_Rto.BackColor = Color.FromArgb(128, 128, 255);
                }
                else
                {
                    bt_Rto.BackColor = Color.Gainsboro;
                }
            }
            //6
            if (Fault_mcc > 0)
            {
                if (Tab_open_now == 6)
                {
                    if (Count_flash == 1)
                    {
                        bt_MccRoom.BackColor = Color.Orange;
                    }
                    else
                    {
                        bt_MccRoom.BackColor = Color.FromArgb(128, 128, 255);
                    }
                }
                else
                {
                    if (Count_flash == 1)
                    {
                        bt_MccRoom.BackColor = Color.Orange;
                    }
                    else
                    {
                        bt_MccRoom.BackColor = Color.Gainsboro;
                    }
                }
            }
            else
            {
                if (Tab_open_now == 6)
                {
                    bt_MccRoom.BackColor = Color.FromArgb(128, 128, 255);
                }
                else
                {
                    bt_MccRoom.BackColor = Color.Gainsboro;
                }
            }


            if (DATA_PLC_SI.Reset)
            {
                BT_TATCOI.PerformClick();
                Data.Reset_bt_tatcoi = true;
            }
            if (DATA_PLC_SI.Reset_3s)
            {
                BT_RESET_AL.PerformClick();
                Data.Reset_bt_reset = true;
            }

        }

        private void ERR_CSV(int id)
        {
            Date_time_csv = DateTime.Now;
            csv1.Clear();
            newFileName1 = Application.StartupPath + @"\Error_Log\Log_" + DateTime.Now.ToString("yyyyMMdd") + ".csv";
            newFilePatch1 = Application.StartupPath + @"\Error_Log\";
            if (0 == 0)
            {
                string khuvuc = "";
                string Tenloi = "";
                try
                {

                    switch (id)
                    {
                        case 1:
                            khuvuc = "VACCUMP PUMP";
                            Tenloi = "No1 VACCUMP PUMP fault";
                            break;
                        case 2:
                            khuvuc = "VACCUMP PUMP";
                            Tenloi = "No2 VACCUMP PUMP fault";
                            break;
                        case 3:
                            khuvuc = "VACCUMP PUMP";
                            Tenloi = "No3 VACCUMP PUMP fault";
                            break;
                        case 4:
                            khuvuc = "VACCUMP PUMP";
                            Tenloi = "No4 VACCUMP PUMP fault";
                            break;
                        case 5:
                            khuvuc = "VACCUMP PUMP";
                            Tenloi = "No5 VACCUMP PUMP fault";
                            break;
                        case 6:
                            khuvuc = "VACCUMP PUMP";
                            Tenloi = "No6 VACCUMP PUMP fault";
                            break;
                        case 7:
                            khuvuc = "VACCUMP PUMP";
                            Tenloi = "WATER BATH TEMP fault";
                            break;
                        case 8:
                            khuvuc = "VACCUMP PUMP";
                            Tenloi = "No1_COLLING_TOWER_fault";
                            break;
                        case 9:
                            khuvuc = "VACCUMP PUMP";
                            Tenloi = "No2_COLLING_TOWER_fault";
                            break;
                        //Vaccum pump
                        case 10:
                            khuvuc = "VACCUMP PUMP";
                            Tenloi = "VACCUM_PUMP_A_fault";
                            break;
                        case 11:
                            khuvuc = "VACCUMP PUMP";
                            Tenloi = "VACCUM_PUMP_B_fault";
                            break;
                        case 12:
                            khuvuc = "VACCUMP PUMP";
                            Tenloi = "VACCUM_PUMP_C_fault";
                            break;
                        case 13:
                            khuvuc = "VACCUMP PUMP";
                            Tenloi = "VACCUM_PUMP_D_fault";
                            break;
                        case 14:
                            khuvuc = "VACCUMP PUMP";
                            Tenloi = "VACCUM_PRESSURE_fault";
                            break;
                        case 15:
                            khuvuc = "VACCUMP PUMP";
                            Tenloi = "Pump_A_fault";
                            break;
                        case 16:
                            khuvuc = "VACCUMP PUMP";
                            Tenloi = "Pump_B_fault";
                            break;
                        case 17:
                            khuvuc = "VACCUMP PUMP";
                            Tenloi = "Pump_C_fault";
                            break;

                        //AIR COMPRESSURE
                        case 18:
                            khuvuc = "AIR COMPRESSURE";
                            Tenloi = "No1_AIR_COMP_fault";
                            break;
                        case 19:
                            khuvuc = "AIR COMPRESSURE";
                            Tenloi = "No2_AIR_COMP_fault";
                            break;
                        case 20:
                            khuvuc = "AIR COMPRESSURE";
                            Tenloi = "On_air_chiller_pos_1_fault";
                            break;
                        case 21:
                            khuvuc = "AIR COMPRESSURE";
                            Tenloi = "On_air_chiller_pos_2_fault";
                            break;
                        case 22:
                            khuvuc = "AIR COMPRESSURE";
                            Tenloi = "AIR_PRESSURE_Mpa_fault";
                            break;

                        //FUME DUST
                        case 23:
                            khuvuc = "FUME DUST";
                            Tenloi = "FUME_PRESSURE_fault";
                            break;
                        case 24:
                            khuvuc = "FUME DUST";
                            Tenloi = "TE_1953A_fault";
                            break;
                        //RTO
                        case 25:
                            khuvuc = "RTO";
                            Tenloi = "TE_1953A_fault";
                            break;
                        case 26:
                            khuvuc = "RTO";
                            Tenloi = "AVE_TEMP_fault";
                            break;
                        case 27:
                            khuvuc = "RTO";
                            Tenloi = "TE_1953B_fault";
                            break;
                        case 28:
                            khuvuc = "RTO";
                            Tenloi = "TE_1954_fault";
                            break;
                        case 29:
                            khuvuc = "RTO";
                            Tenloi = "TE_1952A_fault";
                            break;
                        case 30:
                            khuvuc = "RTO";
                            Tenloi = "TE_1952B_fault";
                            break;
                        case 31:
                            khuvuc = "RTO";
                            Tenloi = "TE_1952C_fault";
                            break;
                        case 32:
                            khuvuc = "RTO";
                            Tenloi = "TE_1951_fault";
                            break;
                        case 33:
                            khuvuc = "RTO";
                            Tenloi = "Vale_close_fault";
                            break;

                        //MCC
                        case 34:
                            khuvuc = "MCC ROOM";
                            Tenloi = "1 MIXER 1";
                            break;
                        case 35:
                            khuvuc = "MCC ROOM";
                            Tenloi = "2 QA TEST";
                            break;
                        case 36:
                            khuvuc = "MCC ROOM";
                            Tenloi = "3 Ex2 MCCB";
                            break;
                        case 37:
                            khuvuc = "MCC ROOM";
                            Tenloi = "4 Ex1 MCCB";
                            break;
                        case 38:
                            khuvuc = "MCC ROOM";
                            Tenloi = "5 MIXER 2";
                            break;

                        case 39:
                            khuvuc = "MCC ROOM";
                            Tenloi = "6 MIXER 3";
                            break;
                        case 40:
                            khuvuc = "MCC ROOM";
                            Tenloi = "7 AIR COND 3";
                            break;
                        case 41:
                            khuvuc = "MCC ROOM";
                            Tenloi = "8 PLC POWER";
                            break;
                        case 42:
                            khuvuc = "MCC ROOM";
                            Tenloi = "9 PACKER";
                            break;
                        case 43:
                            khuvuc = "MCC ROOM";
                            Tenloi = "10 PNEUMATIC";
                            break;

                        //11

                        case 44:
                            khuvuc = "MCC ROOM";
                            Tenloi = "11 HOIST";
                            break;
                        case 45:
                            khuvuc = "MCC ROOM";
                            Tenloi = "12 RTO HEATER";
                            break;
                        case 46:
                            khuvuc = "MCC ROOM";
                            Tenloi = "13 Ex2 INVETER";
                            break;
                        case 47:
                            khuvuc = "MCC ROOM";
                            Tenloi = "14 CS KHO TP";
                            break;
                        case 48:
                            khuvuc = "MCC ROOM";
                            Tenloi = "15 CS KHO SX";
                            break;

                        case 49:
                            khuvuc = "MCC ROOM";
                            Tenloi = "16 CS KHO NL";
                            break;
                        case 50:
                            khuvuc = "MCC ROOM";
                            Tenloi = "17 AIR COND 1";
                            break;
                        case 51:
                            khuvuc = "MCC ROOM";
                            Tenloi = "18 EX PILOT MCCB";
                            break;
                        case 52:
                            khuvuc = "MCC ROOM";
                            Tenloi = "19 EX PILOT INVT";
                            break;
                        case 53:
                            khuvuc = "MCC ROOM";
                            Tenloi = "20 Ex1 INVT";
                            break;

                        //21

                        case 54:
                            khuvuc = "MCC ROOM";
                            Tenloi = "21 MAINTENANCE";
                            break;
                        case 55:
                            khuvuc = "MCC ROOM";
                            Tenloi = "22 DB PANEL";
                            break;
                        case 56:
                            khuvuc = "MCC ROOM";
                            Tenloi = "23 Ex3 MCCB";
                            break;
                        case 57:
                            khuvuc = "MCC ROOM";
                            Tenloi = "24 AIR COND 2";
                            break;
                        case 58:
                            khuvuc = "MCC ROOM";
                            Tenloi = "25 ULTILITY PANEL";
                            break;
                        case 59:
                            khuvuc = "MCC ROOM";
                            Tenloi = "26 Ex3 INVT";
                            break;
                        //MCC temp
                        case 60:
                            khuvuc = "MCC ROOM";
                            Tenloi = "T.R. ROOM TEMP";
                            break;
                        case 61:
                            khuvuc = "MCC ROOM";
                            Tenloi = "MCC ROOM TEMP";
                            break;
                        case 62:
                            khuvuc = "MCC ROOM";
                            Tenloi = "T.R. ROOM HUMI";
                            break;
                        case 63:
                            khuvuc = "MCC ROOM";
                            Tenloi = "MCC ROOM HUMI";
                            break;
                        case 64:
                            khuvuc = "RTO";
                            Tenloi = "XV 1951 AND 1956 OFF";
                            break;
                        case 65:
                            khuvuc = "RTO";
                            Tenloi = "BY PASS TO FC ON";
                            break;
                    }

                    csv1.Clear();
                    string newLine = string.Format("{0},{1},{2},{3}",
                    Date_time_csv.ToString(),
                    "",
                    khuvuc,
                    Tenloi);

                    csv1.AppendLine(newLine);
                    if (!System.IO.File.Exists(newFileName1))
                    {
                        System.IO.Directory.CreateDirectory(newFilePatch1);
                        using (FileStream fs = File.Create(newFileName1))
                        {

                        }
                        File.AppendAllText(newFileName1, csv1.ToString());
                    }
                    else
                    {
                        File.AppendAllText(newFileName1, csv1.ToString());
                    };
                }
                catch (Exception ex)
                {
                    KN.Logerror(ex.ToString());
                }
            }
        }
        private void Update_ketthuc(string path1)
        {
            try
            {
                List<String> lines = new List<String>();
                if (File.Exists(path1)) ;
                {
                    using (StreamReader reader = new StreamReader(path1))
                    {
                        String line;

                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.Contains(","))
                            {
                                String[] split = line.Split(',');

                                if (split[1].ToString() == "")
                                {
                                    split[1] = DateTime.Now.ToString();
                                    line = String.Join(",", split);
                                }
                            }

                            lines.Add(line);
                        }
                    }

                    using (StreamWriter writer = new StreamWriter(path1, false))
                    {
                        foreach (String line in lines)
                            writer.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private double Analog_cal(double input, double int_min, double int_max, double real_min, double real_max)
        {
            double sub_int = 0, sub_real = 0;
            if (int_max - int_min != 0)
            {
                sub_int = int_max - int_min;
            }
            else
            {
                sub_int = 1000;
            }
            if (real_max - real_min != 0)
            {
                sub_real = real_max - real_min;
            }
            else
            {
                sub_real = 1000;
            }

            return (input - int_min) * sub_real / sub_int + real_min;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {

        }


        private void btClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void btMax_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Maximum)
            {
                Left = Top = 0;
                Width = width_Dislay;
                Height = heigh_Dislay;
                Maximum = false;
            }
            else
            {
                Left = Top = 0;
                Width = Screen.PrimaryScreen.WorkingArea.Width;
                Height = Screen.PrimaryScreen.WorkingArea.Height;
                Maximum = true;
            }
        }


        private void Open_tab()
        {
            //int tabIndex = tabMain.SelectedTabPageIndex;
            //if (tabIndex >= 0)
            //{
            //    tabMain.SelectedTabPage.Dispose();
            //}
            List<XtraTabPage> removePages = new List<XtraTabPage>();

            removePages.AddRange(tabMain.TabPages);

            foreach (XtraTabPage page in removePages)
            {
                if (tabMain != null)
                    tabMain.TabPages.Remove(page);
            }


            bt_Waterpump.BackColor = Color.Gainsboro;
            bt_VaccumPump.BackColor = Color.Gainsboro;
            bt_AirPressure.BackColor = Color.Gainsboro;
            bt_FumeDust.BackColor = Color.Gainsboro;
            bt_Rto.BackColor = Color.Gainsboro;
            bt_MccRoom.BackColor = Color.Gainsboro;
            bt_Report.BackColor = Color.Gainsboro;
            btPack.BackColor = Color.Gainsboro;

            switch (Tab_open_now)
            {
                case 1:
                    Open_home();
                    bt_Waterpump.BackColor = Color.FromArgb(128, 128, 255);
                    break;
                case 2:
                    VaccumPump f1 = new VaccumPump();
                    OpenTab("VACCUM PUMP", "VACCUM PUMP", f1, true, Properties.Resources.BaoCao_24);
                    bt_VaccumPump.BackColor = Color.FromArgb(128, 128, 255);
                    break;
                case 3:
                    AirPressure f2 = new AirPressure();
                    OpenTab("AIR PRESSURE", "AIR PRESSURE", f2, true, Properties.Resources.BaoCao_24);
                    bt_AirPressure.BackColor = Color.FromArgb(128, 128, 255);
                    break;
                case 4:
                    FumeDust f3 = new FumeDust();
                    OpenTab("FUME DUST", "FUME DUST", f3, true, Properties.Resources.BaoCao_24);
                    bt_FumeDust.BackColor = Color.FromArgb(128, 128, 255);
                    break;
                case 5:
                    RTO f4 = new RTO();
                    OpenTab("RTO", "RTO", f4, true, Properties.Resources.BaoCao_24);
                    bt_Rto.BackColor = Color.FromArgb(128, 128, 255);
                    break;
                case 6:
                    MccRoom f5 = new MccRoom();
                    OpenTab("MCC ROOM", "MCC ROOM", f5, true, Properties.Resources.BaoCao_24);
                    bt_MccRoom.BackColor = Color.FromArgb(128, 128, 255);
                    break;
                case 7:
                    Report f6 = new Report();
                    OpenTab("REPORT", "REPORT", f6, true, Properties.Resources.BaoCao_24);
                    bt_Report.BackColor = Color.FromArgb(128, 128, 255);
                    break;
                case 8:
                    Pack f7 = new Pack();
                    OpenTab("PACK", "PACK", f7, true, Properties.Resources.BaoCao_24);
                    btPack.BackColor = Color.FromArgb(128, 128, 255);
                    break;
            }
        }


        private void bt_Waterpump_Click(object sender, EventArgs e)
        {
            Tab_open_now = 1;
            Open_tab();
        }

        private void bt_VaccumPump_Click(object sender, EventArgs e)
        {
            Tab_open_now = 2;
            Open_tab();
        }

        private void bt_AirPressure_Click(object sender, EventArgs e)
        {
            Tab_open_now = 3;
            Open_tab();
        }

        private void bt_FumeDust_Click(object sender, EventArgs e)
        {
            Tab_open_now = 4;
            Open_tab();
        }

        private void bt_Rto_Click(object sender, EventArgs e)
        {
            Tab_open_now = 5;
            Open_tab();
        }

        private void bt_MccRoom_Click(object sender, EventArgs e)
        {
            Tab_open_now = 6;
            Open_tab();
        }

        private void bt_Report_Click(object sender, EventArgs e)
        {
            Tab_open_now = 7;
            Open_tab();
        }

        public static void triger()
        {
            Data.Tat_coi = false;
        }

        public Thread th_PLC_Si;
        public Thread th_PLC_SiPack;
        public Thread th_PLC_LS;
        public Thread th_PLC_RW;
        Plc PLC = new Plc(CpuType.S71200, "192.168.1.169", 0, 1);
        Plc PLCPACK = new Plc(CpuType.S71200, "192.168.1.170", 0, 1);
        private void Timer_loaddata_Tick(object sender, EventArgs e)
        {
            try
            {
                if (th_PLC_Si is null)
                {
                    th_PLC_Si = new Thread(KNPLC_S7);
                    th_PLC_Si.Start();
                }
                else
                {
                    if (th_PLC_Si.IsAlive == false)
                    {
                        th_PLC_Si = new Thread(KNPLC_S7);
                        th_PLC_Si.Start();
                    }
                }

                if (th_PLC_SiPack is null)
                {
                    th_PLC_SiPack = new Thread(KNPLC_S7PACK);
                    th_PLC_SiPack.Start();
                }
                else
                {
                    if (th_PLC_SiPack.IsAlive == false)
                    {
                        th_PLC_SiPack = new Thread(KNPLC_S7PACK);
                        th_PLC_SiPack.Start();
                    }
                }

                if (th_PLC_LS is null)
                {
                    th_PLC_LS = new Thread(LS_PLC);
                    th_PLC_LS.Start();
                }
                else
                {
                    if (th_PLC_LS.IsAlive == false)
                    {
                        th_PLC_LS = new Thread(LS_PLC);
                        th_PLC_LS.Start();
                    }
                }

                if (th_PLC_RW is null)
                {
                    th_PLC_RW = new Thread(RW_PLC);
                    th_PLC_RW.Start();
                }
                else
                {
                    if (th_PLC_RW.IsAlive == false)
                    {
                        th_PLC_RW = new Thread(RW_PLC);
                        th_PLC_RW.Start();
                    }
                }
            }
            catch
            {

            }
        }
        private void KNPLC_S7()
        {
            try
            {
                if (PLC.IsAvailable == true && PLC.IsConnected == false)
                {
                    Thread.Sleep(500);
                    PLC.Open();

                    if (PLC.Open() == ErrorCode.NoError)
                    {
                        st_PLCSI.ItemAppearance.Normal.BackColor = Color.LimeGreen;
                    }
                    else
                    {
                        st_PLCSI.ItemAppearance.Normal.BackColor = Color.Red;
                        DATA_PLC.s7_connect = false;
                    }

                }
                else if (PLC.IsConnected == true)
                {
                    st_PLCSI.ItemAppearance.Normal.BackColor = Color.LimeGreen;
                    Read_PLC_SI();
                }
                if (PLC.IsAvailable == false)
                {
                    st_PLCSI.ItemAppearance.Normal.BackColor = Color.Red;
                    DATA_PLC.s7_connect = false;
                }

            }
            catch (Exception ex)
            {
                PLC.Close();
                st_PLCSI.ItemAppearance.Normal.BackColor = Color.Red;
                DATA_PLC.s7_connect = false;
                Thread.Sleep(500);
                PLC.Open();
            }
        }

        private void KNPLC_S7PACK()
        {
            try
            {
                if (PLCPACK.IsAvailable == true && PLCPACK.IsConnected == false)
                {
                    Thread.Sleep(500);
                    PLCPACK.Open();

                    if (PLCPACK.Open() == ErrorCode.NoError)
                    {
                        st_PLCSIPACK.ItemAppearance.Normal.BackColor = Color.LimeGreen;
                    }
                    else
                    {
                        st_PLCSIPACK.ItemAppearance.Normal.BackColor = Color.Red;
                        DATA_PLC.s7_connectpack = false;
                    }

                }
                else if (PLCPACK.IsConnected == true)
                {
                    st_PLCSIPACK.ItemAppearance.Normal.BackColor = Color.LimeGreen;
                    Read_PLC_SIPACK();
                }
                if (PLCPACK.IsAvailable == false)
                {
                    st_PLCSIPACK.ItemAppearance.Normal.BackColor = Color.Red;
                    DATA_PLC.s7_connectpack = false;
                }

            }
            catch (Exception ex)
            {
                PLCPACK.Close();
                st_PLCSIPACK.ItemAppearance.Normal.BackColor = Color.Red;
                DATA_PLC.s7_connectpack = false;
                Thread.Sleep(500);
                PLCPACK.Open();
            }
        }

        private void Read_PLC_SI()
        {
            DATA_PLC.Read_PLC = PLC.ReadBytes(DataType.DataBlock, 8, 0, 38);
            if (DATA_PLC.Read_PLC.Length >= 38)
            {

                DATA_PLC.OM_connect = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[0], 4);
                DATA_PLC.THD_connect = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[0], 5);

                DATA_PLC_SI.ND1 = Math.Round(ChuyenDoi.LayDataDouble(DATA_PLC.Read_PLC, 2), 1);
                DATA_PLC_SI.DO1 = Math.Round(ChuyenDoi.LayDataDouble(DATA_PLC.Read_PLC, 6), 1);
                DATA_PLC_SI.ND2 = Math.Round(ChuyenDoi.LayDataDouble(DATA_PLC.Read_PLC, 10), 1);
                DATA_PLC_SI.DO2 = Math.Round(ChuyenDoi.LayDataDouble(DATA_PLC.Read_PLC, 14), 1);
                DATA_Calibration.v1_in = ChuyenDoi.LayDataInt(DATA_PLC.Read_PLC, 18);
                DATA_Calibration.v2_in = ChuyenDoi.LayDataInt(DATA_PLC.Read_PLC, 20);
                DATA_Calibration.v3_in = ChuyenDoi.LayDataInt(DATA_PLC.Read_PLC, 22);
                DATA_Calibration.v4_in = ChuyenDoi.LayDataInt(DATA_PLC.Read_PLC, 24);
                DATA_Calibration.v5_in = ChuyenDoi.LayDataInt(DATA_PLC.Read_PLC, 26);
                DATA_PLC_SI.Man_pump_cmd = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[28], 0);
                DATA_PLC_SI.On_air_chiller_pos_1 = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[28], 1);
                DATA_PLC_SI.On_air_chiller_pos_2 = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[28], 2);
                DATA_PLC_SI.On_dust_collector_A_Pos = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[28], 3);
                DATA_PLC_SI.On_dust_collector_B_Pos = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[28], 4);
                DATA_PLC_SI.On_fume_collector_A_Pos = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[28], 5);
                DATA_PLC_SI.On_fume_collector_B_Pos = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[28], 6);
                DATA_PLC_SI.On_dust_collector_C_Pos = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[29], 7);

                DATA_PLC_SI.Lamp_stop = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[28], 7);
                DATA_PLC_SI.Lamp_fault = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[29], 0);
                DATA_PLC_SI.Lamp_run = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[29], 1);
                DATA_PLC_SI.Buzz = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[29], 2);
                DATA_PLC_SI.Horn_and_light = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[29], 3);
                DATA_PLC_SI.Off_horn = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[29], 4);
                DATA_PLC_SI.Reset = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[29], 5);
                DATA_PLC_SI.Reset_3s = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[29], 6);

                DATA_PLC_OM.om[1] = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[32], 0);
                DATA_PLC_OM.om[2] = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[32], 1);
                DATA_PLC_OM.om[3] = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[32], 2);
                DATA_PLC_OM.om[4] = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[32], 3);
                DATA_PLC_OM.om[5] = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[32], 4);
                DATA_PLC_OM.om[6] = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[32], 5);
                DATA_PLC_OM.om[7] = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[32], 6);
                DATA_PLC_OM.om[8] = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[32], 7);
                DATA_PLC_OM.om[9] = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[31], 0);
                DATA_PLC_OM.om[10] = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[31], 1);
                DATA_PLC_OM.om[11] = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[31], 2);
                DATA_PLC_OM.om[12] = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[31], 3);
                DATA_PLC_OM.om[13] = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[31], 4);
                DATA_PLC_OM.om[14] = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[31], 5);
                DATA_PLC_OM.om[15] = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[31], 6);
                DATA_PLC_OM.om[16] = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[31], 7);
                DATA_PLC_OM.om[17] = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[34], 0);
                DATA_PLC_OM.om[18] = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[34], 1);
                DATA_PLC_OM.om[19] = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[34], 2);
                DATA_PLC_OM.om[20] = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[34], 3);
                DATA_PLC_OM.om[21] = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[34], 4);
                DATA_PLC_OM.om[22] = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[34], 5);
                DATA_PLC_OM.om[23] = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[34], 6);
                DATA_PLC_OM.om[24] = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[34], 7);
                DATA_PLC_OM.om[25] = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[33], 0);
                DATA_PLC_OM.om[26] = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[33], 1);
                DATA_PLC_OM.om_mute = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[33], 4);

                DATA_PLC.s7_connect = true;

                if (DATA_PLC_SI.ND1 > DATA_PLC_SI.ND1_alarm)
                {
                    DATA_PLC_SI.ND1_fault = true;
                }
                if (DATA_PLC_SI.DO1 > DATA_PLC_SI.DO1_alarm)
                {
                    DATA_PLC_SI.DO1_fault = true;
                }
                if (DATA_PLC_SI.ND2 > DATA_PLC_SI.ND2_alarm)
                {
                    DATA_PLC_SI.ND2_fault = true;
                }
                if (DATA_PLC_SI.DO2 > DATA_PLC_SI.DO2_alarm)
                {
                    DATA_PLC_SI.DO2_fault = true;
                }

                if (Data.System_fault)
                {
                    if (Data.Tat_coi == false)
                    {
                        if (DATA_PLC_SI.Lamp_stop == true)
                        {
                            PLC.Write("DB6.DBX0.0", 0);
                        }
                        if (DATA_PLC_SI.Lamp_fault == false)
                        {
                            PLC.Write("DB6.DBX0.1", 1);
                        }
                        if (DATA_PLC_SI.Lamp_run == true)
                        {
                            PLC.Write("DB6.DBX0.2", 0);
                        }
                        if (DATA_PLC_SI.Buzz == false)
                        {
                            PLC.Write("DB6.DBX0.3", 1);
                        }
                        if (DATA_PLC_SI.Horn_and_light == false)
                        {
                            PLC.Write("DB6.DBX0.4", 1);
                        }
                    }
                    else
                    {
                        if (DATA_PLC_SI.Lamp_stop == false)
                        {
                            PLC.Write("DB6.DBX0.0", 1);
                        }
                        if (DATA_PLC_SI.Lamp_fault == true)
                        {
                            PLC.Write("DB6.DBX0.1", 0);
                        }
                        if (DATA_PLC_SI.Lamp_run == true)
                        {
                            PLC.Write("DB6.DBX0.2", 0);
                        }
                        if (DATA_PLC_SI.Buzz == true)
                        {
                            PLC.Write("DB6.DBX0.3", 0);
                        }
                        if (DATA_PLC_SI.Horn_and_light == true)
                        {
                            PLC.Write("DB6.DBX0.4", 0);
                        }
                    }
                }
                else
                {
                    if (DATA_PLC_SI.Lamp_stop == true)
                    {
                        PLC.Write("DB6.DBX0.0", 0);
                    }
                    if (DATA_PLC_SI.Lamp_fault == true)
                    {
                        PLC.Write("DB6.DBX0.1", 1);
                    }
                    if (DATA_PLC_SI.Lamp_run == false)
                    {
                        PLC.Write("DB6.DBX0.2", 1);
                    }
                    if (DATA_PLC_SI.Buzz == true)
                    {
                        PLC.Write("DB6.DBX0.3", 0);
                    }
                    if (DATA_PLC_SI.Horn_and_light == true)
                    {
                        PLC.Write("DB6.DBX0.4", 0);
                    }
                }
                if (Data.Reset_bt_tatcoi)
                {
                    PLC.Write("DB6.DBX0.6", 0);
                    Data.Reset_bt_tatcoi = false;
                }
                if (Data.Reset_bt_reset)
                {
                    PLC.Write("DB6.DBX0.7", 0);
                    Data.Reset_bt_reset = false;
                }

                if (Data.write == true)
                {
                    if (Data.OM_reset == true)
                    {
                        PLC.Write("DB6.DBX1.0", 1);
                        Data.OM_reset = false;
                        Thread.Sleep(100);
                    }
                    if (Data.OM_tatcoi == true)
                    {
                        PLC.Write("DB6.DBX1.1", 1);
                        Data.OM_tatcoi = false;
                        Thread.Sleep(100);
                    }
                    if (Data.OM_mute == false && DATA_PLC_OM.om_mute == true)
                    {
                        PLC.Write("DB6.DBX1.2", 0);
                    }
                    if (Data.OM_mute == true && DATA_PLC_OM.om_mute == false)
                    {
                        PLC.Write("DB6.DBX1.2", 1);
                    }
                    Data.write = false;
                }
                for (int i_mcc_s = 1; i_mcc_s <= 26; i_mcc_s++)
                {
                    Check_earth(DATA_PLC_OM.om[i_mcc_s], ref DATA_PLC_OM.om_temp[i_mcc_s], ref DATA_PLC_OM.om_fault[i_mcc_s]);
                }
            }


        }

        private void Read_PLC_SIPACK()
        {
            try
            {
                DATA_PLC.Read_PLCPACK = PLCPACK.ReadBytes(DataType.DataBlock, 1, 0, 38);
                //cân tức thời
                var wIC = PLCPACK.Read(DataType.DataBlock, 1, 62, VarType.Real, 3);
                // nhiệt độ tức thời
                var tIC = PLCPACK.Read(DataType.DataBlock, 1, 74, VarType.Real, 3);
                // cân chốt
                var wLV = PLCPACK.Read(DataType.DataBlock, 1, 86, VarType.Real, 3);
                // nhiệt độ chốt 
                var tLV = PLCPACK.Read(DataType.DataBlock, 1, 98, VarType.Real, 3);
                // data chốt
                var dtLV = PLCPACK.Read(DataType.DataBlock, 1, 110, VarType.Real, 3);

                DATA_PLC_SIPACK.wLineA_IC = ((double[])wIC)[0];
                DATA_PLC_SIPACK.wLineB_IC = ((double[])wIC)[1];
                DATA_PLC_SIPACK.wLineC_IC = ((double[])wIC)[2];

                DATA_PLC_SIPACK.tLineA_IC = ((double[])tIC)[0];
                DATA_PLC_SIPACK.tLineB_IC = ((double[])tIC)[1];
                DATA_PLC_SIPACK.tLineC_IC = ((double[])tIC)[2];


                DATA_PLC_SIPACK.wLineA_LV = ((double[])wLV)[0];
                DATA_PLC_SIPACK.wLineB_LV = ((double[])wLV)[1];
                DATA_PLC_SIPACK.wLineC_LV = ((double[])wLV)[2];

                DATA_PLC_SIPACK.tLineA_LV = ((double[])tLV)[0];
                DATA_PLC_SIPACK.tLineB_LV = ((double[])tLV)[1];
                DATA_PLC_SIPACK.tLineC_LV = ((double[])tLV)[2];


                DATA_PLC_SIPACK.isWLineA = ((double[])dtLV)[0];
                DATA_PLC_SIPACK.isWLineB = ((double[])dtLV)[1];
                DATA_PLC_SIPACK.isWLineC = ((double[])dtLV)[2];

                if (DATA_PLC_SIPACK.isWLineA == 0)
                {
                    DATA_PLC_SIPACK.isWWriteA = 1;
                }
                else
                {
                    DATA_PLC_SIPACK.isWWriteA = 0;
                }

                if (DATA_PLC_SIPACK.isWLineB == 0)
                {
                    DATA_PLC_SIPACK.isWWriteB = 1;
                }
                else { DATA_PLC_SIPACK.isWWriteB = 0; }

                if (DATA_PLC_SIPACK.isWLineC == 0)
                {
                    DATA_PLC_SIPACK.isWWriteC = 1;
                }
                else { DATA_PLC_SIPACK.isWWriteC = 0; }

                DATA_PLC.s7_connectpack = true;
            }
            catch (Exception)
            {
            }
        }



        private void LS_PLC()
        {
            try
            {
                if (!modbusClient.Connected)
                {
                    DATA_PLC.LS_connect = false;
                    st_PLCLS.ItemAppearance.Normal.BackColor = Color.Red;
                    modbusClient.IPAddress = "192.168.1.168";
                    modbusClient.Port = int.Parse("502");
                    modbusClient.SerialPort = null;
                    modbusClient.Disconnect();
                    modbusClient.Connect();
                }
                Thread.Sleep(50);
                int[] B = new int[5];
                byte[] C = new byte[10];
                B = modbusClient.ReadHoldingRegisters(100, 5);
                C = ChuyenDoi.ConvertIntArrayToByteArray(B);
                st_PLCLS.ItemAppearance.Normal.BackColor = Color.LimeGreen;
                DATA_PLC_LS.No1_COLLING_TOWER = ChuyenDoi.LayDataBool(C[5], 0);
                DATA_PLC_LS.No2_COLLING_TOWER = ChuyenDoi.LayDataBool(C[5], 1);
                DATA_PLC_LS.No1_WATER_PUMP = ChuyenDoi.LayDataBool(C[5], 2);
                DATA_PLC_LS.No2_WATER_PUMP = ChuyenDoi.LayDataBool(C[5], 3);
                DATA_PLC_LS.No3_WATER_PUMP = ChuyenDoi.LayDataBool(C[5], 4);
                DATA_PLC_LS.No4_WATER_PUMP = ChuyenDoi.LayDataBool(C[5], 5);
                DATA_PLC_LS.No5_WATER_PUMP = ChuyenDoi.LayDataBool(C[5], 6);
                DATA_PLC_LS.No6_WATER_PUMP = ChuyenDoi.LayDataBool(C[5], 7);

                DATA_PLC_LS.VACCUM_PUMP_A = ChuyenDoi.LayDataBool(C[4], 0);
                DATA_PLC_LS.VACCUM_PUMP_B = ChuyenDoi.LayDataBool(C[4], 1);
                DATA_PLC_LS.VACCUM_PUMP_C = ChuyenDoi.LayDataBool(C[4], 2);
                DATA_PLC_LS.VACCUM_PUMP_D = ChuyenDoi.LayDataBool(C[4], 3);
                DATA_PLC_LS.No1_AIR_COMP = ChuyenDoi.LayDataBool(C[4], 6);
                DATA_PLC_LS.No2_AIR_COMP = ChuyenDoi.LayDataBool(C[4], 5);

                Thread.Sleep(20);
                int[] D = new int[3];
                D = modbusClient.ReadHoldingRegisters(2, 3);
                DATA_PLC_LS.Pump_A = Math.Round(Convert.ToDouble(D[0]) / 10, 1);
                DATA_PLC_LS.Pump_B = Math.Round(Convert.ToDouble(D[1]) / 10, 1);
                DATA_PLC_LS.Pump_C = Math.Round(Convert.ToDouble(D[2]) / 10, 1);
                DATA_PLC.LS_connect = true;

                if (DATA_PLC.Read_PLC.Length >= 20 && DATA_PLC.s7_connect && DATA_PLC_SI.Man_pump_cmd)
                {
                    PumpFault_stop_true(DATA_PLC_LS.No1_WATER_PUMP, ref DATA_PLC_LS.No1_WATER_PUMP_temp, ref DATA_PLC_LS.No1_WATER_PUMP_fault);
                    PumpFault_stop_true(DATA_PLC_LS.No2_WATER_PUMP, ref DATA_PLC_LS.No2_WATER_PUMP_temp, ref DATA_PLC_LS.No2_WATER_PUMP_fault);
                    PumpFault_stop_true(DATA_PLC_LS.No3_WATER_PUMP, ref DATA_PLC_LS.No3_WATER_PUMP_temp, ref DATA_PLC_LS.No3_WATER_PUMP_fault);
                    PumpFault_stop_true(DATA_PLC_LS.No4_WATER_PUMP, ref DATA_PLC_LS.No4_WATER_PUMP_temp, ref DATA_PLC_LS.No4_WATER_PUMP_fault);
                    PumpFault_stop_true(DATA_PLC_LS.No5_WATER_PUMP, ref DATA_PLC_LS.No5_WATER_PUMP_temp, ref DATA_PLC_LS.No5_WATER_PUMP_fault);
                    PumpFault_stop_true(DATA_PLC_LS.No6_WATER_PUMP, ref DATA_PLC_LS.No6_WATER_PUMP_temp, ref DATA_PLC_LS.No6_WATER_PUMP_fault);

                    PumpFault_stop_false(DATA_PLC_LS.No1_COLLING_TOWER, ref DATA_PLC_LS.No1_COLLING_TOWER_temp, ref DATA_PLC_LS.No1_COLLING_TOWER_fault);
                    PumpFault_stop_false(DATA_PLC_LS.No2_COLLING_TOWER, ref DATA_PLC_LS.No2_COLLING_TOWER_temp, ref DATA_PLC_LS.No2_COLLING_TOWER_fault);

                    PumpFault_stop_true(DATA_PLC_LS.VACCUM_PUMP_A, ref DATA_PLC_LS.VACCUM_PUMP_A_temp, ref DATA_PLC_LS.VACCUM_PUMP_A_fault);
                    PumpFault_stop_true(DATA_PLC_LS.VACCUM_PUMP_B, ref DATA_PLC_LS.VACCUM_PUMP_B_temp, ref DATA_PLC_LS.VACCUM_PUMP_B_fault);
                    PumpFault_stop_true(DATA_PLC_LS.VACCUM_PUMP_C, ref DATA_PLC_LS.VACCUM_PUMP_C_temp, ref DATA_PLC_LS.VACCUM_PUMP_C_fault);
                    PumpFault_stop_true(DATA_PLC_LS.VACCUM_PUMP_D, ref DATA_PLC_LS.VACCUM_PUMP_D_temp, ref DATA_PLC_LS.VACCUM_PUMP_D_fault);
                    PumpFault_stop_false(DATA_PLC_LS.No1_AIR_COMP, ref DATA_PLC_LS.No1_AIR_COMP_temp, ref DATA_PLC_LS.No1_AIR_COMP_fault);
                    PumpFault_stop_false(DATA_PLC_LS.No2_AIR_COMP, ref DATA_PLC_LS.No2_AIR_COMP_temp, ref DATA_PLC_LS.No2_AIR_COMP_fault);

                    PumpFault_stop_false(DATA_PLC_SI.On_air_chiller_pos_1, ref DATA_PLC_SI.On_air_chiller_pos_1_temp, ref DATA_PLC_SI.On_air_chiller_pos_1_fault);
                    PumpFault_stop_false(DATA_PLC_SI.On_air_chiller_pos_2, ref DATA_PLC_SI.On_air_chiller_pos_2_temp, ref DATA_PLC_SI.On_air_chiller_pos_2_fault);
                }
                Ghi_loi(DATA_PLC_LS.Pump_A, DATA_PLC_SI.Pump_A_alarm, ref DATA_PLC_SI.Pump_A_temp, ref DATA_PLC_SI.Pump_A_fault, ref start_fault[6], ref start_fault_bool[6]);
                Ghi_loi(DATA_PLC_LS.Pump_B, DATA_PLC_SI.Pump_B_alarm, ref DATA_PLC_SI.Pump_B_temp, ref DATA_PLC_SI.Pump_B_fault, ref start_fault[7], ref start_fault_bool[7]);
                Ghi_loi(DATA_PLC_LS.Pump_C, DATA_PLC_SI.Pump_C_alarm, ref DATA_PLC_SI.Pump_C_temp, ref DATA_PLC_SI.Pump_C_fault, ref start_fault[8], ref start_fault_bool[8]);

            }
            catch (Exception ex)
            {
                DATA_PLC.LS_connect = false;
                st_PLCLS.ItemAppearance.Normal.BackColor = Color.Red;
                modbusClient.Disconnect();
                modbusClient.Connect();
            }
            finally
            {

            }
        }
        public static void PumpFault_stop_true(bool status, ref bool status_temp, ref bool status_fault)
        {
            if (status == true && status_temp == false)
            {
                status_fault = true;
                triger();
            }
            status_temp = status;
        }
        public static void PumpFault_stop_false(bool status, ref bool status_temp, ref bool status_fault)
        {
            if (status == false && status_temp == true)
            {
                status_fault = true;
                triger();
            }
            status_temp = status;
        }

        private void RW_PLC()
        {
            try
            {
                var TE_1953A = new Tag<IntPlcMapper, short>()
                {
                    Name = "TE_LOG[4]",
                    Gateway = gateway,
                    Path = path,
                    PlcType = PlcType.ControlLogix,
                    Protocol = Protocol.ab_eip
                };
                TE_1953A.Read();
                DATA_PLC_RW.TE_1953A = Convert.ToInt16(TE_1953A.Value);
                var AVE_TEMP = new Tag<IntPlcMapper, short>()
                {
                    Name = "TE_LOG[7]",
                    Gateway = gateway,
                    Path = path,
                    PlcType = PlcType.ControlLogix,
                    Protocol = Protocol.ab_eip
                };
                AVE_TEMP.Read();
                DATA_PLC_RW.AVE_TEMP = Convert.ToInt16(AVE_TEMP.Value);
                var TE_1953B = new Tag<IntPlcMapper, short>()
                {
                    Name = "TE_LOG[5]",
                    Gateway = gateway,
                    Path = path,
                    PlcType = PlcType.ControlLogix,
                    Protocol = Protocol.ab_eip
                };
                TE_1953B.Read();
                DATA_PLC_RW.TE_1953B = Convert.ToInt16(TE_1953B.Value);

                var TE_1952A = new Tag<IntPlcMapper, short>()
                {
                    Name = "TE_LOG[1]",
                    Gateway = gateway,
                    Path = path,
                    PlcType = PlcType.ControlLogix,
                    Protocol = Protocol.ab_eip
                };
                TE_1952A.Read();
                DATA_PLC_RW.TE_1952A = Convert.ToInt16(TE_1952A.Value);
                var TE_1952B = new Tag<IntPlcMapper, short>()
                {
                    Name = "TE_LOG[2]",
                    Gateway = gateway,
                    Path = path,
                    PlcType = PlcType.ControlLogix,
                    Protocol = Protocol.ab_eip
                };
                TE_1952B.Read();
                DATA_PLC_RW.TE_1952B = Convert.ToInt16(TE_1952B.Value);
                var TE_1952C = new Tag<IntPlcMapper, short>()
                {
                    Name = "TE_LOG[3]",
                    Gateway = gateway,
                    Path = path,
                    PlcType = PlcType.ControlLogix,
                    Protocol = Protocol.ab_eip
                };
                TE_1952C.Read();
                DATA_PLC_RW.TE_1952C = Convert.ToInt16(TE_1952C.Value);

                var TE_1951 = new Tag<IntPlcMapper, short>()
                {
                    Name = "TE_LOG[0]",
                    Gateway = gateway,
                    Path = path,
                    PlcType = PlcType.ControlLogix,
                    Protocol = Protocol.ab_eip
                };
                TE_1951.Read();
                DATA_PLC_RW.TE_1951 = Convert.ToInt16(TE_1951.Value);
                var TE_1954 = new Tag<IntPlcMapper, short>()
                {
                    Name = "TE_LOG[6]",
                    Gateway = gateway,
                    Path = path,
                    PlcType = PlcType.ControlLogix,
                    Protocol = Protocol.ab_eip
                };
                TE_1954.Read();
                DATA_PLC_RW.TE_1954 = Convert.ToInt16(TE_1954.Value);

                var XV1952 = new Tag<BoolPlcMapper, bool>()
                {
                    Name = "ZSO_1952",
                    Gateway = gateway,
                    Path = path,
                    PlcType = PlcType.ControlLogix,
                    Protocol = Protocol.ab_eip
                };
                XV1952.Read();
                DATA_PLC_RW.XV1952 = Convert.ToBoolean(XV1952.Value);
                var XV1951 = new Tag<BoolPlcMapper, bool>()
                {
                    Name = "ZSO_1951",
                    Gateway = gateway,
                    Path = path,
                    PlcType = PlcType.ControlLogix,
                    Protocol = Protocol.ab_eip
                };
                XV1951.Read();
                DATA_PLC_RW.XV1951 = Convert.ToBoolean(XV1951.Value);
                var XV1956 = new Tag<BoolPlcMapper, Boolean>()
                {
                    Name = "ZSO_1956",
                    Gateway = gateway,
                    Path = path,
                    PlcType = PlcType.ControlLogix,
                    Protocol = Protocol.ab_eip
                };

                XV1956.Read();
                DATA_PLC_RW.XV1956 = Convert.ToBoolean(XV1956.Value);

                var xxx = new Tag<IntPlcMapper, short>()
                {
                    Name = "Local:5:I.Data",
                    Gateway = gateway,
                    Path = path,
                    PlcType = PlcType.ControlLogix,
                    Protocol = Protocol.ab_eip
                };
                xxx.Read();
                byte[] intBytes = BitConverter.GetBytes(Convert.ToInt16(xxx.Value));
                DATA_PLC_RW.XXXXXX = ChuyenDoi.LayDataBool(intBytes[1], 4);

                DATA_PLC.RW_connect = true;
                st_PLCAB.ItemAppearance.Normal.BackColor = Color.LimeGreen;

                Ghi_loi(DATA_PLC_RW.TE_1953A, DATA_PLC_SI.TE_1953A_alarm, ref DATA_PLC_SI.TE_1953A_temp, ref DATA_PLC_SI.TE_1953A_fault, ref start_fault[9], ref start_fault_bool[9]);

                Ghi_loi(DATA_PLC_RW.AVE_TEMP, DATA_PLC_SI.AVE_TEMP_alarm, ref DATA_PLC_SI.AVE_TEMP_temp, ref DATA_PLC_SI.AVE_TEMP_fault, ref start_fault[11], ref start_fault_bool[11]);

                Ghi_loi(DATA_PLC_RW.TE_1953B, DATA_PLC_SI.TE_1953B_alarm, ref DATA_PLC_SI.TE_1953B_fault, ref DATA_PLC_SI.TE_1953B_fault, ref start_fault[12], ref start_fault_bool[12]);

                Ghi_loi(DATA_PLC_RW.TE_1954, DATA_PLC_SI.TE_1954_alarm, ref DATA_PLC_SI.TE_1954_temp, ref DATA_PLC_SI.TE_1954_fault, ref start_fault[13], ref start_fault_bool[13]);

                Ghi_loi(DATA_PLC_RW.TE_1952A, DATA_PLC_SI.TE_1952A_alarm, ref DATA_PLC_SI.TE_1952A_temp, ref DATA_PLC_SI.TE_1952A_fault, ref start_fault[14], ref start_fault_bool[14]);

                Ghi_loi(DATA_PLC_RW.TE_1952B, DATA_PLC_SI.TE_1952B_alarm, ref DATA_PLC_SI.TE_1952B_temp, ref DATA_PLC_SI.TE_1952B_fault, ref start_fault[15], ref start_fault_bool[15]);

                Ghi_loi(DATA_PLC_RW.TE_1952C, DATA_PLC_SI.TE_1952C_alarm, ref DATA_PLC_SI.TE_1952C_temp, ref DATA_PLC_SI.TE_1952C_fault, ref start_fault[16], ref start_fault_bool[16]);

                Ghi_loi(DATA_PLC_RW.TE_1951, DATA_PLC_SI.TE_1951_alarm, ref DATA_PLC_SI.TE_1951_temp, ref DATA_PLC_SI.TE_1951_fault, ref start_fault[17], ref start_fault_bool[17]);

                if (DATA_PLC_RW.XV1951 == false && DATA_PLC_RW.XV1956 == false)
                {
                    if (DATA_PLC_SI.TE_1951_1956_temp == false)
                    {
                        triger();
                        DATA_PLC_SI.TE_1951_1956_temp = true;
                    }
                    DATA_PLC_SI.TE_1951_1956_fault = true;

                }
                else
                {
                    DATA_PLC_SI.TE_1951_1956_temp = false;
                }

                if (DATA_PLC_RW.XXXXXX == true)
                {
                    if (DATA_PLC_SI.TE_FC_temp == false)
                    {
                        triger();
                        DATA_PLC_SI.TE_FC_temp = true;
                    }
                    DATA_PLC_SI.TE_FC_fault = true;

                }
                else
                {
                    DATA_PLC_SI.TE_FC_temp = false;
                }
            }
            catch
            {
                DATA_PLC.RW_connect = false;
                st_PLCAB.ItemAppearance.Normal.BackColor = Color.Red;
            }
        }

        public static DateTime[] start_fault = new DateTime[100];
        public static bool[] start_fault_bool = new bool[100];

        public static void Ghi_loi(double a, double b, ref bool c, ref bool d, ref DateTime start_fault, ref bool start_fault_bool)
        {
            if (a > b)
            {

                if (c == false)
                {
                    start_fault = DateTime.Now;
                    c = true;

                }

                if (c == true && (DateTime.Now - start_fault).TotalSeconds > 10)
                {
                    if (start_fault_bool == false)
                    {
                        triger();
                        start_fault_bool = true;
                    }

                    d = true;
                }
            }
            else
            {
                c = false;
                start_fault_bool = false;
                start_fault = DateTime.Now;
            }
        }
        public static void Ghi_loi_am(double a, double b, ref bool c, ref bool d, ref DateTime start_fault, ref bool start_fault_bool)
        {
            if (a < b)
            {
                if (c == false)
                {
                    start_fault = DateTime.Now;
                    c = true;

                }

                if (c == true && (DateTime.Now - start_fault).TotalSeconds > 10)
                {
                    if (start_fault_bool == false)
                    {
                        triger();
                        start_fault_bool = true;
                    }

                    d = true;
                }
            }
            else
            {
                c = false;
                start_fault_bool = false;
                start_fault = DateTime.Now;
            }
        }
        private void barStaticItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void bt_Setting_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Caidat f1 = new Caidat();
            OpenTab("SETTING", "SETTING", f1, true, Properties.Resources.BaoCao_24);
        }

        private void btGioithieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            About f1 = new About();
            OpenTab("ABOUT", "ABOUT", f1, true, Properties.Resources.BaoCao_24);
        }

        private void bt_Calibration_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Calibration f1 = new Calibration();
            OpenTab("CALIBRATION", "CALIBRATION", f1, true, Properties.Resources.BaoCao_24);
        }

        private void bt_Reset_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void timer_excel_real_Tick(object sender, EventArgs e)
        {
            Thread csv_data = new Thread(Write_CSV);
            csv_data.Start();
        }

        private string newFileName;
        private string newFilePatch;
        private string newFileName1;
        private string newFilePatch1;
        private StringBuilder csv = new StringBuilder();
        private StringBuilder csv1 = new StringBuilder();
        private DateTime Date_time_csv;

        private void Write_CSV()
        {
            try
            {
                Date_time_csv = DateTime.Now;
                WATER_PUMP_CSV();
                VACCUM_PUMP_CSV();
                AIR_PRESSURE_CSV();
                FUME_DUST_CSV();
                RTO_CSV();
                MCC_CSV();
                PACKA_CSV();
                PACKB_CSV();
                PACKC_CSV();
            }
            catch
            {
                KN.Showalert("Kiểm tra đường dẫn file");
            }

        }
        private string Display_START_STOP(bool a)
        {
            if (a)
            {
                return "START";
            }
            else
            {
                return "STOP";
            }
        }
        private string Display_OPEN_CLOSE(bool a)
        {
            if (a)
            {
                return "OPEN";
            }
            else
            {
                return "CLOSE";
            }
        }
        private string Display_MCC(bool a)
        {
            if (a)
            {
                return "FAULT";
            }
            else
            {
                return "OK";
            }
        }
        //VACCUMP PUMP
        #region
        private void WATER_PUMP_CSV()
        {
            csv.Clear();
            newFileName = Application.StartupPath + @"\Log\Water_pump_log_" + DateTime.Now.ToString("yyyyMMdd") + ".csv";
            newFilePatch = Application.StartupPath + @"\Log\";
            if (DATA_PLC.LS_connect == true && DATA_PLC.s7_connect == true)
            {
                try
                {
                    csv.Clear();
                    string newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}",
                    Date_time_csv.ToString(),
                    Display_START_STOP(!DATA_PLC_LS.No1_WATER_PUMP),
                    Display_START_STOP(!DATA_PLC_LS.No2_WATER_PUMP),
                    Display_START_STOP(!DATA_PLC_LS.No3_WATER_PUMP),
                    Display_START_STOP(!DATA_PLC_LS.No4_WATER_PUMP),
                    Display_START_STOP(!DATA_PLC_LS.No5_WATER_PUMP),
                    Display_START_STOP(!DATA_PLC_LS.No6_WATER_PUMP),
                    Display_START_STOP(DATA_PLC_LS.No1_COLLING_TOWER),
                    Display_START_STOP(DATA_PLC_LS.No2_COLLING_TOWER),
                    DATA_Calibration.v5_out,
                   DATA_PLC_SI.WATER_BATH_TEMP_alarm);

                    csv.AppendLine(newLine);
                    if (!System.IO.File.Exists(newFileName))
                    {
                        System.IO.Directory.CreateDirectory(newFilePatch);
                        using (FileStream fs = File.Create(newFileName))
                        {

                        }
                        File.AppendAllText(newFileName, csv.ToString());
                    }
                    else
                    {
                        File.AppendAllText(newFileName, csv.ToString());
                    };
                }
                catch (Exception ex)
                {
                    KN.Logerror(ex.ToString());
                }
            }
        }
        #endregion
        //Vaccum pump
        #region
        private void VACCUM_PUMP_CSV()
        {
            csv.Clear();
            newFileName = Application.StartupPath + @"\Log\Vaccum_pump_log_" + DateTime.Now.ToString("yyyyMMdd") + ".csv";
            newFilePatch = Application.StartupPath + @"\Log\";
            if (DATA_PLC.LS_connect == true && DATA_PLC.s7_connect == true)
            {
                try
                {
                    csv.Clear();
                    string newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}",
                    Date_time_csv.ToString(),
                     Display_START_STOP(!DATA_PLC_LS.VACCUM_PUMP_A),
                      DATA_PLC_LS.Pump_A,
                    DATA_PLC_SI.Pump_A_alarm,
                     Display_START_STOP(!DATA_PLC_LS.VACCUM_PUMP_B),
                      DATA_PLC_LS.Pump_B,
                    DATA_PLC_SI.Pump_B_alarm,
                     Display_START_STOP(!DATA_PLC_LS.VACCUM_PUMP_C),
                      DATA_PLC_LS.Pump_C,
                    DATA_PLC_SI.Pump_C_alarm,
                     Display_START_STOP(!DATA_PLC_LS.VACCUM_PUMP_D),
                    DATA_Calibration.v4_out,
                    DATA_PLC_SI.VACCUM_PRESSURE_alarm);

                    csv.AppendLine(newLine);
                    if (!System.IO.File.Exists(newFileName))
                    {
                        System.IO.Directory.CreateDirectory(newFilePatch);
                        using (FileStream fs = File.Create(newFileName))
                        {

                        }
                        File.AppendAllText(newFileName, csv.ToString());
                    }
                    else
                    {
                        File.AppendAllText(newFileName, csv.ToString());
                    };
                }
                catch (Exception ex)
                {
                    KN.Logerror(ex.ToString());
                }
            }
        }
        #endregion
        //Air pressure
        #region
        private void AIR_PRESSURE_CSV()
        {
            csv.Clear();
            newFileName = Application.StartupPath + @"\Log\Air_pressure_log_" + DateTime.Now.ToString("yyyyMMdd") + ".csv";
            newFilePatch = Application.StartupPath + @"\Log\";
            if (DATA_PLC.LS_connect == true && DATA_PLC.s7_connect == true)
            {
                try
                {
                    csv.Clear();
                    string newLine = string.Format("{0},{1},{2},{3},{4},{5},{6}",
                    Date_time_csv.ToString(),
                     Display_START_STOP(!DATA_PLC_LS.No1_AIR_COMP),
                     Display_START_STOP(!DATA_PLC_LS.No2_AIR_COMP),
                    Display_START_STOP(DATA_PLC_SI.On_air_chiller_pos_1),
                    Display_START_STOP(DATA_PLC_SI.On_air_chiller_pos_2),
                    DATA_Calibration.v1_out,
                    DATA_PLC_SI.AIR_PRESSURE_Mpa_alarm);

                    csv.AppendLine(newLine);
                    if (!System.IO.File.Exists(newFileName))
                    {
                        System.IO.Directory.CreateDirectory(newFilePatch);
                        using (FileStream fs = File.Create(newFileName))
                        {

                        }
                        File.AppendAllText(newFileName, csv.ToString());
                    }
                    else
                    {
                        File.AppendAllText(newFileName, csv.ToString());
                    };
                }
                catch (Exception ex)
                {
                    KN.Logerror(ex.ToString());
                }
            }
        }
        #endregion
        //Fume dust
        #region
        private void FUME_DUST_CSV()
        {
            csv.Clear();
            newFileName = Application.StartupPath + @"\Log\Fume_dust_log_" + DateTime.Now.ToString("yyyyMMdd") + ".csv";
            newFilePatch = Application.StartupPath + @"\Log\";
            if (DATA_PLC.LS_connect == true && DATA_PLC.s7_connect == true)
            {
                try
                {
                    csv.Clear();
                    string newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}",
                    Date_time_csv.ToString(),
                     Display_START_STOP(DATA_PLC_SI.On_fume_collector_A_Pos),
                     Display_START_STOP(DATA_PLC_SI.On_fume_collector_B_Pos),
                     Display_START_STOP(DATA_PLC_SI.On_dust_collector_A_Pos),
                     Display_START_STOP(DATA_PLC_SI.On_dust_collector_B_Pos),
                     Display_START_STOP(DATA_PLC_SI.On_dust_collector_C_Pos),
                    DATA_Calibration.v2_out,
                    DATA_PLC_SI.FUME_PRESSURE_alarm,
                    DATA_Calibration.v3_out,
                    DATA_PLC_SI.DUST_PRESSURE_alarm);

                    csv.AppendLine(newLine);
                    if (!System.IO.File.Exists(newFileName))
                    {
                        System.IO.Directory.CreateDirectory(newFilePatch);
                        using (FileStream fs = File.Create(newFileName))
                        {

                        }
                        File.AppendAllText(newFileName, csv.ToString());
                    }
                    else
                    {
                        File.AppendAllText(newFileName, csv.ToString());
                    };
                }
                catch (Exception ex)
                {
                    KN.Logerror(ex.ToString());
                }
            }
        }
        #endregion
        //RTO
        #region
        private void RTO_CSV()
        {
            csv.Clear();
            newFileName = Application.StartupPath + @"\Log\Rto_log_" + DateTime.Now.ToString("yyyyMMdd") + ".csv";
            newFilePatch = Application.StartupPath + @"\Log\";
            if (DATA_PLC.RW_connect == true)
            {
                try
                {
                    csv.Clear();
                    string newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20}",
                    Date_time_csv.ToString(),
                    DATA_PLC_RW.TE_1953A,
                    DATA_PLC_SI.TE_1953A_alarm,
                   DATA_PLC_RW.AVE_TEMP,
                    DATA_PLC_SI.AVE_TEMP_alarm,
                    DATA_PLC_RW.TE_1953B,
                   DATA_PLC_SI.TE_1953B_alarm,
                   DATA_PLC_RW.TE_1952A,
                   DATA_PLC_SI.TE_1952A_alarm,
                  DATA_PLC_RW.TE_1952B,
                   DATA_PLC_SI.TE_1952B_alarm,
                  DATA_PLC_RW.TE_1952C,
                  DATA_PLC_SI.TE_1952C_alarm,
                  DATA_PLC_RW.TE_1954,
                   DATA_PLC_SI.TE_1954_alarm,
                  DATA_PLC_RW.TE_1951,
                  DATA_PLC_SI.TE_1951_alarm,
                     Display_OPEN_CLOSE(DATA_PLC_RW.XV1952),
                    Display_OPEN_CLOSE(DATA_PLC_RW.XV1951),
                    Display_OPEN_CLOSE(DATA_PLC_RW.XV1956),
                     Display_OPEN_CLOSE(DATA_PLC_RW.XXXXXX));

                    csv.AppendLine(newLine);
                    if (!System.IO.File.Exists(newFileName))
                    {
                        System.IO.Directory.CreateDirectory(newFilePatch);
                        using (FileStream fs = File.Create(newFileName))
                        {

                        }
                        File.AppendAllText(newFileName, csv.ToString());
                    }
                    else
                    {
                        File.AppendAllText(newFileName, csv.ToString());
                    };
                }
                catch (Exception ex)
                {
                    KN.Logerror(ex.ToString());
                }
            }
        }
        #endregion
        //MCC
        #region
        private void MCC_CSV()
        {
            csv.Clear();
            newFileName = Application.StartupPath + @"\Log\MCC_log_" + DateTime.Now.ToString("yyyyMMdd") + ".csv";
            newFilePatch = Application.StartupPath + @"\Log\";
            if (DATA_PLC.OM_connect == true && DATA_PLC.s7_connect)
            {
                try
                {
                    csv.Clear();
                    string newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},2{6},{27},{28},{29},{30},{31},{32},{33},{34}",
                    Date_time_csv.ToString(),
                    Display_MCC(DATA_PLC_OM.om[1]),
                   Display_MCC(DATA_PLC_OM.om[2]),
                   Display_MCC(DATA_PLC_OM.om[3]),
                  Display_MCC(DATA_PLC_OM.om[4]),
                    Display_MCC(DATA_PLC_OM.om[5]),
                   Display_MCC(DATA_PLC_OM.om[6]),
                  Display_MCC(DATA_PLC_OM.om[7]),
                  Display_MCC(DATA_PLC_OM.om[8]),
                  Display_MCC(DATA_PLC_OM.om[9]),
                 Display_MCC(DATA_PLC_OM.om[10]),
                   Display_MCC(DATA_PLC_OM.om[11]),
                  Display_MCC(DATA_PLC_OM.om[12]),
                  Display_MCC(DATA_PLC_OM.om[13]),
                  Display_MCC(DATA_PLC_OM.om[14]),
                  Display_MCC(DATA_PLC_OM.om[15]),
                  Display_MCC(DATA_PLC_OM.om[16]),
                   Display_MCC(DATA_PLC_OM.om[17]),
                  Display_MCC(DATA_PLC_OM.om[18]),
                Display_MCC(DATA_PLC_OM.om[19]),
                 Display_MCC(DATA_PLC_OM.om[20]),
                 Display_MCC(DATA_PLC_OM.om[21]),
                  Display_MCC(DATA_PLC_OM.om[22]),
                   Display_MCC(DATA_PLC_OM.om[23]),
                  Display_MCC(DATA_PLC_OM.om[24]),
                  Display_MCC(DATA_PLC_OM.om[25]),
                   Display_MCC(DATA_PLC_OM.om[26]),
                 DATA_PLC_SI.ND1,
                 DATA_PLC_SI.ND1_alarm,
                 DATA_PLC_SI.DO1,
                 DATA_PLC_SI.DO1_alarm,
                DATA_PLC_SI.ND2,
                DATA_PLC_SI.ND2_alarm,
              DATA_PLC_SI.DO2,
               DATA_PLC_SI.DO2_alarm);

                    csv.AppendLine(newLine);
                    if (!System.IO.File.Exists(newFileName))
                    {
                        System.IO.Directory.CreateDirectory(newFilePatch);
                        using (FileStream fs = File.Create(newFileName))
                        {

                        }
                        File.AppendAllText(newFileName, csv.ToString());
                    }
                    else
                    {
                        File.AppendAllText(newFileName, csv.ToString());
                    };
                }
                catch (Exception ex)
                {
                    KN.Logerror(ex.ToString());
                }
            }
        }
        #endregion
        //PACK
        #region
        private void PACKA_CSV()
        {
           
            csv.Clear();
            newFileName = Application.StartupPath + @"\Log\PACKA_log_" + DateTime.Now.ToString("yyyyMMdd") + ".csv";
            newFilePatch = Application.StartupPath + @"\Log\";
            if (DATA_PLC.s7_connectpack && DATA_PLC_SIPACK.isWLineA == 1 && DATA_PLC_SIPACK.isWWriteA == 0)
            {
                DATA_PLC_SIPACK.isWWriteA = 1;
                try
                {
                    csv.Clear();
                    string newLine = string.Format("{0},{1},{2},{3},{4}",
                  "", Date_time_csv.ToString("dd/MM/yyyy"), Date_time_csv.ToString("HH:mm:ss"),
                    DATA_PLC_SIPACK.wLineA_LV.ToString("0.00"),
                    DATA_PLC_SIPACK.tLineA_LV.ToString("0.0"));

                    csv.AppendLine(newLine);
                    if (!System.IO.File.Exists(newFileName))
                    {
                        System.IO.Directory.CreateDirectory(newFilePatch);
                        using (FileStream fs = File.Create(newFileName))
                        {

                        }
                        File.AppendAllText(newFileName, csv.ToString());
                    }
                    else
                    {
                        File.AppendAllText(newFileName, csv.ToString());
                    };
                }
                catch (Exception ex)
                {
                    KN.Logerror(ex.ToString());
                }
            }
        }
        private void PACKB_CSV()
        {
            csv.Clear();
            newFileName = Application.StartupPath + @"\Log\PACKB_log_" + DateTime.Now.ToString("yyyyMMdd") + ".csv";
            newFilePatch = Application.StartupPath + @"\Log\";
            if (DATA_PLC.s7_connectpack && DATA_PLC_SIPACK.isWLineB == 1 && DATA_PLC_SIPACK.isWWriteB == 0)
            {
                try
                {
                    DATA_PLC_SIPACK.isWWriteB = 1;
                    csv.Clear();
                    string newLine = string.Format("{0},{1},{2},{3},{4}",
               "", Date_time_csv.ToString("dd/MM/yyyy"), Date_time_csv.ToString("HH:mm:ss"),
                  DATA_PLC_SIPACK.wLineB_LV.ToString("0.00"),
                    DATA_PLC_SIPACK.tLineB_LV.ToString("0.0"));

                    csv.AppendLine(newLine);
                    if (!System.IO.File.Exists(newFileName))
                    {
                        System.IO.Directory.CreateDirectory(newFilePatch);
                        using (FileStream fs = File.Create(newFileName))
                        {

                        }
                        File.AppendAllText(newFileName, csv.ToString());
                    }
                    else
                    {
                        File.AppendAllText(newFileName, csv.ToString());
                    };
                }
                catch (Exception ex)
                {
                    KN.Logerror(ex.ToString());
                }
            }
        }
        private void PACKC_CSV()
        {
            csv.Clear();
            newFileName = Application.StartupPath + @"\Log\PACKC_log_" + DateTime.Now.ToString("yyyyMMdd") + ".csv";
            newFilePatch = Application.StartupPath + @"\Log\";
            if (DATA_PLC.s7_connectpack && DATA_PLC_SIPACK.isWLineC == 1 && DATA_PLC_SIPACK.isWWriteC == 0)
            {
                try
                {
                    DATA_PLC_SIPACK.isWWriteC = 1;
                    csv.Clear();
                    string newLine = string.Format("{0},{1},{2},{3},{4}",
                "", Date_time_csv.ToString("dd/MM/yyyy"), Date_time_csv.ToString("HH:mm:ss"),
                  DATA_PLC_SIPACK.wLineC_LV.ToString("0.00"),
                    DATA_PLC_SIPACK.tLineC_LV.ToString("0.0"));

                    csv.AppendLine(newLine);
                    if (!System.IO.File.Exists(newFileName))
                    {
                        System.IO.Directory.CreateDirectory(newFilePatch);
                        using (FileStream fs = File.Create(newFileName))
                        {

                        }
                        File.AppendAllText(newFileName, csv.ToString());
                    }
                    else
                    {
                        File.AppendAllText(newFileName, csv.ToString());
                    };
                }
                catch (Exception ex)
                {
                    KN.Logerror(ex.ToString());
                }
            }
        }
        #endregion
        private void bt_mute_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void BT_RESET_AL_Click(object sender, EventArgs e)
        {
            DATA_PLC_LS.No1_COLLING_TOWER_fault = false;
            DATA_PLC_LS.No2_COLLING_TOWER_fault = false;
            DATA_PLC_LS.No1_WATER_PUMP_fault = false;
            DATA_PLC_LS.No2_WATER_PUMP_fault = false;
            DATA_PLC_LS.No3_WATER_PUMP_fault = false;
            DATA_PLC_LS.No4_WATER_PUMP_fault = false;
            DATA_PLC_LS.No5_WATER_PUMP_fault = false;
            DATA_PLC_LS.No6_WATER_PUMP_fault = false;
            DATA_PLC_SI.WATER_BATH_TEMP_fault = false;

            DATA_PLC_LS.VACCUM_PUMP_A_fault = false;
            DATA_PLC_LS.VACCUM_PUMP_B_fault = false;
            DATA_PLC_LS.VACCUM_PUMP_C_fault = false;
            DATA_PLC_LS.VACCUM_PUMP_D_fault = false;
            DATA_PLC_SI.VACCUM_PRESSURE_fault = false;

            DATA_PLC_LS.No1_AIR_COMP_fault = false;
            DATA_PLC_LS.No2_AIR_COMP_fault = false;
            DATA_PLC_SI.On_air_chiller_pos_1_fault = false;
            DATA_PLC_SI.On_air_chiller_pos_2_fault = false;
            DATA_PLC_SI.AIR_PRESSURE_Mpa_fault = false;

            DATA_PLC_SI.FUME_PRESSURE_fault = false;
            DATA_PLC_SI.DUST_PRESSURE_fault = false;

            DATA_PLC_SI.TE_1953A_fault = false;
            DATA_PLC_SI.AVE_TEMP_fault = false;
            DATA_PLC_SI.TE_1953B_fault = false;
            DATA_PLC_SI.TE_1954_fault = false;
            DATA_PLC_SI.TE_1952A_fault = false;
            DATA_PLC_SI.TE_1952B_fault = false;
            DATA_PLC_SI.TE_1952C_fault = false;
            DATA_PLC_SI.TE_1951_fault = false;
            DATA_PLC_SI.TE_1951_1956_fault = false;
            DATA_PLC_SI.TE_FC_fault = false;


            DATA_PLC_SI.ND1_fault = false;
            DATA_PLC_SI.DO1_fault = false;
            DATA_PLC_SI.ND2_fault = false;
            DATA_PLC_SI.DO2_fault = false;

            DATA_PLC_SI.Pump_A_fault = false;
            DATA_PLC_SI.Pump_B_fault = false;
            DATA_PLC_SI.Pump_C_fault = false;

            for (int i_imcc = 1; i_imcc <= 26; i_imcc++)
            {
                DATA_PLC_OM.om_fault[i_imcc] = false;
            }

            if (Fault_mcc_earth > 0)
            {
                Data.write = true;
                Data.OM_reset = true;
                Data.OM_tatcoi = true;
            }

            for (int i_err_r = 1; i_err_r <= 90; i_err_r++)
            {
                Data.Error_temp[i_err_r] = false;
            }



            Data.Tat_coi = false;
            KN.ShowalertThanhCong("Reset lỗi thành công");

            try
            {
                newFileName1 = Application.StartupPath + @"\Error_Log\Log_" + DateTime.Now.ToString("yyyyMMdd") + ".csv";
                newFilePatch1 = Application.StartupPath + @"\Error_Log\";

                Update_ketthuc(newFileName1);
            }
            catch (Exception ex)
            {
                KN.Showalert(ex.Message);
            }

            newFileName1 = Application.StartupPath + @"\Error_Log\Log_" + DateTime.Now.AddDays(-1).ToString("yyyyMMdd") + ".csv";
            newFilePatch1 = Application.StartupPath + @"\Error_Log\";
            Update_ketthuc(newFileName1);
        }

        private void BT_TATCOI_Click(object sender, EventArgs e)
        {
            Data.Tat_coi = true;
            Data.write = true;
            Data.OM_tatcoi = true;
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btPack_Click(object sender, EventArgs e)
        {
            Tab_open_now = 8;
            Open_tab();
        }

        private void st_THD_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
