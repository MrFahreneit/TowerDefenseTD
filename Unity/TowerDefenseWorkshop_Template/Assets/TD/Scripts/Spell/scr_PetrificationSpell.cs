using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD1;

public class scr_PetrificationSpell : MonoBehaviour
{
    [SerializeField]
    private scr_SoundsCaller _PretricationSound = null;

    [SerializeField]
    private scr_ParticleSpawner _PretricationParticle = null; 

    [SerializeField]
    private CapsuleCollider _capsuleCollider = null;

    private Collider[] hitColliders = null;

    void Start()
    {
        if (_PretricationSound != null)
        {
            _PretricationSound.SpawnSound(true);
        }

        if (_PretricationParticle != null)
        {
            _PretricationParticle.SpawnParticle();
        }


        hitColliders = null;
        hitColliders = Physics.OverlapCapsule(gameObject.transform.position, gameObject.transform.position + new Vector3(0, _capsuleCollider.height, 0), _capsuleCollider.radius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.GetComponentInParent<Damageable>() == true)
            {
                hitCollider.GetComponentInParent<scr_Pretrification>().SetStun();
            }

        }
        hitColliders = null;
        Destroy(gameObject);
    }
}
