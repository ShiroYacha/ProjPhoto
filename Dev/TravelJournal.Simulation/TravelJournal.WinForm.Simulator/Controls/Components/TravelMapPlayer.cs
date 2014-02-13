using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using TravelJournal.WinForm.Simulator.Forms;

namespace TravelJournal.WinForm.Simulator.Controls
{
    public partial class TravelMapPlayer : UserControl,ITestControl
    {
        private const int RATIO_DEFAULT_ZOOM = 2;

        private const string ID_ANCHORS_LAYER = "Anchors layer";
        private const string ID_CAMERASPOT_LAYER = "Camera spots layer";

        private GMapOverlay anchorsLayer = new GMapOverlay(ID_ANCHORS_LAYER);
        private GMapOverlay cameraSpotsLayer = new GMapOverlay(ID_CAMERASPOT_LAYER);

        public TravelMapPlayer()
        {
            InitializeComponent();
            // Load layers
            gMapControl.Overlays.Add(cameraSpotsLayer);
            gMapControl.Overlays.Add(anchorsLayer);
        }

        private void TravelMapPlayer_Load(object sender, EventArgs e)
        {
            InitializeGMap();
        }

        private void InitializeGMap()
        {
            gMapControl.MapProvider = GMap.NET.MapProviders.GMapProviders.BingMap;
            gMapControl.DragButton = MouseButtons.Left;
            GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            gMapControl.MaxZoom = 15;
            gMapControl.MinZoom = 1;
            gMapControl.Zoom = RATIO_DEFAULT_ZOOM;
        }

        public void FocusOn(string keywords, int zoom = RATIO_DEFAULT_ZOOM)
        {
            gMapControl.SetPositionByKeywords(keywords);
            gMapControl.Zoom = zoom;
        }

        public void RegisterMouseClickHandler(MouseEventHandler handler)
        {
            gMapControl.MouseClick += handler;
        }

        public GpsPoint ConvertToGpsPoint(Point localPoint)
        {
            PointLatLng gps=gMapControl.FromLocalToLatLng(localPoint.X,localPoint.Y);
            return new GpsPoint() { Lat = gps.Lat, Lng = gps.Lng };
        }

        public void SetAnchors(List<GpsPoint> anchors)
        {
            anchorsLayer.Markers.Clear();
            foreach (GpsPoint anchor in anchors)
            {
                anchorsLayer.Markers.Add(new GMarkerGoogle(new PointLatLng(anchor.Lat,anchor.Lng), GMarkerGoogleType.blue_small));
            }
        }

        public void SetCameraSpots(List<GpsPoint> cameraSpots)
        {
            cameraSpotsLayer.Markers.Clear();
            foreach (GpsPoint cameraSpot in cameraSpots)
            {
                cameraSpotsLayer.Markers.Add(new GMarkerGoogle(new PointLatLng(cameraSpot.Lat, cameraSpot.Lng), GMarkerGoogleType.red_small));
            }
        }

        private void test()
        {
            GMapOverlay markersOverlay = new GMapOverlay("markers");
            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(49 + 6 / 60.0 + 11.35 / 3600.0, 6 + 13 / 60.0 + 12.558 / 3600.0),
              GMarkerGoogleType.red_big_stop);
            markersOverlay.Markers.Add(marker);
            gMapControl.Overlays.Add(markersOverlay);

            List<Placemark> plc = null;
            var st = GMapProviders.GoogleMap.GetPlacemarks(new PointLatLng(49 + 6 / 60.0 + 11.35 / 3600.0, 6 + 13 / 60.0 + 12.558 / 3600.0), out plc);
            if (st == GeoCoderStatusCode.G_GEO_SUCCESS && plc != null)
            {
                foreach (var pl in plc)
                {
                    if (!string.IsNullOrEmpty(pl.PostalCodeNumber))
                    {

                    }
                }
            }
        }

        public void Initialize()
        {
            InitializeGMap();
        }
    }
}
