using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LobbyManager : MonoBehaviour
{
    private int SelectNum;
    private string NickName;

    public GameObject Text_NickName, Button_Play, NetWorkMgr;
    void Start()
    {
        Button_Play.GetComponent<Button>().onClick.AddListener(OnClicked_Play);
    }

    void OnClicked_Play()
    {   
        NickName = Text_NickName.GetComponent<TextMeshProUGUI>().text;
        if (NickName != "" && NetWorkMgr != null)
        {
            NetWorkManager NetMgr = NetWorkMgr.GetComponent<NetWorkManager>();
            NetMgr.SetNickName(NickName);
            NetMgr.OnLogin();
        }
    }
}
