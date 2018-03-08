using de.coe.controls.filecontrols.helpers;

namespace de.coe.controls.filecontrols
{
    partial class ExplorerListView
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExplorerListView));
            this.colHFile = new de.coe.controls.filecontrols.helpers.ExplorerColumnHeader();
            this.colHSize = new de.coe.controls.filecontrols.helpers.ExplorerColumnHeader();
            this.colHTyp = new de.coe.controls.filecontrols.helpers.ExplorerColumnHeader();
            this.colHChanged = new de.coe.controls.filecontrols.helpers.ExplorerColumnHeader();
            this.SuspendLayout();
            // 
            // colHFile
            // 
            this.colHFile.SortCriteria = de.coe.controls.filecontrols.helpers.ExplorerFileSorter.Criteria.ByName;
            resources.ApplyResources(this.colHFile, "colHFile");
            // 
            // colHSize
            // 
            this.colHSize.SortCriteria = de.coe.controls.filecontrols.helpers.ExplorerFileSorter.Criteria.BySize;
            resources.ApplyResources(this.colHSize, "colHSize");
            // 
            // colHTyp
            // 
            this.colHTyp.SortCriteria = de.coe.controls.filecontrols.helpers.ExplorerFileSorter.Criteria.ByType;
            resources.ApplyResources(this.colHTyp, "colHTyp");
            // 
            // colHChanged
            // 
            this.colHChanged.SortCriteria = de.coe.controls.filecontrols.helpers.ExplorerFileSorter.Criteria.ByLastChange;
            resources.ApplyResources(this.colHChanged, "colHChanged");
            // 
            // ExplorerListView
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AllowColumnReorder = true;
            this.BackgroundImage = null;
            this.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHFile,
            this.colHSize,
            this.colHTyp,
            this.colHChanged});
            this.Font = null;
            this.View = System.Windows.Forms.View.Details;
            this.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ExplorerListView_ColumnClick);
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// Spalte "Dateiname" des ExplorerListView-Datengrids
        /// </summary>
        public ExplorerColumnHeader colHFile;
        /// <summary>
        /// Spalte "Dateigröße" des ExplorerListView-Datengrids
        /// </summary>
        public ExplorerColumnHeader colHSize;
        /// <summary>
        /// Spalte "Dateityp" des ExplorerListView-Datengrids ((z.B. .doc = Microsoft Word Dokument))
        /// </summary>        
        public ExplorerColumnHeader colHTyp;
        /// <summary>
        /// Spalte "Geändert Am" des ExplorerListView-Datengrids
        /// </summary>
        public ExplorerColumnHeader colHChanged;


    }
}
