using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace de.coe.components.Image
{
    /// <summary>
    /// The ImgMetaDataJPEG Class handles the acces to the exif information of a JPEG image.
    /// </summary>
    [GuidAttribute("CA3B9E6D-8713-490b-8590-4138A2A4DCD0"),
    ProgId("coeImageMetaData.ImgMetaDataJPEG"),
    ClassInterfaceAttribute(ClassInterfaceType.AutoDual)]
    public class ImgMetaDataJPEG : GlobalizedObject, de.coe.components.Image.IImgMetaDataFileType
    {
        private System.IO.FileInfo moInfo = null;
        private ImageMetaData.enImageType miFileType = ImageMetaData.enImageType.JPEG;
        PropertyItem[] moItems = null;

        /// <summary>
        /// Instances a new ImgMetaDataJPEG class.
        /// </summary>
        public ImgMetaDataJPEG()
        { }

#region "Prozeduren"

        internal void SetProperties(PropertyItem[] soItems, System.IO.FileInfo Info)
        {
            moInfo = Info;
            moItems = soItems;
        }

#endregion

#region "Properties"

#region "File"

        /// <summary>
        /// Path and Name of the image.
        /// </summary>
        [SRCategory("Category_File"), GlobalizedProperty()]
        public string FileName
        {
            get { return moInfo.FullName; }
        }

        /// <summary>
        /// Type of the image (always JPEG).
        /// </summary>
        [SRCategory("Category_File"), GlobalizedProperty()]
        public ImageMetaData.enImageType FileType
        {
            get { return miFileType; }
        }

        /// <summary>
        /// Actual filesize in MB.
        /// </summary>
        [SRCategory("Category_File"), GlobalizedProperty()]
        public string FileSize
        {
            get { return Math.Round((double)moInfo.Length / 1024 / 1024, 2).ToString() + " MB"; }
        }

#endregion

#region "Camera"

        /// <summary>
        /// The manufacturer of the recording equipment. This is the manufacturer of the DSC, scanner, video digitizer or other equipment that generated the image. When the field is left blank, it is treated as unknown.
        /// </summary>
        [SRCategory("Category_Camera"), GlobalizedProperty()]
        public string EquipMake
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x10F); }
        }

        /// <summary>
        /// The model name or model number of the equipment. This is the model name of number of the DSC, scanner, video digitizer or other equipment that generated the image. When the field is left blank, it is treated as unknown.
        /// </summary>
        [SRCategory("Category_Camera"), GlobalizedProperty()]
        public string EquipModel
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x110); }
        }

        /// <summary>
        /// This tag records the name and version of the software or firmware of the camera or image input device used to generate the image. The detailed format is not specified, but it is recommended that the example shown below be followed. When the field is left blank, it is treated as unknown.
        /// </summary>
        [SRCategory("Category_Camera"), GlobalizedProperty()]
        public string Software
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x131); }
        }

#endregion

