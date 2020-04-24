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
    public struct NNS_VECTOR4D : IClearable
    {
        public float x;
        public float y;
        public float z;
        public float w;

        public NNS_VECTOR4D(float _x, float _y, float _z)
        {
            this.x = _x;
            this.y = _y;
            this.z = _z;
            this.w = 0;
        }

        public NNS_VECTOR4D Assign(NNS_VECTOR vec)
        {
            this.x = vec.x;
            this.y = vec.y;
            this.z = vec.z;
            return this;
        }

        public NNS_VECTOR4D Assign(ref SNNS_VECTOR vec)
        {
            this.x = vec.x;
            this.y = vec.y;
            this.z = vec.z;
            return this;
        }

        public void Clear()
        {
            this.x = this.y = this.z = this.w = 0.0f;
        }

        internal NNS_VECTOR4D Assign(VecFx32 vec)
        {
            this.x = (float)vec.x;
            this.y = (float)vec.y;
            this.z = (float)vec.z;
            return this;
        }

        public void Assign(NNS_VECTOR4D v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
            this.w = v.w;
        }

        public static explicit operator OpenGL.glArray4f(NNS_VECTOR4D v)
        {
            return new OpenGL.glArray4f(v.x, v.y, v.z, v.w);
        }

        public static explicit operator float[] (NNS_VECTOR4D v)
        {
            return new float[4] { v.x, v.y, v.z, v.w };
        }

        public static explicit operator NNS_VECTOR(NNS_VECTOR4D v)
        {
            return new NNS_VECTOR(v.x, v.y, v.z);
        }
    }
}
