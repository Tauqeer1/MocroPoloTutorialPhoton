using UnityEngine;
using System.Collections;
/// <summary>
/// To implement callbacks easily in our code(or to override photon builtin method)
/// we inherit a Photon.PunBehaviour
/// </summary>
public class RandomMatchMaker : Photon.PunBehaviour {

	// Use this for initialization
	void Start () {
        //Connect with the photon network and define the unique game version
        PhotonNetwork.ConnectUsingSettings("0.1");
        //Get the full log of photon networking(including errors)
        //PhotonNetwork.logLevel = PhotonLogLevel.Full;
	}
    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    /// <summary>
    /// Call after PUN is ready and autoJoinLobby
    /// is false  if autoJoinLobby is true then it will call 
    /// OnJoinedLobby() method(callback)
    /// </summary>
    void OnConnectedToMaster()
    {
        Debug.Log("Connected to Server");
    }
    /// <summary>
    /// Called when the initial connection got established 
    /// and PUN will send your AppId, the user etc in the background
    /// OnConnectedToMaster() or OnJoinedLobby() are called when PUN is 
    /// ready
    /// </summary>
    void OnConnectedToPhoton()
    {
        Debug.Log("Connected to Photon");
    }
    //Called after joining the lobby and autoJoinedLobby is true
    public override void OnJoinedLobby()
    {
        Debug.Log("Joinned the lobby because autoJoinedLobby is true");
        PhotonNetwork.JoinRandomRoom();
    }
    //Call when failed to join the random room
    public void OnPhotonRandomJoinFailed()
    {
        Debug.Log("Can not join the random room");
        Debug.Log("Now Creating a new room");
        /*Creating a room and the server will assign a unique name because 
        we are not passing a name*/
        PhotonNetwork.CreateRoom(null);
    }
    //Called when this user created a room and entered in it
    void OnCreatedRoom()
    {
        Debug.Log("Room has created ");
    }
    //Called when any user only joined the room
    void OnJoinedRoom()
    {
        Debug.Log("Joined the room");
        GameObject monster = PhotonNetwork.Instantiate("monsterprefab", Vector3.zero, Quaternion.identity, 0);
    }

}