#region "GPS"

        /// <summary>
        /// Version of the Global Positioning Systems (GPS) IFD, given as 2.0.0.0. This tag is mandatory when the GpsIFD tag is present. When the version is 2.0.0.0, the tag value is 0x02000000.
        /// </summary>
        [SRCategory("Category_GPS"), GlobalizedProperty()]
        public string GpsVersion
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x0); }
        }

        /// <summary>
        /// Indicates the GPS latitude. The latitude is expressed as three RATIONAL values giving the degrees, minutes, and seconds, respectively. When degrees, minutes and seconds are expressed, the format is dd/1,mm/1,ss/1. When degrees and minutes are used and, for example, fractions of minutes are given up to two decimal places, the format is dd/1,mmmm/100,0/1.
        /// </summary>
        [SRCategory("Category_GPS"), GlobalizedProperty()]
        public string GpsLatitude
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x2) + " " + ImgMetaDataHelper.GetPropertyValue(moItems, 0x1); }
        }

        /// <summary>
        /// Indicates whether the latitude is north or south latitude. The ASCII value 'N' indicates north latitude, and 'S' is south latitude.
        /// </summary>
        [BrowsableAttribute(false)]
        public string GpsLatitudeRef
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x1); }
        }

        /// <summary>
        /// Indicates whether the longitude is east or west longitude. The ASCII value 'E' indicates east longitude, and 'W' is west longitude.
        /// </summary>
        [BrowsableAttribute(false)]
        public string GpsLongitudeRef
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x3); }
        }

        /// <summary>
        /// Indicates the GPS longitude. The longitude is expressed as three RATIONAL values giving the degrees, minutes, and seconds, respectively. When degrees, minutes and seconds are expressed, the format is ddd/1,mm/1,ss/1. When degrees and minutes are used and, for example, fractions of minutes are given up to two decimal places, the format is ddd/1,mmmm/100,0/1.
        /// </summary>
        [SRCategory("Category_GPS"), GlobalizedProperty()]
        public string GpsLongitude
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x0004) + " " + ImgMetaDataHelper.GetPropertyValue(moItems, 0x3);}
        }

        /// <summary>
        /// Reference altitude, in meters (0=sealevel).
        /// </summary>
        [BrowsableAttribute(false)]
        public string GpsAltitudeRef
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5); }
        }

        /// <summary>
        /// Altitude, in meters, based on the reference altitude specified by GpsAltitudeRef.
        /// </summary>
        [BrowsableAttribute(false)]
        public string GpsAltitude
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x6); }
        }

        /// <summary>
        /// Time as coordinated universal time (UTC). The value is expressed as three rational numbers that give the hour, minute, and second.
        /// </summary>
        [SRCategory("Category_GPS"), GlobalizedProperty()]
        public string GpsTime
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x7); }
        }

        /// <summary>
        /// GPS Date. The value is expressed as three rational numbers that give the hour, minute, and second.
        /// </summary>
        [SRCategory("Category_GPS"), GlobalizedProperty()]
        public string GpsDate
        {
            get 
            {
                return ImgMetaDataHelper.GetPropertyValue(moItems, 0x1D);
            }
        }

        /// <summary>
        /// Specifies the GPS satellites used for measurements. This tag can be used to specify the ID number, angle of elevation, azimuth, SNR, and other information about each satellite. The format is not specified. If the GPS receiver is incapable of taking measurements, the value of the tag must be set to NULL.
        /// </summary>
        [BrowsableAttribute(false)]
        public string GpsSatellites
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x8); }
        }

        /// <summary>
        /// Specifies the status of the GPS receiver when the image is recorded. 'A' means measurement is in progress, and 'V' means the measurement is Interoperability.
        /// </summary>
        [SRCategory("Category_GPS"), GlobalizedProperty()]
        public string GpsStatus
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x9); }
        }

        /// <summary>
        /// Specifies the GPS measurement mode. 2 specifies 2-D measurement, and 3 specifies 3-D measurement.
        /// </summary>
        [BrowsableAttribute(false)]
        public string GpsMeasureMode
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0xA); }
        }

        /// <summary>
        /// GPS DOP (data degree of precision). An HDOP value is written during 2-D measurement, and a PDOP value is written during 3-D measurement.
        /// </summary>
        [BrowsableAttribute(false)]
        public string GpsDop
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0xB); }
        }

        /// <summary>
        /// Specifies the unit used to express the GPS receiver speed of movement. K , M , and N represent kilometers per hour, miles per hour, and knots respectively.
        /// </summary>
        [BrowsableAttribute(false)]
        public string GpsSpeedRef
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0xC); }
        }

        /// <summary>
        /// Speed of the GPS receiver movement.
        /// </summary>
        [BrowsableAttribute(false)]
        public string GpsSpeed
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0xD); }
        }

        /// <summary>
        /// Specifies the reference for giving the direction of GPS receiver movement. T specifies true direction, and M specifies magnetic direction.
        /// </summary>
        [BrowsableAttribute(false)]
        public string GpsTrackRef
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0xE); }
        }

        /// <summary>
        /// Direction of GPS receiver movement. The range of values is from 0.00 to 359.99.
        /// </summary>
        [BrowsableAttribute(false)]
        public string GpsTrack
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0xF); }
        }

        /// <summary>
        /// Specifies the reference for the direction of the image when it is captured. T specifies true direction, and M specifies magnetic direction.
        /// </summary>
        [BrowsableAttribute(false)]
        public string GpsImgDirRef
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x10); }
        }

        /// <summary>
        /// Direction of the image when it was captured. The range of values is from 0.00 to 359.99.
        /// </summary>
        [BrowsableAttribute(false)]
        public string GpsImgDir
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x11); }
        }

        /// <summary>
        /// Indicates the geodetic survey data used by the GPS receiver. If the survey data is restricted to Japan, the value of this tag is 'TOKYO' or 'WGS-84'.
        /// </summary>
        [SRCategory("Category_GPS"), GlobalizedProperty()]
        public string GpsMapDate
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x12); }
        }

        /// <summary>
        /// whether the latitude of the destination point is north or south latitude. N specifies north latitude, and S specifies south latitude.
        /// </summary>
        [BrowsableAttribute(false)]
        public string GpsDestLatRef
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x13); }
        }

        /// <summary>
        /// Latitude of the destination point. The latitude is expressed as three rational values giving the degrees, minutes, and seconds respectively. When degrees, minutes, and seconds are expressed, the format is dd/1, mm/1, ss/1. When degrees and minutes are used and, for example, fractions of minutes are given up to two decimal places, the format is dd/1, mmmm/100, 0/1.
        /// </summary>
        [BrowsableAttribute(false)]
        public string GpsDestLat
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x14); }
        }

        /// <summary>
        /// Specifies whether the longitude of the destination point is east or west longitude. E specifies east longitude, and W specifies west longitude.
        /// </summary>
        [BrowsableAttribute(false)]
        public string GpsDestLongRef
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x15); }
        }

        /// <summary>
        /// Longitude of the destination point. The longitude is expressed as three rational values giving the degrees, minutes, and seconds respectively. When degrees, minutes, and seconds are expressed, the format is ddd/1, mm/1, ss/1. When degrees and minutes are used and, for example, fractions of minutes are given up to two decimal places, the format is ddd/1, mmmm/100, 0/1.
        /// </summary>
        [BrowsableAttribute(false)]
        public string GpsDestLong
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x16); }
        }

        /// <summary>
        /// Specifies the reference used for giving the bearing to the destination point. T specifies true direction, and M specifies magnetic direction.
        /// </summary>
        [BrowsableAttribute(false)]
        public string GpsDestBearRef
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x17); }
        }

        /// <summary>
        /// Bearing to the destination point. The range of values is from 0.00 to 359.99.
        /// </summary>
        [BrowsableAttribute(false)]
        public string GpsDestBear
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x18); }
        }

        /// <summary>
        /// Specifies the unit used to express the distance to the destination point. 'K', 'M', and 'N' represent kilometers, miles, and knots respectively.
        /// </summary>
        [BrowsableAttribute(false)]
        public string GpsDestDistRef
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x19); }
        }

        /// <summary>
        /// Distance to the destination point.
        /// </summary>
        [BrowsableAttribute(false)]
        public string GpsDestDist
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x1A); }
        }

