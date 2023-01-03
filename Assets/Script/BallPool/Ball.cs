using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private Transform respawnPoint;
    [SerializeField]
    private int numBola =1;

    protected bool quietBall = true;

    public bool QuietBall { get => quietBall; set => quietBall = value; }
    protected Rigidbody2D _rigidbody2D;
    private void Start()
    {
        GameManager.Instance.GestorBall.Balls.Add(this);
    }
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

   
    private void FixedUpdate()
    {
        this.transform.rotation = Quaternion.Euler(0, 0, 0);

        if (_rigidbody2D.velocity.x * _rigidbody2D.velocity.y < ConstantsPhisics.VELOCITY_NULL)
        {
            QuietBall = true;
        }
        else
        {
            QuietBall = false;
        }
    }
    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hole")
        {
            if (GameManager.Instance.putBall(numBola))
            {
                this.gameObject.SetActive(false);
                
            }
            this.transform.position = respawnPoint.position;

        }
    }
    public int getIDBall()
    {
        return numBola;
    }
}
