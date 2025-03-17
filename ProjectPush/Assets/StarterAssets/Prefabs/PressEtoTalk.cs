using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PressEtoTalk : MonoBehaviour
{
    public float interactionDistance = 3f; // Distance within which player can interact
    public TextMeshPro textMesh;           // Reference to the TextMesh for dialogue
    public string[] dialogueSentences;     // List of dialogue sentences to loop through
    private int currentSentenceIndex = 0;  // Index of the current sentence in the list
    private bool firstInteraction = true;  // Track if it's the first time pressing "E"
    private Transform player;              // Reference to the player's transform

    void Start()
    {
        textMesh.text = "";
        // Find the player by tag
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogError("Player object with tag 'Player' not found");
        }
    }

    void Update()
    {
        // Check if the player is within interaction range
        if (player != null && Vector3.Distance(transform.position, player.position) <= interactionDistance)
        {
            // Show text and cycle sentences when "E" is pressed near the character
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Show the TextMesh after the first interaction
                if (firstInteraction)
                {
                    textMesh.gameObject.SetActive(true);
                    firstInteraction = false;
                }

                // Display the current sentence
                textMesh.text = dialogueSentences[currentSentenceIndex];

                // Move to the next sentence, looping back to the first if at the end
                currentSentenceIndex = (currentSentenceIndex + 1) % dialogueSentences.Length;
            }
        }
    }
}