#endregion

#region "Flash"
        
        private string GetFlashValue(int Pos, int Length)
        {
            string ssResult = "";
            PropertyItem soItem = ImgMetaDataHelper.GetPropertyItem(moItems, 0x9209);
            if (soItem != null)
            {
                string ssBit = ImgMetaDataHelper.GetBits(soItem.Value[0]);
                if (!string.IsNullOrEmpty(ssBit))
                {
                    if (ssBit.Length >= Pos)
                        { ssResult = ssBit.Substring(ssBit.Length - Pos, Length); }
                }
            }
            return ssResult;
        }

        /// <summary>
        /// This tag indicates the flash status when the picture was taken.
        /// </summary>
        [SRCategory("Category_Flash"), GlobalizedProperty()]
        public string FlashFired
        {
            get 
            {
                string ssReturn = GetFlashValue(1, 1);
                switch (ssReturn)
                {
                    case "0": ssReturn = Properties.Resources.Flash0; break;
                    case "1": ssReturn = Properties.Resources.Flash1; break;
                }
                return string.IsNullOrEmpty(ssReturn) ? Properties.Resources.FlashDefault : ssReturn;
            }
        }

        /// <summary>
        /// This tag indicates the status of returned light.
        /// </summary>
        [SRCategory("Category_Flash"), GlobalizedProperty()]
        public string FlashReturn
        {
            get
            {
                string ssReturn = GetFlashValue(3, 2);
                switch (ssReturn)
                {
                    case "00": ssReturn = Properties.Resources.Flash2; break;
                    case "01": ssReturn = Properties.Resources.FlashDefault; break;
                    case "10": ssReturn = Properties.Resources.Flash3; break;
                    case "11": ssReturn = Properties.Resources.Flash4; break;
                }
                return string.IsNullOrEmpty(ssReturn) ? Properties.Resources.FlashDefault : ssReturn;
            }
        }

        /// <summary>
        /// This tag indicates the camera's flash mode.
        /// </summary>
        [SRCategory("Category_Flash"), GlobalizedProperty()]
        public string FlashMode
        {
            get
            {
                string ssReturn = GetFlashValue(5, 2);
                switch (ssReturn)
                {
                    case "00": ssReturn = Properties.Resources.Flash5; break;
                    case "01": ssReturn = Properties.Resources.Flash6; break;
                    case "10": ssReturn = Properties.Resources.Flash7; break;
                    case "11": ssReturn = Properties.Resources.Flash8; break;
                }
                return string.IsNullOrEmpty(ssReturn) ? Properties.Resources.FlashDefault : ssReturn;
            }
        }

        /// <summary>
        /// This tag indicates the presence of a flash function.
        /// </summary>
        [SRCategory("Category_Flash"), GlobalizedProperty()]
        public string FlashFunction
        {
            get
            {
                string ssReturn = GetFlashValue(6, 1);
                switch (ssReturn)
                {
                    case "0": ssReturn = Properties.Resources.Flash9; break;
                    case "1": ssReturn = Properties.Resources.Flash10; break;
                }
                return string.IsNullOrEmpty(ssReturn) ? Properties.Resources.FlashDefault : ssReturn;
            }
        }

        /// <summary>
        /// This tag indicates the camera's red-eye mode.
        /// </summary>
        [SRCategory("Category_Flash"), GlobalizedProperty()]
        public string FlashRedEye
        {
            get
            {
                string ssReturn = GetFlashValue(7, 1);
                switch (ssReturn)
                {
                    case "0": ssReturn = Properties.Resources.Flash11; break;
                    case "1": ssReturn = Properties.Resources.Flash12; break;
                }
                return string.IsNullOrEmpty(ssReturn) ? Properties.Resources.FlashDefault : ssReturn;
            }
        }

