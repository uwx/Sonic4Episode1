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
    public class NNS_RGBA_U8
    {
        public byte r;
        public byte g;
        public byte b;
        public byte a;

        public NNS_RGBA_U8(byte _r, byte _g, byte _b, byte _a)
        {
            this.r = _r;
            this.g = _g;
            this.b = _b;
            this.a = _a;
        }

        public NNS_RGBA_U8()
        {
        }

        public static int SizeOf()
        {
            return 4;
        }
    }
}
