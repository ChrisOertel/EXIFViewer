using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.InteropServices;
using de.coe.controls.filecontrols.helpers;

namespace de.coe.controls.filecontrols
{
   /// <summary>
    /// <para>Treeview im Windows Explorer Style auf Grundlage des Standard Treeview Controls.</para>
    /// 
    /// <para>Implementierte Funktionen:</para>
    /// <para>-Anzeige aller (Netz-)Laufwerke auf dem lokalen Rechner</para>
    /// <para>-Dynamisches Nachladen von Unterordnern, beim ersten öffnen, bzw. über eine Property ist eine Aktualisierung mit jedem Öffnen eines Knotens möglich.</para>
    /// <para>-Benennung des Rootknotens per default mit dem Rechnernamen, aber frei zu ändern.</para>
    /// <para>-Ausblendung einzelner Laufwerkstypen.</para>
    /// <para>-gezielte Auswahl eines speziellen Verzeichnisses.</para>
    /// <para>-Über eine Property kann die Anzeige der Dateien (inkl. der Icons) in einem Verzeichnis ein-, bzw. ausgeschaltet werden.</para>
    /// 
    /// <para>Komponente ist lokalisierungsfähig und für Deutsch und Englisch lokalisiert.</para>
    /// </summary>
    /// <example>
    /// <para>Beispiel zum Auslesen des im ExplorerTreeView selektierten Verzeichnisses:</para>
    /// <code>
    /// DirectoryNode soNode = (DirectoryNode)explorerTreeView1.SelectedNode;
    /// if (soNode.DirInfo != null) //root Knoten enthält keine DirectoryInfo
    ///     { explorerListView1.DisplayDirectory(soNode.DirInfo.FullName); }
    /// </code>
    /// </example>
    public partial class ExplorerTreeView : TreeView
    {
        private bool mbShowFiles = false;
        private bool mbHideFloppy = false;
        private bool mbHideHdd = false;
        private bool mbHideCDRom = false;
        private bool mbHideNetwork = false;
        private bool mbRefreshOnExpand = false;
        private string msRootName = "";
        private ImageList moImageList = new ImageList();
        private Hashtable moSystemIcons = new Hashtable();
        private string msLicense = "";

        //ToDo: Icons...

        /// <summary>
        /// Klassenkonstruktor.
        /// </summary>
        public ExplorerTreeView()
        {
                InitializeComponent();
                this.ImageList = moImageList;
                AddDefaultIcons();
                msRootName = System.Net.Dns.GetHostName();
                this.MouseDown += new MouseEventHandler(ExplorerTreeView_MouseDown);
                this.BeforeExpand += new TreeViewCancelEventHandler(ExplorerTreeView_BeforeExpand);
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
        /// Liefert/Setzt den Anzeigestatus von Dateien innerhalb des ExplorerTreeView (ShowFiles = true => Anzeige der Dateien innerhalb eines Verzeichnisses).
        /// </summary>
        public bool ShowFiles
        {
            get { return this.mbShowFiles; }
            set { this.mbShowFiles = value; }
        }

        /// <summary>
        /// Liefert/Setzt den Namen des rootknotens des ExplorerTreeView; Wird ein Leerstring übergeben wird automatisch der Name des lokalen Rechners genommen.
        /// </summary>
        public string RootNodeName
        {
            get { return msRootName; }
            set 
            { 
                msRootName = value == "" ? System.Net.Dns.GetHostName() : value;
                if (this.Nodes.Count > 0) { this.Nodes[0].Text = msRootName; }
            }
        }

        /// <summary>
        /// Liefert/Setzt den Anzeigestatus für Floppylaufwerke (true = keine Anzeige)
        /// </summary>
        /// <remarks>
        /// Floppylaufwerke werden im .NET Framework als Wechsellaufwerke (analog zu z.B. USB Festplatten behandelt). Di eUnterscheidung anch Floppylaufwerken erfolgt in dieser Komponente durch die Laufwerksbuchstaben A und B.
        /// </remarks>
        public bool HideFloppyDrives
        {
            get { return this.mbHideFloppy; }
            set { this.mbHideFloppy = value; }
        }

        /// <summary>
        /// Liefert/Setzt den Anzeigestatus für Festplatten (true = keine Anzeige)
        /// </summary>
        public bool HideHarddiskDrives
        {
           get { return this.mbHideHdd; }
           set { this.mbHideHdd = value; }
        }

        /// <summary>
        /// Liefert/Setzt den Anzeigestatus für CDRom-Laufwerke (true = keine Anzeige)
        /// </summary>
        public bool HideCDRomDrives
        {
            get { return this.mbHideCDRom; }
            set { this.mbHideCDRom = value; }
        }

        /// <summary>
        /// Liefert/Setzt den Anzeigestatus für Netzlaufwerke (true = keine Anzeige)
        /// </summary>
        public bool HideNetworkDrives
        {
            get { return this.mbHideNetwork; }
            set { this.mbHideNetwork = value; }
        }

        /// <summary>
        /// Liefert/Setzt den Aktualisierungsstatus für ein Verzeichnis beim erneuten Öffnen eines Verzeichnisknotens.
        /// </summary>
        public bool RefreshDirectoryOnExpand
        {
            get { return this.mbRefreshOnExpand; }
            set { this.mbRefreshOnExpand = value; }
        }

#endregion

#region Events

        private void ExplorerTreeView_MouseDown(object sender, MouseEventArgs e)
        {
             TreeNode soNode = this.GetNodeAt(e.X, e.Y);
             if (soNode == null) return;
             soNode.SelectedImageIndex = 7;
             this.SelectedNode = soNode; //selektiert den aktuellen Knoten         
        }

        private void ExplorerTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if( e.Node is FileNode || e.Node == null) return;
            ReplaceDummyNode(e.Node);
        }      

#endregion

#region "Prozeduren/Funktionen"

