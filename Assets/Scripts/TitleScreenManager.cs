using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
	public void MoveToTestScene()
	{
		SceneManager.LoadScene("TestScene");
	}
}
