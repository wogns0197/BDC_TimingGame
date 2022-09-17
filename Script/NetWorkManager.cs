using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class NetWorkManager : MonoBehaviourPunCallbacks
{
    void Awake() 
    {
        DontDestroyOnLoad(this);
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnLogin()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public void SetNickName(string InNickName)
    {
        PhotonNetwork.NickName = InNickName;
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);
        Debug.Log("Connection Failed.");
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster() // 연결 Success callback 함수
    {
        Debug.Log("Connection Success NickName = " + PhotonNetwork.NickName + ", Version = " + PhotonNetwork.GameVersion);
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        PhotonNetwork.LoadLevel("MainScene");
        // GameDirector Director = GameObject.Find("GameDirector").GetComponent<GameDirector>();
        // Director.OnEnterMainGame(PhotonNetwork.NickName);
    }

    // public override void OnLeave
    
}
