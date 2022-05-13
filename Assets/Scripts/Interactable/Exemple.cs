using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exemple : Interactable
{
    public override void InteractStart()
    {
        Debug.Log("InteractStart");
    }

    public override void InteractEnd()
    {
        Debug.Log("InteractEnd");
    }


}
