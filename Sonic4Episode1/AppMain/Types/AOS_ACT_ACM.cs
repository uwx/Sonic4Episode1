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
    public class AOS_ACT_ACM
    {
        public float trans_x;
        public float trans_y;
        public float trans_z;
        public AppMain.AOS_ACT_COL color;
        public AppMain.AOS_ACT_COL fade;
        public float trans_scale_x;
        public float trans_scale_y;
        public float scale_x;
        public float scale_y;
        public float rotate;

        public void Clear()
        {
            this.trans_x = this.trans_y = this.trans_z = 0.0f;
            this.trans_scale_x = this.trans_scale_y = 0.0f;
            this.scale_x = this.scale_y = 0.0f;
            this.rotate = 0.0f;
            this.color.Clear();
            this.fade.Clear();
        }

        public void Assign(AppMain.AOS_ACT_ACM acm)
        {
            this.trans_x = acm.trans_x;
            this.trans_y = acm.trans_y;
            this.trans_z = acm.trans_z;
            this.color = acm.color;
            this.fade = acm.fade;
            this.trans_scale_x = acm.trans_scale_x;
            this.trans_scale_y = acm.trans_scale_y;
            this.scale_x = acm.scale_x;
            this.scale_y = acm.scale_y;
            this.rotate = acm.rotate;
        }
    }
}
