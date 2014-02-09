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

namespace TravelJournal.WinForm.Test.Controls
{
    public partial class TravelMapPlayer : UserControl
    {
        public TravelMapPlayer()
        {
            InitializeComponent();
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
            gMapControl.Zoom = 6;
        }

        public void FocusOn(string keywords,int zoom)
        {
            gMapControl.SetPositionByKeywords(keywords);
            gMapControl.Zoom = zoom;
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
    }
}
