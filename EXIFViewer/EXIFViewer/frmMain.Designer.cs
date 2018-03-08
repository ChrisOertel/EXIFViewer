namespace de.coe.EXIFViewer
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.oSplitLeft = new System.Windows.Forms.SplitContainer();
            this.oSplitFile = new System.Windows.Forms.SplitContainer();
            this.oTree = new de.coe.controls.filecontrols.ExplorerTreeView();
            this.oFiles = new de.coe.controls.filecontrols.ExplorerListView();
            this.oSplitEXIF = new System.Windows.Forms.SplitContainer();
            this.oImg = new System.Windows.Forms.PictureBox();
            this.oEXIF = new System.Windows.Forms.PropertyGrid();
            this.oMenu = new System.Windows.Forms.MenuStrip();
            this.oMenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.oMenuFileEnd = new System.Windows.Forms.ToolStripMenuItem();
            this.oMenuPath = new System.Windows.Forms.ToolStripMenuItem();
            this.oMenuPathView = new System.Windows.Forms.ToolStripMenuItem();
            this.oMenuPathViewList = new System.Windows.Forms.ToolStripMenuItem();
            this.oMenuPathViewSmall = new System.Windows.Forms.ToolStripMenuItem();
            this.oMenuPathViewDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.oMenuPathViewThumb = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.oMenuPathRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.oMenuLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.oMenuLanguageGerman = new System.Windows.Forms.ToolStripMenuItem();
            this.oMenuLanguageEnglish = new System.Windows.Forms.ToolStripMenuItem();
            this.oMenuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.oMenuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.bgWrkExif = new System.ComponentModel.BackgroundWorker();
            this.bgWrkImg = new System.ComponentModel.BackgroundWorker();
            this.oSplitLeft.Panel1.SuspendLayout();
            this.oSplitLeft.Panel2.SuspendLayout();
            this.oSplitLeft.SuspendLayout();
            this.oSplitFile.Panel1.SuspendLayout();
            this.oSplitFile.Panel2.SuspendLayout();
            this.oSplitFile.SuspendLayout();
            this.oSplitEXIF.Panel1.SuspendLayout();
            this.oSplitEXIF.Panel2.SuspendLayout();
            this.oSplitEXIF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oImg)).BeginInit();
            this.oMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // oSplitLeft
            // 
            this.oSplitLeft.AccessibleDescription = null;
            this.oSplitLeft.AccessibleName = null;
            resources.ApplyResources(this.oSplitLeft, "oSplitLeft");
            this.oSplitLeft.BackgroundImage = null;
            this.oSplitLeft.Font = null;
            this.oSplitLeft.Name = "oSplitLeft";
            // 
            // oSplitLeft.Panel1
            // 
            this.oSplitLeft.Panel1.AccessibleDescription = null;
            this.oSplitLeft.Panel1.AccessibleName = null;
            resources.ApplyResources(this.oSplitLeft.Panel1, "oSplitLeft.Panel1");
            this.oSplitLeft.Panel1.BackgroundImage = null;
            this.oSplitLeft.Panel1.Controls.Add(this.oSplitFile);
            this.oSplitLeft.Panel1.Font = null;
            // 
            // oSplitLeft.Panel2
            // 
            this.oSplitLeft.Panel2.AccessibleDescription = null;
            this.oSplitLeft.Panel2.AccessibleName = null;
            resources.ApplyResources(this.oSplitLeft.Panel2, "oSplitLeft.Panel2");
            this.oSplitLeft.Panel2.BackgroundImage = null;
            this.oSplitLeft.Panel2.Controls.Add(this.oSplitEXIF);
            this.oSplitLeft.Panel2.Font = null;
            // 
            // oSplitFile
            // 
            this.oSplitFile.AccessibleDescription = null;
            this.oSplitFile.AccessibleName = null;
            resources.ApplyResources(this.oSplitFile, "oSplitFile");
            this.oSplitFile.BackgroundImage = null;
            this.oSplitFile.Font = null;
            this.oSplitFile.Name = "oSplitFile";
            // 
            // oSplitFile.Panel1
            // 
            this.oSplitFile.Panel1.AccessibleDescription = null;
            this.oSplitFile.Panel1.AccessibleName = null;
            resources.ApplyResources(this.oSplitFile.Panel1, "oSplitFile.Panel1");
            this.oSplitFile.Panel1.BackgroundImage = null;
            this.oSplitFile.Panel1.Controls.Add(this.oTree);
            this.oSplitFile.Panel1.Font = null;
            // 
            // oSplitFile.Panel2
            // 
            this.oSplitFile.Panel2.AccessibleDescription = null;
            this.oSplitFile.Panel2.AccessibleName = null;
            resources.ApplyResources(this.oSplitFile.Panel2, "oSplitFile.Panel2");
            this.oSplitFile.Panel2.BackgroundImage = null;
            this.oSplitFile.Panel2.Controls.Add(this.oFiles);
            this.oSplitFile.Panel2.Font = null;
            // 
            // oTree
            // 
            this.oTree.AccessibleDescription = null;
            this.oTree.AccessibleName = null;
            resources.ApplyResources(this.oTree, "oTree");
            this.oTree.BackgroundImage = null;
            this.oTree.Font = null;
            this.oTree.HideCDRomDrives = false;
            this.oTree.HideFloppyDrives = false;
            this.oTree.HideHarddiskDrives = false;
            this.oTree.HideNetworkDrives = false;
            this.oTree.LicenseKey = "";
            this.oTree.Name = "oTree";
            this.oTree.RefreshDirectoryOnExpand = false;
            this.oTree.RootNodeName = "Sydney";
            this.oTree.ShowFiles = false;
            // 
            // oFiles
            // 
            this.oFiles.AccessibleDescription = null;
            this.oFiles.AccessibleName = null;
            resources.ApplyResources(this.oFiles, "oFiles");
            this.oFiles.AllowColumnReorder = true;
            this.oFiles.BackgroundImage = null;
            this.oFiles.Font = null;
            this.oFiles.LicenseKey = "";
            this.oFiles.Name = "oFiles";
            this.oFiles.ShowFileDate = true;
            this.oFiles.ShowFileSize = true;
            this.oFiles.ShowFileType = true;
            this.oFiles.UseCompatibleStateImageBehavior = false;
            this.oFiles.View = System.Windows.Forms.View.Details;
            // 
            // oSplitEXIF
            // 
            this.oSplitEXIF.AccessibleDescription = null;
            this.oSplitEXIF.AccessibleName = null;
            resources.ApplyResources(this.oSplitEXIF, "oSplitEXIF");
            this.oSplitEXIF.BackgroundImage = null;
            this.oSplitEXIF.Font = null;
            this.oSplitEXIF.Name = "oSplitEXIF";
            // 
            // oSplitEXIF.Panel1
            // 
            this.oSplitEXIF.Panel1.AccessibleDescription = null;
            this.oSplitEXIF.Panel1.AccessibleName = null;
            resources.ApplyResources(this.oSplitEXIF.Panel1, "oSplitEXIF.Panel1");
            this.oSplitEXIF.Panel1.BackColor = System.Drawing.Color.Black;
            this.oSplitEXIF.Panel1.BackgroundImage = null;
            this.oSplitEXIF.Panel1.Controls.Add(this.oImg);
            this.oSplitEXIF.Panel1.Font = null;
            this.oSplitEXIF.Panel1.Resize += new System.EventHandler(this.Panel1_Resize);
            // 
            // oSplitEXIF.Panel2
            // 
            this.oSplitEXIF.Panel2.AccessibleDescription = null;
            this.oSplitEXIF.Panel2.AccessibleName = null;
            resources.ApplyResources(this.oSplitEXIF.Panel2, "oSplitEXIF.Panel2");
            this.oSplitEXIF.Panel2.BackgroundImage = null;
            this.oSplitEXIF.Panel2.Controls.Add(this.oEXIF);
            this.oSplitEXIF.Panel2.Font = null;
            // 
            // oImg
            // 
            this.oImg.AccessibleDescription = null;
            this.oImg.AccessibleName = null;
            resources.ApplyResources(this.oImg, "oImg");
            this.oImg.BackgroundImage = null;
            this.oImg.Font = null;
            this.oImg.ImageLocation = null;
            this.oImg.Name = "oImg";
            this.oImg.TabStop = false;
            // 
            // oEXIF
            // 
            this.oEXIF.AccessibleDescription = null;
            this.oEXIF.AccessibleName = null;
            resources.ApplyResources(this.oEXIF, "oEXIF");
            this.oEXIF.BackgroundImage = null;
            this.oEXIF.Font = null;
            this.oEXIF.Name = "oEXIF";
            // 
            // oMenu
            // 
            this.oMenu.AccessibleDescription = null;
            this.oMenu.AccessibleName = null;
            resources.ApplyResources(this.oMenu, "oMenu");
            this.oMenu.BackgroundImage = null;
            this.oMenu.Font = null;
            this.oMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oMenuFile,
            this.oMenuPath,
            this.oMenuLanguage,
            this.oMenuHelp});
            this.oMenu.Name = "oMenu";
            this.oMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // oMenuFile
            // 
            this.oMenuFile.AccessibleDescription = null;
            this.oMenuFile.AccessibleName = null;
            resources.ApplyResources(this.oMenuFile, "oMenuFile");
            this.oMenuFile.BackgroundImage = null;
            this.oMenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oMenuFileEnd});
            this.oMenuFile.Name = "oMenuFile";
            this.oMenuFile.ShortcutKeyDisplayString = null;
            // 
            // oMenuFileEnd
            // 
            this.oMenuFileEnd.AccessibleDescription = null;
            this.oMenuFileEnd.AccessibleName = null;
            resources.ApplyResources(this.oMenuFileEnd, "oMenuFileEnd");
            this.oMenuFileEnd.BackgroundImage = null;
            this.oMenuFileEnd.Name = "oMenuFileEnd";
            this.oMenuFileEnd.ShortcutKeyDisplayString = null;
            this.oMenuFileEnd.Click += new System.EventHandler(this.oMenuFileEnd_Click);
            // 
            // oMenuPath
            // 
            this.oMenuPath.AccessibleDescription = null;
            this.oMenuPath.AccessibleName = null;
            resources.ApplyResources(this.oMenuPath, "oMenuPath");
            this.oMenuPath.BackgroundImage = null;
            this.oMenuPath.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oMenuPathView,
            this.toolStripMenuItem2,
            this.oMenuPathRefresh});
            this.oMenuPath.Name = "oMenuPath";
            this.oMenuPath.ShortcutKeyDisplayString = null;
            // 
            // oMenuPathView
            // 
            this.oMenuPathView.AccessibleDescription = null;
            this.oMenuPathView.AccessibleName = null;
            resources.ApplyResources(this.oMenuPathView, "oMenuPathView");
            this.oMenuPathView.BackgroundImage = null;
            this.oMenuPathView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oMenuPathViewDetails,
            this.oMenuPathViewList,
            this.oMenuPathViewSmall,
            this.oMenuPathViewThumb});
            this.oMenuPathView.Name = "oMenuPathView";
            this.oMenuPathView.ShortcutKeyDisplayString = null;
            // 
            // oMenuPathViewList
            // 
            this.oMenuPathViewList.AccessibleDescription = null;
            this.oMenuPathViewList.AccessibleName = null;
            resources.ApplyResources(this.oMenuPathViewList, "oMenuPathViewList");
            this.oMenuPathViewList.BackgroundImage = null;
            this.oMenuPathViewList.Name = "oMenuPathViewList";
            this.oMenuPathViewList.ShortcutKeyDisplayString = null;
            this.oMenuPathViewList.Click += new System.EventHandler(this.oMenuPathViewList_Click);
            // 
            // oMenuPathViewSmall
            // 
            this.oMenuPathViewSmall.AccessibleDescription = null;
            this.oMenuPathViewSmall.AccessibleName = null;
            resources.ApplyResources(this.oMenuPathViewSmall, "oMenuPathViewSmall");
            this.oMenuPathViewSmall.BackgroundImage = null;
            this.oMenuPathViewSmall.Name = "oMenuPathViewSmall";
            this.oMenuPathViewSmall.ShortcutKeyDisplayString = null;
            this.oMenuPathViewSmall.Click += new System.EventHandler(this.oMenuPathViewSmall_Click);
            // 
            // oMenuPathViewDetails
            // 
            this.oMenuPathViewDetails.AccessibleDescription = null;
            this.oMenuPathViewDetails.AccessibleName = null;
            resources.ApplyResources(this.oMenuPathViewDetails, "oMenuPathViewDetails");
            this.oMenuPathViewDetails.BackgroundImage = null;
            this.oMenuPathViewDetails.Checked = true;
            this.oMenuPathViewDetails.CheckState = System.Windows.Forms.CheckState.Checked;
            this.oMenuPathViewDetails.Name = "oMenuPathViewDetails";
            this.oMenuPathViewDetails.ShortcutKeyDisplayString = null;
            this.oMenuPathViewDetails.Click += new System.EventHandler(this.oMenuPathViewDetails_Click);
            // 
            // oMenuPathViewThumb
            // 
            this.oMenuPathViewThumb.AccessibleDescription = null;
            this.oMenuPathViewThumb.AccessibleName = null;
            resources.ApplyResources(this.oMenuPathViewThumb, "oMenuPathViewThumb");
            this.oMenuPathViewThumb.BackgroundImage = null;
            this.oMenuPathViewThumb.Name = "oMenuPathViewThumb";
            this.oMenuPathViewThumb.ShortcutKeyDisplayString = null;
            this.oMenuPathViewThumb.Click += new System.EventHandler(this.oMenuPathViewThumb_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.AccessibleDescription = null;
            this.toolStripMenuItem2.AccessibleName = null;
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            // 
            // oMenuPathRefresh
            // 
            this.oMenuPathRefresh.AccessibleDescription = null;
            this.oMenuPathRefresh.AccessibleName = null;
            resources.ApplyResources(this.oMenuPathRefresh, "oMenuPathRefresh");
            this.oMenuPathRefresh.BackgroundImage = null;
            this.oMenuPathRefresh.Name = "oMenuPathRefresh";
            this.oMenuPathRefresh.ShortcutKeyDisplayString = null;
            this.oMenuPathRefresh.Click += new System.EventHandler(this.oMenuPathRefresh_Click);
            // 
            // oMenuLanguage
            // 
            this.oMenuLanguage.AccessibleDescription = null;
            this.oMenuLanguage.AccessibleName = null;
            resources.ApplyResources(this.oMenuLanguage, "oMenuLanguage");
            this.oMenuLanguage.BackgroundImage = null;
            this.oMenuLanguage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oMenuLanguageGerman,
            this.oMenuLanguageEnglish});
            this.oMenuLanguage.Name = "oMenuLanguage";
            this.oMenuLanguage.ShortcutKeyDisplayString = null;
            // 
            // oMenuLanguageGerman
            // 
            this.oMenuLanguageGerman.AccessibleDescription = null;
            this.oMenuLanguageGerman.AccessibleName = null;
            resources.ApplyResources(this.oMenuLanguageGerman, "oMenuLanguageGerman");
            this.oMenuLanguageGerman.BackgroundImage = null;
            this.oMenuLanguageGerman.Name = "oMenuLanguageGerman";
            this.oMenuLanguageGerman.ShortcutKeyDisplayString = null;
            this.oMenuLanguageGerman.Click += new System.EventHandler(this.mnuLanguageGerman_Click);
            // 
            // oMenuLanguageEnglish
            // 
            this.oMenuLanguageEnglish.AccessibleDescription = null;
            this.oMenuLanguageEnglish.AccessibleName = null;
            resources.ApplyResources(this.oMenuLanguageEnglish, "oMenuLanguageEnglish");
            this.oMenuLanguageEnglish.BackgroundImage = null;
            this.oMenuLanguageEnglish.Name = "oMenuLanguageEnglish";
            this.oMenuLanguageEnglish.ShortcutKeyDisplayString = null;
            this.oMenuLanguageEnglish.Click += new System.EventHandler(this.mnuLanguageEnglish_Click);
            // 
            // oMenuHelp
            // 
            this.oMenuHelp.AccessibleDescription = null;
            this.oMenuHelp.AccessibleName = null;
            resources.ApplyResources(this.oMenuHelp, "oMenuHelp");
            this.oMenuHelp.BackgroundImage = null;
            this.oMenuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oMenuHelpAbout});
            this.oMenuHelp.Name = "oMenuHelp";
            this.oMenuHelp.ShortcutKeyDisplayString = null;
            // 
            // oMenuHelpAbout
            // 
            this.oMenuHelpAbout.AccessibleDescription = null;
            this.oMenuHelpAbout.AccessibleName = null;
            resources.ApplyResources(this.oMenuHelpAbout, "oMenuHelpAbout");
            this.oMenuHelpAbout.BackgroundImage = null;
            this.oMenuHelpAbout.Name = "oMenuHelpAbout";
            this.oMenuHelpAbout.ShortcutKeyDisplayString = null;
            this.oMenuHelpAbout.Click += new System.EventHandler(this.oMenuHelpAbout_Click);
            // 
            // bgWrkExif
            // 
            this.bgWrkExif.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWrkExif_DoWork);
            this.bgWrkExif.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWrkExif_RunWorkerCompleted);
            // 
            // bgWrkImg
            // 
            this.bgWrkImg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWrkImg_DoWork);
            this.bgWrkImg.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWrkImg_RunWorkerCompleted);
            // 
            // frmMain
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.oSplitLeft);
            this.Controls.Add(this.oMenu);
            this.Font = null;
            this.Name = "frmMain";
            this.oSplitLeft.Panel1.ResumeLayout(false);
            this.oSplitLeft.Panel2.ResumeLayout(false);
            this.oSplitLeft.ResumeLayout(false);
            this.oSplitFile.Panel1.ResumeLayout(false);
            this.oSplitFile.Panel2.ResumeLayout(false);
            this.oSplitFile.ResumeLayout(false);
            this.oSplitEXIF.Panel1.ResumeLayout(false);
            this.oSplitEXIF.Panel2.ResumeLayout(false);
            this.oSplitEXIF.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.oImg)).EndInit();
            this.oMenu.ResumeLayout(false);
            this.oMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip oMenu;
        private System.Windows.Forms.ToolStripMenuItem oMenuFile;
        private System.Windows.Forms.ToolStripMenuItem oMenuFileEnd;
        private System.Windows.Forms.ToolStripMenuItem oMenuPath;
        private System.Windows.Forms.ToolStripMenuItem oMenuPathView;
        private System.Windows.Forms.ToolStripMenuItem oMenuPathViewList;
        private System.Windows.Forms.ToolStripMenuItem oMenuPathViewSmall;
        private System.Windows.Forms.ToolStripMenuItem oMenuPathViewDetails;
        private System.Windows.Forms.ToolStripMenuItem oMenuPathViewThumb;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem oMenuPathRefresh;
        private System.Windows.Forms.SplitContainer oSplitLeft;
        private System.Windows.Forms.SplitContainer oSplitEXIF;
        private System.Windows.Forms.PropertyGrid oEXIF;
        private System.Windows.Forms.SplitContainer oSplitFile;
        private System.Windows.Forms.PictureBox oImg;
        private System.ComponentModel.BackgroundWorker bgWrkExif;
        private System.ComponentModel.BackgroundWorker bgWrkImg;
        private de.coe.controls.filecontrols.ExplorerTreeView oTree;
        private de.coe.controls.filecontrols.ExplorerListView oFiles;
        private System.Windows.Forms.ToolStripMenuItem oMenuHelp;
        private System.Windows.Forms.ToolStripMenuItem oMenuHelpAbout;
        private System.Windows.Forms.ToolStripMenuItem oMenuLanguage;
        private System.Windows.Forms.ToolStripMenuItem oMenuLanguageGerman;
        private System.Windows.Forms.ToolStripMenuItem oMenuLanguageEnglish;
    }
}

