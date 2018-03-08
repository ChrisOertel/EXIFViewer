using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Text;
using System.IO;
using System.Collections;
using System.Drawing;
using de.coe.components.win32api;
using de.coe.controls.filecontrols.helpers;

namespace de.coe.controls.filecontrols
{
    /// <summary>
    /// <para>Listview im Windows Explorer Style auf Grundlage des Standard Listview Controls.</para>
    /// 
    /// <para>Implementierte Funktionen:</para>
    /// <para>-Anzeige der Dateien in einem spezifizierten Ordner mit folgenden Informationen: Dateiname, Dateigröße, Dateityp und letztes Änderungsdatum. Ein Umschalten der Ansicht und das Verschieben der Spalten ist über die Standardfunktionen des Listview Controls möglich.</para>
    /// <para>-Sortierung der einzelnen Spalten in der Detailansicht über einen Click auf dem Spaltenkopf.</para>
    /// 
    /// <para>Komponente ist lokalisierungsfähig und für Deutsch und Englisch lokalisiert.</para>
    /// </summary>
    /// <example>
    /// <para>Beispiel zum Auslesen der im ExplorerListView selektierten Dateien:</para>
    /// <code>
    /// FileInformation soFile = (FileInformation)explorerListView1.SelectedItems[0].Tag;
    /// MessageBox.Show (soFile.Name);
    /// </code>
    /// </example>
    public partial class ExplorerListView : ListView
    {
        private ImageList moImgListSmall = new ImageList();
        private ImageList moImgListLarge = new ImageList();
        private Hashtable moSystemIcons = new Hashtable();
        private string msFilePath = "";
        private string msSearchPattern = "";
        private View moView;
        private bool mbShowFileSize = true;
        private bool mbShowFileType = true;
        private bool mbShowFileDate = true;
        private string msLicense = "";

        /// <summary>
        /// Sortierfunktionen für die Anzeige im ExplorerListView
        /// </summary>
        protected ExplorerFileSorter ExpFileSorter = new ExplorerFileSorter();

        /// <summary>
        /// Klassenkonstruktor.
        /// </summary>
        public ExplorerListView()
        {
            System.Diagnostics.Trace.WriteLine(">>> de.coe.controls.filecontrols.ExplorerListView.ExplorerListView()");
            InitializeComponent();
            moImgListLarge.ImageSize = new Size(90, 90);
            moImgListLarge.ColorDepth = ColorDepth.Depth32Bit;
            this.SmallImageList = moImgListSmall;
            this.LargeImageList = moImgListLarge;
            this.View = moView;
            System.Diagnostics.Trace.WriteLine("<<< de.coe.controls.filecontrols.ExplorerListView.ExplorerListView()");
        }

#region "Properties"

        /// <summary>
        /// Lizenzschlüssel für diese Komponente.
        /// </summary>
        public string LicenseKey
        {
            get { return msLicense; }
            set { msLicense = value; }
        }

        /// <summary>
        /// Blendet die Anzeigespalte für den Dateityp ein, bzw. aus.
        /// </summary>
        public bool ShowFileType
        {
            get { return mbShowFileType; }
            set { mbShowFileType = value; }
        }

        /// <summary>
        /// Blendet die Anzeigespalte für das Dateidatum ein, bzw. aus.
        /// </summary>
        public bool ShowFileDate
        {
            get { return mbShowFileDate; }
            set { mbShowFileDate = value; }
        }

        /// <summary>
        /// Blendet die Anzeigespalte für die Dateigröße ein, bzw. aus.
        /// </summary>
        public bool ShowFileSize
        {
            get { return mbShowFileSize; }
            set { mbShowFileSize = value; }
        }

#endregion

#region "Prozeduren/Funktionen"

