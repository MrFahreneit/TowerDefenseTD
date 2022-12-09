using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD1;

public class scr_SpellForwardSend : MonoBehaviour
{
    [SerializeField]
    private CapsuleCollider _capsuleCollider = null;

    private Collider[] hitColliders = null;

    void Start()
    {
        hitColliders = null;
        hitColliders = Physics.OverlapCapsule(gameObject.transform.position, gameObject.transform.position + new Vector3(0, _capsuleCollider.height, 0), _capsuleCollider.radius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.GetComponentInParent<scr_SpellForwardReceiver>() == true)
            {
                hitCollider.GetComponentInParent<scr_SpellForwardReceiver>().StartFastForward();
            }

        }
        hitColliders = null;
        Destroy(gameObject);
    }
}

