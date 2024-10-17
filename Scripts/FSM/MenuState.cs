using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : FSMState
{
    private void Awake()
    {
        stateID = StateID.Menu;
        AddTransition(Transition.StartButtonClick, StateID.Play);
    }

    public override void DoBeforeEntering()
    {
      
        controller.view.ShowMenu();
    }

    public override void DoBeforeLeaving()
    {
        controller.view.HideMenu();
    }

    public void OnStartButtonClick() {
        controller.audioManager.PlayCursor();
        fsm.PerformTransition(Transition.StartButtonClick);
    }
}
