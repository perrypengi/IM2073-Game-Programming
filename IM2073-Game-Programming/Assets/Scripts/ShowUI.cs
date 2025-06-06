using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowUI : MonoBehaviour
{
    public GameObject uiObject;
    public bool isInRange = false; //check if player is within interactable range

    public static GameObject currentActiveUI;

    private Coroutine hideCoroutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uiObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
            // If there's a different active UI, destroy it first
            if (currentActiveUI != null && currentActiveUI != uiObject)
            {
                Destroy(currentActiveUI);
            }

            // Show this UI if it's not already active
            if (currentActiveUI != uiObject)
            {
                uiObject.SetActive(true);
                currentActiveUI = uiObject;

                // Start coroutine to hide after 8 seconds
                if (hideCoroutine != null)
                {
                    StopCoroutine(hideCoroutine);
                }
                hideCoroutine = StartCoroutine(WaitForSec());
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

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(8);
        if (uiObject != null)
        {
            Destroy(uiObject);
            if (currentActiveUI == uiObject)
            {
                currentActiveUI = null;
            }
        }
    }
}
