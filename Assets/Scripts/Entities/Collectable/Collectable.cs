using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : EffectTrigger
{
    override public void ApplyEffect(Stickman stickman)
	{
		Use(stickman.attributes);
		Destroy(gameObject);
	}

	public abstract void Use(StickmanAttributes attributes);
	
}
