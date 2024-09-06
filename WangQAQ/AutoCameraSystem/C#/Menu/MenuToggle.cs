using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class MenuToggle : UdonSharpBehaviour
{

    public CameraManage CameraManageOBJ = null;

    [HideInInspector] public string toggle = null;

    void Start()
    {
        
    }

    public void _OnButtonEvent()
    {
        if (toggle != null && CameraManageOBJ != null)
        {
            switch (toggle)
            {
                case "Camera1":
                    CameraManageOBJ.SetCameraPos(0);
                    break;
                case "Camera2":
                    CameraManageOBJ.SetCameraPos(1);
                    break;
                case "Camera3":
                    CameraManageOBJ.SetCameraPos(2);
                    break;
                case "Camera4":
                    CameraManageOBJ.SetCameraPos(3);
                    break;
                case "Camera5":
                    CameraManageOBJ.SetCameraPos(4);
                    break;
                case "Camera6":
                    CameraManageOBJ.SetCameraPos(5);
                    break;
                case "Camera7":
                    CameraManageOBJ.SetCameraPos(6);
                    break;
                case "Camera8":
                    CameraManageOBJ.SetCameraPos(7);
                    break;
                case "Camera9":
                    CameraManageOBJ.SetCameraPos(8);
                    break;
            }
        }
    }
}
