using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ScreenManager : MonoBehaviour
{
    DeviceOrientation phoneOrientation;
    [SerializeField] private List<Canvas> screens;
    [SerializeField] private new CinemachineVirtualCamera camera;

    private bool inPuzzle = false;

    void Update()
    {
        if (!inPuzzle)
        {
            phoneOrientation = Input.deviceOrientation;

            //switch that changes the camera's rotation and active canvas based on the phone's orientation.
            switch (phoneOrientation)
            {
                case DeviceOrientation.Portrait:
                    camera.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    SwitchCanvas(screens[0]);
                    break;
                case DeviceOrientation.LandscapeLeft:
                    camera.transform.localRotation = Quaternion.Euler(0, 0, -270);
                    SwitchCanvas(screens[1]);
                    break;
                case DeviceOrientation.LandscapeRight:
                    camera.transform.localRotation = Quaternion.Euler(0, 0, 270);
                    SwitchCanvas(screens[2]);
                    break;
                case DeviceOrientation.PortraitUpsideDown:
                    camera.transform.localRotation = Quaternion.Euler(0, 0, 180);
                    SwitchCanvas(screens[3]);
                    break;
                default:
                    camera.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    SwitchCanvas(screens[0]);
                    break;

            }
        }
    }

    public void SetPuzzle(bool value)
    {
        inPuzzle = value;
    }

    /// <summary>
    /// Switched the active canvas in the list to the given canvas
    /// </summary>
    /// <param name="canvas"></param>
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
