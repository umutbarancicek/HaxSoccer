using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class ServerManagement : MonoBehaviourPunCallbacks
{
    [SerializeField] private Transform[] spawnPoints;
    private bool ballSpawned = false;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to the server");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Connected to the lobby");
        PhotonNetwork.JoinOrCreateRoom("MertSoccer", new RoomOptions { MaxPlayers = 10, IsOpen = true, IsVisible = true }, TypedLobby.Default);
    }

   public override void OnJoinedRoom()
{
    Debug.Log("Connected to the Room");

   
        GameObject myObject = PhotonNetwork.Instantiate("Ronaldo", spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity, 0, null);
        Debug.Log("ADAM GELDI");
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("NEco geldi");
            GameObject ball = PhotonNetwork.Instantiate("Ball", spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity, 0, null);
            ballSpawned = true;
        }

}

    public override void OnLeftRoom()
    {
        Debug.Log("Left the Room");
    }

    public override void OnLeftLobby()
    {
        Debug.Log("Left the Lobby");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("Could not join any room");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Could not join any random room");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Could not create room");
    }
}
