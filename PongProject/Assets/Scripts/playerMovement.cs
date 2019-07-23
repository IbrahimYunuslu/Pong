using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    private Vector3 upMost, downMost;
    public float speed = 10;
    private float height;
    private ballMovement ball;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindObjectOfType<ballMovement>();
        height = GetComponent<SpriteRenderer>().sprite.bounds.size.y;
        downMost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,0));
        upMost = Camera.main.ViewportToWorldPoint(new Vector3(1,1,0));
        downMost.y += height;
        upMost.y -= height;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Player")
        {
            UserMovement();
        }
        else
        {
            if (ball.posX < 0)
            {
                ComputerMovement();
            }
        }

    }

    void UserMovement(){
        if(Input.GetKey(KeyCode.UpArrow)){
            MovePlayerUp();
        }else if(Input.GetKey(KeyCode.DownArrow)){
            MovePlayerDown();
        }
        
        float restrictedY = Mathf.Clamp(transform.position.y, downMost.y, upMost.y);
        transform.position = new Vector3(transform.position.x, restrictedY, transform.position.z);

    }

    void ComputerMovement(){
        if (transform.position.y > ball.posY)
        {
            MovePlayerDown();
        }else if (transform.position.y < ball.posY)
        {
            MovePlayerUp();
        }

        float restrictedY = Mathf.Clamp(transform.position.y, downMost.y, upMost.y);
        transform.position = new Vector3(transform.position.x, restrictedY, transform.position.z);
    }

    void MovePlayerUp(){
        transform.position += Vector3.up * speed * Time.deltaTime;
    }

    void MovePlayerDown(){
        transform.position -= Vector3.up * speed * Time.deltaTime;
    }

}
