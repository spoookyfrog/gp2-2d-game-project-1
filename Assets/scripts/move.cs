using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour
{
    public float collectedScore = 0;
    //Accel is public so we can edit the movement speed within unity
    public float accel = 1f;
    //seprate speed for both horizontal and veritcal
    public float horiAccel = 1f;
    public float vertAccel = .1f;

    public float jumpForce = 30f;

    public float JumpCooldown = 0f;

    bool canJump = true;

    public float coyoteTime = 2f;
    public float LongerTime = 2f;

    // Start is called before the first frame update

    Rigidbody2D myRB;



    //void function, does not return any data
    void Start()
    {
        myRB = GetComponent<Rigidbody2D> ();
    }



    // Update is called once per frame
    void Update()
    {

    }


    //----------------------------- FIXED UPDATE ---------------------------------
    void FixedUpdate () //aka -> every physics update
    {
        //Move() function to find out what the current player inputs are
        Vector3 currentMove = Move();
        //mulitply out horizontal and vertical move separtely
        currentMove.x *= horiAccel;
        currentMove.y *= vertAccel;
        //put it into a Translate, muliply by our accleration variable
       myRB.AddForce(currentMove);

       if(Input.GetAxis("Jump") > .05f && canJump)

        {
            StartCoroutine(JumpCycle(JumpCooldown));
        }
    }



    //gets the inputs of the WASD / keyboard / joysticks
    //this funtion gets the overall direction and returns it as a vector3
    public Vector3 Move()
    {
    //Unity's defaults axes provides a value of -1 to 1
    //In case of Vertical, w = 1 and s = -1
        float y = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");

    //contruct our vector out of teh vertical/horizontal axis
        Vector3 mymove = new Vector3(x,y,0);
    //then they return that value
        return mymove;
    }



    //checking for enemy or colliable collisons 
    public void OnCollisionEnter2D(Collision2D collision)
    {
        canJump =true;
    //when we collide with something and destory it and increase the player score
        Debug.Log("Player collided with" + collision.gameObject.name);

        if(collision.gameObject.tag == "collectiable")
        {
            Destroy(collision.gameObject);
            collectedScore++;
        }

        if(collision.gameObject.tag == "bomb")
        {
            SceneManager.LoadScene(1);        
        }
    }
        


    public void OnCollisionStay2D(Collision2D collision)
    {

    }   

    public void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("exited collision");
        StartCoroutine(LongerJump(LongerTime));
    }


    
    public void Jump()

    {
        myRB.AddForce(Vector3.up*jumpForce);
    }

    public IEnumerator JumpCycle(float time)
    //code above will excute right away
    {
        Jump();
        yield return new WaitForSeconds(time);
        canJump =true;
        
    }
    //code above will go after the time
    public IEnumerator LongerJump(float time)
    //code above will excute right away
    {
        yield return new WaitForSeconds(time);
        canJump =false;
    }
        
}