        /// <summary>
        /// Initialisiert den ExplorerTreeView; Falls dieser vorher schon einmal initialisiert wurde, wird die bisherige Anzeige gelöscht und der Baum mit den aktuellen Eigenschaften neu aufgebaut.
        /// </summary>
        public void InitTree()
        {
            if (de.coe.components.License.LicCheck.CheckKeyForRegKey(msLicense) != "48404A4F4D")
            {
                throw new Exception(Properties.Resources.LicInvalid);
            }
            else
            {
                moSystemIcons.Clear();
                moImageList.Images.Clear();
                Nodes.Clear();
                AddDefaultIcons();//Icons laden
                this.SelectedImageIndex = 7;
                //Hauptknoten erzeugen
                DirectoryNode soNode = new DirectoryNode(this, msRootName);
                //Laufwerke hinzufügen
                foreach (DriveInfo soInfo in DriveInfo.GetDrives())
                {
                    int siIndex = 6;
                    bool mbShowDrive = true;
                    switch (soInfo.DriveType)
                    {
                        case DriveType.Fixed:
                            siIndex = 2;
                            if (mbHideHdd == true) { mbShowDrive = false; }
                            break;
                        case DriveType.Network:
                            siIndex = 3;
                            if (mbHideNetwork == true) { mbShowDrive = false; }
                            break;
                        case DriveType.Removable:
                            if (soInfo.Name.Substring(0, 1) == "A" | soInfo.Name.Substring(0, 1) == "B")
                            {
                                siIndex = 1;
                                if (mbHideFloppy == true) { mbShowDrive = false; }
                            }
                            else
                            { siIndex = 4; }
                            break;
                        case DriveType.CDRom:
                            siIndex = 5;
                            if (mbHideCDRom == true) { mbShowDrive = false; }
                            break;
                    }
                    if (mbShowDrive == true)
                    { DirectoryNode soDrive = new DirectoryNode(soNode, new DirectoryInfo(soInfo.Name), siIndex); }
                }
                soNode.SelectedImageIndex = 7;
                soNode.Expand();
            }
        }

