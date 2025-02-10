using System;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool isInRange = false; //check if player is within interactable range
    public GameObject scoreManager;
    int pumpkin = 3; //pumpkin point
    int mushroom = 1; //mushroom point
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager");
    }
    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(KeyCode.E)) //player presses E to get interactables
            {
                Debug.Log("E button pressed");

                if (gameObject.tag == "Pumpkin")
                {
                    scoreManager.GetComponent<ScoreManager>().Score(pumpkin); //get 3 points
                }
                else if (gameObject.tag == "Mushroom")
                {
                    scoreManager.GetComponent<ScoreManager>().Score(mushroom); //get 1 point
                }
                Destroy(transform.gameObject); //destroy gameObject
            }
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            isInRange = true;
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            isInRange = false;
        }
    }

}
