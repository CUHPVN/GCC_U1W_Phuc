using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowParticle : GameUnit
{
    private void OnEnable()
    {
        Invoke(nameof(DespawnByTime), 3f);
    }
    public void DespawnByTime()
    {
        SimplePool.Despawn(this);
    }
}