#endregion

#region "Picture"

        /// <summary>
        /// This tag indicates the exposure mode set when the image was shot. In auto-bracketing mode, the camera shoots a series of frames of the same scene at different exposure settings.
        /// </summary>
        [SRCategory("Category_EXIF"), GlobalizedProperty()]
        public string ExposureMode
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0xA402); }
        }

        /// <summary>
        /// This tag indicates the location and area of the main subject in the overall scene.
        /// </summary>
        [SRCategory("Category_EXIF"), GlobalizedProperty()]
        public string SubjectArea
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x9214); }
        }

        /// <summary>
        /// This tag indicates the use of special processing on image data, such as rendering geared to output. When special processing is performed, the reader is expected to disable or minimize any further processing.
        /// </summary>
        [SRCategory("Category_EXIF"), GlobalizedProperty()]
        public string CustomRendered
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0xA401); }
        }

        /// <summary>
        /// This tag indicates the white balance set when the image was shot.
        /// </summary>
        [SRCategory("Category_EXIF"), GlobalizedProperty()]
        public string WhiteBalance
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0xA403); }
        }

        /// <summary>
        /// This tag indicates the digital zoom ratio when the image was shot. If the numerator of the recorded value is 0, this indicates that digital zoom was not used.
        /// </summary>
        [SRCategory("Category_EXIF"), GlobalizedProperty()]
        public string DigitalZoomRatio
        {
            get 
            {
                string ssTemp = ImgMetaDataHelper.GetPropertyValue(moItems, 0xA404);
                return String.IsNullOrEmpty(ssTemp) ? "0" : ssTemp; 
            }
        }

        /// <summary>
        /// This tag indicates the equivalent focal length assuming a 35mm film camera, in mm. A value of 0 means the focal length is unknown. Note that this tag differs from the FocalLength tag.
        /// </summary>
        [SRCategory("Category_EXIF"), GlobalizedProperty()]
        public string FocalLengthIn35mmFilm
        {
            get 
            {
                string ssTemp = ImgMetaDataHelper.GetPropertyValue(moItems, 0xA405);
                return String.IsNullOrEmpty(ssTemp) ? "0" : ssTemp; 
            }
        }

        /// <summary>
        /// This tag indicates the type of scene that was shot. It can also be used to record the mode in which the image was shot. Note that this differs from the scene type (SceneType) tag.
        /// </summary>
        [SRCategory("Category_EXIF"), GlobalizedProperty()]
        public string SceneCaptureType
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0xA406); }
        }

        /// <summary>
        /// This tag indicates the degree of overall image gain adjustment.
        /// </summary>
        [SRCategory("Category_EXIF"), GlobalizedProperty()]
        public string GainControl
        {
            get 
            {
                string ssTemp = ImgMetaDataHelper.GetPropertyValue(moItems, 0xA407);
                return String.IsNullOrEmpty(ssTemp) ? Properties.Resources.GainControl0 : ssTemp; 
            }
        }

        /// <summary>
        /// This tag indicates the direction of contrast processing applied by the camera when the image was shot.
        /// </summary>
        [SRCategory("Category_EXIF"), GlobalizedProperty()]
        public string Contrast
        {
            get 
            {
                string ssTemp = ImgMetaDataHelper.GetPropertyValue(moItems, 0xA408);
                return String.IsNullOrEmpty(ssTemp) ? Properties.Resources.Contrast0 : ssTemp; 
            }
        }

        /// <summary>
        /// This tag indicates the direction of saturation processing applied by the camera when the image was shot.
        /// </summary>
        [SRCategory("Category_EXIF"), GlobalizedProperty()]
        public string Saturation
        {
            get 
            {
                string ssTemp = ImgMetaDataHelper.GetPropertyValue(moItems, 0xA409);
                return String.IsNullOrEmpty(ssTemp) ? Properties.Resources.Saturation0 : ssTemp; 
            }
        }

        /// <summary>
        /// This tag indicates the direction of sharpness processing applied by the camera when the image was shot.
        /// </summary>
        [SRCategory("Category_EXIF"), GlobalizedProperty()]
        public string Sharpness
        {
            get 
            {
                string ssTemp = ImgMetaDataHelper.GetPropertyValue(moItems, 0xA40A);
                return String.IsNullOrEmpty(ssTemp) ? Properties.Resources.Sharpness0 : ssTemp; 
            }
        }

        /// <summary>
        /// This tag indicates information on the picture-taking conditions of a particular camera model. The tag is used only to indicate the picture-taking conditions in the reader.
        /// The information is recorded in the format shown below. The data is recorded in Unicode using SHORT type for the number of display rows and columns and UNDEFINED type for the camera settings. The Unicode (UCS-2) string including Signature is NULL terminated. The specifics of the Unicode string are as given in ISO/IEC 10464-1.
        /// Length Type Meaning
        /// 2 SHORT Display columns
        /// 2 SHORT Display rows
        /// Any UNDEFINED Camera setting-1
        /// Any UNDEFINED Camera setting-2
        /// Any UNDEFINED Camera setting-n
        /// </summary>
        [SRCategory("Category_EXIF"), GlobalizedProperty()]
        public string DeviceSettingDescription
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0xA40B); }
        }

        /// <summary>
        /// This tag indicates the distance to the subject.
        /// 0 = unknown
        /// 1 = Macro
        /// 2 = Close view
        /// 3 = Distant view
        /// Other = reserved
        /// </summary>
        [SRCategory("Category_EXIF"), GlobalizedProperty()]
        public string SubjectDistanceRange
        {
            get 
            {
                string ssTemp = ImgMetaDataHelper.GetPropertyValue(moItems, 0xA40C);
                return String.IsNullOrEmpty(ssTemp) ? Properties.Resources.SubjectDistanceRange0 : ssTemp; 
            }
        }

        /// <summary>
        /// The image orientation viewed in terms of rows and columns.
        /// 1 = The 0th row is at the visual top of the image, and the 0th column is the visual left-hand side.
        /// 2 = The 0th row is at the visual top of the image, and the 0th column is the visual right-hand side.
        /// 3 = The 0th row is at the visual bottom of the image, and the 0th column is the visual right-hand side.
        /// 4 = The 0th row is at the visual bottom of the image, and the 0th column is the visual left-hand side.
        /// 5 = The 0th row is the visual left-hand side of the image, and the 0th column is the visual top.
        /// 6 = The 0th row is the visual right-hand side of the image, and the 0th column is the visual top.
        /// 7 = The 0th row is the visual right-hand side of the image, and the 0th column is the visual bottom.
        /// 8 = The 0th row is the visual left-hand side of the image, and the 0th column is the visual bottom.
        /// Other = reserved
        /// </summary>
        [SRCategory("Category_EXIF"), GlobalizedProperty()]
        public string Orientation
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x112); }
        }

        /// <summary>
        /// Indicates the ISO Speed and ISO Latitude of the camera or input device as specified in ISO 12232.
        /// </summary>
        [SRCategory("Category_EXIF"), GlobalizedProperty()]
        public string ISOSpeed
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x8827); }
        }

        /// <summary>
        /// Shutter speed. The unit is the APEX (Additive System of Photographic Exposure) setting.
        /// </summary>
        [SRCategory("Category_EXIF"), GlobalizedProperty()]
        public string ShutterSpeed
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x9201); }
        }

        /// <summary>
        /// Exposure time, given in seconds (sec).
        /// </summary>
        [SRCategory("Category_EXIF"), GlobalizedProperty()]
        public string ExposureTime
        {
            get 
            { 
                return ImgMetaDataHelper.GetPropertyValue(moItems, 0x829A); 
            }
        }

        /// <summary>
        /// The class of the program used by the camera to set exposure when the picture is taken. The tag values are as follows.
        /// 0 = Not defined
        /// 1 = Manual
        /// 2 = Normal program
        /// 3 = Aperture priority
        /// 4 = Shutter priority
        /// 5 = Creative program (biased toward depth of field)
        /// 6 = Action program (biased toward fast shutter speed)
        /// 7 = Portrait mode (for closeup photos with the background out of focus)
        /// 8 = Landscape mode (for landscape photos with the background in focus)
        /// Other = reserved
        /// </summary>
        [SRCategory("Category_EXIF"), GlobalizedProperty()]
        public string ExposureProgram
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x8822); }
        }

        /// <summary>
        /// The F number.
        /// </summary>
        [SRCategory("Category_EXIF"), GlobalizedProperty()]
        public string FNumber
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x829D); }
        }

        /// <summary>
        /// The lens aperture. The unit is the APEX value.
        /// </summary>
        [SRCategory("Category_EXIF"), GlobalizedProperty()]
        public string Aperture
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x9202); }
        }

        /// <summary>
        /// The exposure bias. The unit is the APEX value. Ordinarily it is given in the range of –99.99 to 99.99.
        /// </summary>
        [SRCategory("Category_EXIF"), GlobalizedProperty()]
        public string ExposureBias
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x9204); }
        }

        /// <summary>
        /// The smallest F number of the lens. The unit is the APEX value. Ordinarily it is given in the range of 00.00 to 99.99, but it is not limited to this range.
        /// </summary>
        [SRCategory("Category_EXIF"), GlobalizedProperty()]
        public string MaxAperture
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x9205); }
        }

        /// <summary>
        /// Indicates the Opto-Electric Conversion Function (OECF) specified in ISO 14524. OECF is the relationship between the camera optical input and the image values.
        /// </summary>
        [SRCategory("Category_EXIF"), GlobalizedProperty()]
        public string OECF
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x8828); }
        }

        /// <summary>
        /// The value of brightness. The unit is the APEX value. Ordinarily it is given in the range of -99.99 to 99.99. Note that if the numerator of the recorded value is FFFFFFFF.H, Unknown shall be indicated.
        /// </summary>
        [SRCategory("Category_EXIF"), GlobalizedProperty()]
        public string Brightness
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x9203); }
        }

        /// <summary>
        /// The distance to the subject, given in meters. Note that if the numerator of the recorded value is FFFFFFFF.H, Infinity shall be indicated; and if the numerator is 0, Distance unknown shall be indicated.
        /// </summary>
        [SRCategory("Category_EXIF"), GlobalizedProperty()]
        public string SubjectDistance
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x9206); }
        }

        /// <summary>
        /// The metering mode.
        /// </summary>
        [SRCategory("Category_EXIF"), GlobalizedProperty()]
        public string MeteringMode
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x9207); }
        }

        /// <summary>
        /// The kind of light source.
        /// </summary>
        [SRCategory("Category_EXIF"), GlobalizedProperty()]
        public string LightSource
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x9208); }
        }

        /// <summary>
        /// The actual focal length of the lens, in mm. Conversion is not made to the focal length of a 35 mm film camera.
        /// </summary>
        [SRCategory("Category_EXIF"), GlobalizedProperty()]
        public string FocalLength
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x920A); }
        }

        /// <summary>
        /// Indicates the spectral sensitivity of each channel of the camera used. The tag value is an ASCII string compatible with the standard developed by the ASTM Technical committee.
        /// </summary>
        [SRCategory("Category_EXIF"), GlobalizedProperty()]
        public string SpectralSensitivity
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x8824); }
        }

        /// <summary>
        /// This tag records the camera or input device spatial frequency table and SFR values in the direction of image width, image height, and diagonal direction, as specified in ISO 12233.
        /// </summary>
        [SRCategory("Category_EXIF"), GlobalizedProperty()]
        public string SpatialFrequencyResponse
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0xA20C); }
        }

        /// <summary>
        /// Indicates the number of pixels in the image width (X) direction per FocalPlaneResolutionUnit on the camera focal plane.
        /// </summary>
        [SRCategory("Category_EXIF"), GlobalizedProperty()]
        public string FocalPlaneXResolution
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0xA20E); }
        }

        /// <summary>
        /// Indicates the number of pixels in the image width (Y) direction per FocalPlaneResolutionUnit on the camera focal plane.
        /// </summary>
        [SRCategory("Category_EXIF"), GlobalizedProperty()]
        public string FocalPlaneYResolution
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0xA20F); }
        }

        /// <summary>
        /// Indicates the unit for measuring FocalPlaneXResolution and FocalPlaneYResolution. This value is the same as the ResolutionUnit.
        /// </summary>
        [SRCategory("Category_EXIF"), GlobalizedProperty()]
        public string FocalPlaneResolutionUnit
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0xA210); }
        }

        /// <summary>
        /// Indicates the location of the main subject in the scene. The value of this tag represents the pixel at the center of the main subject relative to the left edge, prior to rotation processing as per the Rotation tag. The first value indicates the X column number and second indicates the Y row number.
        /// </summary>
        [SRCategory("Category_EXIF"), GlobalizedProperty()]
        public string SubjectLocation
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0xA214); }
        }

        /// <summary>
        /// Indicates the exposure index selected on the camera or input device at the time the image is captured.
        /// </summary>
        [SRCategory("Category_EXIF"), GlobalizedProperty()]
        public string ExposureIndex
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0xA215); }
        }

        /// <summary>
        /// Indicates the image sensor type on the camera or input device.
        /// </summary>
        [SRCategory("Category_EXIF"), GlobalizedProperty()]
        public string SensingMethod
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0xA217); }
        }

        /// <summary>
        /// Indicates the image source. If a DSC (Digital Still Camera) recorded the image, this tag value of this tag always be set to 3, indicating that the image was recorded on a DSC.
        /// </summary>
        [SRCategory("Category_EXIF"), GlobalizedProperty()]
        public string FileSource
        {
            get 
            {
                string ssTemp = ImgMetaDataHelper.GetPropertyValue(moItems, 0xA300);
                return String.IsNullOrEmpty(ssTemp) ? "DSC" : ssTemp; 
            }
        }

        /// <summary>
        /// Indicates the type of scene. If a DSC recorded the image, this tag value shall always be set to 1, indicating that the image was directly photographed.
        /// </summary>
        [SRCategory("Category_EXIF"), GlobalizedProperty()]
        public string SceneType
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0xA301); }
        }

        /// <summary>
        /// Indicates the color filter array (CFA) geometric pattern of the image sensor when a one-chip color area sensor is used. It does not apply to all sensing methods.
        /// </summary>
        [SRCategory("Category_EXIF"), GlobalizedProperty()]
        public string CfaPattern
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0xA302); }
        }

        /// <summary>
        /// Unit of measure for the horizontal resolution and the vertical resolution. 
        /// A setting of 2 indicates inches and a setting of 3 indicates centimeters.
        /// </summary>
        [SRCategory("Category_EXIF"), GlobalizedProperty()]
        public string ResolutionUnit
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x128); }
        }

