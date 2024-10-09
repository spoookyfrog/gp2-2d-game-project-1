using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombs : MonoBehaviour
{
    public GameObject bomb;
    public void SpawnBombs()
    {
        Debug.Log("bomb");
        int spawnPointX = Random.Range(-8,8);
        int spawnPointY = Random.Range(-4,4);

        Vector3 spawnPosition = new Vector3(spawnPointX,spawnPointY);

        Instantiate (bomb, spawnPosition, Quaternion.identity); //to spawn objects into your scene via game object, location and rotation
    }
}
