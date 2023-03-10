using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPlayer : Ball
{
    [SerializeField]
    private GameObject walls;

    private GameObject pivot;
    private SpringJoint2D _springJoint2D;
    private bool  canBreakPivot = false;
    
    private int firstBall = 0;
    public bool CanBreakPivot { get => canBreakPivot; set => canBreakPivot = value; }
    public int FirstBall { get => firstBall; set => firstBall = value; }

    private void Start()
    {
        base.Start();
        GameManager.Instance.BallPlayer = this;
    }
    

    public void moveBall()
    {
        Vector3 vector3 = this.transform.position;
        _springJoint2D = gameObject.AddComponent<SpringJoint2D>() as SpringJoint2D;
        //GetComponent<Rigidbody2D>().gravityScale = 1;
        _springJoint2D.autoConfigureDistance = false;
        _springJoint2D.distance = 0.5f;
        pivot = Instantiate(PrefabsManager.Instance.Pivot);
        pivot.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, pivot.transform.position.z);
        _springJoint2D.connectedBody = pivot.GetComponent<Rigidbody2D>();
        walls.SetActive(false);
        CanBreakPivot = false;

    }

    private void Update()
    {
        print("SE PARO LA BOLA:" +quietBall /*+" velocidad: "+ Mathf.Abs(_rigidbody2D.velocity.x * _rigidbody2D.velocity.y)*/);
        //print("Velocidad: "+_rigidbody2D.velocity.magnitude);
        
        if (pivot && CanBreakPivot)
        {
            print("DISTANCIA DEL PIVOT: "+ Vector3.Distance(this.transform.position, pivot.transform.position));
            if(Vector3.Distance(this.transform.position,pivot.transform.position) <1.25f)
            {
                walls.SetActive(true);
                //print("ENTRA EN EL TRIGGER");
                GetComponent<Rigidbody2D>().gravityScale = 0;

                Destroy(_springJoint2D);
                Destroy(pivot);
            }
        }
        if (_rigidbody2D.velocity.x * _rigidbody2D.velocity.y < ConstantsPhisics.VELOCITY_NULL)
        {
            QuietBall = true;
        }
        else
        {
            QuietBall = false;
        }
    }
    private void OnMouseDown()
    {
        //print("Clickaaaa");
        GameManager.Instance.PlayerController.clickBall();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        if(FirstBall ==0 && collision.gameObject.tag == Constants.TAG_HOLE)
        {
            FirstBall = collision.gameObject.GetComponent<Ball>().getIDBall();
        }
    }
    
    
}
