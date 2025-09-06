using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    public static DialogueBox Instance;

    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public float typingSpeed = 0.05f;

    private string fullText;
    private bool isTyping = false;
    private string lastShownMessage = "";

    private Queue<string> messageQueue = new Queue<string>();

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void ShowDialogue(string text)
    {
        fullText = text;
        dialoguePanel.SetActive(true);
        StartCoroutine(TypeText());
    }

    public void ShowDialogueQueue(List<string> messages)
    {
        messageQueue.Clear(); //clear previous messages
        foreach (string msg in messages)
        {
            messageQueue.Enqueue(msg);
        }

        ShowNextDialogue(); //Start the first one
    }

    private void ShowNextDialogue()
    {
        if (messageQueue.Count > 0)
        {
            fullText = messageQueue.Dequeue();
            dialoguePanel.SetActive(true);
            StartCoroutine(TypeText());
        }
        else
        {
            HideDialogue(); // Close the panel if no more messages
        }


    }

    IEnumerator TypeText()
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char c in fullText)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    public void HideDialogue()
    {
        dialoguePanel.SetActive(false);
        lastShownMessage = "";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isTyping)
        {
            HideDialogue();
        }
    }
}
