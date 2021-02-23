using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstscenedialogue : MonoBehaviour
{
    public DialogueBase dialogue;

    public void TriggerDialogue()
    {
        DialogueManager2.instance.EnqueueDialogue(dialogue);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            TriggerDialogue();
        }
    }
}
