using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTrigger : MonoBehaviour
{
    public Direction direction;

    private void OnTriggerEnter(Collider other)
    {
        if (other == null) return;
        Stickman o = other.GetComponent<Stickman>();
        if (o == null) return;
        o.changeDirection(direction);
    }
}
