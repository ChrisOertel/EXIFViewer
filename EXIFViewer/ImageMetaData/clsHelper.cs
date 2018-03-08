using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Imaging;

namespace de.coe.components.Image
{
    class ImgMetaDataHelper
    {

        internal static PropertyItem GetPropertyItem(PropertyItem[] Items, int siID)
        {
            PropertyItem soReturn = null;
            
            foreach (System.Drawing.Imaging.PropertyItem soItem in Items)
            {
                if (soItem.Id == siID)
                {
                    soReturn = soItem;
                    break;
                }
            }
            return soReturn;
        }

        internal static string GetPropertyValue(PropertyItem[] Items, int siID)
        {
            Encoding soAscii = Encoding.ASCII;
            string ssValue = "";
            PropertyItem soItem = GetPropertyItem(Items, siID);

            if (soItem != null)
            {
                if (soItem.Value != null)
                {
                    //1 = BYTE An 8-bit unsigned integer.,
                    if (soItem.Type == 0x1)
                    {
                        switch (soItem.Id)
                        {
                            case 0:
                                ssValue = soItem.Value[0].ToString();
                                for (int i = 1; i < soItem.Value.Length; i++)
                                {
                                    ssValue += "." + soItem.Value[i].ToString();
                                }
                                break;
                            default:
                                ssValue = soItem.Value[0].ToString();
                                break;
                        }
                    }
                    //2 = ASCII An 8-bit byte containing one 7-bit ASCII code. The final byte is terminated with NULL.,
                    else if (soItem.Type == 0x2)
                    {
                        // string					
                        ssValue = soAscii.GetString(soItem.Value);
                    }
                    //3 = SHORT A 16-bit (2 -byte) unsigned integer,
                    else if (soItem.Type == 0x3)
                    {
                        // orientation // lookup table					
                        switch (soItem.Id)
                        {
                            case 0x8827: // ISO
                                ssValue = convertToInt16U(soItem.Value).ToString();
                                break;
                            case 0xA217: // sensing method
                                {
                                    switch (convertToInt16U(soItem.Value))
                                    {
                                        case 1: ssValue = Properties.Resources.SensingMethod1; break;
                                        case 2: ssValue = Properties.Resources.SensingMethod2; break;
                                        case 3: ssValue = Properties.Resources.SensingMethod3; break;
                                        case 4: ssValue = Properties.Resources.SensingMethod4; break;
                                        case 5: ssValue = Properties.Resources.SensingMethod5; break;
                                        case 7: ssValue = Properties.Resources.SensingMethod7; break;
                                        case 8: ssValue = Properties.Resources.SensingMethod8; break;
                                        default: ssValue = Properties.Resources.SensingMethodDefault; break;
                                    }
                                }
                                break;
                            case 0x112: // Orientation
                                switch (convertToInt16U(soItem.Value))
                                {
                                    case 1: ssValue = Properties.Resources.Orientation1; break;
                                    case 2: ssValue = Properties.Resources.Orientation2; break;
                                    case 3: ssValue = Properties.Resources.Orientation3; break;
                                    case 4: ssValue = Properties.Resources.Orientation4; break;
                                    case 5: ssValue = Properties.Resources.Orientation5; break;
                                    case 6: ssValue = Properties.Resources.Orientation6; break;
                                    case 7: ssValue = Properties.Resources.Orientation7; break;
                                    case 8: ssValue = Properties.Resources.Orientation8; break;
                                    default: ssValue = Properties.Resources.OrientationDefault; break;
                                }
                                break;
                            case 0x8822: // aperture 
                                switch (convertToInt16U(soItem.Value))
                                {
                                    case 0: ssValue = Properties.Resources.Aperture0; break;
                                    case 1: ssValue = Properties.Resources.Aperture1; break;
                                    case 2: ssValue = Properties.Resources.Aperture2; break;
                                    case 3: ssValue = Properties.Resources.Aperture3; break;
                                    case 4: ssValue = Properties.Resources.Aperture4; break;
                                    case 5: ssValue = Properties.Resources.Aperture5; break;
                                    case 6: ssValue = Properties.Resources.Aperture6; break;
                                    case 7: ssValue = Properties.Resources.Aperture7; break;
                                    case 8: ssValue = Properties.Resources.Aperture8; break;
                                    default: ssValue = Properties.Resources.ApertureDefault; break;
                                }
                                break;
                            case 0x9207: // metering mode
                                switch (convertToInt16U(soItem.Value))
                                {
                                    case 0: ssValue = Properties.Resources.MeteringMode0; break;
                                    case 1: ssValue = Properties.Resources.MeteringMode1; break;
                                    case 2: ssValue = Properties.Resources.MeteringMode2; break;
                                    case 3: ssValue = Properties.Resources.MeteringMode3; break;
                                    case 4: ssValue = Properties.Resources.MeteringMode4; break;
                                    case 5: ssValue = Properties.Resources.MeteringMode5; break;
                                    case 6: ssValue = Properties.Resources.MeteringMode6; break;
                                    case 255: ssValue = Properties.Resources.MeteringMode255; break;
                                    default: ssValue = Properties.Resources.MeteringModeDefault; break;
                                }
                                break;
                            case 0x9208: // light source
                                {
                                    switch (convertToInt16U(soItem.Value))
                                    {
                                        case 0: ssValue = Properties.Resources.LightSource0; break;
                                        case 1: ssValue = Properties.Resources.LightSource1; break;
                                        case 2: ssValue = Properties.Resources.LightSource2; break;
                                        case 3: ssValue = Properties.Resources.LightSource3; break;
                                        case 4: ssValue = Properties.Resources.LightSource4; break;
                                        case 9: ssValue = Properties.Resources.LightSource9; break;
                                        case 10: ssValue = Properties.Resources.LightSource10; break;
                                        case 11: ssValue = Properties.Resources.LightSource11; break;
                                        case 12: ssValue = Properties.Resources.LightSource12; break;
                                        case 13: ssValue = Properties.Resources.LightSource13; break;
                                        case 14: ssValue = Properties.Resources.LightSource14; break;
                                        case 15: ssValue = Properties.Resources.LightSource15; break;
                                        case 17: ssValue = Properties.Resources.LightSource17; break;
                                        case 18: ssValue = Properties.Resources.LightSource18; break;
                                        case 19: ssValue = Properties.Resources.LightSource19; break;
                                        case 20: ssValue = Properties.Resources.LightSource20; break;
                                        case 21: ssValue = Properties.Resources.LightSource21; break;
                                        case 22: ssValue = Properties.Resources.LightSource22; break;
                                        case 23: ssValue = Properties.Resources.LightSource23; break;
                                        case 24: ssValue = Properties.Resources.LightSource24; break;
                                        case 255: ssValue = Properties.Resources.LightSource255; break;
                                        default: ssValue = Properties.Resources.LightSourceDefault; break;
                                    }
                                }
                                break;
                            case 0x0128: //ResolutionUnit
                                {
                                    switch (convertToInt16U(soItem.Value))
                                    {
                                        case 2: ssValue = Properties.Resources.ResolutionUnit2; break;
                                        case 3: ssValue = Properties.Resources.ResolutionUnit3; break;
                                        default: ssValue = Properties.Resources.ResolutionUnitDefault; break;
                                    }
                                }
                                break;
                            //case 0x9209:
                            //    {
                            //        switch (convertToInt16U(soItem.Value))
                            //        {
                            //            case 0: ssValue = Properties.Resources.Flash0; break;
                            //            case 1: ssValue = Properties.Resources.Flash1; break;
                            //            case 5: ssValue = Properties.Resources.Flash3; break;
                            //            case 7: ssValue = Properties.Resources.Flash4; break;
                            //            default: ssValue = Properties.Resources.FlashDefault; break;
                            //        }
                            //    }
                            //break;
                            case 0xA402: //ExposureMode
                                switch (convertToInt16U(soItem.Value))
                                {
                                    case 0: ssValue = Properties.Resources.ExposureMode0; break;
                                    case 1: ssValue = Properties.Resources.ExposureMode1; break;
                                    case 2: ssValue = Properties.Resources.ExposureMode2; break;
                                    default: ssValue = Properties.Resources.ExposureModeDefault; break;
                                }
                                break;
                            case 0xA401: //CustomRendered
                                switch (convertToInt16U(soItem.Value))
                                {
                                    case 0: ssValue = Properties.Resources.CustomRendered0; break;
                                    case 1: ssValue = Properties.Resources.CustomRendered1; break;
                                    default: ssValue = Properties.Resources.CustomRenderedDefault; break;
                                }
                                break;
                            case 0xA403: //WhiteBalance
                                switch (convertToInt16U(soItem.Value))
                                {
                                    case 0: ssValue = Properties.Resources.WhiteBalance0; break;
                                    case 1: ssValue = Properties.Resources.WhiteBalance1; break;
                                    default: ssValue = Properties.Resources.WhiteBalanceDefault; break;
                                }
                                break;
                            case 0xA406: //SceneCaptureType
                                switch (convertToInt16U(soItem.Value))
                                {
                                    case 0: ssValue = Properties.Resources.SceneCaptureType0; break;
                                    case 1: ssValue = Properties.Resources.SceneCaptureType1; break;
                                    case 2: ssValue = Properties.Resources.SceneCaptureType2; break;
                                    case 3: ssValue = Properties.Resources.SceneCaptureType3; break;
                                    default: ssValue = Properties.Resources.SceneCaptureTypeDefault; break;
                                }
                                break;
                            case 0xA407: //GainControl
                                switch (convertToInt16U(soItem.Value))
                                {
                                    case 0: ssValue = Properties.Resources.GainControl0; break;
                                    case 1: ssValue = Properties.Resources.GainControl1; break;
                                    case 2: ssValue = Properties.Resources.GainControl2; break;
                                    case 3: ssValue = Properties.Resources.GainControl3; break;
                                    case 4: ssValue = Properties.Resources.GainControl4; break;
                                    default: ssValue = Properties.Resources.GainControlDefault; break;
                                }
                                break;
                            case 0xA408: //Contrast
                                switch (convertToInt16U(soItem.Value))
                                {
                                    case 0: ssValue = Properties.Resources.Contrast0; break;
                                    case 1: ssValue = Properties.Resources.Contrast1; break;
                                    case 2: ssValue = Properties.Resources.Contrast2; break;
                                    default: ssValue = Properties.Resources.ContrastDefault; break;
                                }
                                break;
                            case 0xA409: //Saturation
                                switch (convertToInt16U(soItem.Value))
                                {
                                    case 0: ssValue = Properties.Resources.Saturation0; break;
                                    case 1: ssValue = Properties.Resources.Saturation1; break;
                                    case 2: ssValue = Properties.Resources.Saturation2; break;
                                    default: ssValue = Properties.Resources.SaturationDefault; break;
                                }
                                break;
                            case 0xA40A: //Sharpness
                                switch (convertToInt16U(soItem.Value))
                                {
                                    case 0: ssValue = Properties.Resources.Sharpness0; break;
                                    case 1: ssValue = Properties.Resources.Sharpness1; break;
                                    case 2: ssValue = Properties.Resources.Sharpness2; break;
                                    default: ssValue = Properties.Resources.SharpnessDefault; break;
                                }
                                break;
                            case 0xA40C: //SubjectDistanceRange
                                switch (convertToInt16U(soItem.Value))
                                {
                                    case 0: ssValue = Properties.Resources.SubjectDistanceRange0; break;
                                    case 1: ssValue = Properties.Resources.SubjectDistanceRange1; break;
                                    case 2: ssValue = Properties.Resources.SubjectDistanceRange2; break;
                                    case 3: ssValue = Properties.Resources.SubjectDistanceRange3; break;
                                    default: ssValue = Properties.Resources.SubjectDistanceRangeDefault; break;
                                }
                                break;
                            default:
                                ssValue = convertToInt16U(soItem.Value).ToString();
                                break;
                        }
                    }
                    //4 = LONG A 32-bit (4 -byte) unsigned integer,
                    else if (soItem.Type == 0x4)
                    {
                        // orientation // lookup table					
                        ssValue = convertToInt32U(soItem.Value).ToString();
                    }
                    //5 = RATIONAL Two LONGs. The first LONG is the numerator and the second LONG expresses the//denominator.,
                    else if (soItem.Type == 0x5)
                    {
                        URational r = new URational(soItem.Value);
                        //
                        //convert here
                        //
                        switch (soItem.Id)
                        {
                            case 0x9202: // aperture
                                ssValue = "f " + Math.Round(Math.Pow(Math.Sqrt(2), r.ToDouble()), 2).ToString("0.00");
                                break;
                            case 0x920A:
                                ssValue = r.ToDouble().ToString();
                                break;
                            case 0x829A:
                                ssValue = r.ToString("/");
                                if (ssValue.IndexOf("/1") != -1)
                                { ssValue = Convert.ToInt16(ssValue.Substring(0, ssValue.IndexOf("/1"))).ToString("0.0"); }
                                break;
                            case 0x829D: // F-number
                                ssValue = "F/" + r.ToDouble().ToString();
                                break;
                            case 0xA20E: // FocalPlaneXResolution
                                ssValue = Math.Round(r.ToDouble()).ToString();
                                break;
                            case 0xA20F: // FocalPlaneYResolution
                                ssValue = Math.Round(r.ToDouble()).ToString();
                                break;
                            case 0x9205: //MaxAparture
                                ssValue = r.ToDouble().ToString();
                                break;
                            case 0x2: // GPSLatitude                                
                                ssValue = new GPSRational(soItem.Value).ToString();
                                break;
                            case 0x4: // GPSLongitude
                                ssValue = new GPSRational(soItem.Value).ToString();
                                break;
                            case 0x7: // GPSTimeStamp                                
                                ssValue = new GPSRational(soItem.Value).ToString(":");
                                break;
                            default:
                                ssValue = r.ToString("/");
                                break;
                        }

                    }
                    //7 = UNDEFINED An 8-bit byte that can take any value depending on the field definition,
                    else if (soItem.Type == 0x7)
                    {
                        switch (soItem.Id)
                        {
                            case 0xA300:
                                {
                                    if (soItem.Value[0] == 3)
                                    {
                                        ssValue = Properties.Resources.ImageSource3;
                                    }
                                    else
                                    {
                                        ssValue = Properties.Resources.ImageSourceDefault;
                                    }
                                    break;
                                }
                            case 0xA301:
                                if (soItem.Value[0] == 1)
                                    ssValue = Properties.Resources.SceneType1;
                                else
                                    ssValue = Properties.Resources.SceneTypeDefault;
                                break;
                            case 0x9000:
                                if (soItem.Value != null)
                                { ssValue = ((double)Convert.ToInt16(soAscii.GetString(soItem.Value)) / 100).ToString().Replace(",", "."); }
                                break;
                            default:
                                if (soItem.Value != null)
                                { ssValue = soAscii.GetString(soItem.Value); }
                                break;
                        }
                    }
                    //9 = SLONG A 32-bit (4 -byte) signed integer (2's complement notation),
                    else if (soItem.Type == 0x9)
                    {
                        ssValue = convertToInt32(soItem.Value).ToString();
                    }
                    //10 = SRATIONAL Two SLONGs. The first SLONG is the numerator and the second SLONG is the denominator.
                    else if (soItem.Type == 0xA)
                    {
                        Rational r = new Rational(soItem.Value);
                        switch (soItem.Id)
                        {
                            case 0x9201: // shutter speed
                                ssValue = "1/" + Math.Round(Math.Pow(2, r.ToDouble()), 2).ToString();
                                break;
                            case 0x9203:
                                ssValue = Math.Round(r.ToDouble(), 4).ToString();
                                break;
                            case 0x9204:
                                ssValue = Math.Round(r.ToDouble(), 4).ToString("0.00") + " EV";
                                break;
                            default:
                                ssValue = r.ToString("/");
                                break;
                        }
                    }
                }
            }
            return ssValue;
        }

