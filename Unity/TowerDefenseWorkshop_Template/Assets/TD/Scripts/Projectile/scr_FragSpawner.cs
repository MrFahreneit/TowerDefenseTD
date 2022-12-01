using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD1;

public class scr_FragSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _toSpawn = null;
    [SerializeField]
    private AProjectile _projectileInfo = null;
    [SerializeField]
    private int _numberToSpawn = 5;
    [SerializeField]
    private float _spread = 30f;

    public void SpawnFrag()
    {
        for (int i = 0; i < _numberToSpawn; i++)
        {
            var instance = Instantiate(_toSpawn, gameObject.transform.position, gameObject.transform.rotation);

            instance.transform.rotation =
                Quaternion.Euler
                (Random.Range(_spread * -1, _spread), Random.Range(_spread * -1, _spread), 0)
                * Quaternion.Euler(90, 0, 0);
            instance.GetComponentInParent<AProjectile>().SetDamage(_projectileInfo.GetDamage());
        }

    }


}
