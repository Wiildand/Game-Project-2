using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TeleportableEvent : MonoBehaviour
{
    public UnityAction onTeleported;

    public void Teleported()
    {
        if (onTeleported != null)
            onTeleported();
    }
}