        private static int convertToInt32(byte[] arr)
        {
            if (arr.Length != 4)
                return 0;
            else
                return arr[3] << 24 | arr[2] << 16 | arr[1] << 8 | arr[0];
        }

        private static int convertToInt16(byte[] arr)
        {
            if (arr.Length != 2)
                return 0;
            else
                return arr[1] << 8 | arr[0];
        }

        private static uint convertToInt32U(byte[] arr)
        {
            if (arr.Length != 4)
                return 0;
            else
                return Convert.ToUInt32(arr[3] << 24 | arr[2] << 16 | arr[1] << 8 | arr[0]);
        }

        private static uint convertToInt16U(byte[] arr)
        {
            if (arr.Length != 2)
                return 0;
            else
                return Convert.ToUInt16(arr[1] << 8 | arr[0]);
        }

        public static string GetBits(byte inByte)
        {
            byte Testbyte = 128;
            string bits = "";
            int i;
            for (i = 1; i <= 8; i++)
            {
                if ((inByte & Testbyte) == Testbyte)
                {
                    bits += "1";
                }
                else
                {
                    bits += "0";
                }
                Testbyte = (byte)(Testbyte >> 1);
            }
            return bits;
        } 

        internal sealed class Rational
        {
            private Int32 _num;
            private Int32 _denom;

