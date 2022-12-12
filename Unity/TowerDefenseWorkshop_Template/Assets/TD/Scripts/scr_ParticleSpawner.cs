using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_ParticleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _Particle = null;

    [SerializeField]
    private bool _rotateFromSpawner = false;

    public void SpawnParticle()
    {
        if(_Particle != null)
        {
            var instance = Instantiate(_Particle);
            instance.transform.position = gameObject.transform.position;
            if (_rotateFromSpawner)
            {
                instance.transform.rotation = gameObject.transform.rotation;
            }
        }

    }
}
