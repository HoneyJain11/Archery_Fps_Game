using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class PlayerSpwanner : MonoBehaviour
{
    public GameObject playerPrefab;
    PhotonView photonView;
    private void Start()
    {
        PhotonNetwork.Instantiate(playerPrefab.name, transform.position, Quaternion.Euler(0, 100, 0));
        /*photonView = playerPrefab.GetComponent<PhotonView>();
        if (photonView.IsMine)
        {
            PhotonNetwork.Instantiate(playerPrefab.name, transform.position, Quaternion.Euler(0, 100, 0));
        }*/

    }
}
