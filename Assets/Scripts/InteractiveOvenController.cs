using UnityEngine;

public class InteractiveOvenController : InteractiveObjectController
{
    override public void Interact()
    {
        bool victory = MainManager.Instance.inventory.checkVictory();
        if (victory)
            MainManager.Instance.FinishGame(true);
    }
}
