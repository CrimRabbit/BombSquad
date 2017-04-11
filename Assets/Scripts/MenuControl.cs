using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour {

	public void StartLocalGame() {
		Debug.Log("start local game");
		NetworkManager.singleton.StartHost();
	}
	
	public void JoinLocalGame() {
		if (hostNameInput.text != "Hostname") {
			NetworkManager.singleton.networkAddress = hostNameInput.text;
		}	
		NetworkManager.singleton.StartClient();
	}
	
	void StartMatchMaker() {
		NetworkManager.singleton.StartMatchMaker();
	}
	
	public UnityEngine.UI.Text hostNameInput;


	void Start() {
		hostNameInput.text = NetworkManager.singleton.networkAddress;
	}

	public void Credits() {
		//Debug.Log("Display credits");
		SceneManager.LoadScene("CreditsScene");
	}
}
