using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanStatusPanel : MonoBehaviour
{
    private static int MAX_STICKMAN_COUNT = 8;
    public GameObject stickmanIconPrefab;
    private int currentStickmanCount = MAX_STICKMAN_COUNT;

    void Start()
    {
        setCount(6);
    }

    void setCount(int count)
    {
        currentStickmanCount = count;
        updateIcons();
    }

    void updateIcons()
    {
        for (int i = 0; i < currentStickmanCount; ++i)
        {
            Vector3 iconPosition = transform.position;
            iconPosition.x += i * 20  + 15;
            iconPosition.y -= 15;
            GameObject stickmanIcon = Instantiate(stickmanIconPrefab) as GameObject;
            stickmanIcon.transform.parent = transform;
            stickmanIcon.transform.position = iconPosition;
            Debug.Log("tao roi ma");
        }
    }
}
