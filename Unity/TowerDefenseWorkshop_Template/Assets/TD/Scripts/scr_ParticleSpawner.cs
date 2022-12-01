using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_ParticleSpawner : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _damageParticle = null;

    [SerializeField]
    private bool _rotateFromSpawner = false;

    public void SpawnParticle()
    {
        var instance = Instantiate(_damageParticle);
        instance.transform.position = gameObject.transform.position;
        if (_rotateFromSpawner)
        {
            instance.transform.rotation = gameObject.transform.rotation;
        }
    }
}
