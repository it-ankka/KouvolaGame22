using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    Queue<string> lines;
    DialogueTrigger trigger;

    // Start is called before the first frame update
    void Start()
    {
        lines = new Queue<string>();
    }
    
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(this);
    }
    
    public void StartDialogue(Dialogue dialogue, DialogueTrigger trigger)
    {
        if (this.trigger && this.trigger.Equals(trigger)) {
            NextLine();
            return;
        }

        trigger.Activated = true;
        Player.instance.disablePlayerMovement();
        this.trigger = trigger;
        Debug.Log("Dialogue started");
        lines.Clear();
        foreach(string line in dialogue.lines)
        {
            lines.Enqueue(line);
        }
        
        NextLine();
    }
    
    public void NextLine()
    {
        if (lines.Count < 1)
        {
            EndDialogue();
            return;
        }
        
        
        string currLine = lines.Dequeue();
        Debug.Log("Dialog: " + currLine);

    }
    
    public void EndDialogue()
    {
        trigger.Activated = false;
        trigger = null;
        Player.instance.enablePlayerControls();
        Debug.Log("Dialogue ended");
    }
}
