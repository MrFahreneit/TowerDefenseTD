using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD1;

public class scr_Explosion : MonoBehaviour
{
    [SerializeField]
    private Timer _timer = null;
    [SerializeField]
    private float _dotTimer = 0.25f;

    [SerializeField]
    private SphereCollider _collider = null;

    [SerializeField]
    private bool _insta = true;

    [SerializeField]
    private float _percentDamage = 1f;
    private GameObject _hookedExplosion = null;

    [SerializeField]
    private bool _followHook = false;


    private float _initialDamage = 1f;
    private float _damage = 0f;

    #pragma warning disable CS0414
    private bool isSpawned = false;
    #pragma warning restore CS0414

    private Collider[] hitColliders = null;

    void Start()
    {
        _damage = _initialDamage * _percentDamage;
        isSpawned = false;
        _timer.Start();

        if(_insta == true)
        {
            hitColliders = null;
            hitColliders = Physics.OverlapSphere(gameObject.transform.position, _collider.radius);
            foreach (var hitCollider in hitColliders)
            {
                Debug.Log(hitCollider);
                if (hitCollider.GetComponentInParent<Damageable>() == true)
                {
                    hitCollider.GetComponentInParent<Damageable>().TakeDamage(_damage);

                }

            }
            hitColliders = null;
            Destroy(gameObject);
        }
        else
        {
            DamageAround();
        }

    }

    void Update()
    {
        _timer.Update();

        if (_timer.IsRunning == false)
        {
            isSpawned = true;
            _timer.Stop();
            Destroy(gameObject);
        }

        if (_followHook == true)
        {
            if(_hookedExplosion != null)
            {
                gameObject.transform.position = _hookedExplosion.transform.position;
            }
            else
            {

            }
            
        }
    }

    private void DamageAround()
    {
        hitColliders = null;
        hitColliders = Physics.OverlapSphere(gameObject.transform.position, _collider.radius);
        foreach (var hitCollider in hitColliders)
        {
            Debug.Log(hitCollider);
            if (hitCollider.GetComponentInParent<Damageable>() == true)
            {
                hitCollider.GetComponentInParent<Damageable>().TakeDamage(_damage);
            }

        }
        hitColliders = null;
        Invoke("DamageAround", _dotTimer);
    }

    public void InitializeDamage(float intialDamage)
    {
        _initialDamage = intialDamage;
    }

    public void SetHooked(GameObject newHooked)
    {
        _hookedExplosion = newHooked;
    }
    public GameObject GetHooked()
    {
        return _hookedExplosion;
    }


}
