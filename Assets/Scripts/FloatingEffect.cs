using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingEffect : MonoBehaviour
{
    public float timeToLive = 0.5f;
    public float floatSpeed = 16;

    private float timeElapsed = 0.0f;
    private Vector3 floatDirection;
    // Start is called before the first frame update
    void Start()
    {
        floatDirection = transform.up;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        transform.position += floatDirection * floatSpeed * Time.deltaTime;
        if (timeElapsed > timeToLive)
        {
            floatDirection *= -1;
            timeElapsed = 0.0f;
        }
    }
}
