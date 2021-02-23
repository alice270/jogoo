using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public enum GameState { FreeRoam, Battle }
public class GameController : MonoBehaviour
{

    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] RhythmManager rhythmSystem;
    [SerializeField] Camera worldCamera;
    GameState state;


    private void Start()
    {
        playerMovement.iniciarBatalha += StartBattle;
        rhythmSystem.terminarBatalha += EndBattle;
    }

    void StartBattle()
    {
        state = GameState.Battle;
        rhythmSystem.gameObject.SetActive(true);
        worldCamera.gameObject.SetActive(false);
    }

    void EndBattle(bool won)
    {
        state = GameState.FreeRoam;
        rhythmSystem.gameObject.SetActive(false);
        worldCamera.gameObject.SetActive(true);
    }
    private void Update()
    {
        if (state == GameState.FreeRoam)
        {
            playerMovement.HandleUpdate();
        }
        else if (state == GameState.Battle)
        {
            rhythmSystem.HandleUpdate();
        }
    }
}