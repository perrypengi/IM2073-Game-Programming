using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    float currentTime = 0f;
    public float startingTime = 500f;
    public TMP_Text timer;
    public GameObject uiObject1;
    public GameObject uiObject2;
    private bool timerStarted = false; //have not started the timer

    void Start()
    {
        //hide UI objects
        uiObject1.SetActive(false);
        uiObject2.SetActive(false);
        currentTime = startingTime;
    }
    void Update()
    {
        if (timerStarted)
        {
            //show UI objects
            uiObject1.SetActive(true);
            uiObject2.SetActive(true);
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
            timerStarted = true; //start timer when player enters trigger (the gate)
        }
    }
}
