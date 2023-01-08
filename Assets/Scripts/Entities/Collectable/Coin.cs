using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Collectable
{
	public override void Use(StickmanAttributes attributes)
	{
		GameManager.instance.ReceiveCoin(1);
	}
}
