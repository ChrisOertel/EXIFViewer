using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace de.coe.components.Image
{

#region "IImgMetaDataFileTyp"

    /// <summary>
    /// Interface for the shared metadata access of the supported image types.
    /// </summary>
    [Guid("6B622377-AFF0-4674-B0F1-84B395A90A49")]
    public interface IImgMetaDataFileType
    {
        /// <summary>
        /// Path and Name of the image.
        /// </summary>
        string FileName { get; }
        /// <summary>
        /// Type of the image.
        /// </summary>
        ImageMetaData.enImageType FileType { get; }
    }

#endregion

#region "ImageMetaData"

    /// <summary>
    /// Interface for COM access of the ImageMetaData classe.
    /// </summary>
    [Guid("7786D854-CECA-431c-9685-37D9D4EBEFAD")]
    public interface IImageMetaData
    {
        /// <summary>
        /// Reads the metadata of the given file. 
        /// </summary>
        /// <param name="FileName">Path and name of the image which metadata should be read..</param>
        /// <returns>IImgMetaDataFileType Interface for the corresponding metadate object. With the FileType Property of the interface the correct metadata class can be found out.</returns>
        IImgMetaDataFileType GetMetaData(string FileName);
    }

    /// <summary>
    /// Central class for the shared metadata access of the supported image types.
    /// </summary>
    /// <example>
    /// C#:
    /// <code>
    /// private void test()
    /// {
    ///     de.coe.components.Image.ImageMetaData soMeta = new de.coe.components.Image.ImageMetaData();
    ///     de.coe.components.Image.IImgMetaDataFileType soType = soMeta.GetMetaData(@"D:\IMG_1407.JPG");
    ///     if (soType != null)
    ///     {
    ///         if (soType.FileType == de.coe.components.Image.ImageMetaData.enImageType.JPEG)
    ///         {
    ///             de.coe.Tools.Image.ImgMetaDataJPEG soJPEG = (de.coe.components.Image.ImgMetaDataJPEG)soType;
    ///             System.Diagnostics.Trace.WriteLine(soJPEG.EquipModel);
    ///             System.Diagnostics.Trace.WriteLine(soJPEG.DateTime);
    ///             System.Diagnostics.Trace.WriteLine(soJPEG.PixelXDimension);
    ///             System.Diagnostics.Trace.WriteLine(soJPEG.PixelYDimension);
    ///         }
    ///     }
    /// }
    /// </code>
    /// 
    /// Visual Basic 6:
    /// <code>
    /// Public Sub test()
    /// Dim soInfo As New ImageMetaData
    /// Dim soData As IImgMetaDataFileType
    /// Dim soJPEG As New ImgMetaDataJPEG
    /// 
    /// Set soData = soInfo.GetMetaData("D:\IMG_1407.JPG")
    /// If Not soData Is Nothing Then
    ///     If soData.FileType = enImageType_JPEG Then
    ///         Set soJPEG = soData
    ///         Debug.Print soJPEG.EquipModel
    ///         Debug.Print soJPEG.DateTime
    ///         Debug.Print soJPEG.PixelXDimension
    ///         Debug.Print soJPEG.PixelYDimension
    ///     End If
    /// End If
    /// End Sub
    /// </code>
    /// </example>
    [GuidAttribute("8A296BED-CC27-4af6-A57D-41D3DE7C5BCC"),
    ProgId("coeImageMetaData.ImageMetaData"),
    ClassInterfaceAttribute(ClassInterfaceType.AutoDual)]
    public class ImageMetaData : de.coe.components.Image.IImageMetaData
    {

        private string msLicense = "";

        /// <summary>
        /// Lizenzschlüssel für diese Komponente.
        /// </summary>
        public string LicenseKey
        {
            get { return msLicense; }
            set { msLicense = value; }
        }

        /// <summary>
        /// Enumeration of all supportes image types.
        /// </summary>
        public enum enImageType 
        { 
            /// <summary>
            /// A JPEG image.
            /// </summary>
            JPEG 
        };

        /// <summary>
        /// Klassenkonstruktor.
        /// </summary>
        public ImageMetaData()
        {
        }

        /// <summary>
        /// Reads the metadata of the given file. 
        /// </summary>
        /// <param name="FileName">Path and name of the image which metadata should be read..</param>
        /// <returns>IImgMetaDataFileType Interface for the corresponding metadate object. With the FileType Property of the interface the correct metadata class can be found out.</returns>
        public IImgMetaDataFileType GetMetaData(string FileName)
        {
            if (de.coe.components.License.LicCheck.CheckKeyForRegKey(msLicense) != "2C2A381E20")
            {
                throw new Exception(Properties.Resources.LicInvalid);
            }
            else
            {
                if (System.IO.File.Exists(FileName) == true)
                {
                    IImgMetaDataFileType soData = null;
                    System.IO.FileInfo soInfo = new System.IO.FileInfo(FileName);
                    switch (soInfo.Extension.ToUpper())
                    {
                        case ".JPG":
                        case ".JPEG":
                            ImgMetaDataJPEG soJPEG = new ImgMetaDataJPEG();
                            soJPEG.SetProperties(GetProperties(FileName), soInfo);
                            soData = soJPEG;
                            break;
                        default:
                            return null;
                    }
                    return soData;
                }
                else
                    { return null; }
            }
        }

        private PropertyItem[] GetProperties(string FileName)
        {
            //ToDo: Was passiert, wenn Dateiextension falsch?
            FileStream soStream = new FileStream(FileName, FileMode.Open, FileAccess.Read);
            System.Drawing.Image soImage = System.Drawing.Image.FromStream(soStream,/* useEmbeddedColorManagement = */ true, /* validateImageData = */ false);
            return soImage.PropertyItems;
        }

    }

#endregion

}
