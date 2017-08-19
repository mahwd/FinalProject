using Android.Gms.Maps;
using Android.Gms.Maps.Model;

namespace WAU.Resources
{
    public class cameraMover
    {
        public void Move(LatLng pos, int zoom, GoogleMap map)
        {
            CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
            builder.Target(pos).Zoom(zoom).Build();
            CameraPosition camPosition = builder.Build();
            CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(camPosition);
            map.MoveCamera(cameraUpdate);
        }
        public void MoveAnimated(LatLng pos, int zoom, GoogleMap map)
        {
            CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
            builder.Target(pos).Zoom(zoom).Build();
            CameraPosition camPosition = builder.Build();
            CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(camPosition);
            map.AnimateCamera(cameraUpdate);
        }


    }
}