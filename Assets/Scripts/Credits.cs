using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    private float offset;
    public float speed = 400.0f;
    public GUIStyle style;
    public Rect viewArea;

    private void Start()
    {
		 if (this.viewArea.width == 0.0f)
		{
			this.viewArea = new Rect(0.0f, 0.0f, Screen.width, Screen.height);
		}
        this.offset = this.viewArea.height;
    }

    private void Update()
    {
        this.offset -= Time.deltaTime * this.speed;
    }

    private void OnGUI()
    {
        GUI.BeginGroup(this.viewArea);

        var position = new Rect(0, this.offset, this.viewArea.width, this.viewArea.height);
        var text = @"
Credits

Game Design: lol
Game Design: lol
Game Design: lol
Game Design: lol
Game Design: lol
Game Design: lol
Game Design: lol
Game Design: lol
Game Design: lol
Game Design: lol
Game Design: lol
Game Design: lol
Game Design: lol
Game Design: lol
Game Design: lol
Game Design: lol
Game Design: lol
Game Design: lol
Game Design: lol
yay
		";

        GUI.Label(position, text, this.style);

        GUI.EndGroup();
    }

	public void Back() {
		Debug.Log ("Back clicked");
		SceneManager.LoadScene("TitleScene");
	}
}
