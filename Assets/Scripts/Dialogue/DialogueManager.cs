using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text sentenceText;
    public GameObject conversationPanel;

    private Queue<string> dialogues;
    // Start is called before the first frame update
    void Start()
    {
        dialogues = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Time.timeScale = 0;

        conversationPanel.SetActive(true);

        nameText.text = dialogue.name;

        dialogues.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            dialogues.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(dialogues.Count == 0)
        {
            EndDialogue();
            conversationPanel.SetActive(false);
            Time.timeScale = 1;
            return;
        }

        string sentence = dialogues.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence (string sentence)
    {
        sentenceText.text = "";

        foreach(char letter in sentence.ToCharArray())
        {
            sentenceText.text += letter;
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(0.01));
            yield return null;
        }
    }
    void EndDialogue()
    {
        sentenceText.text = "Koniec rozmowy";

    }
}   
