using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private static GameManager _instance = null;

	private int nInitialStickman = 0;

	public GameObject stickman;
	private List<GameObject> stickmanAlive = new List<GameObject>();


	public static GameManager instance
	{
		get
		{
			if (_instance == null)
				Debug.LogError("GameManager must be initialized");
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

		InitGame();
	}

	private void InitGame()
	{
		// GenerateStickman(stickman, nInitialStickman, Vector3.zero);
	}

	public void GenerateStickman(GameObject stickman, int n, Vector3 position, Vector3 scaleVector)
	{
		nInitialStickman += n;
		for (int i = 0; i < n; ++i)
		{
			float biasX = Random.Range(-0.05f, 0.05f);
			float biasZ = Random.Range(-0.05f, 0.05f);
			GameObject myModelTrf = Instantiate(stickman, new Vector3(position.x + biasX, position.y, position.z + biasZ), Quaternion.identity) as GameObject;
			// myModelTrf.transform.localScale = scaleVector;
			stickmanAlive.Add(myModelTrf);
		}
	}

	public void ResetGame()
	{
		for (int i = 0; i < stickmanAlive.Count; ++i)
		{
			Destroy(stickmanAlive[i]);
		}
		stickmanAlive.Clear();
		nInitialStickman = 0;
	}

	public void RemoveStickman(GameObject obj)
    {
		if (obj != null)
		{
			stickmanAlive.Remove(obj);
			nInitialStickman--;
			Destroy(obj);
			GameOver();
		}
    }

	public void AchievedStickman()
	{
		nInitialStickman--;
		GameOver();
	}

	private void GameOver()
	{
		if (nInitialStickman == 0)
		{
			UIManager.instance.GameOver();
		}
	}
}
