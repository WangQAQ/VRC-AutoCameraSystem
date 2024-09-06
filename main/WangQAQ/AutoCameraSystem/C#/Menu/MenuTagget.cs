
using TMPro;
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class MenuTagget : UdonSharpBehaviour
{
    public CameraFollow CFollow = null;

    public TMP_InputField inp = null;

    void Start()
    {
        
    }

    public void _OnInputEndEdit()
    {
        if(inp != null)
        {
            if(inp.text != null && CFollow != null)
            {
                if(inp.text.Length > 0)
                {
                    CFollow.StartTaggetSync(inp.text);
                }
            }
        }
    }
}
