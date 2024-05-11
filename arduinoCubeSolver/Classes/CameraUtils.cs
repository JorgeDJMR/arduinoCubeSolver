using Emgu.CV;
using DirectShowLib;

public static class CameraUtils
{
    public static List<string> GetAvailableCameraNames()
    {
        List<string> cameraNames = new List<string>();
        DsDevice[] videoInputDevices = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);

        foreach (DsDevice device in videoInputDevices)
            cameraNames.Add(device.Name);
    
        return cameraNames;
    }

    public static bool IsCameraIndexValid(int cameraIndex)
    {
        DsDevice[] videoInputDevices = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
        if (cameraIndex >= 0 && cameraIndex < videoInputDevices.Length)
            return true;
        return false;
    }
}