        /// <summary>
        /// Liefert den interner Index innerhalb der internen ExplorerTreeView Imagelist zurück. Falls für die Extension der Datei noch kein Icon zu der internen ImageList vorhanden ist, wird dieses hinzugefügt.
        /// </summary>
        /// <param name="path">kompletter Pfad zu der Datei</param>
        /// <returns>Interner Index innerhalb der internen ExplorerTreeView Imagelist.</returns>
        /// <remarks>
        /// Methode ist nur public, da die Klasse FileNode hierauf zugreifen muß, evtl. wird sich für diese Klasse noch der Namespace ändern, um den Zugriff auf protected/private zu ändern.
        /// </remarks>
        public int GetIconImageIndex( string path )
        {  
            string extension = Path.GetExtension( path );
            if( moSystemIcons.ContainsKey( extension ) == false )
            {
                Icon icon = de.coe.components.win32api.GetFileInformation.GetSmallIcon( path );            
                moImageList.Images.Add( icon );
                moSystemIcons.Add( extension, moImageList.Images.Count-1 );
            }
            return (int)moSystemIcons[ Path.GetExtension( path )];
        }

        /// <summary>
        /// Anzeige eines spezifischen Verzeichnisses im ExplorerTreeView. Der Knoten des Verzeichnisses wird hierdurch automatishc selektiert.
        /// </summary>
        /// <param name="Path">Kompletter Pfad zu dem im ExplorerTreeView anzuzeigenden Verzeichnis.</param>
        /// <returns>true = Verzeichnis wird angezeigt, false = Verzeichnis nicht im ExplorerTreeView gefunden</returns>
        /// <remarks>
        /// Während der Baum nach dem angegebenen Verzeichnis sucht, wird die Eigenschaft RefreshOnExpand temporär abgeschaltet und nach Beendigung der Funktion wieder auf seinen vorherigen Wert gesetzt.
        /// </remarks>
        public bool ExpandDirectory(string Path)
        {
            if (Directory.Exists(Path) == true)
            {
                bool mbTemp = mbRefreshOnExpand;
                mbRefreshOnExpand = false;
                string[] ssPathPart = Path.Split(new Char[] { '\\' });
                FindSubNodeFromNode(this.Nodes[0], ssPathPart, 0);
                Application.DoEvents();
                mbRefreshOnExpand = mbTemp;
                return true;
            }
            else
                { return false; }
        }

        private void ReplaceDummyNode(TreeNode Node)
        {
            DirectoryNode soDirNode = (DirectoryNode)Node;
            if (!soDirNode.Loaded)
            {
                soDirNode.Nodes[0].Remove(); //Dummyknoten entfernen
                soDirNode.LoadDirectory();
                if (ShowFiles == true)
                { soDirNode.LoadFiles(); }
            }
            else if (mbRefreshOnExpand == true && soDirNode.Parent != null)
            {
                for (int i = soDirNode.Nodes.Count -1; i >= 0; i--)
                {
                    soDirNode.Nodes[i].Remove();
                }
                soDirNode.LoadDirectory();
                if (ShowFiles == true)
                { soDirNode.LoadFiles(); }
            }
        }

        private void FindSubNodeFromNode(TreeNode Parent, string [] Text, int Level)
        {
            string ssDir = Text[Level].ToUpper() + ((Level == 0 && Text[Level].Length == 2) ? "\\" : "");
            foreach (TreeNode soNode in Parent.Nodes)
            {
                if ((soNode.Text.ToUpper() == ssDir) && (Level < Text.GetLength(0) - 1))
                {
                    ReplaceDummyNode(soNode);
                    if (Text[Level + 1] != "")
                        { FindSubNodeFromNode(soNode, Text, Level + 1); }
                    else
                    {
                        Application.DoEvents();
                        soNode.SelectedImageIndex = 7;
                        this.SelectedNode = soNode;
                    }
                    break;
                }

                else if ((soNode.Text.ToUpper() == ssDir) && (Level == Text.GetLength(0) - 1))
                {
                    Application.DoEvents();
                    soNode.SelectedImageIndex = 7;
                    this.SelectedNode = soNode;
                    break;
                }
            }
        }

        private void AddIcon(string Resource, string Key, int ID)
        {
            Icon soIcon = new Icon(typeof(ExplorerTreeView), Resource);
            moImageList.Images.Add(soIcon);
            moSystemIcons.Add(Key, ID);
        }

