using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using accel;
using dbg;
using er;
using er.web;
using gs;
using gs.backup;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Graphics.PackedVector;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using mpp;
using setting;

public partial class AppMain
{
    private enum DME_STGSLCT_ACT : uint
    {
        ACT_ZONE_BG_LT = 0,
        ACT_ZONE_BG_LB = 1,
        ACT_ZONE_BG_RT = 2,
        ACT_ZONE_BG_RB = 3,
        ACT_TAB_MODE_L = 4,
        ACT_ICON_SONIC = 5,
        ACT_REST_NUM_100 = 6,
        ACT_REST_NUM_10 = 7,
        ACT_REST_NUM_1 = 8,
        ACT_TAB_EMER = 9,
        ACT_ICON_EMER_1 = 10, // 0x0000000A
        ACT_ICON_EMER_2 = 11, // 0x0000000B
        ACT_ICON_EMER_3 = 12, // 0x0000000C
        ACT_ICON_EMER_4 = 13, // 0x0000000D
        ACT_ICON_EMER_5 = 14, // 0x0000000E
        ACT_ICON_EMER_6 = 15, // 0x0000000F
        ACT_ICON_EMER_7 = 16, // 0x00000010
        ACT_TEX_ZONE_UP = 17, // 0x00000011
        ACT_TEX_ZONE_UP_S = 18, // 0x00000012
        ACT_TAB_ZONE_SCR1 = 19, // 0x00000013
        ACT_TAB_ZONE_SCR2 = 20, // 0x00000014
        ACT_TAB_ZONE_SCR3 = 21, // 0x00000015
        ACT_TAB_ZONE_SCR4 = 22, // 0x00000016
        ACT_TAB_ZONE_SCR5 = 23, // 0x00000017
        ACT_TAB_ZONE_SCR6 = 24, // 0x00000018
        ACT_TAB_ZONE_SCR1_1a = 25, // 0x00000019
        ACT_TAB_ZONE_SCR1_2a = 26, // 0x0000001A
        ACT_TAB_ZONE_SCR1_3a = 27, // 0x0000001B
        ACT_TAB_ZONE_SCR2_1a = 28, // 0x0000001C
        ACT_TAB_ZONE_SCR2_2a = 29, // 0x0000001D
        ACT_TAB_ZONE_SCR2_3a = 30, // 0x0000001E
        ACT_TAB_ZONE_SCR3_1a = 31, // 0x0000001F
        ACT_TAB_ZONE_SCR3_2a = 32, // 0x00000020
        ACT_TAB_ZONE_SCR3_3a = 33, // 0x00000021
        ACT_TAB_ZONE_SCR4_1a = 34, // 0x00000022
        ACT_TAB_ZONE_SCR4_2a = 35, // 0x00000023
        ACT_TAB_ZONE_SCR4_3a = 36, // 0x00000024
        ACT_TAB_ZONE_TAB = 37, // 0x00000025
        ACT_TAB_ZONE_TEXT = 38, // 0x00000026
        ACT_TAB_ZONE_TEXT_S = 39, // 0x00000027
        ACT_TAB_ZONE_COVER1 = 40, // 0x00000028
        ACT_TAB_ZONE_COVER2 = 41, // 0x00000029
        ACT_TAB_ZONE_COVER3 = 42, // 0x0000002A
        ACT_ICON_DOWN_1 = 43, // 0x0000002B
        ACT_ICON_DOWN_2 = 44, // 0x0000002C
        ACT_ICON_DOWN_3 = 45, // 0x0000002D
        ACT_ICON_DOWN_4 = 46, // 0x0000002E
        ACT_ICON_DOWN_5 = 47, // 0x0000002F
        ACT_ICON_DOWN_6 = 48, // 0x00000030
        ACT_ICON_L_ARROW = 49, // 0x00000031
        ACT_ICON_R_ARROW = 50, // 0x00000032
        ACT_TAB_STATE_L = 51, // 0x00000033
        ACT_TAB_STATE_C = 52, // 0x00000034
        ACT_TAB_STATE_R = 53, // 0x00000035
        ACT_TAB_STATE_L2 = 54, // 0x00000036
        ACT_TAB_STATE_C2 = 55, // 0x00000037
        ACT_TAB_STATE_R2 = 56, // 0x00000038
        ACT_TAB_STATE_MOVE = 57, // 0x00000039
        ACT_TAB_START = 58, // 0x0000003A
        ACT_TAB_TABLE2 = 58, // 0x0000003A
        ACT_TAB_TABLE1 = 59, // 0x0000003B
        ACT_TAB_TABLE3 = 60, // 0x0000003C
        ACT_TAB_SCR = 61, // 0x0000003D
        ACT_TAB_SCR_BG = 62, // 0x0000003E
        ACT_TAB_TEXT = 63, // 0x0000003F
        ACT_TAB_A_NUM = 64, // 0x00000040
        ACT_TAB_MESS = 65, // 0x00000041
        ACT_TAB_LINE = 66, // 0x00000042
        ACT_TAB_ICON_EMER = 67, // 0x00000043
        ACT_TAB_NUM_SPE_STAGE = 68, // 0x00000044
        ACT_TAB_ICON_SPE_EMER = 69, // 0x00000045
        ACT_TAB_CURSOR_UP = 70, // 0x00000046
        ACT_TAB_CURSOR_DOWN = 71, // 0x00000047
        ACT_TAB_TEX_SCORE = 72, // 0x00000048
        ACT_TAB_TEX_TIME = 73, // 0x00000049
        ACT_TAB_TEX_BOSS = 74, // 0x0000004A
        ACT_TAB_TEX_SPE_STAGE = 75, // 0x0000004B
        ACT_TAB_S_NUM1 = 76, // 0x0000004C
        ACT_TAB_S_NUM2 = 77, // 0x0000004D
        ACT_TAB_S_NUM3 = 78, // 0x0000004E
        ACT_TAB_S_NUM4 = 79, // 0x0000004F
        ACT_TAB_S_NUM5 = 80, // 0x00000050
        ACT_TAB_S_NUM6 = 81, // 0x00000051
        ACT_TAB_S_NUM7 = 82, // 0x00000052
        ACT_TAB_S_NUM8 = 83, // 0x00000053
        ACT_TAB_END = 84, // 0x00000054
        ACT_TAB_S_NUM9 = 84, // 0x00000054
        ACT_NONE = 85, // 0x00000055
        ACT_TAB_COVER2 = 85, // 0x00000055
        ACT_TAB_COVER1 = 86, // 0x00000056
        ACT_TAB_COVER3 = 87, // 0x00000057
        ACT_TEX_BIG_TIME = 88, // 0x00000058
        ACT_TEX_BIG_SCORE = 89, // 0x00000059
        ACT_WIN_TEX_MSG = 90, // 0x0000005A
        ACT_WIN_TEX_MSG2 = 91, // 0x0000005B
        ACT_WIN_TEX_MSG_SSONIC = 92, // 0x0000005C
        ACT_WAVE_BG = 93, // 0x0000005D
        ACT_DOWN_BG = 94, // 0x0000005E
        ACT_BLUE_BG = 95, // 0x0000005F
        ACT_BTN_CANCEL1 = 96, // 0x00000060
        ACT_BTN_LB = 97, // 0x00000061
        ACT_BTN_MENU = 98, // 0x00000062
        ACT_BTN_LB_ARROW = 99, // 0x00000063
        ACT_BTN_RB_ARROW = 100, // 0x00000064
        ACT_BTN_CANCEL2 = 101, // 0x00000065
        ACT_BTN_X = 102, // 0x00000066
        ACT_BTN_Y = 103, // 0x00000067
        ACT_BACK_BTN01_L = 104, // 0x00000068
        ACT_BACK_BTN01_R = 105, // 0x00000069
        ACT_YES_BTN_L = 106, // 0x0000006A
        ACT_YES_BTN_C = 107, // 0x0000006B
        ACT_YES_BTN_R = 108, // 0x0000006C
        ACT_NO_BTN_L = 109, // 0x0000006D
        ACT_NO_BTN_C = 110, // 0x0000006E
        ACT_NO_BTN_R = 111, // 0x0000006F
        ACT_TEX_FIX_BACK = 112, // 0x00000070
        ACT_TEX_BACK1 = 113, // 0x00000071
        ACT_TEX_YES = 114, // 0x00000072
        ACT_TEX_NO = 115, // 0x00000073
        ACT_NUM = 116, // 0x00000074
    }
}
