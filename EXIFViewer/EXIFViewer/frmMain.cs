using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using de.coe.controls.filecontrols.helpers;

namespace de.coe.EXIFViewer
{
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();
            if (Thread.CurrentThread.CurrentCulture.Name.Substring(0, 2).ToUpper() == "DE")
                { oMenuLanguageGerman.Checked = true; }
            else
                { SetCurrentCulture("en"); }
            oTree.LicenseKey = "AR4T2-6LO85-F5JKF-BS73U-H2Z4J";
            oFiles.LicenseKey = "AR4T2-6LO85-F5JKF-BS73U-H2Z4J";
            this.oTree.Click += new EventHandler(oTree_Click);
            this.oFiles.Click += new EventHandler(oFiles_Click);
            this.oFiles.SelectedIndexChanged += new EventHandler(oFiles_SelectedIndexChanged);
            oTree.InitTree();
        }

        private void oFiles_Click(object sender, EventArgs e)
        {
            LoadExif();
        }

        private void LoadExif()
        {
            if (oFiles.SelectedItems.Count == 1)
            {
                if (oImg.Image != null)
                {
                    oImg.Image.Dispose();
                    oImg.Image = null;
                }
                FileInformation soFile = (FileInformation)oFiles.SelectedItems[0].Tag;
                bgWrkExif.RunWorkerAsync(soFile);
                bgWrkImg.RunWorkerAsync(soFile);
            }
            else
            {
                oEXIF.SelectedObject = null;
            }  
        }

        private void oFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (oFiles.SelectedItems.Count == 0)
            {
                oImg.Image = null;
                oEXIF.SelectedObject = null;
            }
        }

        private void ResizePictureBox(Image soImg)
        {
            int siHeight = 0;
            int siWidth = 0;

            if (soImg.Width > soImg.Height)
            {
                siWidth = oSplitEXIF.Panel1.Width;
                siHeight = (int)(soImg.Height / ((double)soImg.Width / (double)oSplitEXIF.Panel1.Width));
            }
            else
            {
                siHeight = oSplitEXIF.Panel1.Height;
                siWidth = (int)(soImg.Width / ((double)soImg.Height / (double)oSplitEXIF.Panel1.Height));
            }
            oImg.Width = siWidth;
            oImg.Height = siHeight;
            oImg.Top = (oSplitEXIF.Panel1.Height - oImg.Height) / 2;
            oImg.Left = (oSplitEXIF.Panel1.Width - oImg.Width) / 2;
        }

        private void oTree_Click(object sender, EventArgs e)
        {
            DirectoryNode soNode = (DirectoryNode)oTree.SelectedNode;
            if (soNode.DirInfo != null) //root Knoten enthält keine DirectoryInfo
            { 
                oFiles.DisplayDirectory(soNode.DirInfo.FullName, "*.J*G");
                if (oFiles.SelectedItems.Count == 0)
                {
                    oImg.Image = null;
                    oEXIF.SelectedObject = null;
                }
            }
        }

        private void Panel1_Resize(object sender, System.EventArgs e)
        {
            if (oImg.Image != null)
            {
                ResizePictureBox(oImg.Image);
            }
        }

        private void oMenuFileEnd_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void oMenuPathRefresh_Click(object sender, EventArgs e)
        {
            oFiles.Refresh();
        }

        private void oMenuPathViewList_Click(object sender, EventArgs e)
        {
            oFiles.View = View.List;
            oMenuPathViewList.Checked = true;
            oMenuPathViewSmall.Checked = false;
            oMenuPathViewThumb.Checked = false;
            oMenuPathViewDetails.Checked = false;
        }

        private void oMenuPathViewSmall_Click(object sender, EventArgs e)
        {
            oFiles.View = View.SmallIcon;
            oMenuPathViewList.Checked = false;
            oMenuPathViewSmall.Checked = true;
            oMenuPathViewThumb.Checked = false;
            oMenuPathViewDetails.Checked = false;
        }

        private void oMenuPathViewDetails_Click(object sender, EventArgs e)
        {
            oFiles.View = View.Details;
            oMenuPathViewList.Checked = false;
            oMenuPathViewSmall.Checked = false;
            oMenuPathViewDetails.Checked = true;
            oMenuPathViewThumb.Checked = false;
        }

        private void oMenuPathViewThumb_Click(object sender, EventArgs e)
        {
            oMenuPathViewList.Checked = false;
            oMenuPathViewSmall.Checked = false;
            oMenuPathViewDetails.Checked = false;
            oMenuPathViewThumb.Checked = true;
            oFiles.View = View.LargeIcon;
            oFiles.Refresh();
        }

        private void oMenuHelpAbout_Click(object sender, EventArgs e)
        {
            frmAbout soFrmAbout = new frmAbout();
            soFrmAbout.ShowDialog();
        }

        private void bgWrkExif_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument != null)
            {
                FileInformation soFile = (FileInformation)e.Argument;
                if (soFile != null)
                {
                    de.coe.components.Image.ImageMetaData soMeta = new de.coe.components.Image.ImageMetaData();
                    soMeta.LicenseKey = "737HA-2M6B1-7QBA2-AE420-P5110";
                    de.coe.components.Image.IImgMetaDataFileType soType = soMeta.GetMetaData(soFile.FileInfo.FullName);
                    if (soType != null)
                    {
                        if (soType.FileType == de.coe.components.Image.ImageMetaData.enImageType.JPEG)
                        {
                            de.coe.components.Image.ImgMetaDataJPEG soJPEG = (de.coe.components.Image.ImgMetaDataJPEG)soType;
                            e.Result = soJPEG;
                        }
                    }
                }
            }
        }

        private void bgWrkExif_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            oEXIF.SelectedObject = e.Result;
        }

        private void bgWrkImg_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument != null)
            {
                FileInformation soFile = (FileInformation)e.Argument;
                if (soFile != null)
                {
                    Image soImg = Image.FromFile(soFile.FileInfo.FullName);
                    e.Result = soImg;
                }
            }
        }

        private void bgWrkImg_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                Image soImg = (Image)e.Result;
                ResizePictureBox(soImg);
                oImg.Image = soImg;
            }
        }

        private void SetCurrentCulture(string Culture) 
        { 
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Culture); 
            switch (Culture) 
            { 
                case "de":
                    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Culture + "-" + Culture.ToUpper());
                    oMenuLanguageGerman.Checked = true;
                    oMenuLanguageEnglish.Checked = false;
                    break;
                case "en":
                    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Culture + "-GB");
                    oMenuLanguageGerman.Checked = false;
                    oMenuLanguageEnglish.Checked = true;
                    break;
            }
            this.SuspendLayout();
            System.Resources.ResourceManager soResource = new System.Resources.ResourceManager(this.GetType());
            //Menü
            foreach (ToolStripMenuItem soCtrl in oMenu.Items)
            {
                soCtrl.Text = soResource.GetString(soCtrl.Name + ".Text");
                if (soCtrl.HasDropDownItems == true)
                {
                    SetMenuCulture(soCtrl, soResource);
                }
            }
            oFiles.SetCurrentCulture(Culture);
            this.ResumeLayout();
            LoadExif();
        }

        private void SetMenuCulture(ToolStripMenuItem soCtrls, System.Resources.ResourceManager soResource)
        {
            foreach (object soObjCtrl in soCtrls.DropDownItems)
            {
                if (soObjCtrl.GetType() != typeof(ToolStripSeparator))
                {
                    ToolStripMenuItem soCtrl = (ToolStripMenuItem)soObjCtrl;
                    soCtrl.Text = soResource.GetString(soCtrl.Name + ".Text");
                    if (soCtrl.HasDropDownItems == true)
                    {
                        SetMenuCulture(soCtrl, soResource);
                    }
                }
            }
        }

        private void mnuLanguageGerman_Click(object sender, EventArgs e)
        {
            SetCurrentCulture("de");
        }

        private void mnuLanguageEnglish_Click(object sender, EventArgs e)
        {
            SetCurrentCulture("en");
        }
    }
}
