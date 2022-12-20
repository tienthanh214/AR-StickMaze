using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;


// reference: https://library.vuforia.com/getting-started/vuforia-engine-api-unity#attach-content-to-a-target
public class GenStickmanEffect : DefaultObserverEventHandler
{
    ImageTargetBehaviour mImageTarget;
    public GameObject myModelPrefab;
    [SerializeField] private float startDropHeight;
    [SerializeField] private float relativeScale;

    private void Awake()
    {
        mImageTarget = GetComponent<ImageTargetBehaviour>();
    }

    protected override void OnTrackingFound()
    {
        InstantiateStickman();
    }

	protected override void OnTrackingLost()
	{
        GameManager.instance.ResetGame();
	}

	void InstantiateStickman()
    {
        if (myModelPrefab != null)
        {
            //GameObject myModelTrf = Instantiate(myModelPrefab);
            //// myModelTrf.transform.parent = mImageTarget.transform;
            //myModelTrf.transform.localPosition = new Vector3(0f, startDropHeight, 0f);
            //myModelTrf.transform.rotation = Quaternion.identity;
            //myModelTrf.transform.localScale = new Vector3(relativeScale, relativeScale, relativeScale);
            GameManager.instance.GenerateStickman(myModelPrefab,
                5,
                new Vector3(0f, startDropHeight, 0f),
                new Vector3(relativeScale, relativeScale, relativeScale));
        }
    }
}
