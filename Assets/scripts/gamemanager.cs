using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gamemanager : MonoBehaviour
{
    //public time passed variabel
    public float myTimer = 0f;
    //reference to the enemy, player and score
    public GameObject myPlayer;
    public TextMeshProUGUI myScore;
    public GameObject myEnemy;
    public float myFixedTimer = 0f;
    public float spawnInterval = .5f;
    public float spawnTimer = 0f;
    public float playerScore = 0;
    public Transform[] spawnPoints;
    public float minSpawnInterval = 1f;
    public float maxSpawnInterval = 5f;
    public GameObject bomb;
    move playerScript; 
    // Start is called before the first frame update
    void Start()
    {
        myPlayer = GameObject.FindGameObjectWithTag("Player");
        playerScript = myPlayer.GetComponent<move>();
        spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);

        
        //invokerepeating is a method that calls a function and runs it every x seconds with a y seconds
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
            spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);

            int randomIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(myEnemy, spawnPoints[randomIndex].position, Quaternion.identity);

            Debug.Log("bomb in game manager");
            int spawnPointX = Random.Range(-8,8);
            int spawnPointY = Random.Range(-4,4);

            Vector3 spawnPosition = new Vector3(spawnPointX,spawnPointY);

            Instantiate (bomb, spawnPosition, Quaternion.identity); //to spawn objects into your scene via game object, location and rotation

        }
        //since the gamemanger has a connection to the player, we can reference the player compnents to find out score
        playerScore = playerScript.collectedScore;
        myScore.text = playerScore.ToString();
    }

    void FixedUpdate()
    {
        //add time passed between each physics frame
        myFixedTimer += Time.fixedDeltaTime;
    }
}
