using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class TimerAndScore : MonoBehaviour
{
    public GameObject uiObject1;
    public GameObject uiObject2;
    public GameObject uiObject3;
    public GameObject uiObject4;
    private bool gameStarted = false; //have not started the game

    float currentTime = 0f;
    public float startingTime = 60f;
    public TMP_Text timer;

    public TMP_Text scoreText;
    public int score = 0; //score starts at 0

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uiObject1.SetActive(false);
        uiObject2.SetActive(false);
        uiObject3.SetActive(false);
        uiObject4.SetActive(false);

        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted)
        {
            //show UI objects
            uiObject1.SetActive(true);
            uiObject2.SetActive(true);
            uiObject3.SetActive(true);
            uiObject4.SetActive(true);

            currentTime -= 1 * Time.deltaTime;
            timer.text = currentTime.ToString("0"); //to round the value and update text
            if (currentTime <= 0)
            {
                currentTime = 0;
                SceneManager.LoadScene("WinEnding"); //load (win)ending scene when time is up
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameStarted = true; //start timer when player enters trigger (the gate)
        }
    }
}
