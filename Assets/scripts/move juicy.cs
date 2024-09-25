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
        myMat = GetComponent<SpriteRenderer>();
        myRender = myRender.material;
        collisionAudio GetComponent<AudioSource>();
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
      collisionAudio.clip = hitsound(Random.Range(0, hitsound.Length));
      collisionAudio.Play();
      
    }

    public IEnumerator changeColor (float time)
    {

    }
}