#endregion

#region "Version"

        /// <summary>
        /// The version of this standard supported. Nonexistence of this field is taken to mean nonconformance to the standard. Conformance to this standard is indicated by recording "0220" as 4-byte ASCII. Since the type is UNDEFINED, there is no NULL for termination.
        /// </summary>
        [SRCategory("Category_Version"), GlobalizedProperty()]
        public string ExifVersion
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x9000); }
        }

        /// <summary>
        /// The Flashpix format version supported by a FPXR file. If the FPXR function supports Flashpix format Ver. 1.0, this is indicated similarly to ExifVersion by recording "0100" as 4-byte ASCII. Since the type is UNDEFINED, there is no NULL for termination.
        /// </summary>
        [SRCategory("Category_Version"), GlobalizedProperty()]
        public string FlashpixVersion
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0xA000); }
        }

#endregion

#region "ImageConfiguration"

        /// <summary>
        /// Information specific to compressed data. The channels of each component are arranged in order from the 1st component to the 4th. For uncompressed data the data arrangement is given in the PhotometricInterpretation tag. However, since PhotometricInterpretation can only express the order of Y,Cb and Cr, this tag is provided for cases when compressed data uses components other than Y, Cb, and Cr and to enable support of other sequences.
        /// </summary>
        [SRCategory("Category_ImageConfiguration"), GlobalizedProperty()]
        public string ComponentsConfiguration
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x9101); }
        }

        /// <summary>
        /// Information specific to compressed data. The compression mode used for a compressed image is indicated in unit bits per pixel.
        /// </summary>
        [SRCategory("Category_ImageConfiguration"), GlobalizedProperty()]
        public string CompressedBitsPerPixel
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x9102); }
        }

        /// <summary>
        /// Information specific to compressed data. When a compressed file is recorded, the valid width of the meaningful image shall be recorded in this tag, whether or not there is padding data or a restart marker. This tag should not exist in an uncompressed file.
        /// </summary>
        [SRCategory("Category_ImageConfiguration"), GlobalizedProperty()]
        public string PixelXDimension
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0xA002); }
        }

        /// <summary>
        /// Information specific to compressed data. When a compressed file is recorded, the valid height of the meaningful image shall be recorded in this tag, whether or not there is padding data or a restart marker. This tag should not exist in an uncompressed file. Since data padding is unnecessary in the vertical direction, the number of lines recorded in this valid image height tag will in fact be the same as that recorded in the SOF.
        /// </summary>
        [SRCategory("Category_ImageConfiguration"), GlobalizedProperty()]
        public string PixelYDimension
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0xA003); }
        }

