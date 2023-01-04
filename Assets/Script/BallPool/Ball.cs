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
    protected void Start()
    {
        GameManager.Instance.GestorBall.Balls.Add(this);
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Awake()
    {
        
    }

   
    protected void FixedUpdate()
    {
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
        if (_rigidbody2D.velocity.magnitude < 0.01f )
        {
            _rigidbody2D.velocity = Vector2.zero;
            quietBall = true;
        }
        else
        {
            quietBall = false;
            
            
        }
    }
    protected void OnCollisionEnter2D(Collision2D collision)
    {
        //quietBall = false;
        if (collision.gameObject.tag == Constants.TAG_HOLE)
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
