using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD1;

public class scr_SpawnPurified : MonoBehaviour
{
    [SerializeField]
    private PathFollower _pathFollower = null;

    [SerializeField]
    private GameObject _spawnPoint;

    [SerializeField]
    private GameObject _purified;

    private void OnDestroy()
    {
        int actorSpawned = _pathFollower.GetDamage();
        for (int i = 0; i < actorSpawned; i++)
        {
            Instantiate(_purified, _spawnPoint.transform.position, Quaternion.identity);
        }
    }
}
