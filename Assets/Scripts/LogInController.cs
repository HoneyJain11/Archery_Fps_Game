using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class LogInController : MonoBehaviourPunCallbacks
{
    public TMP_InputField createInput;
    public TMP_InputField joinInput;
    public Button createBtn;
    public Button JoinBtn;

    private void Awake()
    {
        createBtn.onClick.AddListener(CreateRoom);
        JoinBtn.onClick.AddListener(JoinRoom);
    }

    public void CreateRoom()
    {
        Debug.Log("Create Room");

        PhotonNetwork.CreateRoom(createInput.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("GamePlay");
        Debug.Log("OnJoinedRoom");
    }
}
