using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baodongchem
{
    public class Communication
    {
        //khai báo config file path
        public static string Common = Application.StartupPath + @"\Communication\Common.ini";
        //GMES



        public static void ReadCommon()
        {
            try
            {
                DATA_PLC_LS.No1_WATER_PUMP_fault = Convert.ToBoolean(INI.ReadIni(Common, "Water_pump", "No1_WATER_PUMP_fault ", "false"));
                DATA_PLC_LS.No2_WATER_PUMP_fault = Convert.ToBoolean(INI.ReadIni(Common, "Water_pump", "No2_WATER_PUMP_fault ", "false"));
                DATA_PLC_LS.No3_WATER_PUMP_fault = Convert.ToBoolean(INI.ReadIni(Common, "Water_pump", "No3_WATER_PUMP_fault ", "false"));
                DATA_PLC_LS.No4_WATER_PUMP_fault = Convert.ToBoolean(INI.ReadIni(Common, "Water_pump", "No4_WATER_PUMP_fault ", "false"));
                DATA_PLC_LS.No5_WATER_PUMP_fault = Convert.ToBoolean(INI.ReadIni(Common, "Water_pump", "No5_WATER_PUMP_fault ", "false"));
                DATA_PLC_LS.No6_WATER_PUMP_fault = Convert.ToBoolean(INI.ReadIni(Common, "Water_pump", "No6_WATER_PUMP_fault ", "false"));
                DATA_PLC_LS.No1_COLLING_TOWER_fault = Convert.ToBoolean(INI.ReadIni(Common, "Water_pump", "No1_COLLING_TOWER_fault ", "false"));
                DATA_PLC_LS.No2_COLLING_TOWER_fault = Convert.ToBoolean(INI.ReadIni(Common, "Water_pump", "No2_COLLING_TOWER_fault ", "false"));

                DATA_PLC_LS.VACCUM_PUMP_A_fault = Convert.ToBoolean(INI.ReadIni(Common, "Water_pump", "VACCUM_PUMP_A_fault ", "false"));
                DATA_PLC_LS.VACCUM_PUMP_B_fault = Convert.ToBoolean(INI.ReadIni(Common, "Water_pump", "VACCUM_PUMP_B_fault ", "false"));
                DATA_PLC_LS.VACCUM_PUMP_C_fault = Convert.ToBoolean(INI.ReadIni(Common, "Water_pump", "VACCUM_PUMP_C_fault ", "false"));
                DATA_PLC_LS.VACCUM_PUMP_D_fault = Convert.ToBoolean(INI.ReadIni(Common, "Water_pump", "VACCUM_PUMP_D_fault ", "false"));
                DATA_PLC_LS.No1_AIR_COMP_fault = Convert.ToBoolean(INI.ReadIni(Common, "Water_pump", "No1_AIR_COMP_fault ", "false"));
                DATA_PLC_LS.No2_AIR_COMP_fault = Convert.ToBoolean(INI.ReadIni(Common, "Water_pump", "No2_AIR_COMP_fault ", "false"));

                DATA_PLC_SI.On_air_chiller_pos_1_fault = Convert.ToBoolean(INI.ReadIni(Common, "Water_pump", "On_air_chiller_pos_1_fault ", "false"));
                DATA_PLC_SI.On_air_chiller_pos_2_fault = Convert.ToBoolean(INI.ReadIni(Common, "Water_pump", "On_air_chiller_pos_2_fault ", "false"));

                DATA_PLC_SI.WATER_BATH_TEMP_fault = Convert.ToBoolean(INI.ReadIni(Common, "Water_pump", "WATER_BATH_TEMP_fault ", "false"));
                DATA_PLC_SI.WATER_BATH_TEMP_alarm = Convert.ToDouble(INI.ReadIni(Common, "Water_pump", "WATER_BATH_TEMP_alarm ", "0"));

                DATA_PLC_SI.VACCUM_PRESSURE_fault = Convert.ToBoolean(INI.ReadIni(Common, "Water_pump", "VACCUM_PRESSURE_fault ", "false"));
                DATA_PLC_SI.VACCUM_PRESSURE_alarm = Convert.ToDouble(INI.ReadIni(Common, "Water_pump", "VACCUM_PRESSURE_alarm ", "0"));

                DATA_PLC_SI.AIR_PRESSURE_Mpa_fault = Convert.ToBoolean(INI.ReadIni(Common, "Water_pump", "AIR_PRESSURE_Mpa_fault ", "false"));
                DATA_PLC_SI.AIR_PRESSURE_Mpa_alarm = Convert.ToDouble(INI.ReadIni(Common, "Water_pump", "AIR_PRESSURE_Mpa_alarm ", "0"));

                //FUME DUST
                DATA_PLC_SI.FUME_PRESSURE_fault = Convert.ToBoolean(INI.ReadIni(Common, "Water_pump", "FUME_PRESSURE_fault ", "false"));
                DATA_PLC_SI.FUME_PRESSURE_alarm = Convert.ToDouble(INI.ReadIni(Common, "Water_pump", "FUME_PRESSURE_alarm ", "0"));

                DATA_PLC_SI.DUST_PRESSURE_fault = Convert.ToBoolean(INI.ReadIni(Common, "Water_pump", "DUST_PRESSURE_fault ", "false"));
                DATA_PLC_SI.DUST_PRESSURE_alarm = Convert.ToDouble(INI.ReadIni(Common, "Water_pump", "DUST_PRESSURE_alarm ", "0"));

                //DATA RTO
                DATA_PLC_SI.TE_1953A_fault = Convert.ToBoolean(INI.ReadIni(Common, "Water_pump", "TE_1953A_fault ", "false"));
                DATA_PLC_SI.TE_1953A_alarm = Convert.ToDouble(INI.ReadIni(Common, "Water_pump", "TE_1953A_alarm", "0"));

                DATA_PLC_SI.AVE_TEMP_fault = Convert.ToBoolean(INI.ReadIni(Common, "Water_pump", "AVE_TEMP_fault ", "false"));
                DATA_PLC_SI.AVE_TEMP_alarm = Convert.ToDouble(INI.ReadIni(Common, "Water_pump", "AVE_TEMP_alarm ", "0"));

                DATA_PLC_SI.TE_1953B_fault = Convert.ToBoolean(INI.ReadIni(Common, "Water_pump", "TE_1953B_fault ", "false"));
                DATA_PLC_SI.TE_1953B_alarm = Convert.ToDouble(INI.ReadIni(Common, "Water_pump", "TE_1953B_alarm ", "0"));

                DATA_PLC_SI.TE_1954_fault = Convert.ToBoolean(INI.ReadIni(Common, "Water_pump", "TE_1954_fault ", "false"));
                DATA_PLC_SI.TE_1954_alarm = Convert.ToDouble(INI.ReadIni(Common, "Water_pump", "TE_1954_alarm ", "0"));

                DATA_PLC_SI.TE_1952A_fault = Convert.ToBoolean(INI.ReadIni(Common, "Water_pump", "TE_1952A_fault ", "false"));
                DATA_PLC_SI.TE_1952A_alarm = Convert.ToDouble(INI.ReadIni(Common, "Water_pump", "TE_1952A_alarm", "0"));

                DATA_PLC_SI.TE_1952B_fault = Convert.ToBoolean(INI.ReadIni(Common, "Water_pump", "TE_1952B_fault ", "false"));
                DATA_PLC_SI.TE_1952B_alarm = Convert.ToDouble(INI.ReadIni(Common, "Water_pump", "TE_1952B_alarm ", "0"));

                DATA_PLC_SI.TE_1952C_fault = Convert.ToBoolean(INI.ReadIni(Common, "Water_pump", "TE_1952C_fault ", "false"));
                DATA_PLC_SI.TE_1952C_alarm = Convert.ToDouble(INI.ReadIni(Common, "Water_pump", "TE_1952C_alarm ", "0"));

                DATA_PLC_SI.TE_1951_fault = Convert.ToBoolean(INI.ReadIni(Common, "Water_pump", "TE_1951_fault ", "false"));
                DATA_PLC_SI.TE_1951_alarm = Convert.ToDouble(INI.ReadIni(Common, "Water_pump", "TE_1951_alarm ", "0"));

                DATA_PLC_SI.TE_1951_1956_fault = Convert.ToBoolean(INI.ReadIni(Common, "Water_pump", "TE_1951_1956_fault ", "false"));

                DATA_PLC_SI.TE_FC_fault = Convert.ToBoolean(INI.ReadIni(Common, "Water_pump", "TE_FC_fault ", "false"));

                //RTD

                DATA_PLC_SI.ND1_fault = Convert.ToBoolean(INI.ReadIni(Common, "Water_pump", "ND1_fault ", "false"));
                DATA_PLC_SI.ND1_alarm = Convert.ToDouble(INI.ReadIni(Common, "Water_pump", "ND1_alarm", "0"));

                DATA_PLC_SI.DO1_fault = Convert.ToBoolean(INI.ReadIni(Common, "Water_pump", "DO1_fault ", "false"));
                DATA_PLC_SI.DO1_alarm = Convert.ToDouble(INI.ReadIni(Common, "Water_pump", "DO1_alarm ", "0"));

                DATA_PLC_SI.ND2_fault = Convert.ToBoolean(INI.ReadIni(Common, "Water_pump", "ND2_fault ", "false"));
                DATA_PLC_SI.ND2_alarm = Convert.ToDouble(INI.ReadIni(Common, "Water_pump", "ND2_alarm ", "0"));

                DATA_PLC_SI.DO2_fault = Convert.ToBoolean(INI.ReadIni(Common, "Water_pump", "DO2_fault ", "false"));
                DATA_PLC_SI.DO2_alarm = Convert.ToDouble(INI.ReadIni(Common, "Water_pump", "DO2_alarm ", "0"));

                //PUMP
                DATA_PLC_SI.Pump_A_fault = Convert.ToBoolean(INI.ReadIni(Common, "Water_pump", "Pump_A_fault ", "false"));
                DATA_PLC_SI.Pump_A_alarm = Convert.ToDouble(INI.ReadIni(Common, "Water_pump", "Pump_A_alarm ", "0"));

                DATA_PLC_SI.Pump_B_fault = Convert.ToBoolean(INI.ReadIni(Common, "Water_pump", "Pump_B_fault ", "false"));
                DATA_PLC_SI.Pump_B_alarm = Convert.ToDouble(INI.ReadIni(Common, "Water_pump", "Pump_B_alarm ", "0"));

                DATA_PLC_SI.Pump_C_fault = Convert.ToBoolean(INI.ReadIni(Common, "Water_pump", "Pump_C_fault ", "false"));
                DATA_PLC_SI.Pump_C_alarm = Convert.ToDouble(INI.ReadIni(Common, "Water_pump", "Pump_C_alarm ", "0"));

                DATA_PLC_SI.Pump_D_fault = Convert.ToBoolean(INI.ReadIni(Common, "Water_pump", "Pump_D_fault ", "false"));
                DATA_PLC_SI.Pump_D_alarm = Convert.ToDouble(INI.ReadIni(Common, "Water_pump", "Pump_D_alarm ", "0"));

                //ANALOG

                DATA_Calibration.v1_int_min = Convert.ToDouble(INI.ReadIni(Common, "Analog", "v1_int_min ", "0"));
                DATA_Calibration.v1_int_max = Convert.ToDouble(INI.ReadIni(Common, "Analog", "v1_int_max  ", "1"));
                DATA_Calibration.v1_real_min = Convert.ToDouble(INI.ReadIni(Common, "Analog", "v1_real_min  ", "0"));
                DATA_Calibration.v1_real_max = Convert.ToDouble(INI.ReadIni(Common, "Analog", "v1_real_max  ", "1"));

                DATA_Calibration.v2_int_min = Convert.ToDouble(INI.ReadIni(Common, "Analog", "v2_int_min ", "0"));
                DATA_Calibration.v2_int_max = Convert.ToDouble(INI.ReadIni(Common, "Analog", "v2_int_max  ", "1"));
                DATA_Calibration.v2_real_min = Convert.ToDouble(INI.ReadIni(Common, "Analog", "v2_real_min  ", "0"));
                DATA_Calibration.v2_real_max = Convert.ToDouble(INI.ReadIni(Common, "Analog", "v2_real_max  ", "1"));

                DATA_Calibration.v3_int_min = Convert.ToDouble(INI.ReadIni(Common, "Analog", "v3_int_min ", "0"));
                DATA_Calibration.v3_int_max = Convert.ToDouble(INI.ReadIni(Common, "Analog", "v3_int_max  ", "1"));
                DATA_Calibration.v3_real_min = Convert.ToDouble(INI.ReadIni(Common, "Analog", "v3_real_min  ", "0"));
                DATA_Calibration.v3_real_max = Convert.ToDouble(INI.ReadIni(Common, "Analog", "v3_real_max  ", "1"));

                DATA_Calibration.v4_int_min = Convert.ToDouble(INI.ReadIni(Common, "Analog", "v4_int_min ", "0"));
                DATA_Calibration.v4_int_max = Convert.ToDouble(INI.ReadIni(Common, "Analog", "v4_int_max  ", "1"));
                DATA_Calibration.v4_real_min = Convert.ToDouble(INI.ReadIni(Common, "Analog", "v4_real_min  ", "0"));
                DATA_Calibration.v4_real_max = Convert.ToDouble(INI.ReadIni(Common, "Analog", "v4_real_max  ", "1"));

                DATA_Calibration.v5_int_min = Convert.ToDouble(INI.ReadIni(Common, "Analog", "v5_int_min ", "0"));
                DATA_Calibration.v5_int_max = Convert.ToDouble(INI.ReadIni(Common, "Analog", "v5_int_max  ", "1"));
                DATA_Calibration.v5_real_min = Convert.ToDouble(INI.ReadIni(Common, "Analog", "v5_real_min  ", "0"));
                DATA_Calibration.v5_real_max = Convert.ToDouble(INI.ReadIni(Common, "Analog", "v5_real_max  ", "1"));

                //MCC
                for (int i_mcc_r = 1; i_mcc_r <= 26; i_mcc_r++)
                {
                    DATA_PLC_OM.om_fault[i_mcc_r] = Convert.ToBoolean(INI.ReadIni(Common, "OM", "OM_"+ i_mcc_r.ToString(), "false"));
                }
            }
            catch (Exception ex)
            {
                KN.Showalert(ex.Message);
            }
}

        public static void WriteCommon()
        {
            try
            {
                INI.WriteIni(Common, "Water_pump", "No1_WATER_PUMP_fault ", DATA_PLC_LS.No1_WATER_PUMP_fault.ToString());
                INI.WriteIni(Common, "Water_pump", "No2_WATER_PUMP_fault ", DATA_PLC_LS.No2_WATER_PUMP_fault.ToString());
                INI.WriteIni(Common, "Water_pump", "No3_WATER_PUMP_fault ", DATA_PLC_LS.No3_WATER_PUMP_fault.ToString());
                INI.WriteIni(Common, "Water_pump", "No4_WATER_PUMP_fault ", DATA_PLC_LS.No4_WATER_PUMP_fault.ToString());
                INI.WriteIni(Common, "Water_pump", "No5_WATER_PUMP_fault ", DATA_PLC_LS.No5_WATER_PUMP_fault.ToString());
                INI.WriteIni(Common, "Water_pump", "No6_WATER_PUMP_fault ", DATA_PLC_LS.No6_WATER_PUMP_fault.ToString());
                INI.WriteIni(Common, "Water_pump", "No1_COLLING_TOWER_fault ", DATA_PLC_LS.No1_COLLING_TOWER_fault.ToString());
                INI.WriteIni(Common, "Water_pump", "No2_COLLING_TOWER_fault ", DATA_PLC_LS.No2_COLLING_TOWER_fault.ToString());


                INI.WriteIni(Common, "Water_pump", "VACCUM_PUMP_A_fault ", DATA_PLC_LS.VACCUM_PUMP_A_fault.ToString());
                INI.WriteIni(Common, "Water_pump", "VACCUM_PUMP_B_fault ", DATA_PLC_LS.VACCUM_PUMP_B_fault.ToString());
                INI.WriteIni(Common, "Water_pump", "VACCUM_PUMP_C_fault ", DATA_PLC_LS.VACCUM_PUMP_C_fault.ToString());
                INI.WriteIni(Common, "Water_pump", "VACCUM_PUMP_D_fault ", DATA_PLC_LS.VACCUM_PUMP_D_fault.ToString());
                INI.WriteIni(Common, "Water_pump", "No1_AIR_COMP_fault ", DATA_PLC_LS.No1_AIR_COMP_fault.ToString());
                INI.WriteIni(Common, "Water_pump", "No2_AIR_COMP_fault ", DATA_PLC_LS.No2_AIR_COMP_fault.ToString());

                INI.WriteIni(Common, "Water_pump", "On_air_chiller_pos_1_fault ", DATA_PLC_SI.On_air_chiller_pos_1_fault.ToString());
                INI.WriteIni(Common, "Water_pump", "On_air_chiller_pos_2_fault ", DATA_PLC_SI.On_air_chiller_pos_2_fault.ToString());

                INI.WriteIni(Common, "Water_pump", "WATER_BATH_TEMP_fault ", DATA_PLC_SI.WATER_BATH_TEMP_fault.ToString());
                INI.WriteIni(Common, "Water_pump", "WATER_BATH_TEMP_alarm ", DATA_PLC_SI.WATER_BATH_TEMP_alarm.ToString());

                INI.WriteIni(Common, "Water_pump", "VACCUM_PRESSURE_fault ", DATA_PLC_SI.VACCUM_PRESSURE_fault.ToString());
                INI.WriteIni(Common, "Water_pump", "VACCUM_PRESSURE_alarm ", DATA_PLC_SI.VACCUM_PRESSURE_alarm.ToString());

                INI.WriteIni(Common, "Water_pump", "AIR_PRESSURE_Mpa_fault ", DATA_PLC_SI.AIR_PRESSURE_Mpa_fault.ToString());
                INI.WriteIni(Common, "Water_pump", "AIR_PRESSURE_Mpa_alarm ", DATA_PLC_SI.AIR_PRESSURE_Mpa_alarm.ToString());

                //FUME DUST

                INI.WriteIni(Common, "Water_pump", "FUME_PRESSURE_fault ", DATA_PLC_SI.FUME_PRESSURE_fault.ToString());
                INI.WriteIni(Common, "Water_pump", "FUME_PRESSURE_alarm ", DATA_PLC_SI.FUME_PRESSURE_alarm.ToString());

                INI.WriteIni(Common, "Water_pump", "DUST_PRESSURE_fault ", DATA_PLC_SI.DUST_PRESSURE_fault.ToString());
                INI.WriteIni(Common, "Water_pump", "DUST_PRESSURE_alarm ", DATA_PLC_SI.DUST_PRESSURE_alarm.ToString());

                //RTO
                INI.WriteIni(Common, "Water_pump", "TE_1953A_fault ", DATA_PLC_SI.TE_1953A_fault.ToString());
                INI.WriteIni(Common, "Water_pump", "TE_1953A_alarm ", DATA_PLC_SI.TE_1953A_alarm.ToString());

                INI.WriteIni(Common, "Water_pump", "AVE_TEMP_fault ", DATA_PLC_SI.AVE_TEMP_fault.ToString());
                INI.WriteIni(Common, "Water_pump", "AVE_TEMP_alarm ", DATA_PLC_SI.AVE_TEMP_alarm.ToString());

                INI.WriteIni(Common, "Water_pump", "TE_1953B_fault ", DATA_PLC_SI.TE_1953B_fault.ToString());
                INI.WriteIni(Common, "Water_pump", "TE_1953B_alarm ", DATA_PLC_SI.TE_1953B_alarm.ToString());

                INI.WriteIni(Common, "Water_pump", "TE_1954_fault ", DATA_PLC_SI.TE_1954_fault.ToString());
                INI.WriteIni(Common, "Water_pump", "TE_1954_alarm ", DATA_PLC_SI.TE_1954_alarm.ToString());

                INI.WriteIni(Common, "Water_pump", "TE_1952A_fault ", DATA_PLC_SI.TE_1952A_fault.ToString());
                INI.WriteIni(Common, "Water_pump", "TE_1952A_alarm ", DATA_PLC_SI.TE_1952A_alarm.ToString());

                INI.WriteIni(Common, "Water_pump", "TE_1952B_fault ", DATA_PLC_SI.TE_1952B_fault.ToString());
                INI.WriteIni(Common, "Water_pump", "TE_1952B_alarm ", DATA_PLC_SI.TE_1952B_alarm.ToString());

                INI.WriteIni(Common, "Water_pump", "TE_1952C_fault ", DATA_PLC_SI.TE_1952C_fault.ToString());
                INI.WriteIni(Common, "Water_pump", "TE_1952C_alarm ", DATA_PLC_SI.TE_1952C_alarm.ToString());

                INI.WriteIni(Common, "Water_pump", "TE_1951_fault ", DATA_PLC_SI.TE_1951_fault.ToString());
                INI.WriteIni(Common, "Water_pump", "TE_1951_alarm ", DATA_PLC_SI.TE_1951_alarm.ToString());

                INI.WriteIni(Common, "Water_pump", "TE_1951_1956_fault ", DATA_PLC_SI.TE_1951_1956_fault.ToString());

                INI.WriteIni(Common, "Water_pump", "TE_FC_fault ", DATA_PLC_SI.TE_FC_fault.ToString());

                //DATA RTD

                INI.WriteIni(Common, "Water_pump", "ND1_fault ", DATA_PLC_SI.ND1_fault.ToString());
                INI.WriteIni(Common, "Water_pump", "ND1_alarm ", DATA_PLC_SI.ND1_alarm.ToString());

                INI.WriteIni(Common, "Water_pump", "DO1_fault ", DATA_PLC_SI.DO1_fault.ToString());
                INI.WriteIni(Common, "Water_pump", "DO1_alarm ", DATA_PLC_SI.DO1_alarm.ToString());

                INI.WriteIni(Common, "Water_pump", "ND2_fault ", DATA_PLC_SI.ND2_fault.ToString());
                INI.WriteIni(Common, "Water_pump", "ND2_alarm ", DATA_PLC_SI.ND2_alarm.ToString());

                INI.WriteIni(Common, "Water_pump", "DO2_fault ", DATA_PLC_SI.DO2_fault.ToString());
                INI.WriteIni(Common, "Water_pump", "DO2_alarm ", DATA_PLC_SI.DO2_alarm.ToString());

                //Pump_A_fault
                INI.WriteIni(Common, "Water_pump", "Pump_A_fault ", DATA_PLC_SI.Pump_A_fault.ToString());
                INI.WriteIni(Common, "Water_pump", "Pump_A_alarm ", DATA_PLC_SI.Pump_A_alarm.ToString());

                INI.WriteIni(Common, "Water_pump", "Pump_B_fault ", DATA_PLC_SI.Pump_B_fault.ToString());
                INI.WriteIni(Common, "Water_pump", "Pump_B_alarm ", DATA_PLC_SI.Pump_B_alarm.ToString());

                INI.WriteIni(Common, "Water_pump", "Pump_C_fault ", DATA_PLC_SI.Pump_C_fault.ToString());
                INI.WriteIni(Common, "Water_pump", "Pump_C_alarm ", DATA_PLC_SI.Pump_C_alarm.ToString());

                INI.WriteIni(Common, "Water_pump", "Pump_D_fault ", DATA_PLC_SI.Pump_D_fault.ToString());
                INI.WriteIni(Common, "Water_pump", "Pump_D_alarm ", DATA_PLC_SI.Pump_D_alarm.ToString());
                //

                INI.WriteIni(Common, "Analog", "v1_int_min  ", DATA_Calibration.v1_int_min.ToString());
                INI.WriteIni(Common, "Analog", "v1_int_max   ", DATA_Calibration.v1_int_max.ToString());
                INI.WriteIni(Common, "Analog", "v1_real_min   ", DATA_Calibration.v1_real_min.ToString());
                INI.WriteIni(Common, "Analog", "v1_real_max   ", DATA_Calibration.v1_real_max.ToString());

                INI.WriteIni(Common, "Analog", "v2_int_min  ", DATA_Calibration.v2_int_min.ToString());
                INI.WriteIni(Common, "Analog", "v2_int_max   ", DATA_Calibration.v2_int_max.ToString());
                INI.WriteIni(Common, "Analog", "v2_real_min   ", DATA_Calibration.v2_real_min.ToString());
                INI.WriteIni(Common, "Analog", "v2_real_max   ", DATA_Calibration.v2_real_max.ToString());

                INI.WriteIni(Common, "Analog", "v3_int_min  ", DATA_Calibration.v3_int_min.ToString());
                INI.WriteIni(Common, "Analog", "v3_int_max   ", DATA_Calibration.v3_int_max.ToString());
                INI.WriteIni(Common, "Analog", "v3_real_min   ", DATA_Calibration.v3_real_min.ToString());
                INI.WriteIni(Common, "Analog", "v3_real_max   ", DATA_Calibration.v3_real_max.ToString());

                INI.WriteIni(Common, "Analog", "v4_int_min  ", DATA_Calibration.v4_int_min.ToString());
                INI.WriteIni(Common, "Analog", "v4_int_max   ", DATA_Calibration.v4_int_max.ToString());
                INI.WriteIni(Common, "Analog", "v4_real_min   ", DATA_Calibration.v4_real_min.ToString());
                INI.WriteIni(Common, "Analog", "v4_real_max   ", DATA_Calibration.v4_real_max.ToString());

                INI.WriteIni(Common, "Analog", "v5_int_min  ", DATA_Calibration.v5_int_min.ToString());
                INI.WriteIni(Common, "Analog", "v5_int_max   ", DATA_Calibration.v5_int_max.ToString());
                INI.WriteIni(Common, "Analog", "v5_real_min   ", DATA_Calibration.v5_real_min.ToString());
                INI.WriteIni(Common, "Analog", "v5_real_max   ", DATA_Calibration.v5_real_max.ToString());

                for (int i_mcc_w = 1; i_mcc_w <= 26; i_mcc_w++)
                {
                    INI.WriteIni(Common, "OM", "OM_" + i_mcc_w.ToString(), DATA_PLC_OM.om_fault[i_mcc_w].ToString());
                }
            }
            catch (Exception ex)
            {
                KN.Showalert(ex.Message);
            }
        }
    }
}
