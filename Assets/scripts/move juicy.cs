using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movejuicy : MonoBehaviour

{
    SpriteRenderer myRender;
    Material myMat;
AudioSource collisionAudio;
public AudioClip[] hitsound;
    // Start is called before the first frame update
    void Start()
    {
        myRender = GetComponent<SpriteRenderer>();
        myMat = myRender.material;
        collisionAudio = GetComponent<AudioSource>();
        AudioClip temp = hitsound[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "collectiable")

      {

        StartCoroutine(changeColor(.5f));
        Debug.Log("touched collectiable");

      }  
      collisionAudio.clip = hitsound[Random.Range(0, hitsound.Length)];
      collisionAudio.Play();
      
    }

    public IEnumerator changeColor (float time)
    {
      //code runs here the second you call this function
      yield return new WaitForSeconds(time); //wait for TIME seconds before executing the rest of this method
      //code that runs after TIME seconds have passed
    }

    public Vector3 Direction()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(x,y,0);
        return dir;
    }
}
