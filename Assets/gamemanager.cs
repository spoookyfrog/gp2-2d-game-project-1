using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    //public time passed variabel
    public float myTimer = 0f;
    public float myFixedTimer = 0f;
    public float spawnInterval = .5f;
    public float spawnTimer = 0f;
    public GameObject myEnemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //add time passed between frames
        myTimer += Time.deltaTime;
//track enemy spawn time here
        spawnTimer += Time.deltaTime;
        //once the interval hits, trigger an enemy spawn and reset timer
        if(spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f;
            Instantiate(myEnemy);
            Debug.Log("enemy spawn");
        }
    }

    void FixedUpdate()
    {
        //add time passed between each physics frame
        myFixedTimer += Time.fixedDeltaTime;
    }
}