        private void AddDefaultIcons()
        {
            AddIcon("icons.home.ico", "Home", 0);
            AddIcon("icons.floppy.ico", "Floppy", 1);
            AddIcon("icons.hdd.ico", "HDD", 2);
            AddIcon("icons.network.ico", "Network", 3);
            AddIcon("icons.remove.ico", "Remove", 4);
            AddIcon("icons.cdrom.ico", "CDRom", 5);
            AddIcon("icons.folder.ico", "Folder", 6);
            AddIcon("icons.selectednode.ico", "Selected", 7);
        }

#endregion

 }
}

namespace de.coe.controls.filecontrols.helpers
{
   /// <summary>
    /// Erweiterung des Standardcontrols TreeNode um Verzeichnisinformationen
   /// </summary>
   public class DirectoryNode : TreeNode
   {
      private DirectoryInfo soDirInfo;

#region "Konstruktoren"

      /// <summary>
      /// Konstruktor für den Rootknoten des Treeviews.
      /// </summary>
      /// <param name="treeView">TreeView Objekt, an den der Rootknoten erzeugt werden soll.</param>
      /// <param name="NodeName">Name des Rootknotens.</param>
      public DirectoryNode(ExplorerTreeView treeView, string NodeName)
       {
           this.soDirInfo = null;
           this.Tag = "";
           this.ImageIndex = 0;
           this.Text = NodeName;
           this.SelectedImageIndex = 7;
           treeView.Nodes.Add(this);
           Virtualize();
       }

      /// <summary>
      /// Konstruktor für die Laufwerksknoten unterhalb des Rootknotens.
      /// </summary>
      /// <param name="Parent">Vaterknoten, an den der DirectoryNode für ein Laufwerk angehängt werden soll (=Rootknoten).</param>
      /// <param name="DirInfo">DirectoryInfo Objekt für das Verzeichnis, für das ein DirectoryNode erzeugt werden soll.</param>
      /// <param name="ImgIndex">interner Index für das Laufwerksicon (siehe Anmerkungen).</param>
      /// <remarks>
      /// <para>Bedeutung des Iconindex für Laufwerke:</para>
      /// <para>Home=0</para>
      /// <para>Floppylaufwerk=1</para>
      /// <para>Festplatte=2</para>
      /// <para>Netzlaufwerk=3</para>
      /// <para>Wechseldatenträger=4</para>
      /// <para>CDRom-Laufwerk=5</para>
      /// <para>Verzeichnis=6</para>
      /// </remarks>
      public DirectoryNode(DirectoryNode Parent, DirectoryInfo DirInfo, int ImgIndex) : base(DirInfo.Name)
      {
         this.soDirInfo = DirInfo;
         this.Tag = DirInfo.FullName;
         this.ImageIndex = ImgIndex;
         this.SelectedImageIndex = this.ImageIndex;   
         Parent.Nodes.Add( this );
         Virtualize();
      }
      
      /// <summary>
      /// Konstruktor für einen Verzeichniskoten innerhalb des ExplorerTreeViews. Der Name des Knotens entspricht dem Verzeichnisnamen aus der übergebenen DirInfo.
      /// </summary>
      /// <param name="treeView">TreeView Objekt, an das ein Verzeichnisknoten angehängt werden soll.</param>
      /// <param name="DirInfo">DirectoryInfo Objekt für das Verzeichnis, für das ein DirectoryNode erzeugt werden soll.</param>      
      public DirectoryNode( ExplorerTreeView treeView, DirectoryInfo DirInfo ) : base( DirInfo.Name )
      {
        this.soDirInfo = DirInfo;
        this.Tag = DirInfo.FullName;
        this.ImageIndex = 6;
        this.SelectedImageIndex = this.ImageIndex;   
        treeView.Nodes.Add( this );
        Virtualize();
      }

#endregion

#region "Properties"

    /// <summary>
    /// Überprüfung, ob die Unterknoten bereits geladen wurden, oder ob dies noch ein Dummyknoten ist.
    /// </summary>
    public bool Loaded
    {
        get
        {
            if (this.Nodes.Count != 0)
            {
                if (this.Nodes[0] is DummyChildNode)
                    return false;
            }
            return true;
        }
    }

