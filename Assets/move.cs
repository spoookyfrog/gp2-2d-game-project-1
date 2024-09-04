using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    //Accel is public so we can edit the movement speed within unity
public float accel = 1f;
    // Start is called before the first frame update
    //void function, does not return any data
void Start()
    {
    }
    // Update is called once per frame
void Update()
    {
    }
void FixedUpdate () //aka -> every physics update

    {
    //Move() function to find out what the current player inputs are
        Vector3 currentMove = Move();
    //put it into a Translate, muliply by our accleration variable
        transform.Translate(currentMove*accel); 
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
}
