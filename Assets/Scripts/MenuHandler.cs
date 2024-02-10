#if UNITY_EDITOR
using UnityEditor;
#endif

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
	public TMP_InputField InputField;

	public void StartNew()
	{
		var text = InputField.text;

		if (!string.IsNullOrEmpty(text))
		{
			DataManager.Instance.CurrentPlayerName = text;
		}

		SceneManager.LoadScene(1);
	}

	public void ExitGame()
	{
#if UNITY_EDITOR
		EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
	}
}
