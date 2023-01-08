using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevelPanel : MonoBehaviour
{
    public void LoadLevel(int level)
    {
        SceneManager.LoadScene("Map_" + level.ToString());
    }
}
