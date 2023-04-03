using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    DeviceOrientation phoneOrientation;
    [SerializeField] private List<Canvas> screens;

    // Update is called once per frame
    void Update()
    {
        phoneOrientation = Input.deviceOrientation;

        switch (phoneOrientation)
        {
            case DeviceOrientation.Portrait:
                Camera.main.transform.localRotation = Quaternion.Euler(0, 0, 0);
                SwitchCanvas(screens[0]);
                break;
            case DeviceOrientation.LandscapeLeft:
                Camera.main.transform.localRotation = Quaternion.Euler(0, 0, -270);
                SwitchCanvas(screens[1]);
                break;
            case DeviceOrientation.LandscapeRight:
                Camera.main.transform.localRotation = Quaternion.Euler(0, 0, 270);
                SwitchCanvas(screens[2]);
                break;
            case DeviceOrientation.PortraitUpsideDown:
                Camera.main.transform.localRotation = Quaternion.Euler(0, 0, 180);
                SwitchCanvas(screens[3]);
                break;
            default:
                Camera.main.transform.localRotation = Quaternion.Euler(0, 0, 270);
                SwitchCanvas(screens[2]);
                break;

        }
    }

    private void SwitchCanvas(Canvas canvas)
    {
        foreach (var item in screens)
        {
            if(item.gameObject.activeInHierarchy)
                item.gameObject.SetActive(false);
        }

        canvas.gameObject.SetActive(true);
    }
}
