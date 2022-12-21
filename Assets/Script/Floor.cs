using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float coeficientFloor=0.1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ball")
        {

        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.ToLower() == "ball")
        {
            print("Colisiona con el suelo");
            Rigidbody2D rigibodyBall = collision.GetComponent<Rigidbody2D>();
            if(Mathf.Abs(rigibodyBall.velocity.x) >ConstantsPhisics.VELOCITY_NULL)
            {
                rigibodyBall.AddForce(Vector2.left*Mathf.Sign(rigibodyBall.velocity.x)*coeficientFloor);
            }
            if (Mathf.Abs(rigibodyBall.velocity.y )>ConstantsPhisics.VELOCITY_NULL)
            {
                print("Velocidad en contra: " +(Vector2.down * Mathf.Sign(rigibodyBall.velocity.y) * coeficientFloor));
                rigibodyBall.AddForce(Vector2.down * Mathf.Sign(rigibodyBall.velocity.y) * coeficientFloor);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "ball")
        {

        }
    }
}