       /// <summary>
       /// DirectoryInfo Objekt des aktuellen Knotens
       /// </summary>
       public DirectoryInfo DirInfo
       {
           get { return soDirInfo; }
       }

#endregion

#region "Prozeduren/Funktionen"

    private void Virtualize()
      {
         int fileCount = 0;
         try
         {
            if( this.TreeView.ShowFiles == true ) fileCount = this.soDirInfo.GetFiles().Length;         
            if( (fileCount + this.soDirInfo.GetDirectories().Length) > 0 ) new DummyChildNode( this );            
         }
         catch
         {
         }
      }

      /// <summary>
      /// Lädt die zugehörigen Unterverzeichnisse zu einem Verzeichnisknoten.
      /// </summary>
      public void LoadDirectory()
      {         
         foreach( DirectoryInfo directoryInfo in soDirInfo.GetDirectories() )
         {
            new DirectoryNode( this, directoryInfo, 6 );            
         }
      }           

      /// <summary>
      /// Lädt die zugehörigen Dateien zu einem Verzeichnisknoten.
      /// </summary>
      public void LoadFiles()
      {
         foreach( FileInfo file in soDirInfo.GetFiles() )
         {
            new FileNode( this, file );            
         }
      }

      /// <summary>
      /// Liefert ein neues ExplorerTreeView Objekt zurück, welches dem ExplorerTreeView Objekt entspricht, aus dem der aktuelle Verzeichnisknoten stammt.
      /// </summary>
      public new ExplorerTreeView TreeView
      {
         get{ return (ExplorerTreeView)base.TreeView; }
      }

#endregion
  }

    /// <summary>
    /// Erweiterung des Standardcontrols TreeNode um Dateiinformationen
    /// </summary>
    /// <remarks>
    /// Klase wird in einer zukünftigen Version evtl. den Namespace wechseln, um ExplorerTreeView.GetIconImageIndex nicht public setzen zu müssen.
    /// </remarks>
   public class FileNode : TreeNode
   {
      private FileInfo soFileInfo;
      private DirectoryNode soDirNode;

      /// <summary>
      /// Konstruktor für einen neuen Dateiknoten im ExplorerTreeView. Der Name des Knotens entspricht dem Dateinamen aus der übergebenen FileInfo.
      /// </summary>
      /// <param name="DirNode">Vaterknoten, an den der Dateiknoten angehängt wird.</param>
      /// <param name="FileInfo">FileInfo Objekt der hinzuzufügenden Datei.</param>
      public FileNode( DirectoryNode DirNode, FileInfo FileInfo ) : base( FileInfo.Name )
      {         
         this.soDirNode = DirNode;
         this.soFileInfo = FileInfo;
         this.Tag = FileInfo.FullName;
         this.ImageIndex = ((ExplorerTreeView)soDirNode.TreeView).GetIconImageIndex( soFileInfo.FullName );
         this.SelectedImageIndex = this.ImageIndex;
         soDirNode.Nodes.Add( this );        
      }
   }

   /// <summary>
   /// Erweiterung des Standardcontrols TreeNode. Wird zur Unterscheidung von bereits geladenen Verzeichnis./Dateiknoten von noch nicht Geladenen benötigt.
   /// </summary>
   public class DummyChildNode : TreeNode
   {
      /// <summary>
       /// Konstruktor für Dummyverzeichnisknoten im ExplorerTreeView (siehe Anmerkungen).
      /// </summary>
       /// <param name="Parent">Vaterknoten, an den der Dummyknoten angehängt wird.</param>
      /// <remarks>
      /// Dummyknoten werden im Rahmen des Controls benötigt um das Plus (+) Zeichenim TreeView für noch nicht geladenen Unterverzeichnisknoten anzuzeigen. Mit dem ersten aufklappen eines Knotens werden die Dummyknoten durch die richtigen Verzeichnis-/Dateiknoten ersetzt.
      /// </remarks>
      public DummyChildNode( TreeNode Parent ) : base()
      {
         Parent.Nodes.Add( this );
      }
   }

}