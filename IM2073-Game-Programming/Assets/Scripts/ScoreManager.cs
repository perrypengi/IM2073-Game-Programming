using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public int score = 0; //score starts at 0
    public GameObject uiObject1;
    public GameObject uiObject2;
    private bool scoreStarted = false; //have not started keeping score

    public void Score(int point)
    {
        score += point;
        scoreText.text = score.ToString(); //update text
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //hide UI objects
        uiObject1.SetActive(false);
        uiObject2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreStarted)
        {
            //show UI objects
            uiObject1.SetActive(true);
            uiObject2.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            scoreStarted = true; //start keeping score when player enters trigger (the gate)
        }
    }
}