            public Rational(byte[] bytes)
            {
                byte[] n = new byte[4];
                byte[] d = new byte[4];
                Array.Copy(bytes, 0, n, 0, 4);
                Array.Copy(bytes, 4, d, 0, 4);
                _num = BitConverter.ToInt32(n, 0);
                _denom = BitConverter.ToInt32(d, 0);
            }

            public double ToDouble()
            {
                return Math.Round(Convert.ToDouble(_num) / Convert.ToDouble(_denom), 2);
            }

            public string ToString(string separator)
            {
                return _num.ToString() + separator + _denom.ToString();
            }

            public override string ToString()
            {
                return this.ToString("/");
            }
        }

        internal sealed class URational
        {
            private UInt32 _num;
            private UInt32 _denom;

            public URational(byte[] bytes)
            {
                byte[] n = new byte[4];
                byte[] d = new byte[4];
                Array.Copy(bytes, 0, n, 0, 4);
                Array.Copy(bytes, 4, d, 0, 4);
                _num = BitConverter.ToUInt32(n, 0);
                _denom = BitConverter.ToUInt32(d, 0);
            }

            public double ToDouble()
            {
                return Math.Round(Convert.ToDouble(_num) / Convert.ToDouble(_denom), 2);
            }

            public override string ToString()
            {
                return this.ToString("/");
            }

