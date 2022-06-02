using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour, Interactable
{
    public bool Activated { get; set; }
    public Dialogue dialogue;
    public void interact() {
        DialogueManager.instance.StartDialogue(dialogue, this);
    }
}
