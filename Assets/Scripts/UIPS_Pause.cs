using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPS_Pause : UIPanelSequentiable
{
    //CONSTRUCTOR
    public UIPS_Pause(GameObject currentPanel) : base(currentPanel) { }


    //TODO: FIX

    //TAKE OVER LOGIC: PAUSE
    protected override void TakeOverLogic() => GameStateController.Instance.PauseGame();

    //GO BACK LOGIC: UNPAUSE
    protected override void GoBackLogic() => GameStateController.Instance.UnpauseGame();

}
