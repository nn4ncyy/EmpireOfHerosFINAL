using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { FreeRoam, Dialog }
public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController playerController ;
    [SerializeField] EmptyPlayer emptyPlayer ;

    GameState state;
    private void Start() 
    {
        DialogManager.Instance.OnShowDialog += () =>
        {
            state = GameState.Dialog;
        };
        DialogManager.Instance.OnHideDialog += () =>
        {
            if(state == GameState.Dialog)
            {
               state = GameState.FreeRoam;
            }
        };
    }
    private void Update() 
    {
        if (state == GameState.FreeRoam) 
        {
            playerController.HandleUpdate();
            emptyPlayer.HandleUpdate();

        } else if (state == GameState.Dialog) 
        {
            DialogManager.Instance.HandleUpdate();
         }
    }
}
