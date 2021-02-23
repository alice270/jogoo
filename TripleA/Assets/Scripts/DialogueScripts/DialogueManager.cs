using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{


    public static DialogueManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Fiz this" + gameObject.name);
        }

        else
        {
            instance = this;
        }
    }

    public GameObject dialogueBox;

    public Text dialogueName;
    public Text dialogueText;
    public Image dialoguePortrait;
    public float delay = 0.001f;
    private string completeText;


    public bool inDialogue;
    public bool isCurrentlyTyping;
    private bool buffer;

    public Queue<DialogueBase.Info> dialogueInfo = new Queue<DialogueBase.Info>();

    public void EnqueueDialogue(DialogueBase db)
    {

        buffer = true;
        if (inDialogue) return;
        inDialogue = true;
        StartCoroutine(BufferTimer());

        dialogueBox.SetActive(true);
        dialogueInfo.Clear();

        foreach (DialogueBase.Info info in db.dialogueInfo)
        {
            dialogueInfo.Enqueue(info);
        }
        DequeueDialogue();
    }

    public void DequeueDialogue()
    {
        if (isCurrentlyTyping == true)
        {
            //ta aqui o problema falta i TIREI
            CompleteText();
            StopAllCoroutines();
            isCurrentlyTyping = false;
            return;
        }


        if (dialogueInfo.Count == 0)
        {
            EndofDialogue();
            return;
        }

        DialogueBase.Info info = dialogueInfo.Dequeue();
        completeText = info.myText; //COMPLETI AQUI

        //dialogueName.text = info.myName;
        dialogueName.text = info.character.myName;
        dialogueText.text = info.myText;
        //dialoguePortrait.sprite = info.portrait;
        dialoguePortrait.sprite = info.character.myPortrait;

        dialogueText.text = "";
        StartCoroutine(TypeText(info));
    }


    IEnumerator TypeText(DialogueBase.Info info)
    {

        isCurrentlyTyping = true;

        foreach (char c in info.myText.ToCharArray())
        {
            yield return new WaitForSeconds(delay);
            dialogueText.text += c;
            //AudioManager.instance.PlayClip(info.character.myVoice); // COLOQUEI ISSO

        }

        isCurrentlyTyping = false;
    }

    IEnumerator BufferTimer()
    {
        yield return new WaitForSeconds(0.1f);
        buffer = false;
    }

    private void CompleteText()
    {
        dialogueText.text = completeText;
    }

    public void EndofDialogue()
    {
        dialogueBox.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (inDialogue)
            {
                DequeueDialogue();
            }
        }
    }
}
