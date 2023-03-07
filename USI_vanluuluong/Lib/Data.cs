using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baodongchem
{
    public static class Data
    {
        public static bool OM_tatcoi = false;
        public static bool OM_reset = false;
        public static bool OM_mute = false;

        public static bool write = false;
        public static bool Tat_coi = false;
        public static bool System_fault = false;
        public static bool Reset_bt_tatcoi = false;
        public static bool Reset_bt_reset = false;

        public static bool[] Error = new bool[100];
        public static bool[] Error_temp = new bool[100];
    }

    public static class DATA_PLC
    {
        public static byte[] Read_PLC = { };
        public static byte[] Read_PLCPACK = { };
        public static bool s7_connect = false;
        public static bool s7_connectpack = false;
        public static bool LS_connect = false;
        public static bool RW_connect = false;
        public static bool OM_connect = false;
        public static bool THD_connect = false;
        public static int OM_dis_count = 0;
    }
    public static class DATA_PLC_SIPACK
    {

        //Cân tức thời
        public static double wLineA_IC = 0;
        public static double wLineB_IC = 0;
        public static double wLineC_IC = 0;

        //nhiệt độ tức thời
        public static double tLineA_IC = 0;
        public static double tLineB_IC = 0;
        public static double tLineC_IC = 0;

        //Cân độ Chốt
        public static double wLineA_LV = 0;
        public static double wLineB_LV = 0;
        public static double wLineC_LV = 0;

        //Nhiệt độ Chốt
        public static double tLineA_LV = 0;
        public static double tLineB_LV = 0;
        public static double tLineC_LV = 0;


        //Tham số chốt cân 
        public static double isWLineA = 0;
        public static double isWLineB = 0;
        public static double isWLineC = 0;


        public static double isWWriteA = 0;
        public static double isWWriteB = 0;
        public static double isWWriteC = 0;

        public static double countA = 0;
        public static double countB = 0;
        public static double countC = 0;

    }
        public static class DATA_PLC_SI
    {
        public static bool Man_pump_cmd = false;
        public static bool On_air_chiller_pos_1 = false;
        public static bool On_air_chiller_pos_2 = false;

        public static bool On_air_chiller_pos_1_temp = false;
        public static bool On_air_chiller_pos_2_temp = false;

        public static bool On_air_chiller_pos_1_fault = false;
        public static bool On_air_chiller_pos_2_fault = false;

        public static bool On_dust_collector_A_Pos = false;
        public static bool On_dust_collector_B_Pos = false;
        public static bool On_dust_collector_C_Pos = false;
        public static bool On_fume_collector_A_Pos = false;
        public static bool On_fume_collector_B_Pos = false;

        public static bool Lamp_stop = false;
        public static bool Lamp_fault = false;
        public static bool Lamp_run = false;
        public static bool Buzz = false;
        public static bool Horn_and_light = false;
        public static bool Off_horn = false;
        public static bool Reset = false;
        public static bool Reset_3s = false;

        public static double ND1 = 0;
        public static double DO1 = 0;
        public static double ND2 = 0;
        public static double DO2 = 0;

        public static bool Vale_close = true;
        public static bool Vale_close_temp = false;
        public static bool Vale_close_fault = false;

        public static bool WATER_BATH_TEMP_temp= true;
        public static bool WATER_BATH_TEMP_fault = false;
        public static double WATER_BATH_TEMP_alarm = 0;

        public static bool VACCUM_PRESSURE_temp = false;
        public static bool VACCUM_PRESSURE_fault = false;
        public static double VACCUM_PRESSURE_alarm = 0;

        public static bool AIR_PRESSURE_Mpa_temp = false;
        public static bool AIR_PRESSURE_Mpa_fault = false;
        public static double AIR_PRESSURE_Mpa_alarm = 0;

        public static bool FUME_PRESSURE_temp = false;
        public static bool FUME_PRESSURE_fault = false;
        public static double FUME_PRESSURE_alarm = 0;

        public static bool DUST_PRESSURE_temp = false;
        public static bool DUST_PRESSURE_fault = false;
        public static double DUST_PRESSURE_alarm = 0;

        public static bool TE_1953A_temp = false;
        public static bool TE_1953A_fault = false;
        public static double TE_1953A_alarm = 0;

        public static bool AVE_TEMP_temp = false;
        public static bool AVE_TEMP_fault = false;
        public static double AVE_TEMP_alarm = 0;

        public static bool TE_1953B_temp = false;
        public static bool TE_1953B_fault = false;
        public static double TE_1953B_alarm = 0;

        public static bool TE_1954_temp = false;
        public static bool TE_1954_fault = false;
        public static double TE_1954_alarm = 0;

        public static bool TE_1952A_temp = false;
        public static bool TE_1952A_fault = false;
        public static double TE_1952A_alarm = 0;

        public static bool TE_1952B_temp = false;
        public static bool TE_1952B_fault = false;
        public static double TE_1952B_alarm = 0;

        public static bool TE_1952C_temp = false;
        public static bool TE_1952C_fault = false;
        public static double TE_1952C_alarm = 0;

        public static bool TE_1951_temp = false;
        public static bool TE_1951_fault = false;
        public static double TE_1951_alarm = 0;

        public static bool TE_1951_1956_temp = false;
        public static bool TE_1951_1956_fault = false;

        public static bool TE_FC_temp = false;
        public static bool TE_FC_fault = false;

        public static bool ND1_temp = false;
        public static bool ND1_fault = false;
        public static double ND1_alarm = 0;

        public static bool DO1_temp = false;
        public static bool DO1_fault = false;
        public static double DO1_alarm = 0;

        public static bool ND2_temp = false;
        public static bool ND2_fault = false;
        public static double ND2_alarm = 0;

        public static bool DO2_temp = false;
        public static bool DO2_fault = false;
        public static double DO2_alarm = 0;

        public static bool Pump_A_temp = false;
        public static bool Pump_A_fault = false;
        public static double Pump_A_alarm = 0;

        public static bool Pump_B_temp = false;
        public static bool Pump_B_fault = false;
        public static double Pump_B_alarm = 0;

        public static bool Pump_C_temp = false;
        public static bool Pump_C_fault = false;
        public static double Pump_C_alarm = 0;

        public static bool Pump_D_temp = false;
        public static bool Pump_D_fault = false;
        public static double Pump_D_alarm = 0;
    }
    public static class DATA_PLC_LS
    {
        public static bool No1_WATER_PUMP = false;
        public static bool No2_WATER_PUMP = false;
        public static bool No3_WATER_PUMP = false;
        public static bool No4_WATER_PUMP = false;
        public static bool No5_WATER_PUMP = false;
        public static bool No6_WATER_PUMP = false;
        public static bool No1_COLLING_TOWER = false;
        public static bool No2_COLLING_TOWER = false;
        public static bool VACCUM_PUMP_A = false;
        public static bool VACCUM_PUMP_B = false;
        public static bool VACCUM_PUMP_C = false;
        public static bool VACCUM_PUMP_D = false;
        public static bool No1_AIR_COMP = false;
        public static bool No2_AIR_COMP = false;

        public static bool No1_WATER_PUMP_temp = true;
        public static bool No2_WATER_PUMP_temp = true;
        public static bool No3_WATER_PUMP_temp = true;
        public static bool No4_WATER_PUMP_temp = true;
        public static bool No5_WATER_PUMP_temp = true;
        public static bool No6_WATER_PUMP_temp = true;
        public static bool No1_COLLING_TOWER_temp = false;
        public static bool No2_COLLING_TOWER_temp = false;
        public static bool VACCUM_PUMP_A_temp = true;
        public static bool VACCUM_PUMP_B_temp = true;
        public static bool VACCUM_PUMP_C_temp = true;
        public static bool VACCUM_PUMP_D_temp = true;
        public static bool No1_AIR_COMP_temp = false;
        public static bool No2_AIR_COMP_temp = false;

        public static bool No1_WATER_PUMP_fault = false;
        public static bool No2_WATER_PUMP_fault = false;
        public static bool No3_WATER_PUMP_fault = false;
        public static bool No4_WATER_PUMP_fault = false;
        public static bool No5_WATER_PUMP_fault = false;
        public static bool No6_WATER_PUMP_fault = false;
        public static bool No1_COLLING_TOWER_fault = false;
        public static bool No2_COLLING_TOWER_fault = false;
        public static bool VACCUM_PUMP_A_fault = false;
        public static bool VACCUM_PUMP_B_fault = false;
        public static bool VACCUM_PUMP_C_fault = false;
        public static bool VACCUM_PUMP_D_fault = false;
        public static bool No1_AIR_COMP_fault = false;
        public static bool No2_AIR_COMP_fault = false;

        public static double Pump_A = 0;
        public static double Pump_B = 0;
        public static double Pump_C = 0;
        public static double Pump_D = 0;
    }
    public static class DATA_PLC_OM
    {
        public static string Read_PLC_OM = "";
        public static bool[] om = {false,false,false,false,false,false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
        public static bool[] om_temp = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
        public static bool[] om_fault = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };

        public static bool om_mute = false;
    }
    public static class DATA_PLC_RW
    {
        public static double TE_1953A = 0;
        public static double AVE_TEMP = 0;
        public static double TE_1953B = 0;
        public static double TE_1952A = 0;
        public static double TE_1952B = 0;
        public static double TE_1952C = 0;
        public static double TE_1954 = 0;
        public static double TE_1951 = 0;

        public static bool XV1952 = false;
        public static bool XV1951 = false;
        public static bool XV1956 = false;
        public static bool XXXXXX = false;
    }

    public static class DATA_Calibration
    {
        public static double v1_in = 0;
        public static double v1_int_min = 0;
        public static double v1_int_max = 0;
        public static double v1_real_min = 0;
        public static double v1_real_max = 0;
        public static double v1_out= 0;

        public static double v2_in = 0;
        public static double v2_int_min = 0;
        public static double v2_int_max = 0;
        public static double v2_real_min = 0;
        public static double v2_real_max = 0;
        public static double v2_out = 0;

        public static double v3_in = 0;
        public static double v3_int_min = 0;
        public static double v3_int_max = 0;
        public static double v3_real_min = 0;
        public static double v3_real_max = 0;
        public static double v3_out = 0;

        public static double v4_in = 0;
        public static double v4_int_min = 0;
        public static double v4_int_max = 0;
        public static double v4_real_min = 0;
        public static double v4_real_max = 0;
        public static double v4_out = 0;

        public static double v5_in = 0;
        public static double v5_int_min = 0;
        public static double v5_int_max = 0;
        public static double v5_real_min = 0;
        public static double v5_real_max = 0;
        public static double v5_out = 0;
    }
}
