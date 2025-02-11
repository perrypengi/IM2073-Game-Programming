using UnityEngine;
using TMPro;

public class GhostInteraction : MonoBehaviour
{
    // Reference to the TextMesh Pro text component used to display rules
    public TMP_Text ruleText;
    // Defines the interaction distance between the player and the ghost NPC, adjustable in the Inspector panel
    public float interactionDistance = 3f;
    // An array of strings to store game rules, where rule content can be set in the Inspector panel
    public string[] gameRules;

    // Cache the player object to avoid searching for it every frame
    private GameObject player;
    // A flag indicating whether the player is within the interaction range
    private bool isPlayerNear = false;

    private void Start()
    {
        // Find the player object
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("Could not find the player object with the tag 'Player'. Please check the settings.");
            return;
        }

        // Ensure the text component exists and is enabled
        if (ruleText == null)
        {
            Debug.LogError("The ruleText reference is not set in the GhostInteraction script. Please check.");
            return;
        }
        ruleText.enabled = true;
        ruleText.text = "";
    }

    private void Update()
    {
        if (player == null || ruleText == null) return;
        float distance = Vector3.Distance(transform.position, player.transform.position);
        Debug.Log($"Distance: {distance}, isPlayerNear: {isPlayerNear}");
        if (distance <= interactionDistance)
        {
            if (!isPlayerNear)
            {
                isPlayerNear = true;
                ShowRules();
            }
        }
        /*else
        {
            if (isPlayerNear)
            {
                isPlayerNear = false;
                HideRules();
            }
        }
        */
    }

    private void ShowRules()
    {
        Debug.Log("ShowRules method called");
        if (ruleText == null) return;

        string combinedRules = "";
        foreach (string rule in gameRules)
        {
            combinedRules += rule + "\n";
        }
        ruleText.text = combinedRules;
    }

    /*private void HideRules()
    {
        Debug.Log("HideRules method called");
        if (ruleText == null) return;
        ruleText.text = "";
    }
    */
}