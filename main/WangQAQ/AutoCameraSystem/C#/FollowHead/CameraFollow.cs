
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;

public class CameraFollow : UdonSharpBehaviour
{

    public GameObject Tagget = null;
    public GameObject Camera = null;
    
    private VRCPlayerApi[] Players = null;

    private VRCPlayerApi PApi = null;
    private bool OnTagget = false;

    private int MaxRoomPlayers = 80;
    
    [UdonSynced]
    [HideInInspector]
    public string PlayerName = "";

    void Start()
    {

        Players = new VRCPlayerApi[MaxRoomPlayers];

        if (Players == null)
            return;

    }

    private void Update()
    {

        if (OnTagget)
        {
            if(Tagget != null && Camera != null && PApi != null) 
            {
                if(PApi.IsValid() == true)
                {
                    Vector3 tmp = PApi.GetPosition();
                    tmp.y += PApi.GetAvatarEyeHeightAsMeters();
                    Tagget.transform.position = tmp;
                }
            }
        }

        Camera.transform.LookAt(Tagget.transform);
    }

    bool StartTagget()
    {
        if(Tagget != null && Camera != null)
        {
            if(Players != null)
            {
                VRCPlayerApi.GetPlayers(Players);
                for (int i = 0; i < VRCPlayerApi.GetPlayerCount(); i++)
                {
                    if (Players[i].displayName == PlayerName)
                    {
                        PApi = Players[i];
                        OnTagget = true;
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public void StartTaggetSync(string Name)
    {
        if (!Networking.IsOwner(gameObject))
        {
            Networking.SetOwner(Networking.LocalPlayer, gameObject);
        }

        string PlayerNameBack = PlayerName;

        PlayerName = Name;

        if (StartTagget())
        {
            RequestSerialization();
        }
        else
        {
            PlayerName = PlayerNameBack;
        }
    }

    public override void OnDeserialization()
    {
        if (!Networking.IsOwner(gameObject))
        {
            StartTagget();
        }
    }

}
