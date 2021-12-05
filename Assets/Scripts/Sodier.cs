using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sodier : MonoBehaviour
{
    Rigidbody _rb;
    float movement;
    float _xPosition;
    Vector3 _position;

    [SerializeField]
    float _speed = 3f;
    [SerializeField]
    float _leftRight = 2f;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _xPosition = transform.position.x;
    }

    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        HorizontalConstrain();
    }

    void FixedUpdate()
    {
        _rb.velocity = transform.forward * _speed + new Vector3(movement * _leftRight, 0, 0);
    }

    private void HorizontalConstrain()
    {
        if (transform.position.x < _xPosition - 4.85f)
        {
            transform.position = new Vector3(_xPosition- 4.85f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > _xPosition + 2.6f)
        {
            transform.position = new Vector3(_xPosition + 2.6f, transform.position.y, transform.position.z);
        }
    }
}
