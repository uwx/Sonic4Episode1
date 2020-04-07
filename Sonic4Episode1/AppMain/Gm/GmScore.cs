﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using mpp;

public partial class AppMain
{
    public static void GmScoreCreateScore(
          int score,
          int pos_x,
          int pos_y,
          int scale,
          int vib_level)
    {
        int[] numArray1 = new int[5];
        int[] numArray2 = new int[5] { 10000, 1000, 100, 10, 1 };
        if (score <= 0)
            return;
        AppMain.OBS_OBJECT_WORK parent_obj = AppMain.OBM_OBJECT_TASK_DETAIL_INIT((ushort)18432, (byte)5, (byte)0, (byte)0, (AppMain.TaskWorkFactoryDelegate)(() => (object)new AppMain.GMS_SCORE_DISP_WORK()), (string)null);
        AppMain.GMS_SCORE_DISP_WORK gmsScoreDispWork = (AppMain.GMS_SCORE_DISP_WORK)parent_obj;
        parent_obj.pos.x = pos_x;
        parent_obj.pos.y = pos_y - 65536;
        parent_obj.pos.z = 1179648;
        parent_obj.flag |= 18U;
        parent_obj.move_flag |= 256U;
        parent_obj.ppFunc = new AppMain.MPP_VOID_OBS_OBJECT_WORK(AppMain.gmScoreMainFunc);
        gmsScoreDispWork.vib_level = vib_level;
        gmsScoreDispWork.base_pos.Assign(parent_obj.pos);
        gmsScoreDispWork.scale = scale;
        gmsScoreDispWork.rise_dist = -8 * (scale - 4096) - 131072;
        gmsScoreDispWork.rise_spd = gmsScoreDispWork.rise_dist * 2 / 30;
        gmsScoreDispWork.rise_dec = -gmsScoreDispWork.rise_spd / 30;
        gmsScoreDispWork.timer = 184320;
        if (score > 99999)
            score = 99999;
        int num1 = score;
        bool flag = false;
        int num2 = 0;
        for (int index = 0; index < 5; ++index)
        {
            numArray1[4 - index] = num1 / numArray2[index];
            num1 -= numArray1[4 - index] * numArray2[index];
            if (!flag)
            {
                if (numArray1[4 - index] == 0)
                {
                    numArray1[4 - index] = -1;
                }
                else
                {
                    flag = true;
                    ++num2;
                }
            }
            else
                ++num2;
        }
        int ofst_x = ((num2 * 11 + (num2 - 1)) * 4096 >> 1) - 22528;
        int num3 = -49152;
        int index1 = 0;
        while (index1 < 5 && numArray1[index1] != -1)
        {
            gmsScoreDispWork.efct_work[index1] = AppMain.GmEfctCmnEsCreate(parent_obj, 56 + numArray1[index1]);
            gmsScoreDispWork.efct_work[index1].efct_com.obj_work.scale.x = gmsScoreDispWork.efct_work[index1].efct_com.obj_work.scale.y = gmsScoreDispWork.efct_work[index1].efct_com.obj_work.scale.z = scale;
            gmsScoreDispWork.efct_work[index1].obj_3des.command_state = 10U;
            AppMain.GmComEfctSetDispOffset(gmsScoreDispWork.efct_work[index1], ofst_x, 0, 0);
            ++index1;
            ofst_x += num3;
        }
    }

    public static void gmScoreMainFunc(AppMain.OBS_OBJECT_WORK obj_work)
    {
        AppMain.GMS_SCORE_DISP_WORK gmsScoreDispWork = (AppMain.GMS_SCORE_DISP_WORK)obj_work;
        gmsScoreDispWork.base_pos.y += gmsScoreDispWork.rise_spd;
        gmsScoreDispWork.rise_spd += gmsScoreDispWork.rise_dec;
        if (gmsScoreDispWork.rise_spd > 0)
            gmsScoreDispWork.rise_spd = 0;
        obj_work.pos.Assign(gmsScoreDispWork.base_pos);
        if (gmsScoreDispWork.rise_spd != 0)
        {
            gmsScoreDispWork.vib_timer = AppMain.ObjTimeCountUp(gmsScoreDispWork.vib_timer);
            int index = gmsScoreDispWork.vib_timer >> 12 & 7;
            obj_work.pos.x += AppMain.FX_Mul(AppMain.gm_score_vib_tbl[index][0], AppMain.gm_score_vib_scale_tbl[gmsScoreDispWork.vib_level]);
            obj_work.pos.y += AppMain.FX_Mul(AppMain.gm_score_vib_tbl[index][1], AppMain.gm_score_vib_scale_tbl[gmsScoreDispWork.vib_level]);
        }
        gmsScoreDispWork.timer = AppMain.ObjTimeCountDown(gmsScoreDispWork.timer);
        if (gmsScoreDispWork.timer > 0)
            return;
        for (int index = 0; index < 5; ++index)
        {
            if (gmsScoreDispWork.efct_work[index] != null)
                gmsScoreDispWork.efct_work[index].efct_com.obj_work.flag |= 8U;
        }
        obj_work.flag |= 4U;
    }

}