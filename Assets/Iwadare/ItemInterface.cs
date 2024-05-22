using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ItemInterface
{
    public void PlayerHitEvent(Animator playerAnim);

    public void RodHitEvent();
}
