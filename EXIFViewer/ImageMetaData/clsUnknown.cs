using System;
using System.Collections.Generic;
using System.Text;

namespace de.coe.components.Image
{
    //private class clsUnknown
    //{
    //    #region "Unknown"

    //    //        /// <summary>
    //    //        /// Type of data in a subfile.
    //    //        /// </summary>
    //    //        public string NewSubfileType
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0xFE); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Type of data in a subfile.
    //    //        /// </summary>
    //    //        public string SubfileType
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0xFF); }
    //    //        }

    //    //        /// <summary>
    //    //        /// The number of columns of image data, equal to the number of pixels per row. In JPEG compressed data a JPEG marker is used instead of this tag.
    //    //        /// </summary>
    //    //        public string ImageWidth
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x100); }
    //    //        }

    //    //        /// <summary>
    //    //        /// The number of rows of image data. In JPEG compressed data a JPEG marker is used instead of this tag.
    //    //        /// </summary>
    //    //        public string ImageHeight
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x101); }
    //    //        }

    //    //        /// <summary>
    //    //        /// The number of bits per image component. In this standard each component of the image is 8 bits, so the value for this tag is 8. See also SamplesPerPixel. In JPEG compressed data a JPEG marker is used instead of this tag.
    //    //        /// </summary>
    //    //        public string BitsPerSample
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x102); }
    //    //        }

    //    //        /// <summary>
    //    //        /// The compression scheme used for the image data. When a primary image is JPEG compressed, this designation is not necessary and is omitted. When thumbnails use JPEG compression, this tag value is set to 6.
    //    //        /// </summary>
    //    //        public string Compression
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x103); }
    //    //        }

    //    //        /// <summary>
    //    //        /// The pixel composition. In JPEG compressed data a JPEG marker is used instead of this tag.
    //    //        /// </summary>
    //    //        public string PhotometricInterpretation
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x106); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Technique used to convert from gray pixels to black and white pixels.
    //    //        /// </summary>
    //    //        public string ThreshHolding
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x107); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Width of the dithering or halftoning matrix.
    //    //        /// </summary>
    //    //        public string CellWidth
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x108); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Height of the dithering or halftoning matrix.
    //    //        /// </summary>
    //    //        public string CellHeight
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x109); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Logical order of bits in a byte.
    //    //        /// </summary>
    //    //        public string FillOrder
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x10A); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Null-terminated character string that specifies the name of the document from which the image was scanned.
    //    //        /// </summary>
    //    //        public string DocumentName
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x10D); }
    //    //        }

    //    //        /// <summary>
    //    //        /// A character string giving the title of the image. It may be a comment such as "1988 company picnic" or the like. Two-byte character codes cannot be used. When a 2-byte code is necessary, the Exif Private tag UserComment is to be used.
    //    //        /// </summary>
    //    //        public string ImageDescription
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x10E); }
    //    //        }

    //    //        /// <summary>
    //    //        /// For each strip, the byte offset of that strip. It is recommended that this be selected so the number of strip bytes does not exceed 64 Kbytes. With JPEG compressed data this designation is not needed and is omitted. See also RowsPerStrip and StripByteCounts.
    //    //        /// </summary>
    //    //        public string StripOffsets
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x111); }
    //    //        }

    //    //        /// <summary>
    //    //        /// The image orientation viewed in terms of rows and columns.
    //    //        /// 1 = The 0th row is at the visual top of the image, and the 0th column is the visual left-hand side.
    //    //        /// 2 = The 0th row is at the visual top of the image, and the 0th column is the visual right-hand side.
    //    //        /// 3 = The 0th row is at the visual bottom of the image, and the 0th column is the visual right-hand side.
    //    //        /// 4 = The 0th row is at the visual bottom of the image, and the 0th column is the visual left-hand side.
    //    //        /// 5 = The 0th row is the visual left-hand side of the image, and the 0th column is the visual top.
    //    //        /// 6 = The 0th row is the visual right-hand side of the image, and the 0th column is the visual top.
    //    //        /// 7 = The 0th row is the visual right-hand side of the image, and the 0th column is the visual bottom.
    //    //        /// 8 = The 0th row is the visual left-hand side of the image, and the 0th column is the visual bottom.
    //    //        /// Other = reserved
    //    //        /// </summary>
    //    //        public string Orientation
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x112); }
    //    //        }

    //    //        /// <summary>
    //    //        /// The number of components per pixel. Since this standard applies to RGB and YCbCr images, the value set for this tag is 3. In JPEG compressed data a JPEG marker is used instead of this tag.
    //    //        /// </summary>
    //    //        public string SamplesPerPixel
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x115); }
    //    //        }

    //    //        /// <summary>
    //    //        /// The number of rows per strip. This is the number of rows in the image of one strip when an image is divided into strips. With JPEG compressed data this designation is not needed and is omitted. See also RowsPerStrip and StripByteCounts.
    //    //        /// </summary>
    //    //        public string RowsPerStrip
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x116); }
    //    //        }

    //    //        /// <summary>
    //    //        /// The total number of bytes in each strip. With JPEG compressed data this designation is not needed and is omitted.
    //    //        /// </summary>
    //    //        public string StripBytesCount
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x117); }
    //    //        }

    //    //        /// <summary>
    //    //        /// For each color component, the minimum value assigned to that component. See also SamplesPerPixel.
    //    //        /// </summary>
    //    //        public string MinSampleValue
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x118); }
    //    //        }

    //    //        /// <summary>
    //    //        /// For each color component, the maximum value assigned to that component. See also SamplesPerPixel.
    //    //        /// </summary>
    //    //        public string MaxSampleValue
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x119); }
    //    //        }

    //    //        /// <summary>
    //    //        /// The number of pixels per ResolutionUnit in the ImageWidth direction. When the image resolution is unknown, 72 [dpi] is designated.
    //    //        /// </summary>
    //    //        public string XResolution
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x11A); }
    //    //        }

    //    //        /// <summary>
    //    //        /// The number of pixels per ResolutionUnit in the ImageLength direction. The same value as XResolution is designated.
    //    //        /// </summary>
    //    //        public string YResolution
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x11B); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Indicates whether pixel components are recorded in chunky or planar format. In JPEG compressed files a JPEG marker is used instead of this tag. If this field does not exist, the TIFF default of 1 (chunky) is assumed.
    //    //        /// </summary>
    //    //        public string PlanarConfig
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x11C); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Null-terminated character string that specifies the name of the page from which the image was scanned.
    //    //        /// </summary>
    //    //        public string PageName
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x11D); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Offset from the left side of the page to the left side of the image. The unit of measure is specified by PropertyTagResolutionUnit.
    //    //        /// </summary>
    //    //        public string XPosition
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x11E); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Offset from the top of the page to the top of the image. The unit of measure is specified by PropertyTagResolutionUnit.
    //    //        /// </summary>
    //    //        public string YPosition
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x11F); }
    //    //        }

    //    //        /// <summary>
    //    //        /// For each string of contiguous unused bytes, the byte offset of that string.
    //    //        /// </summary>
    //    //        public string FreeOffset
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x120); }
    //    //        }

    //    //        /// <summary>
    //    //        /// For each string of contiguous unused bytes, the number of bytes in that string.
    //    //        /// </summary>
    //    //        public string FreeByteCounts
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x121); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Precision of the number specified by PropertyTagGrayResponseCurve. 
    //    //        /// 1 specifies tenths, 2 specifies hundredths, 3 specifies thousandths, and so on.
    //    //        /// </summary>
    //    //        public string GrayResponseUnit
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x122); }
    //    //        }

    //    //        /// <summary>
    //    //        /// For each possible pixel value in a grayscale image, the optical density of that pixel value.
    //    //        /// </summary>
    //    //        public string GrayResponseCurve
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x123); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Set of flags that relate to T4 encoding.
    //    //        /// </summary>
    //    //        public string T4Option
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x124); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Set of flags that relate to T6 encoding.
    //    //        /// </summary>
    //    //        public string T6Option
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x125); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Page number of the page from which the image was scanned.
    //    //        /// </summary>
    //    //        public string PageNumber
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x129); }
    //    //        }

    //    //        /// <summary>
    //    //        /// A transfer function for the image, described in tabular style. Normally this tag is not necessary, since color space is specified in the color space information tag (ColorSpace).
    //    //        /// </summary>
    //    //        public string TransferFuncition
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x12D); }
    //    //        }

    //    //        /// <summary>
    //    //        /// The date and time of image creation. In this standard it is the date and time the file was changed. The format is "YYYY:MM:DD HH:MM:SS" with time shown in 24-hour format, and the date and time separated by one blank character [20.H]. When the date and time are unknown, all the character spaces except colons (":") may be filled with blank characters, or else the Interoperability field may be filled with blank characters. The character string length is 20 bytes including NULL for termination. When the field is left blank, it is treated as unknown.
    //    //        /// </summary>
    //    //        public string DateTime
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x132); }
    //    //        }

    //    //        /// <summary>
    //    //        /// This tag records the name of the camera owner, photographer or image creator. The detailed format is not specified, but it is recommended that the information be written as in the example below for ease of Interoperability. When the field is left blank, it is treated as unknown.
    //    //        /// Ex.) "Camera owner, John Smith; Photographer, Michael Brown; Image creator, Ken James"
    //    //        /// </summary>
    //    //        public string Artist
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x13B); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Null-terminated character string that specifies the computer and/or operating system used to create the image.
    //    //        /// </summary>
    //    //        public string HostComputer
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x13C); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Type of prediction scheme that was applied to the image data before the encoding scheme was applied.
    //    //        /// </summary>
    //    //        public string Predictor
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x13D); }
    //    //        }

    //    //        /// <summary>
    //    //        /// The chromaticity of the white point of the image. Normally this tag is not necessary, since color space is specified in the color space information tag (ColorSpace).
    //    //        /// </summary>
    //    //        public string WhitePoint
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x13E); }
    //    //        }

    //    //        /// <summary>
    //    //        /// The chromaticity of the three primary colors of the image. Normally this tag is not necessary, since color space is specified in the color space information tag (ColorSpace).
    //    //        /// </summary>
    //    //        public string PrimaryChromaticities
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x13F); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Color palette (lookup table) for a palette-indexed image.
    //    //        /// </summary>
    //    //        public string ColorMap
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x140); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Information used by the halftone function.
    //    //        /// </summary>
    //    //        public string HalftoneHints
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x141); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Number of pixel columns in each tile.
    //    //        /// </summary>
    //    //        public string TileWidth
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x142); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Number of pixel rows in each tile.
    //    //        /// </summary>
    //    //        public string TileLength
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x143); }
    //    //        }

    //    //        /// <summary>
    //    //        /// For each tile, the byte offset of that tile.
    //    //        /// </summary>
    //    //        public string TileOffset
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x144); }
    //    //        }

    //    //        /// <summary>
    //    //        /// For each tile, the number of bytes in that tile.
    //    //        /// </summary>
    //    //        public string TileByteCounts
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x145); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Set of inks used in a separated image.
    //    //        /// </summary>
    //    //        public string InkSet
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x14C); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Sequence of concatenated, null-terminated, character strings that specify the names of the inks used in a separated image.
    //    //        /// </summary>
    //    //        public string InkNames
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x14D); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Number of inks.
    //    //        /// </summary>
    //    //        public string NumberOfInks
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x14E); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Color component values that correspond to a 0 percent dot and a 100 percent dot.
    //    //        /// </summary>
    //    //        public string DotRange
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x150); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Null-terminated character string that describes the intended printing environment.
    //    //        /// </summary>
    //    //        public string TargetPrinter
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x151); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Number of extra color components. For example, one extra component might hold an alpha value.
    //    //        /// </summary>
    //    //        public string ExtraSamples
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x152); }
    //    //        }

    //    //        /// <summary>
    //    //        /// For each color component, the numerical format (unsigned, signed, floating point) of that component. See also SamplesPerPixel.
    //    //        /// </summary>
    //    //        public string SampleFormat
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x153); }
    //    //        }

    //    //        /// <summary>
    //    //        /// For each color component, the minimum value of that component. See also SamplesPerPixel.
    //    //        /// </summary>
    //    //        public string SMinSampleValue
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x154); }
    //    //        }

    //    //        /// <summary>
    //    //        /// For each color component, the maximum value of that component. See also SamplesPerPixel.
    //    //        /// </summary>
    //    //        public string SMaxSampleValue
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x155); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Table of values that extends the range of the transfer function.
    //    //        /// </summary>
    //    //        public string TransferRange
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x156); }
    //    //        }

    //    //        /// <summary>
    //    //        /// JPEG compression process.
    //    //        /// </summary>
    //    //        public string JPEGProc
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x200); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Offset to the start of a JPEG bitstream.
    //    //        /// </summary>
    //    //        public string JPEGInterFormat
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x201); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Length, in bytes, of the JPEG bitstream.
    //    //        /// </summary>
    //    //        public string JPEGInterLength
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x202); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Length of the restart interval.
    //    //        /// </summary>
    //    //        public string JPEGRestartInterval
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x203); }
    //    //        }

    //    //        /// <summary>
    //    //        /// For each color component, a lossless predictor-selection value for that component. See also SamplesPerPixel.
    //    //        /// </summary>
    //    //        public string JPEGLosslessPredictors
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x205); }
    //    //        }

    //    //        /// <summary>
    //    //        /// For each color component, a point transformation value for that component. See also SamplesPerPixel.
    //    //        /// </summary>
    //    //        public string JPEGPointTransforms
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x206); }
    //    //        }

    //    //        /// <summary>
    //    //        /// For each color component, the offset to the quantization table for that component. See also SamplesPerPixel.
    //    //        /// </summary>
    //    //        public string JPEGQTables
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x207); }
    //    //        }

    //    //        /// <summary>
    //    //        /// For each color component, the offset to the DC Huffman table (or lossless Huffman table) for that component. See also SamplesPerPixel.
    //    //        /// </summary>
    //    //        public string JPEGDCTables
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x208); }
    //    //        }

    //    //        /// <summary>
    //    //        /// For each color component, the offset to the AC Huffman table for that component. See also SamplesPerPixel.
    //    //        /// </summary>
    //    //        public string JPEGACTables
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x209); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Coefficients for transformation from RGB to YCbCr image data. 
    //    //        /// </summary>
    //    //        public string YCbCrCoefficients
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x211); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Sampling ratio of chrominance components in relation to the luminance component.
    //    //        /// </summary>
    //    //        public string YCbCrSubsampling
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x212); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Position of chrominance components in relation to the luminance component.
    //    //        /// </summary>
    //    //        public string YCbCrPositioning
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x213); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Reference black point value and reference white point value.
    //    //        /// </summary>
    //    //        public string REFBlackWhite
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x214); }
    //    //        }

    //    //        /// <summary>
    //    //        /// International Color Consortium (ICC) profile embedded in the image.
    //    //        /// </summary>
    //    //        public string ICCProfile
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x8773); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Gamma value attached to the image. 
    //    //        /// The gamma value is stored as a rational number (pair of long) with a numerator of 100000. For example, a gamma value of 2.2 is stored as the pair (100000, 45455).
    //    //        /// </summary>
    //    //        public string Gamma
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x301); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Null-terminated character string that identifies an ICC profile. 
    //    //        /// </summary>
    //    //        public string ICCProfileDescriptor
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x302); }
    //    //        }

    //    //        /// <summary>
    //    //        /// How the image should be displayed as defined by the International Color Consortium (ICC). 
    //    //        /// If an Image object is constructed with the useEmbeddedColorManagement parameter set to TRUE, then the Imaging API renders the image according to the specified rendering intent. 
    //    //        /// The following table shows the possible settings for this property.
    //    //        /// 
    //    //        /// 0  Perceptual intent, which is suitable for photographs, gives good adaptation to the display device gamut at the expense of colorimetric accuracy. 
    //    //        /// 1  Relative colorimetric intent is suitable for images (for example, logos) that require color appearance matching that is relative to the display device white point. 
    //    //        /// 2  Saturation intent, which is suitable for charts and graphs, preserves saturation at the expense of hue and lightness. 
    //    //        /// 3  Absolute colorimetric intent is suitable for proofs (previews of images destined for a different display device) that require preservation of absolute colorimetry. 
    //    //        /// </summary>
    //    //        public string SRGBRenderingIntent
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x303); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Null-terminated character string that specifies the title of the image.
    //    //        /// </summary>
    //    //        public string ImageTitle
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x320); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Copyright information. In this standard the tag is used to indicate both the photographer and editor copyrights. It is the copyright notice of the person or organization claiming rights to the image. The Interoperability copyright statement including date and rights should be written in this field; e.g., "Copyright, John Smith, 19xx. All rights reserved." In this standard the field records both the photographer and editor copyrights, with each recorded in a separate part of the statement. When there is a clear distinction between the photographer and editor copyrights, these are to be written in the order of photographer followed by editor copyright, separated by NULL (in this case, since the statement also ends with a NULL, there are two NULL codes) (see example 1). When only the photographer copyright is given, it is terminated by one NULL code (see example 2). When only the editor copyright is given, the photographer copyright part consists of one space followed by a terminating NULL code, then the editor copyright is given (see example 3). When the field is left blank, it is treated as unknown. 
    //    //        /// Ex. 1) When both the photographer copyright and editor copyright are given.
    //    //        /// Photographer copyright + NULL[00.H] + editor copyright + NULL[00.H]
    //    //        /// Ex. 2) When only the photographer copyright is given.
    //    //        /// Photographer copyright + NULL[00.H]
    //    //        /// Ex. 3) When only the editor copyright is given.
    //    //        /// Space[20.H]+ NULL[00.H] + editor copyright + NULL[00.H]
    //    //        /// </summary>
    //    //        public string Copyright
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x8298); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Units in which to display horizontal resolution. 
    //    //        /// A setting of 1 indicates pixels per inch and a setting of 2 indicates pixels per centimeter.
    //    //        /// </summary>
    //    //        public string ResolutionXUnit
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5001); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Units in which to display vertical resolution.
    //    //        /// A setting of 1 indicates pixels per inch and a setting of 2 indicates pixels per centimeter.
    //    //        /// </summary>
    //    //        public string ResolutionYUnit
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5002); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Units in which to display the image width.
    //    //        /// 1  Inches  
    //    //        /// 2  Centimeters  
    //    //        /// 3  Points  
    //    //        /// 4  Picas  
    //    //        /// 5  Columns  
    //    //        /// </summary>
    //    //        public string ResolutionXLengthUnit
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5003); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Units in which to display the image height.
    //    //        /// 1  Inches  
    //    //        /// 2  Centimeters  
    //    //        /// 3  Points  
    //    //        /// 4  Picas  
    //    //        /// 5  Columns  
    //    //        /// </summary>
    //    //        public string ResolutionYLengthUnit
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5004); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Sequence of one-byte Boolean values that specify printing options.
    //    //        /// </summary>
    //    //        public string PrintFlags
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5005); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Print flags version.
    //    //        /// </summary>
    //    //        public string PrintFlagsVersion
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5006); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Print flags center crop marks.
    //    //        /// </summary>
    //    //        public string PrintFlagsCrop
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5007); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Print flags bleed width.
    //    //        /// </summary>
    //    //        public string PrintFlagsBleedWidth
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5008); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Print flags bleed width scale.
    //    //        /// </summary>
    //    //        public string PrintFlagsBleedWidthScale
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5009); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Ink's screen frequency, in lines per inch.
    //    //        /// </summary>
    //    //        public string HalftoneLPI
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x500A); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Units for the screen frequency.
    //    //        /// A setting of 1 indicates lines per inch and a setting of 2 indicates lines per centimeter
    //    //        /// </summary>
    //    //        public string HalftoneLPIUnit
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x500B); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Angle for screen.
    //    //        /// </summary>
    //    //        public string HalftoneDegree
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x500C); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Shape of the halftone dots.
    //    //        /// </summary>
    //    //        public string HalftoneShape
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x500D); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Miscellaneous halftone information.
    //    //        /// </summary>
    //    //        public string HalftoneMisc
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x500E); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Boolean value that specifies whether to use the printer's default screens.
    //    //        /// A setting of 1 indicates that the printer's default screens should be used and a setting of 2 indicates otherwise. 
    //    //        /// </summary>
    //    //        public string HalftoneScreen
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x500F); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Private property used by the Adobe Photoshop format. 
    //    //        /// Not for public use.
    //    //        /// </summary>
    //    //        public string JPEGQuality
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5010); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Block of information about grids and guides.
    //    //        /// </summary>
    //    //        public string GridSize
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5011); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Format of the thumbnail image.
    //    //        /// A setting of 1 indicates raw RGB and a setting of 2 indicates JPEG.
    //    //        /// </summary>
    //    //        public string ThumbnailFormat
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5012); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Width, in pixels, of the thumbnail image.
    //    //        /// </summary>
    //    //        public string ThumbnailWidth
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5013); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Height, in pixels, of the thumbnail image.
    //    //        /// </summary>
    //    //        public string ThumbnailHeight
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5014); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Bits per pixel (BPP) for the thumbnail image.
    //    //        /// </summary>
    //    //        public string ThumbnailColorDepth
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5015); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Number of color planes for the thumbnail image.
    //    //        /// </summary>
    //    //        public string ThumbnailPlanes
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5016); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Byte offset between rows of pixel data.
    //    //        /// </summary>
    //    //        public string ThumbnailRawBytes
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5017); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Total size, in bytes, of the thumbnail image.
    //    //        /// </summary>
    //    //        public string ThumbnailSize
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5018); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Compressed size, in bytes, of the thumbnail image.
    //    //        /// </summary>
    //    //        public string ThumbnailCompressedSize
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5019); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Table of values that specify color transfer functions.
    //    //        /// </summary>
    //    //        public string ColorTransferFunction
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x501A); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Raw thumbnail bits in JPEG or RGB format. Depends on ThumbnailFormat.
    //    //        /// </summary>
    //    //        public string ThumbnailData
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x501B); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Number of pixels per row in the thumbnail image.
    //    //        /// </summary>
    //    //        public string ThumbnailImageWidth
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5020); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Units in which to display vertical resolution.
    //    //        /// A setting of 1 indicates pixels per inch and a setting of 2 indicates pixels per centimeter.
    //    //        /// </summary>
    //    //        public string ThumbnailImageHeight
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x502); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Number of bits per color component in the thumbnail image. See also PropertyTagThumbnailSamplesPerPixel.
    //    //        /// </summary>
    //    //        public string ThumbnailBitsPerSample
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5022); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Compression scheme used for thumbnail image data.
    //    //        /// </summary>
    //    //        public string ThumbnailCompression
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5023); }
    //    //        }

    //    //        /// <summary>
    //    //        /// How thumbnail pixel data will be interpreted.
    //    //        /// </summary>
    //    //        public string ThumbnailPhotometricInterp
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5024); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Null-terminated character string that specifies the title of the image.
    //    //        /// </summary>
    //    //        public string ThumbnailImageDescription
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5025); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Null-terminated character string that specifies the manufacturer of the equipment used to record the thumbnail image.
    //    //        /// </summary>
    //    //        public string ThumbnailEquipMake
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5026); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Null-terminated character string that specifies the model name or model number of the equipment used to record the thumbnail image.
    //    //        /// </summary>
    //    //        public string ThumbnailEquipModel
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5027); }
    //    //        }

    //    //        /// <summary>
    //    //        /// For each strip in the thumbnail image, the byte offset of that strip. See also ThumbnailRowsPerStrip and ThumbnailStripBytesCount.
    //    //        /// </summary>
    //    //        public string ThumbnailStripOffsets
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5028); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Thumbnail image orientation in terms of rows and columns. See also Orientation.
    //    //        /// </summary>
    //    //        public string ThumbnailOrientation
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5029); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Number of color components per pixel in the thumbnail image.
    //    //        /// </summary>
    //    //        public string ThumbnailSamplesPerPixel
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x502A); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Number of rows per strip in the thumbnail image. See also ThumbnailStripBytesCount and ThumbnailStripOffsets.
    //    //        /// </summary>
    //    //        public string ThumbnailRowsPerStrip
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x502B); }
    //    //        }

    //    //        /// <summary>
    //    //        /// For each thumbnail image strip, the total number of bytes in that strip´.
    //    //        /// </summary>
    //    //        public string ThumbnailStripBytesCount
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x502C); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Thumbnail resolution in the width direction. The resolution unit is given in ThumbnailResolutionUnit.
    //    //        /// </summary>
    //    //        public string ThumbnailResolutionX
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x502D); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Thumbnail resolution in the height direction. The resolution unit is given in ThumbnailResolutionUnit.
    //    //        /// </summary>
    //    //        public string ThumbnailResolutionY
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x502E); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Whether pixel components in the thumbnail image are recorded in chunky or planar format. See also PlanarConfig.
    //    //        /// </summary>
    //    //        public string ThumbnailPlanarConfig
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x502F); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Unit of measure for the horizontal resolution and the vertical resolution of the thumbnail image. See also ResolutionUnit.
    //    //        /// </summary>
    //    //        public string ThumbnailResolutionUnit
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5030); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Tables that specify transfer functions for the thumbnail image. See also TransferFunction.
    //    //        /// </summary>
    //    //        public string ThumbnailTransferFunction
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5031); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Null-terminated character string that specifies the name and version of the software or firmware of the device used to generate the thumbnail image.
    //    //        /// </summary>
    //    //        public string ThumbnailSoftwareUsed
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5032); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Date and time the thumbnail image was created. See also DateTime.
    //    //        /// </summary>
    //    //        public string ThumbnailDateTime
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5033); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Null-terminated character string that specifies the name of the person who created the thumbnail image.
    //    //        /// </summary>
    //    //        public string ThumbnailArtist
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5034); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Chromaticity of the white point of the thumbnail image. See also WhitePoint.
    //    //        /// </summary>
    //    //        public string ThumbnailWhitePoint
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5035); }
    //    //        }

    //    //        /// <summary>
    //    //        /// For each of the three primary colors in the thumbnail image, the chromaticity of that color. See also PrimaryChromaticities.
    //    //        /// </summary>
    //    //        public string ThumbnailPrimaryChromaticities
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5036); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Coefficients for transformation from RGB to YCbCr data for the thumbnail image. See also PropertyTagYCbCrCoefficients.
    //    //        /// </summary>
    //    //        public string ThumbnailYCbCrCoefficients
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5037); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Sampling ratio of chrominance components in relation to the luminance component for the thumbnail image. See also PropertyTagYCbCrSubsampling.
    //    //        /// </summary>
    //    //        public string ThumbnailYCbCrSubsampling
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5038); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Position of chrominance components in relation to the luminance component for the thumbnail image. See also PropertyTagYCbCrPositioning.
    //    //        /// </summary>
    //    //        public string ThumbnailYCbCrPositioning
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5039); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Reference black point value and reference white point value for the thumbnail image. See also PropertyTagREFBlackWhite.
    //    //        /// </summary>
    //    //        public string ThumbnailRefBlackWhite
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x503A); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Null-terminated character string that contains copyright information for the thumbnail image.
    //    //        /// </summary>
    //    //        public string ThumbnailCopyRight
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x503B); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Luminance table. 
    //    //        /// The luminance table and the chrominance table are used to control JPEG quality. A valid luminance or chrominance table has 64 entries of type PropertyTagTypeShort. If an image has a luminance table or a chrominance table, it must have both tables.
    //    //        /// </summary>
    //    //        public string LuminanceTable
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5090); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Chrominance table. 
    //    //        /// The luminance table and the chrominance table are used to control JPEG quality. A valid luminance or chrominance table has 64 entries of type PropertyTagTypeShort. If an image has a luminance table or a chrominance table, it must have both tables.
    //    //        /// </summary>
    //    //        public string ChrominanceTable
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5091); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Time delay, in hundredths of a second, between two frames in an animated GIF image.
    //    //        /// </summary>
    //    //        public string FrameDelay
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5100); }
    //    //        }

    //    //        /// <summary>
    //    //        /// For an animated GIF image, the number of times to display the animation. 
    //    //        /// A value of 0 specifies that the animation should be displayed infinitely.
    //    //        /// </summary>
    //    //        public string LoopCount
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5101); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Unit for PropertyTagPixelPerUnitX and PropertyTagPixelPerUnitY.
    //    //        /// A setting of 0 indicates that property is unknown.
    //    //        /// </summary>
    //    //        public string PixelUnit
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5110); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Pixels per unit in the x direction.
    //    //        /// </summary>
    //    //        public string PixelPerUnitX
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5111); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Pixels per unit in the y direction.
    //    //        /// </summary>
    //    //        public string PixelPerUnitY
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5112); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Palette histogram.
    //    //        /// </summary>
    //    //        public string PaletteHistogram
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0x5113); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Interoperability IFD is composed of tags which stores the information to ensure the Interoperability and pointed by the following tag located in Exif IFD.
    //    //        /// The Interoperability structure of Interoperability IFD is same as TIFF defined IFD structure but does not contain the image data characteristically compared with normal TIFF IFD.
    //    //        /// </summary>
    //    //        public string InteroperabilityIFD
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0xA005); }
    //    //        }

    //    //        /// <summary>
    //    //        /// Indicates the strobe energy at the time the image is captured, as measured in Beam Candle Power Seconds (BCPS).
    //    //        /// </summary>
    //    //        public string FlashEnergy
    //    //        {
    //    //            get { return ImgMetaDataHelper.GetPropertyValue(moItems, 0xA20B); }
    //    //        }

    //    #endregion

    //}
}