        /// <summary>
        /// Anzeige eines über den Parameter übergebenen Verzeichnisses in dem Control.
        /// </summary>
        /// <param name="FilePath">Kompletter Pfad zu dem anzuzeigenden Ordner</param>
        /// <param name="SearchPattern">Suchkriterium für die anzuzeigenden Dateien (z.B. "*.jpg")</param>
        public void DisplayDirectory(string FilePath, string SearchPattern)
        {
            System.Diagnostics.Trace.WriteLine(">>> de.coe.controls.filecontrols.ExplorerListView.DisplayDirectory");
            if (de.coe.components.License.LicCheck.CheckKeyForRegKey(msLicense) != "48404A4F4D")
            {
                System.Diagnostics.Trace.WriteLine("ERR de.coe.controls.filecontrols.ExplorerListView.DisplayDirectory => " + Properties.Resources.LicInvalid);
                throw new Exception(Properties.Resources.LicInvalid);
            }
            else
            {
                msFilePath = FilePath;
                msSearchPattern = SearchPattern;
                moView = this.View;
                this.moImgListSmall.Images.Clear();
                this.moImgListLarge.Images.Clear();
                this.moSystemIcons.Clear();
                this.Items.Clear();
                try //Ordner einlesen
                {
                    foreach (string ssFile in Directory.GetFiles(FilePath, SearchPattern, SearchOption.TopDirectoryOnly))
                    {
                        FileInformation soFileInfo = new FileInformation(ssFile);
                        ListViewItem soLVI = this.Items.Add(soFileInfo.Name);
                        soLVI.Tag = soFileInfo;
                        soLVI.ImageIndex = GetIconImageIndex(ssFile);
                        if (mbShowFileSize == true)
                        { soLVI.SubItems.Add((soFileInfo.Size + 1023) / 1024 + " KB"); }
                        if (mbShowFileType == true)
                        { soLVI.SubItems.Add(soFileInfo.Filetype); }
                        if (mbShowFileDate == true)
                        { soLVI.SubItems.Add(soFileInfo.LastChanged.ToString()); }
                    }
                    if (moView == View.LargeIcon)
                    { this.LargeImageList = moImgListLarge; }
                    else
                    { this.SmallImageList = moImgListSmall; }
                    this.ListViewItemSorter = ExpFileSorter;
                    this.View = moView;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    System.Diagnostics.Trace.WriteLine("ERR de.coe.controls.filecontrols.ExplorerListView.DisplayDirectory => " + ex.Message.ToString());
                }
            }
            System.Diagnostics.Trace.WriteLine("<<< de.coe.controls.filecontrols.ExplorerListView.DisplayDirectory");
        }

        /// <summary>
        /// Aktualisiert die Anzeige anhand des zuletzt übergebenen Pfades und Suchkriteriums.
        /// </summary>
        public override void Refresh()
        {
            System.Diagnostics.Trace.WriteLine(">>> de.coe.controls.filecontrols.ExplorerListView.Refresh");
            DisplayDirectory(msFilePath, msSearchPattern);
            System.Diagnostics.Trace.WriteLine("<<< de.coe.controls.filecontrols.ExplorerListView.Refresh");
        }

        /// <summary>
        /// Setzt die zur Anzeige verwendete Sprache zur Laufzeit neu.
        /// </summary>
        /// <param name="Culture">Sprache, die zur Anzeige verwendet werden soll (de oder en).</param>
        public void SetCurrentCulture(string Culture)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Culture);
            switch (Culture)
            {
                case "de":
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Culture + "-" + Culture.ToUpper());
                    break;
                case "en":
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Culture + "-GB");
                    break;
            }
            this.SuspendLayout();
            //oFiles
            System.Resources.ResourceManager soResource = new System.Resources.ResourceManager(this.GetType());
            this.Columns[0].Text = soResource.GetString("colHFile.Text");
            this.Columns[1].Text = soResource.GetString("colHSize.Text");
            this.Columns[3].Text = soResource.GetString("colHChanged.Text");
            this.Columns[2].Text = soResource.GetString("colHTyp.Text");
            this.ResumeLayout();
        }

        private int GetIconImageIndex(string FilePath)
        {
            System.Diagnostics.Trace.WriteLine(">>> de.coe.controls.filecontrols.ExplorerListView.GetIconImageIndex");
            string ssKey = "";
            if (moView != View.LargeIcon)
                { ssKey = System.IO.Path.GetExtension(FilePath); }
            else
                { ssKey = System.IO.Path.GetFileName(FilePath); }
            if (moSystemIcons.ContainsKey(ssKey) == false)
            {
                Icon soIcon;
                soIcon = GetFileInformation.GetSmallIcon(FilePath);
                moImgListSmall.Images.Add(soIcon);
                if (moView != View.LargeIcon)
                {
                    soIcon = GetFileInformation.GetLargeIcon(FilePath);
                    moImgListLarge.Images.Add(soIcon);
                }
                else
                    {
                        try
                        { moImgListLarge.Images.Add(ResizeImage(Image.FromFile(FilePath), 120)); }
                        catch
                        {
                            soIcon = GetFileInformation.GetLargeIcon(FilePath);
                            moImgListLarge.Images.Add(soIcon);
                        }
                    }
                moSystemIcons.Add(ssKey, moImgListSmall.Images.Count - 1);
            }
            System.Diagnostics.Trace.WriteLine("<<< de.coe.controls.filecontrols.ExplorerListView.GetIconImageIndex");
            return (int)moSystemIcons[ssKey];
        }

        private Image ResizeImage(Image OriginalImg, int MaxHeightOrWidth)
        {
            int siWidth;
            int siHeight;
            if (OriginalImg.Height > OriginalImg.Width)
            {
                siHeight = MaxHeightOrWidth;
                siWidth = (int)(Math.Round(OriginalImg.Width / ((double)OriginalImg.Height / (double)siHeight)));
            }
            else if (OriginalImg.Width > OriginalImg.Height)
            {
                siWidth = MaxHeightOrWidth;
                siHeight = (int)(Math.Round(OriginalImg.Height / ((double)OriginalImg.Width / (double)siWidth)));
            }
            else
            {
                siWidth = MaxHeightOrWidth;
                siHeight = MaxHeightOrWidth;
            }
            Bitmap soBMP = new Bitmap(MaxHeightOrWidth, MaxHeightOrWidth);
            Graphics soGraphic = Graphics.FromImage(soBMP);
            soGraphic.Clear(this.BackColor);
            soGraphic.DrawImage(OriginalImg, (int)Math.Round((double)(soBMP.Width - siWidth) / 2), (int)Math.Round((double)(soBMP.Height - siHeight) / 2), soBMP.Width + 1, soBMP.Height + 1);
            Image soNewImg = soBMP;
            return soNewImg;
        } 

