﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractOnFloor : MonoBehaviour
{
    public DialogueBase DB;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            DialogueManager.instance.EnqueueDialogue(DB);
        }
    }
}