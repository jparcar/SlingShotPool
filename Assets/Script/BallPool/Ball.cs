using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    public float fuerza=10;
    private Rigidbody2D _rigidbody2D;
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    /*
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _rigidbody2D.AddForce(Vector2.up * fuerza);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _rigidbody2D.AddForce(Vector2.down * fuerza);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _rigidbody2D.AddForce(Vector2.left * fuerza);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _rigidbody2D.AddForce(Vector2.right * fuerza);
        }
    }*/
    private void FixedUpdate()
    {
        //if(Mathf.Abs(_rigidbody2D.velocity.X)<= ConstantsPhisics.VELOCITY_NULL)
        
        
    }
}
