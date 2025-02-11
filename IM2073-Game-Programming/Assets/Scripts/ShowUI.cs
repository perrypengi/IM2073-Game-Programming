using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowUI : MonoBehaviour
{
    public GameObject uiObject;
    public bool isInRange = false; //check if player is within interactable range

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
            if (uiObject != null) 
            {
                uiObject.SetActive(true);
                StartCoroutine("WaitForSec");
              
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
        Destroy(uiObject);
    }
}
