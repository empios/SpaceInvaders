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

    private Queue<string> dialoguesQueue;


    public void StartDialogue(Dialogue dialogue)
    {
        Time.timeScale = 0;

        conversationPanel.SetActive(true);

        nameText.text = dialogue.name;

        dialoguesQueue = new Queue<string>();
        dialoguesQueue.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            dialoguesQueue.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(dialoguesQueue.Count == 0)
        {
            EndDialogue();
            conversationPanel.SetActive(false);
            Time.timeScale = 1;
            return;
        }

        string sentence = dialoguesQueue.Dequeue();
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
