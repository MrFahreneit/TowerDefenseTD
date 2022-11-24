using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_WitchMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject _targetMovement = null;
    [SerializeField]
    private float _speed = 15f;

    private Vector3 _targetVector;

    private void Awake()
    {
        SetNewTarget(gameObject);
    }

    public void SetNewTarget(GameObject newTarget)
    {
        _targetMovement = newTarget;
        _targetVector = _targetMovement.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _targetVector, Time.deltaTime * _speed);
    }
}
