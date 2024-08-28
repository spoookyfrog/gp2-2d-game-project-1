using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void FixedUpdate () //aka -> every physics update
    {
        transform.Translate(Move()*accel);
    }

    public Vector3 Move()

    {
        float y = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");

        Vector3 mymove = new Vector3(x,y,0);
        return mymove;
    }
}
