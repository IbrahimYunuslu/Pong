using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMovement : MonoBehaviour
{

    private Rigidbody2D body;
    private float forceX, forceY;
    [HideInInspector] public float posX, posY, x, y; 
    private scoring score;
    private AudioSource gameAudio;
    public AudioClip ball, playerHit, computerHit;
    private bool toLeft;
    // Start is called before the first frame update
    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
        
        gameAudio = GetComponent<AudioSource>();
        score = GameObject.FindObjectOfType<scoring>();
        body = GetComponent<Rigidbody2D>();
        
        forceX=Random.Range(-5,5);
        if (forceX == 0)    forceX = 2f;
        forceY=Random.Range(-2,2);
        if (forceY == 0)    forceY = 2f;
        
        moveBall();
    }

    // Update is called once per frame
    void Update()
    {
        posX = transform.position.x;
        posY = transform.position.y;
        
        if (body.velocity.x == 0 && body.velocity.y == 0)
        {
            ResetBall();
        }
        if (body.velocity.x == 0)
        {
            ResetBall();
        }
    }

    void moveBall(){
        body.velocity = new Vector2(forceX, forceY);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.name == "top" || other.gameObject.name == "bottomWall" && body.velocity.y <= 25f)
        {
            body.velocity += new Vector2(0,1f);
        }else if (other.gameObject.name == "middle")
        {
            if (body.velocity.x < 0 )
            {
                body.velocity -= new Vector2(1f,1f);
            }else if (body.velocity.x > 0)
            {
                body.velocity += new Vector2(1f,1f);
            }
        }else if (other.gameObject.name == "bottom" || other.gameObject.name == "topWall" && body.velocity.y >= -25f)
        {
            body.velocity += new Vector2(0,-1f);
        }

        print("after" + body.velocity.x + " and " + body.velocity.y);
        gameAudio.clip = ball;
        gameAudio.Play();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.name == "leftWall")
        {
            score.PlayerScore();
            toLeft = true;
            gameAudio.clip = playerHit;
            gameAudio.Play();
        }else if (other.name == "rightWall")
        {
            score.ComputerScore();
            toLeft = false;
            gameAudio.clip = computerHit;
            gameAudio.Play();
        }
        
        ResetBall();
    }

    void ResetBall(){
        transform.position = new Vector2(x,y);
        if (!toLeft)
        {
            forceX=Random.Range(-5,0);
            if (forceX == 0)    forceX = -2;
            forceY=Random.Range(-2,2);
            if (forceY == 0)    forceY = 2;
            
        }else if(toLeft){
            forceX=Random.Range(0,5);
            if (forceX == 0)    forceX = 2;
            forceY=Random.Range(-2,2);
            if (forceY == 0)    forceY = 2;
        }
        moveBall();
    }

}
