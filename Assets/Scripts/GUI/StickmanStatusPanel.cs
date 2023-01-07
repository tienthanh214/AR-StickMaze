using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanStatusPanel : MonoBehaviour
{
    private static int MAX_STICKMAN_COUNT = 8;
    public GameObject stickmanIconPrefab;
    private List<GameObject> stickmanIconList = new List<GameObject>();

    void Start()
    {
        updateCount(3);
    }

    public void updateCount(int count)
    {
        if (count < 0)
            count = 0;
        else if (count > MAX_STICKMAN_COUNT)
            count = MAX_STICKMAN_COUNT;

        int currentCount = stickmanIconList.Count;

        if (currentCount < count)
        {
            for (int i = currentCount; i < count; ++i)
            {
                Vector3 iconPosition = transform.position;
                iconPosition.x += i * 20 + 15;
                iconPosition.y -= 15;
                GameObject stickmanIcon = Instantiate(stickmanIconPrefab);
                stickmanIcon.transform.SetParent(transform);
                stickmanIcon.transform.position = iconPosition;
                stickmanIconList.Add(stickmanIcon);
            }
        }
        else
        {
            for (int i = count; i < currentCount; ++i)
            {
                int lastIndex = stickmanIconList.Count - 1;
                GameObject stickmanIcon = stickmanIconList[lastIndex];
                stickmanIconList.RemoveAt(lastIndex);
                Destroy(stickmanIcon);
            }
        }
    }
}
