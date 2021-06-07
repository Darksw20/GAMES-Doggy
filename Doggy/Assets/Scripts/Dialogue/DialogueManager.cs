using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    private Queue<string> sentences;

    public void startDialogue(Dialogue dialogue)
    {
        string aux;
        sentences = new Queue<string>();

        nameText.text = dialogue.name;

        sentences.Clear();
        foreach(string sentence in dialogue.sentences)
        {
            aux = sentence.Replace("______", GameManager.instancia.playerName);
            sentences.Enqueue(aux);
        }

        displayNextSentence();
    }

    public void displayNextSentence()
    {
        if (sentences.Count == 0)
        {
            endDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(typeSentence(sentence));

    }

    IEnumerator typeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    private void endDialogue()
    {
        GameObject.Find("Dialogue").SetActive(false);
        GameObject.Find("Pajaro").SetActive(false);
        timeController.timerIsRunning = true;
        enabled = false;
    }

}