#endregion

#region "Events"

        private void ExplorerListView_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
            System.Diagnostics.Trace.WriteLine(">>> de.coe.controls.filecontrols.ExplorerListView.ExplorerListView_ColumnClick");
            ExplorerColumnHeader soCH = ((ExplorerColumnHeader)(this.Columns[e.Column]));
            ExpFileSorter.SortCriteria = soCH.SortCriteria;
            this.Sort();
            System.Diagnostics.Trace.WriteLine("<<< de.coe.controls.filecontrols.ExplorerListView.ExplorerListView_ColumnClick");
        }

#endregion
    }
}

namespace de.coe.controls.filecontrols.helpers
{
    /// <summary>
    /// Sortierfunktionen für die Anzeige im ExplorerListView
    /// </summary>
    public class ExplorerFileSorter : IComparer
    {
        private bool sortAscending = true;
        private Criteria sortBy = Criteria.ByName;

        /// <summary>
        /// Aufzählung der möglichen Sortierkriterien für den ExplorerListView.             
        ///    ByName => Dateiname
        ///    ByType => Dateityp
        ///    BySize => Dateigröße
        ///    ByLastChange => letztes Änderungsdatum
        /// </summary>
        public enum Criteria
        {
            /// <summary>
            /// Sortierung nach dem Dateinamen
            /// </summary>
            ByName,
            /// <summary>
            /// Sortierung nach dem Dateityp (z.B. .doc = Microsoft Word Dokument)
            /// </summary>
            ByType,
            /// <summary>
            /// Sortierung nach der Dateigröße
            /// </summary>
            BySize,
            /// <summary>
            /// Sortierung nach dem Änderungsdatum
            /// </summary>
            ByLastChange
        }

        /// <summary>
        /// Liefert/Setzt die Sortierreihenfolgen (aufsteigend = true)
        /// </summary>
        public bool Ascending
        {
            get
            { return sortAscending; }
            set
            { sortAscending = value; }
        }

        /// <summary>
        /// Liefert/Setzt das Sortierkriterium.
        /// Wird nochmals das gleiche Sortierkriterium gesetzt, welches schon gesetzt ist, wird die Sortierreihenfolge umgekehrt.
        /// </summary>
        public Criteria SortCriteria
        {
            get
            { return sortBy; }
            set
            {
                if (sortBy == value)
                { sortAscending = !(sortAscending); }
                else
                { sortAscending = true; }
                sortBy = value;
            }
        }

