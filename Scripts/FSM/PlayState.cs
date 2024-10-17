using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : FSMState {
    private void Awake()
    {
        stateID = StateID.Play;
        AddTransition(Transition.PauseButtonClick, StateID.Pause);
    }
    public override void DoBeforeEntering()
    {
        controller.view.ShowGameUI(controller.model.score, controller.model.HighScore);
        controller.gameManager.StartGame();
    }

    public override void DoBeforeLeaving()
    {
       // controller.view.HideGameUI();
        controller.gameManager.PauseGame();
    }
    public void OnPauseButtonClick()
    {
        controller.audioManager.PlayCursor();
        controller.view.ShowSettingUI();
        fsm.PerformTransition(Transition.PauseButtonClick);
    }

    public void OnRestartButtonClick()
    {
        controller.view.HideGameOverUI();
        controller.model.Restart();
        controller.gameManager.StartGame();
    }
    public void OnBackButtonClick()
    {
        controller.audioManager.PlayCursor();
        controller.view.HideSettingUI();
        fsm.PerformTransition(Transition.StartButtonClick);
    }

}
