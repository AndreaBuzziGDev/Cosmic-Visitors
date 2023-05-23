using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPS_Pause : UIPanelSequentiable
{
    //CONSTRUCTOR
    public UIPS_Pause(GameObject currentPanel) : base(currentPanel) { }



    //TAKE OVER LOGIC: PAUSE
    protected override void TakeOverLogic() => GameStateController.Instance.setState(GameStateController.eGameState.Paused);

    //GO BACK LOGIC: UNPAUSE
    protected override void GoBackLogic() => GameStateController.Instance.setState(GameStateController.eGameState.Playing);

}
