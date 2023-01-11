using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StickmanStatusPanel : MonoBehaviour
{
    public Text stickmanCountText;
    public Text starCountText;
    private List<GameObject> stickmanIconList = new List<GameObject>();

    void Start()
    {
        UpdateStickmanCount(0);
        UpdateStarCount(0);
    }

    public void UpdateStickmanCount(int count)
    {
        stickmanCountText.text = count.ToString();
    }

    public void UpdateStarCount(int count)
    {
        starCountText.text = count.ToString();
    }
}
