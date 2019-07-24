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
    public AudioClip ball, menu, playerHit, computerHit, playerWin, computerWin;
    private bool toLeft;
    // Start is called before the first frame update
    void Start()
    {
        gameAudio = GetComponent<AudioSource>();
        // = GetComponent<AudioClip>();
        x = transform.position.x;
        y = transform.position.y;
        score = GameObject.FindObjectOfType<scoring>();
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
        if (body.velocity.x == 0 && body.velocity.y == 0)
        {
            ResetBall();
        }
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
