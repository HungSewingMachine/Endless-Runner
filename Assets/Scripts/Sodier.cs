using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sodier : MonoBehaviour
{
    Rigidbody _rb;

    [SerializeField]
    float _thrust = 3f;
    [SerializeField]
    float _side = 2f;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //_rb.velocity = transform.forward * _thrust;
        //Move();
        _rb.velocity = transform.forward * _thrust + new Vector3(Input.GetAxis("Horizontal") * _side, 0, 0);
    }
    /*
    void Move()
    { 
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x >= _leftBoundary)
            {
                transform.Translate(Vector3.left * _side * Time.deltaTime);
            }
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x <= _rightBoundary)
            {
                transform.Translate(Vector3.right * _side * Time.deltaTime);
            }
        }
    } */

    
}
