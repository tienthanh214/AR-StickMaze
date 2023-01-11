using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    private static UIManager _instance = null;
	private static bool isGamePaused = false;

	public StickmanStatusPanel stickmanStatusPanel;
	public TitlePanel levelTitle;
	public GameObject alertDialog;

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

		ResumeGame();
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

	public void UpdateLevelTitle(int level)
    {
		if (levelTitle == null)
		{
			Debug.Log("UiManager: LevelTitle is null");
			return;
		}
		levelTitle.UpdateTitle(TitlePanel.LEVEL + " " + level.ToString());
    } 

	public void UpdateStickmanCount(int count)
    {
		if (stickmanStatusPanel == null)
        {
			Debug.Log("UiManager: Stickman Status Panel is null");
			return;
        }
		stickmanStatusPanel.UpdateStickmanCount(count);
    }

	public void UpdateStarCount(int count)
    {
		if (stickmanStatusPanel == null)
		{
			Debug.Log("UiManager: Stickman Status Panel is null");
			return;
		}
		stickmanStatusPanel.UpdateStarCount(count);
    }

	public void OnWinGame(int stickmanReachGoal, int starCollected, int score)
    {
		PauseGame();
		ShowAlertDialog("You Won", "Achivement:" +
			"\n> Total score: " + score.ToString() +
			"\n> Stickmans reach goal: " + stickmanReachGoal.ToString() +
			"\n> Star collected: " + starCollected.ToString());
    }

	public void OnLoseGame(int starCollected, int score)
	{
		PauseGame();
		ShowAlertDialog("You Lost", "Achivement:" +
			"\n> Total score: " + score.ToString() +
			"\n> Star collected: " + starCollected.ToString());
	}

	public void ShowAlertDialog(string title, string content)
    {
		alertDialog.SetActive(true);
		AlertDialog dialog = alertDialog.GetComponent<AlertDialog>();
		if(dialog == null)
        {
			Debug.Log("Alert Dialog is null");
			return;
        }
		dialog.title.text = title;
		dialog.content.text = content;
    }

	public void HideAlertDialog()
    {
		alertDialog.SetActive(false);
    }

	public void OnReplayPressed()
    {
		GameManager.Instance.ResetGame();
		ResumeGame();
    }

	public void OnHomePressed()
    {
		GameManager.Instance.ResetGame();
		ResumeGame();
		Destroy(gameObject);
		SceneManager.LoadScene("Start_Menu");
	}

	public void OnNextPressed()
    {
		int lvl = int.Parse(SceneManager.GetActiveScene().name.Substring(4)) + 1;
		SceneManager.LoadScene("Map_" + lvl.ToString());

	}
}
