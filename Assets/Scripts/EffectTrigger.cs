using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Effect
{
    JUMP,
    UP,
    DOWN,
    LEFT,
    RIGHT,
    SPIKES
}

public class EffectTrigger : MonoBehaviour
{
    public Effect effect;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other == null) return;
    //    Stickman o = other.GetComponent<Stickman>();
    //    if (o == null) return;
    //    ApplyEffect(o);
    //}

    public void ApplyEffect(Stickman stickman)
    {
        switch (effect)
        {
            case Effect.UP:
                stickman.changeDirection(Direction.UP);
                break;
            case Effect.DOWN:
                stickman.changeDirection(Direction.DOWN);
                break;
            case Effect.LEFT:
                stickman.changeDirection(Direction.LEFT);
                break;
            case Effect.RIGHT:
                stickman.changeDirection(Direction.RIGHT);
                break;
            case Effect.JUMP:
                stickman.jump();
                break;
            case Effect.SPIKES:
                // Deal emotional damage to stickman
                break;
        }
    }
}
