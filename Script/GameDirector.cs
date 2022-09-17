using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class GameDirector : MonoBehaviourPunCallbacks, IPunObservable
{
    public PhotonView PV;
    public GameObject Button;
    public GameObject NickNameUI;
    private ButtonPrefab ButtonInstance;
    public GameObject Panel;
    private int NetWorkNum = 1;

    public List<string> PlayerList;

    void Start()
    {
        ButtonInstance = Button.GetComponent<ButtonPrefab>();
        // GetComponent<PhotonView>().ViewID =
        PV.RPC("OnEnterMainGame", RpcTarget.All, PhotonNetwork.NickName);
        // OnEnterMainGame(PhotonNetwork.NickName);
    }

    // void Update()
    // {
        
    // }

    [PunRPC]
    public void OnEnterMainGame(string InNickName)
    {        
        bool Finded = false;
        foreach(string el in PlayerList)
        {
            if (el == InNickName){
                Finded = true;
            }
        }

        if (Finded == false)
        {
            PlayerList.Add(InNickName);

            GameObject NickNameTextUI = Instantiate(NickNameUI);
            NickNameTextUI.name = InNickName;
            NickNameTextUI.GetComponent<Text>().text = InNickName;
            NickNameTextUI.transform.parent = Panel.transform;
        }        
    }

    public void OnClickedButton_Binded()
    {
        if (ButtonInstance == null) {
            return;
        }

        PV.RPC("AddNumRPC", RpcTarget.All);
        //OnSendToNetWork();
        // ButtonInstance.SetText((NetWorkNum).ToString());
    }

    [PunRPC]
    void AddNumRPC()
    {
        ButtonInstance.SetText((++NetWorkNum).ToString());
    }
    private void OnSendToNetWork()
    {
        NetWorkNum++;
    }

    private void OnReceivedFromNetWork(int InNum)
    {
        ButtonInstance.SetText((NetWorkNum).ToString());
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(PlayerList);
            Debug.Log("Stream Write : " + NetWorkNum);
        }

        if (stream.IsReading)
        {
            PlayerList = (List<string>)stream.ReceiveNext();
            Debug.Log("Stream Read : " + NetWorkNum);
        }
    }
}
