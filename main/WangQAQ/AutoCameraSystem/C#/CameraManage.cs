
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

[UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
public class CameraManage : UdonSharpBehaviour
{
    public GameObject Camera = null;
    public GameObject[] Pos = null;

    private int Length = -1;

    [UdonSynced]
    [HideInInspector]
    public int CameraPosSync = 0;

    /// <summary>
    //  这里不用同步，菜单系统同步了
    /// </summary>

    void Start()
    {

        if (Pos.Length <= 0)                                                    //Pos 判空
        {
            this.gameObject.SetActive(false);
            Debug.Log("NO POS!");
            return;
        }

        Length = Pos.Length - 1;                                                //长度转下标

        if (Camera == null)                                                     //Camera 判空
        {
            this.gameObject.SetActive(false);
            return;
        }

        if(SetCameraPos(CameraPosSync) == false)
        {
            this.gameObject.SetActive(false);
            return;
        }

    }

    public bool SetCameraPos(int pos)
    {

        if ( 0 <= pos && pos <= Length )
        {
            if (Pos[pos] != null)
            {

                Camera.transform.SetParent(Pos[pos].transform);                 //Camera 设置倒默认

                Camera.transform.localPosition = Vector3.zero;                  //清空坐标       
                Camera.transform.localEulerAngles = Vector3.zero;

                return true;

            }
        }
        return false;
    }

    public void SendCameraPos(int pos)
    {
        if (SetCameraPos(pos)) 
        {
            if (!Networking.IsOwner(gameObject))
            {
                Networking.SetOwner(Networking.LocalPlayer, gameObject);
            }

            CameraPosSync = pos;

            RequestSerialization();
        }
    }

    public override void OnDeserialization()
    {
        SetCameraPos(CameraPosSync);
    }
}
