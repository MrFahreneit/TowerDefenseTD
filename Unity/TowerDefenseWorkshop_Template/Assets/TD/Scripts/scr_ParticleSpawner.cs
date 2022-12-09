using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_ParticleSpawner : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _Particle = null;

    [SerializeField]
    private bool _rotateFromSpawner = false;

    public void SpawnParticle()
    {
        //var instance = Instantiate(_Particle);
        //instance.transform.position = gameObject.transform.position;
        //if (_rotateFromSpawner)
        //{
           // instance.transform.rotation = gameObject.transform.rotation;
        //}
    }
}
