using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_WitchMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject _targetMovement = null;
    [SerializeField]
    private float _speed = 12f;
    [SerializeField]
    private float _rotateSpeed = 8f;

    private Vector3 _targetVector;

    private Vector3 direction;

    private void Awake()
    {
        SetNewTarget(gameObject);
    }

    public void SetNewTarget(GameObject newTarget)
    {
        _targetMovement = newTarget;
        _targetVector = _targetMovement.transform.position;
        direction = _targetMovement.transform.position - transform.position; ;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _targetVector, Time.deltaTime * _speed);

        direction.y = 0;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _rotateSpeed * Time.deltaTime);
    }
}
