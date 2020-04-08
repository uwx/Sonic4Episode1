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
    public class GMS_BOSS1_EFF_SHOCKWAVE_WORK : AppMain.IOBS_OBJECT_WORK
    {
        public readonly AppMain.GMS_EFFECT_3DES_WORK eff_3des;
        public AppMain.GMS_BOSS1_MGR_WORK mgr_work;
        public uint atk_rect_timer;

        public GMS_BOSS1_EFF_SHOCKWAVE_WORK()
        {
            this.eff_3des = new AppMain.GMS_EFFECT_3DES_WORK((object)this);
        }

        public AppMain.OBS_OBJECT_WORK Cast()
        {
            return this.eff_3des.efct_com.obj_work;
        }
    }
}
