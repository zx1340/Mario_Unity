using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
	public void StartGame()
	{
		// "Stage1" is the name of the first scene we created.
		print("WTF I WANT START GAME");
		SceneManager.LoadScene ("Mario");
	}
}