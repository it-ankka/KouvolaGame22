using UnityEngine;
public interface Interactable
{
    public bool Activated { get; set; }
    void interact();
}