using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDirection : MonoBehaviour
{
	public Direction direction;
	// Start is called before the first frame update
	private void OnTriggerEnter(Collider other)
	{
		if (other == null) return;
		Stickman o = other.GetComponent<Stickman>();
		if (o == null) return;
		o.jump();
		o.changeDirection(direction);
	}
}
