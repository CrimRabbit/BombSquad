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
		Debug.Log("joining local game");
		NetworkManager.singleton.networkAddress = hostNameInput.text;
		NetworkManager.singleton.StartClient();
	}
	
	void StartMatchMaker() {
		NetworkManager.singleton.StartMatchMaker();
	}

	public UnityEngine.UI.InputField hostNameInput;

	void Awake() {
		//Debug.Log ("Original text: " + hostNameInput.text);
		Debug.Log ("set ip text: " + Network.player.ipAddress);
		hostNameInput.text = Network.player.ipAddress;
		//Debug.Log ("New text: " + hostNameInput.text);
	}

	public void HowToPlay() {
		Debug.Log("how to play");
		SceneManager.LoadScene("HowToPlayScene");
	}

	public void Credits() {
		Debug.Log("Display credits");
		SceneManager.LoadScene("CreditsScene");
	}
}
