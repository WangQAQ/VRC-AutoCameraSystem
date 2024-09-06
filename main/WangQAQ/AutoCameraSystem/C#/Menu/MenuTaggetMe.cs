
using TMPro;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class MenuTaggetMe : UdonSharpBehaviour
{
    public CameraFollow CFollow = null;

    void Start()
    {

    }

    public void _OnButtonDown()
    {
        if (CFollow != null)
        {
            CFollow.StartTaggetSync(Networking.LocalPlayer.displayName);
        }
    }
}