#endregion

#region "DateTime"

        /// <summary>
        /// The date and time when the original image data was generated. For a DSC the date and time the picture was taken are recorded. The internal format is "YYYY:MM:DD HH:MM:SS" with time shown in 24-hour format, and the date and time separated by one blank character [20.H]. When the date and time are unknown, all the character spaces except colons (":") may be filled with blank characters, or else the Interoperability field may be filled with blank characters. The character string length is 20 bytes including NULL for termination. When the field is left blank, it will report 01.01.1900 00:00:00.
        /// </summary>
        [SRCategory("Category_DateTime"), GlobalizedProperty()]
        public DateTime DateTimeOriginal
        {
            get 
            {
                string ssTemp = ImgMetaDataHelper.GetPropertyValue(moItems, 0x9003);
                if (string.IsNullOrEmpty(ssTemp))
                    { ssTemp = "1900:01:01 00:00:00\0";}
                return System.DateTime.ParseExact(ssTemp, "yyyy:MM:dd HH:mm:ss\0", System.Globalization.CultureInfo.InvariantCulture); 
            }
        }

        /// <summary>
        /// The date and time when the image was stored as digital data. If, for example, an image was captured by DSC and at the same time the file was recorded, then the DateTimeOriginal and DateTimeDigitized will have the same contents. The internal format is "YYYY:MM:DD HH:MM:SS" with time shown in 24-hour format, and the date and time separated by one blank character [20.H]. When the date and time are unknown, all the character spaces except colons (":") may be filled with blank characters, or else the Interoperability field may be filled with blank characters. The character string length is 20 bytes including NULL for termination. When the field is left blank, it will report 01.01.1900 00:00:00.
        /// </summary>
        [SRCategory("Category_DateTime"), GlobalizedProperty()]
        public DateTime DateTimeDigitized
        {
            get
            {
                string ssTemp = ImgMetaDataHelper.GetPropertyValue(moItems, 0x9004);
                if (string.IsNullOrEmpty(ssTemp))
                { ssTemp = "1900:01:01 00:00:00\0"; }
                return System.DateTime.ParseExact(ssTemp, "yyyy:MM:dd HH:mm:ss\0", System.Globalization.CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// A tag used to record fractions of seconds for the DateTime tag.
        /// </summary>
        [BrowsableAttribute(false)]
        public string SubsecTime
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x9290); }
        }

        /// <summary>
        /// A tag used to record fractions of seconds for the DateTimeOriginal tag.
        /// </summary>
        [BrowsableAttribute(false)]
        public string SubsecTimeOriginal
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x9291); }
        }

        /// <summary>
        /// A tag used to record fractions of seconds for the DateTimeDigitized tag.
        /// </summary>
        [BrowsableAttribute(false)]
        public string SubsecTimeDigitized
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x9292); }
        }

