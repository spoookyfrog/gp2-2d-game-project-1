using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public float currentTime = 0f;
    public float startingTime = 10f;
    public TextMeshProUGUI countdown;
    public int sceneID;
    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    void Start()
    {
        currentTime = startingTime;
    }
    void Update()
    {
        currentTime -= 1 * Time.deltaTime; //time goes down by 1 second
        countdown.text = currentTime.ToString("0"); // to show whole numbers

        if(currentTime <= 10)
        {
            countdown.color = Color.red;
        }
        

        if(currentTime <= 0)
        {
            currentTime = 0;
            MoveToScene(sceneID);
        }
    }

}
