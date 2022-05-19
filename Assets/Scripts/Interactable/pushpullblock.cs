using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushpullblock : Interactable
{
    public override void InteractStart(Player player)
    {
        this.transform.SetParent(player.gameObject.transform);
    }

    public override void InteractEnd(Player player)
    {
        this.transform.SetParent(null);
    }


}
