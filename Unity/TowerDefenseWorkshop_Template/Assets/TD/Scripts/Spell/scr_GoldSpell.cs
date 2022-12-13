using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD1;

public class scr_GoldSpell : MonoBehaviour
{
    [SerializeField]
    private scr_SoundsCaller _GoldSpellSound = null;

    [SerializeField]
    private scr_ParticleSpawner _GoldSpellParticle = null; 

    [SerializeField]
    private CapsuleCollider _capsuleCollider = null;

    private Collider[] hitColliders = null;

    void Start()
    {
        if (_GoldSpellParticle != null)
        {
            _GoldSpellParticle.SpawnParticle();
        }

        if (_GoldSpellSound != null)
        {
            _GoldSpellSound.SpawnSound(true);
        }

        hitColliders = null;
        hitColliders = Physics.OverlapCapsule(gameObject.transform.position, gameObject.transform.position + new Vector3(0, _capsuleCollider.height, 0), _capsuleCollider.radius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.GetComponentInParent<Damageable>() == true)
            {
                hitCollider.GetComponentInParent<scr_GoldMultiplier>().AddAMultiplier();
            }

        }
        hitColliders = null;
        Destroy(gameObject);
    }

}