#endregion

#region "UserInformation"

        /// <summary>
        /// A tag for manufacturers of Exif writers to record any desired information. The contents are up to the manufacturer, but this tag should not be used for any other than its intended purpose.
        /// </summary>
        [SRCategory("Category_UserInfo"), GlobalizedProperty()]
        public string MakerNote
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x927C); }
        }

        /// <summary>
        /// A tag for Exif users to write keywords or comments on the image besides those in ImageDescription, and without the character code limitations of the ImageDescription tag.
        /// </summary>
        [SRCategory("Category_UserInfo"), GlobalizedProperty()]
        public string UserComment
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x9286); }
        }

#endregion

#region "IPTC"

//ToDo: IPTC

#endregion

#region "OtherExif"

        /// <summary>
        /// The color space information tag (ColorSpace) is always recorded as the color space specifier.
        /// Normally sRGB (=1) is used to define the color space based on the PC monitor conditions and environment. If a color space other than sRGB is used, Uncalibrated (=FFFF.H) is set. Image data recorded as Uncalibrated can be treated as sRGB when it is converted to Flashpix.
        /// </summary>
        [SRCategory("Category_ImgData"), GlobalizedProperty()]
        public string ColorSpace
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0xA001); }
        }

        /// <summary>
        /// This tag is used to record the name of an audio file related to the image data. The only relational information recorded here is the Exif audio file name and extension (an ASCII string consisting of 8 characters + '.' + 3 characters). The path is not recorded. Stipulations on audio are given in section 0. File naming conventions are given in section 0.
        /// When using this tag, audio files shall be recorded in conformance to the Exif audio format. Writers are also allowed to store the data such as Audio within APP2 as Flashpix extension stream data.
        /// Audio files shall be recorded in conformance to the Exif audio format.
        /// The mapping of Exif image files and audio files is done in any of the three ways shown in Table 8. If multiple files are mapped to one file as in [2] or [3] of this table, the above format is used to record just one audio file name. If there are multiple audio files, the first recorded file is given.
        /// In the case of [3] in Table 8, for example, for the Exif image file "DSC00001.JPG" only "SND00001.WAV" is given as the related Exif audio file.
        /// When there are three Exif audio files "SND00001.WAV", "SND00002.WAV" and "SND00003.WAV", the Exif image file name for each of them, "DSC00001.JPG," is indicated. By combining multiple relational information, a variety of playback possibilities can be supported. The method of using relational information is left to the implementation on the playback side. Since this information is an ASCII character string, it is terminated by NULL.
        /// </summary>
        [SRCategory("Category_FileInfo"), GlobalizedProperty()]
        public string RelatedSoundFile
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0xA004); }
        }

        /// <summary>
        /// This tag indicates an identifier assigned uniquely to each image. It is recorded as an ASCII string equivalent to hexadecimal notation and 128-bit fixed length.
        /// </summary>
        [SRCategory("Category_Other"), GlobalizedProperty()]
        public string ImageUniqueID
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0xA420); }
        }

#endregion

#region "UnshownOtherExif"

        /// <summary>
        /// A pointer to the Exif IFD. 
        /// Exif IFD is a set of tags for recording Exif-specific attribute information. It is pointed to by the offset from the TIFF header (Value Offset) indicated by an Exif private tag value. 
        /// An Exif IFD has the same structure as that of the IFD specified in TIFF. Ordinarily, however, it does not contain image data as in the case of TIFF. 
        /// </summary>
        [BrowsableAttribute(false)]
        public string ExifIFD
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x8769); }
        }

        /// <summary>
        /// A pointer to the Exif-related GPS Info IFD. 
        /// GPS IFD is a set of tags for recording GPS information. It is pointed to by the offset from the TIFF header (Value Offset) indicated by a GPS private tag value. 
        /// The Interoperability structure of the GPS Info IFD, like that of Exif IFD, has no image data. 
        /// </summary>
        [BrowsableAttribute(false)]
        public string GpsIFD
        {
            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x8825); }
        }

#endregion

#endregion

    }

}
