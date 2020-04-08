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
    public class GMS_BOSS5_ARM_PART_ANIM_INFO
    {
        public readonly AppMain.NNS_ROTATE_A32 start_rot = new AppMain.NNS_ROTATE_A32();
        public readonly AppMain.NNS_ROTATE_A32 end_rot = new AppMain.NNS_ROTATE_A32();
        public int is_anim;

        public GMS_BOSS5_ARM_PART_ANIM_INFO()
        {
        }

        public GMS_BOSS5_ARM_PART_ANIM_INFO(
          int anim,
          AppMain.NNS_ROTATE_A32 rot,
          AppMain.NNS_ROTATE_A32 erot)
        {
            this.is_anim = anim;
            this.start_rot = rot;
            this.end_rot = erot;
        }
    }
}
