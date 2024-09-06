
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class MeshSwap : UdonSharpBehaviour
{
    public MeshRenderer[] HideMesh;
    public MeshRenderer ShowMesh;

    [HideInInspector] public bool toggleState = false;
    [HideInInspector] public int buttonID = -1;

    void Start()
    {

    }

    public void _OnButtonEvent()
    {
        if (HideMesh != null && ShowMesh != null)
        {
            if(HideMesh.Length != 0)
            {
                if (toggleState)
                {
                    for(int i = 0; i < HideMesh.Length; i++)
                    {
                        HideMesh[i].enabled = false;
                    }
                    ShowMesh.enabled = true;
                }
                else
                {
                    for (int i = 0; i < HideMesh.Length; i++)
                    {
                        HideMesh[i].enabled = true;
                    }
                    ShowMesh.enabled = false;
                }
            }
        }
    }
}