            public string ToString(string separator)
            {
                return _num.ToString() + separator + _denom.ToString();
            }
        }

        internal sealed class GPSRational
        {
            private Rational _hours;
            private Rational _minutes;
            private Rational _seconds;

            public Rational Hours
            {
                get
                {
                    return _hours;
                }
                set
                {
                    _hours = value;
                }
            }
            public Rational Minutes
            {
                get
                {
                    return _minutes;
                }
                set
                {
                    _minutes = value;
                }
            }
            public Rational Seconds
            {
                get
                {
                    return _seconds;
                }
                set
                {
                    _seconds = value;
                }
            }

            public GPSRational(byte[] bytes)
            {
                byte[] h = new byte[8]; byte[] m = new byte[8]; byte[] s = new byte[8];

                Array.Copy(bytes, 0, h, 0, 8); Array.Copy(bytes, 8, m, 0, 8); Array.Copy(bytes, 16, s, 0, 8);

                _hours = new Rational(h);
                _minutes = new Rational(m);
                _seconds = new Rational(s);
            }

            public override string ToString()
            {
                return _hours.ToDouble() + "° "
                    + _minutes.ToDouble() + "\' "
                    + _seconds.ToDouble() + "\"";
            }

            public string ToString(string separator)
            {
                return _hours.ToDouble() + separator
                    + _minutes.ToDouble() + separator +
                    _seconds.ToDouble();
            }
        }

    }
}
