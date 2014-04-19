using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelJournal.PCL.DataService;

namespace TravelJournal.WinForm.Simulator.Controls.Components
{
    public partial class PhotoTreeView : UserControl, ITestControl
    {
        private List<Album> albums;

        public PhotoTreeView()
        {
            InitializeComponent();
            // Enable default double buffering processing (DoubleBuffered returns true)
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            // Disable default CommCtrl painting on non-Vista systems
            if (Environment.OSVersion.Version.Major < 6)
                SetStyle(ControlStyles.UserPaint, true);
        }

        public List<Album> Albums
        {
            get { return albums; }
            set
            {
                albums = value;
                if (albums != null)
                {
                    // Update UI
                    IEnumerable<TreeNode> albumNodes = CreateAlbumTreeNodes(albums);
                    UpdateTreeView(albumNodes);
                }
                else
                    Initialize();
            }
        }

        public void Initialize()
        {
            treeView.Nodes.Clear();
        }

        public List<Album> CreateTestPhotoTree()
        {
            List<Album> testAlbums = new List<Album>();
            testAlbums.Add(new Album()
            {
                AlbumName = "Album 1",
                PhotoList = CreateTestPhotoList()
            });
            return testAlbums;
        }

        private void UpdateTreeView(IEnumerable<TreeNode> albumNodes)
        {
            treeView.Nodes.Clear();
            treeView.BeginUpdate();
            foreach (TreeNode albumNode in albumNodes)
                treeView.Nodes.Add(albumNode);
            treeView.EndUpdate();
            treeView.ExpandAll();
        }
        private IEnumerable<TreeNode> CreateAlbumTreeNodes(List<Album> albums)
        {
            List<TreeNode> albumNodes = new List<TreeNode>();
            foreach (Album album in albums)
            {
                TreeNode albumNode = new TreeNode(album.AlbumName);
                albumNode.Name = album.AlbumName;
                // Populate sub albums
                CreateSubTreeNodes(albumNode, album);
                albumNodes.Add(albumNode);
            }
            return albumNodes;

        }
        private void CreateSubTreeNodes(TreeNode albumNode, Album album)
        {
            List<TreeNode> countryNodes = new List<TreeNode>();
            List<TreeNode> cityNodes = new List<TreeNode>();
            if (album.PhotoList != null)
            {
                foreach (Photo photo in album.PhotoList)
                {
                    TreeNode photoNode = new TreeNode(photo.PhotoName);
                    photoNode.Name = photo.PhotoName;
                    // Create or add to city node
                    TreeNode cityNode = CreateOrAddToSubNode(cityNodes, photo.Position.City, photoNode);
                    // Create or add to country node
                    CreateOrAddToSubNode(countryNodes, photo.Position.Country, cityNode);
                }
                // Add to album node
                albumNode.Nodes.AddRange(countryNodes.ToArray());
            }
        }
        private TreeNode CreateOrAddToSubNode(List<TreeNode> nodes, string key, TreeNode subNode)
        {
            if (key==null||key == string.Empty) key = "Unknown";
            TreeNode node = nodes.Find((n) => { return n.Name == key; });
            if (node == null)
            {
                node = new TreeNode() { Name = key, Text = key };
                nodes.Add(node);
            }
            if (!node.Nodes.ContainsKey(subNode.Name)) node.Nodes.Add(subNode);
            return node;
        }
        private List<Photo> CreateTestPhotoList()
        {
            List<Photo> allPhotos=new List<Photo>() {
                    new Photo(){PhotoName="Photo 1",Position=new GpsPosition(){City="Metz",Country="France"}},
                    new Photo(){PhotoName="Photo 2",Position=new GpsPosition(){City="Metz",Country="France"}},
                    new Photo(){PhotoName="Photo 3",Position=new GpsPosition(){City="Metz",Country="France"}},
                    new Photo(){PhotoName="Photo 4",Position=new GpsPosition(){City="Paris",Country="France"}},
                    new Photo(){PhotoName="Photo 5",Position=new GpsPosition(){City="München",Country="Germany"}},
                    new Photo(){PhotoName="Photo 6",Position=new GpsPosition(){City="Köln",Country="Germany"}},
                    new Photo(){PhotoName="Photo 7",Position=new GpsPosition(){City="Lyon",Country="France"}},
                    new Photo(){PhotoName="Photo 8",Position=new GpsPosition(){City="Lyon",Country="France"}},
                    new Photo(){PhotoName="Photo 9",Position=new GpsPosition(){City="Lyon",Country="France"}},
                    new Photo(){PhotoName="Photo 10",Position=new GpsPosition(){City="Lyon",Country="France"}},
                    new Photo(){PhotoName="Photo 11",Position=new GpsPosition(){City="Brest",Country="France"}},
                    };
            Random random = new Random();
            return allPhotos.Take(random.Next(allPhotos.Count)).ToList();
        }
    }
}
