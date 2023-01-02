using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPlayer : Ball
{
    private GameObject pivot;
    private SpringJoint2D _springJoint2D;
    private bool  canBreakPivot = false;

    public bool CanBreakPivot { get => canBreakPivot; set => canBreakPivot = value; }

    private void Start()
    {
        GameManager.Instance.BallPlayer = this;
    }


    public void moveBall()
    {
        Vector3 vector3 = this.transform.position;
        _springJoint2D = gameObject.AddComponent<SpringJoint2D>() as SpringJoint2D;
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _springJoint2D.autoConfigureDistance = false;
        _springJoint2D.distance = 0.5f;
        pivot = Instantiate(PrefabsManager.Instance.Pivot);
        pivot.transform.position = this.transform.position;
        _springJoint2D.connectedBody = pivot.GetComponent<Rigidbody2D>();

        CanBreakPivot = false;

    }

    private void Update()
    {
        if (pivot && CanBreakPivot)
        {
            print("DISTANCIA DEL PIVOT: "+ Vector3.Distance(this.transform.position, pivot.transform.position));
            if(Vector3.Distance(this.transform.position,pivot.transform.position) <1.25f)
            {
                print("ENTRA EN EL TRIGGER");
                GetComponent<Rigidbody2D>().gravityScale = 0;
                Destroy(_springJoint2D);
                Destroy(pivot);
            }
        }
    }
    private void OnMouseDown()
    {
        //print("Clickaaaa");
        GameManager.Instance.PlayerController.clickBall();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("HOLA SOY EL COLAIDER");
        if (collision.name.Contains(ConstantsName.PIVOT))
        {
            


        }
    }
}
