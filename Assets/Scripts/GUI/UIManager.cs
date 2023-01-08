using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance = null;
	private static bool isGamePaused = false;

	public static UIManager instance
    {
        get
        {
            if (_instance == null)
				Debug.LogError("UIManager must be initialized");
			return _instance;
        }
    }

	private void Awake()
	{
		if (_instance != null)
		{
			Destroy(gameObject);
		}
		_instance = this;

		DontDestroyOnLoad(gameObject);
	}

	public void ToggleResumeOrPause()
	{
		Debug.Log("Pause button pressed");
		if (isGamePaused) ResumeGame();
		else PauseGame();
	}

	private void PauseGame()
	{
		Time.timeScale = 0f;
		isGamePaused = true;
	}

	private void ResumeGame()
	{
		Time.timeScale = 1f;
		isGamePaused = false;
	}
}
