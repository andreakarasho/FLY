﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace FLY.Mathematics
{
    public struct Color : IEquatable<Color>, IEquatable<uint>
    {
        public byte R, G, B, A;


        public Color(uint rgba)
        {
            R = (byte)rgba;
            G = (byte)(rgba >> 8);
            B = (byte)(rgba >> 16);
            A = (byte)(rgba >> 24);
        }

        public Color(byte r, byte g, byte b, byte a = 0xFF)
        {
            (R, G, B, A) = (r, g, b, a);
        }

        public Color(Vector3 vec) : this(vec.X, vec.Y, vec.Z)
        {

        }

        public Color(Vector4 vec) : this(vec.X, vec.Y, vec.Z, vec.W)
        {

        }

        public Color(float r, float g, float b, float a = 1f) 
        {
            R = (byte) FLYMath.Clamp(r * 255, byte.MinValue, byte.MaxValue);
            G = (byte) FLYMath.Clamp(g * 255, byte.MinValue, byte.MaxValue);
            B = (byte) FLYMath.Clamp(b * 255, byte.MinValue, byte.MaxValue);
            A = (byte) FLYMath.Clamp(a * 255, byte.MinValue, byte.MaxValue);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetValue(uint rgba)
        {
            R = (byte) (rgba & 0xFF);
            G = (byte) ((rgba >> 8) & 0xFF);
            B = (byte) ((rgba >> 16) & 0xFF);
            A = (byte) ((rgba >> 24) & 0xFF);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint GetValue() => (uint) (R | (G << 8) | (B << 16) | (A << 24));


        public Vector4 ToVector4() => new Vector4(R / 255.0f, G / 255.0f, B / 255.0f, A / 255.0f);


		public bool Equals(Color other)
        {
            return (R, G, B, A) == (other.R, G, B, A);
        }

        public bool Equals(uint other)
        {
            return GetValue() == other;
        }


        public override string ToString()
        {
            return $"R: {R}, G: {G}, B: {B}, A: {A} - #{GetValue():X8}";
        }


        public static implicit operator Color(uint val)
        {
            return new Color(val);
        }


		public static readonly Color Transparent = new Color(0);
		public static readonly Color AliceBlue = new Color(0xfffff8f0);
		public static readonly Color AntiqueWhite = new Color(0xffd7ebfa);
		public static readonly Color Aqua = new Color(0xffffff00);
		public static readonly Color Aquamarine = new Color(0xffd4ff7f);
		public static readonly Color Azure = new Color(0xfffffff0);
		public static readonly Color Beige = new Color(0xffdcf5f5);
		public static readonly Color Bisque = new Color(0xffc4e4ff);
		public static readonly Color Black = new Color(0xff000000);
		public static readonly Color BlanchedAlmond = new Color(0xffcdebff);
		public static readonly Color Blue = new Color(0xffff0000);
		public static readonly Color BlueViolet = new Color(0xffe22b8a);
		public static readonly Color Brown = new Color(0xff2a2aa5);
		public static readonly Color BurlyWood = new Color(0xff87b8de);
		public static readonly Color CadetBlue = new Color(0xffa09e5f);
		public static readonly Color Chartreuse = new Color(0xff00ff7f);
		public static readonly Color Chocolate = new Color(0xff1e69d2);
		public static readonly Color Coral = new Color(0xff507fff);
		public static readonly Color CornflowerBlue = new Color(0xffed9564);
		public static readonly Color Cornsilk = new Color(0xffdcf8ff);
		public static readonly Color Crimson = new Color(0xff3c14dc);
		public static readonly Color Cyan = new Color(0xffffff00);
		public static readonly Color DarkBlue = new Color(0xff8b0000);
		public static readonly Color DarkCyan = new Color(0xff8b8b00);
		public static readonly Color DarkGoldenrod = new Color(0xff0b86b8);
		public static readonly Color DarkGray = new Color(0xffa9a9a9);
		public static readonly Color DarkGreen = new Color(0xff006400);
		public static readonly Color DarkKhaki = new Color(0xff6bb7bd);
		public static readonly Color DarkMagenta = new Color(0xff8b008b);
		public static readonly Color DarkOliveGreen = new Color(0xff2f6b55);
		public static readonly Color DarkOrange = new Color(0xff008cff);
		public static readonly Color DarkOrchid = new Color(0xffcc3299);
		public static readonly Color DarkRed = new Color(0xff00008b);
		public static readonly Color DarkSalmon = new Color(0xff7a96e9);
		public static readonly Color DarkSeaGreen = new Color(0xff8bbc8f);
		public static readonly Color DarkSlateBlue = new Color(0xff8b3d48);
		public static readonly Color DarkSlateGray = new Color(0xff4f4f2f);
		public static readonly Color DarkTurquoise = new Color(0xffd1ce00);
		public static readonly Color DarkViolet = new Color(0xffd30094);
		public static readonly Color DeepPink = new Color(0xff9314ff);
		public static readonly Color DeepSkyBlue = new Color(0xffffbf00);
		public static readonly Color DimGray = new Color(0xff696969);
		public static readonly Color DodgerBlue = new Color(0xffff901e);
		public static readonly Color Firebrick = new Color(0xff2222b2);
		public static readonly Color FloralWhite = new Color(0xfff0faff);
		public static readonly Color ForestGreen = new Color(0xff228b22);
		public static readonly Color Fuchsia = new Color(0xffff00ff);
		public static readonly Color Gainsboro = new Color(0xffdcdcdc);
		public static readonly Color GhostWhite = new Color(0xfffff8f8);
		public static readonly Color Gold = new Color(0xff00d7ff);
		public static readonly Color Goldenrod = new Color(0xff20a5da);
		public static readonly Color Gray = new Color(0xff808080);
		public static readonly Color Green = new Color(0xff008000);
		public static readonly Color GreenYellow = new Color(0xff2fffad);
		public static readonly Color Honeydew = new Color(0xfff0fff0);
		public static readonly Color HotPink = new Color(0xffb469ff);
		public static readonly Color IndianRed = new Color(0xff5c5ccd);
		public static readonly Color Indigo = new Color(0xff82004b);
		public static readonly Color Ivory = new Color(0xfff0ffff);
		public static readonly Color Khaki = new Color(0xff8ce6f0);
		public static readonly Color Lavender = new Color(0xfffae6e6);
		public static readonly Color LavenderBlush = new Color(0xfff5f0ff);
		public static readonly Color LawnGreen = new Color(0xff00fc7c);
		public static readonly Color LemonChiffon = new Color(0xffcdfaff);
		public static readonly Color LightBlue = new Color(0xffe6d8ad);
		public static readonly Color LightCoral = new Color(0xff8080f0);
		public static readonly Color LightCyan = new Color(0xffffffe0);
		public static readonly Color LightGoldenrodYellow = new Color(0xffd2fafa);
		public static readonly Color LightGray = new Color(0xffd3d3d3);
		public static readonly Color LightGreen = new Color(0xff90ee90);
		public static readonly Color LightPink = new Color(0xffc1b6ff);
		public static readonly Color LightSalmon = new Color(0xff7aa0ff);
		public static readonly Color LightSeaGreen = new Color(0xffaab220);
		public static readonly Color LightSkyBlue = new Color(0xffface87);
		public static readonly Color LightSlateGray = new Color(0xff998877);
		public static readonly Color LightSteelBlue = new Color(0xffdec4b0);
		public static readonly Color LightYellow = new Color(0xffe0ffff);
		public static readonly Color Lime = new Color(0xff00ff00);
		public static readonly Color LimeGreen = new Color(0xff32cd32);
		public static readonly Color Linen = new Color(0xffe6f0fa);
		public static readonly Color Magenta = new Color(0xffff00ff);
		public static readonly Color Maroon = new Color(0xff000080);
		public static readonly Color MediumAquamarine = new Color(0xffaacd66);
		public static readonly Color MediumBlue = new Color(0xffcd0000);
		public static readonly Color MediumOrchid = new Color(0xffd355ba);
		public static readonly Color MediumPurple = new Color(0xffdb7093);
		public static readonly Color MediumSeaGreen = new Color(0xff71b33c);
		public static readonly Color MediumSlateBlue = new Color(0xffee687b);
		public static readonly Color MediumSpringGreen = new Color(0xff9afa00);
		public static readonly Color MediumTurquoise = new Color(0xffccd148);
		public static readonly Color MediumVioletRed = new Color(0xff8515c7);
		public static readonly Color MidnightBlue = new Color(0xff701919);
		public static readonly Color MintCream = new Color(0xfffafff5);
		public static readonly Color MistyRose = new Color(0xffe1e4ff);
		public static readonly Color Moccasin = new Color(0xffb5e4ff);
		public static readonly Color NavajoWhite = new Color(0xffaddeff);
		public static readonly Color Navy = new Color(0xff800000);
		public static readonly Color OldLace = new Color(0xffe6f5fd);
		public static readonly Color Olive = new Color(0xff008080);
		public static readonly Color OliveDrab = new Color(0xff238e6b);
		public static readonly Color Orange = new Color(0xff00a5ff);
		public static readonly Color OrangeRed = new Color(0xff0045ff);
		public static readonly Color Orchid = new Color(0xffd670da);
		public static readonly Color PaleGoldenrod = new Color(0xffaae8ee);
		public static readonly Color PaleGreen = new Color(0xff98fb98);
		public static readonly Color PaleTurquoise = new Color(0xffeeeeaf);
		public static readonly Color PaleVioletRed = new Color(0xff9370db);
		public static readonly Color PapayaWhip = new Color(0xffd5efff);
		public static readonly Color PeachPuff = new Color(0xffb9daff);
		public static readonly Color Peru = new Color(0xff3f85cd);
		public static readonly Color Pink = new Color(0xffcbc0ff);
		public static readonly Color Plum = new Color(0xffdda0dd);
		public static readonly Color PowderBlue = new Color(0xffe6e0b0);
		public static readonly Color Purple = new Color(0xff800080);
		public static readonly Color Red = new Color(0xff0000ff);
		public static readonly Color RosyBrown = new Color(0xff8f8fbc);
		public static readonly Color RoyalBlue = new Color(0xffe16941);
		public static readonly Color SaddleBrown = new Color(0xff13458b);
		public static readonly Color Salmon= new Color(0xff7280fa);
		public static readonly Color SandyBrown = new Color(0xff60a4f4);
		public static readonly Color SeaGreen = new Color(0xff578b2e);
		public static readonly Color SeaShell = new Color(0xffeef5ff);
		public static readonly Color Sienna = new Color(0xff2d52a0);
		public static readonly Color Silver = new Color(0xffc0c0c0);
		public static readonly Color SkyBlue = new Color(0xffebce87);
		public static readonly Color SlateBlue= new Color(0xffcd5a6a);
		public static readonly Color SlateGray= new Color(0xff908070);
		public static readonly Color Snow= new Color(0xfffafaff);
		public static readonly Color SpringGreen= new Color(0xff7fff00);
		public static readonly Color SteelBlue= new Color(0xffb48246);
		public static readonly Color Tan= new Color(0xff8cb4d2);
		public static readonly Color Teal= new Color(0xff808000);
		public static readonly Color Thistle= new Color(0xffd8bfd8);
		public static readonly Color Tomato= new Color(0xff4763ff);
		public static readonly Color Turquoise= new Color(0xffd0e040);
		public static readonly Color Violet= new Color(0xffee82ee);
		public static readonly Color Wheat= new Color(0xffb3def5);
		public static readonly Color White= new Color(uint.MaxValue);
		public static readonly Color WhiteSmoke= new Color(0xfff5f5f5);
		public static readonly Color Yellow = new Color(0xff00ffff);
		public static readonly Color YellowGreen = new Color(0xff32cd9a);
	}
}
