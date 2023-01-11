using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Collectable
{
	public ParticleSystem particle;
	public override void Use(StickmanAttributes attributes)
	{
		Instantiate(particle, transform.position, Quaternion.identity);
		GameManager.Instance.ReceiveCoin(1);
	}
}
