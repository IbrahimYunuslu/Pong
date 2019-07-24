using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMovement : MonoBehaviour
{

    private Rigidbody2D body;
    private float forceX, forceY;
    public float posX, posY;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        forceX=Random.Range(-5,5);
        if (forceX == 0)    forceX = 2;
        forceY=Random.Range(-2,2);
        if (forceY == 0)    forceY = 2;
        moveBall();
    }

    // Update is called once per frame
    void Update()
    {
        posX = transform.position.x;
        posY = transform.position.y;
    }

    void moveBall(){
        body.velocity = new Vector2(forceX, forceY);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.name == "top" && other.gameObject.name == "bottomWall")
        {
            body.velocity += new Vector2(0,0.05f).normalized;
        }else if (other.gameObject.name == "middle")
        {
            body.velocity += new Vector2(0.05f,0.05f).normalized;
        }else if (other.gameObject.name == "bottom" && other.gameObject.name == "topWall")
        {
            body.velocity += new Vector2(0,-0.05f).normalized;
        }
    }

}