        /// <summary>
        /// Führt den Vergleich zweier ListViewItems anhand der gewählten Sortierkriterien für die Sortierung durch.
        /// </summary>
        /// <param name="x">1. ListViewItem für den Vergleich</param>
        /// <param name="y">2. ListViewItem für den Vergleich</param>
        /// <returns></returns>
        public int Compare(object x, object y)
        {
            ListViewItem soLVI1 = ((ListViewItem)(x));
            ListViewItem soLVI2 = ((ListViewItem)(y));
            FileInformation soFI1 = ((FileInformation)(soLVI1.Tag));
            FileInformation soFI2 = ((FileInformation)(soLVI2.Tag));
            if (soFI1 == null | soFI2 == null)
            {
                return 0;
            }
            int siResult = 0;
            if (sortBy == Criteria.ByName)
            {
                siResult = soFI1.Name.CompareTo(soFI2.Name);
            }
            else if (sortBy == Criteria.BySize)
            {
                siResult = soFI1.Size.CompareTo(soFI2.Size);
            }
            else if (sortBy == Criteria.ByType)
            {
                siResult = soFI1.Filetype.CompareTo(soFI2.Filetype);
            }
            else if (sortBy == Criteria.ByLastChange)
            {
                siResult = soFI1.LastChanged.CompareTo(soFI2.LastChanged);
            }
            if (!(sortAscending))
            {
                siResult = -siResult;
            }
            return siResult;
        }
    }

    /// <summary>
    /// Erweiterung des Standard ColumnHeader des Listview Controls, um (u.a. im graphischen Designer) eine Zuordnung von Spalten zu Sortierkriterien (ByName, ByType, BySize, ByLastChange) zu schaffen
    /// </summary>
    public class ExplorerColumnHeader : ColumnHeader
    {
        private ExplorerFileSorter.Criteria sortBy;

        /// <summary>
        /// Setzt/Liefert die Sortierkriterien (ByName, ByType, BySize, ByLastChange) für eine einzelne Spalte
        /// </summary>
        public ExplorerFileSorter.Criteria SortCriteria
        {
            get
            { return sortBy; }
            set
            { sortBy = value; }
        }
    }

    /// <summary>
    /// Sammlung der Informationen zu einer Datei. 
    /// Innerhalb des ExplorerListView hat jeder Eintrag an der Prpperty Tag die spezifische FileInformation und kann von dort wieder ausgelesen werden.
    /// </summary>
    public class FileInformation : IDisposable
    {
        private string msName;
        private long mlLength;
        private string msFiletype;
        private DateTime mdLastChanged;
        private Icon moLargeIcon;
        private Icon moSmallIcon;
        private FileInfo moFI;

        /// <summary>
        /// Konstruktor, der durch Übergabe eines Dateinamens die ReadOnly Properties der Klasse füllt.
        /// </summary>
        /// <param name="Path">Name der Datei zu der die Dateiinformationen gelesen werden sollen</param>
        public FileInformation(string Path)
        {
            FileInfo soFI = new System.IO.FileInfo(Path);
            msName = soFI.Name;
            moFI = soFI;
            mlLength = soFI.Length;
            mdLastChanged = soFI.LastWriteTime;
            msFiletype = GetFileInformation.GetFileType(Path);
            moSmallIcon = GetFileInformation.GetSmallIcon(Path);
            moLargeIcon = GetFileInformation.GetLargeIcon(Path);
        }

        /// <summary>
        /// Dekonstruktor, welcher die geladenen Icon Resourcen zu einer Datei wieder freigibt.
        /// </summary>
        public void Dispose()
        {
            LargeIcon.Dispose();
            SmallIcon.Dispose();
        }

#region "Properties"

        /// <summary>
        /// FileInfo Objekt der Datei
        /// </summary>
        public FileInfo FileInfo
        {
            get { return moFI; }
        }

        /// <summary>
        /// Name der Datei
        /// </summary>
        public string Name
        {
            get { return msName; }
        }

        /// <summary>
        /// Dateityp der Datei (z.B. .doc = Microsoft Word Dokument)
        /// </summary>
        public string Filetype
        {
            get { return msFiletype; }
        } 

        /// <summary>
        /// Dateigröße der Datei in KB
        /// </summary>
        public long Size
        {
            get { return mlLength; }
        }

        /// <summary>
        /// Letztes Änderungsdatum der Datei
        /// </summary>
        public DateTime LastChanged
        {
            get { return mdLastChanged; }
        }

        /// <summary>
        /// Largeicon(32*32 Pixel) der Datei
        /// </summary>
        public Icon LargeIcon
        {
            get { return moLargeIcon; }
        }

        /// <summary>
        /// Largeicon(16*16 Pixel) der Datei
        /// </summary>
        public Icon SmallIcon
        {
            get { return moSmallIcon; }
        }

#endregion

    }
}