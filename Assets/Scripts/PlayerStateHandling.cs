using System;
using UnityEngine;

public class PlayerStateHandling : MonoBehaviour
{
    public enum PlayerState
    {
        Moving,
        Chatting,
        Dialogue,
        InShop,
        Interacting,
        InMenu,
    }
    
    public static PlayerState CurrentState;
    
    
    public bool MovementPaused  => CurrentState is PlayerState.Chatting or PlayerState.Dialogue or PlayerState.InShop or PlayerState.Interacting or PlayerState.InMenu;
   
    private static PlayerStateHandling _instance;

   
    public static PlayerStateHandling Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindFirstObjectByType<PlayerStateHandling>();
                if(_instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = nameof(PlayerStateHandling);
                    _instance = go.AddComponent<PlayerStateHandling>();
                    DontDestroyOnLoad(go);
                }
            }
            return _instance;
        }
    }
    
    
    public void SetState(PlayerState state)
    {
        CurrentState = state;
        
        switch (CurrentState)
        {
            case PlayerState.Moving:
                Debug.Log("Player is moving");
                break;
            case PlayerState.Chatting:
                Debug.Log("Player is chatting");
                break;
            case PlayerState.Dialogue:
                Debug.Log("Player is in dialogue");
                break;
            case PlayerState.InShop:
                Debug.Log("Player is in shop");
                break;
            case PlayerState.Interacting:
                Debug.Log("Player is interacting");
                break;
            case PlayerState.InMenu:
                Debug.Log("Player is in menu");
                break;
        }
    }
}
