using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public abstract void InteractStart(Player player);
    public abstract void InteractEnd(Player player);
}
