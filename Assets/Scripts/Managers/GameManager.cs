using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private enum GameState { init, start, play, response, wait, battle, end };

    public enum GamePlayers { PLAYER, OPPONENT };

    private GameState m_State = GameState.init;

    public Player m_Player;
    public Player m_Opponent;

    bool m_TurnEnd = false;
    bool m_AttackSelected = false;
    bool m_Passed = false;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    private void Start()
    {
        
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {
        ExecuteState();
    }

    /// <summary>
    /// Executes the block of the current state
    /// </summary>
    private void ExecuteState()
    {
        switch(m_State)
        {
            case GameState.init:
                StateInit();
                break;
            case GameState.start:
                StateStart();
                break;
            case GameState.play:
                StatePlay();
                break;
            case GameState.response:
                StateResponse();
                break;
            case GameState.wait:
                StateWait();
                break;
            case GameState.battle:
                StateBattle();
                break;
            case GameState.end:
                StateEnd();
                break;
        };
    }

    /// <summary>
    /// Sets the state to the given state
    /// </summary>
    /// <param name="t_State"> state to change to </param>
    private void SetState(GameState t_State)
    {
        switch (t_State)
        {
            case GameState.init:
                {

                }
                break;
            case GameState.start:
                {
                Debug.Log("Turn Start");
                m_Player.RoundStart();
                m_Opponent.RoundStart();
                m_TurnEnd = false;
                }
                break;

            case GameState.play:
                Debug.Log("Play Phase");
                break;
            case GameState.response:
                Debug.Log("Response Phase");
                break;
            case GameState.wait:
                break;
            case GameState.battle:
                break;
            case GameState.end:
                Debug.Log("Turn End");
                break;
        };
        m_State = t_State;
    }

    //===================================================================================================
    //  GAME STATES
    //===================================================================================================
    #region GameStates
    
    /// <summary>
    /// 
    /// </summary>
    private void StateInit()
    {
        SetState(GameState.start);
    }

    /// <summary>
    /// 
    /// </summary>
    private void StateStart()
    {
        SetState(GameState.play);
    }

    /// <summary>
    /// 
    /// </summary>
    private void StatePlay()
    {
        if(m_Passed)
        {
            SetState(GameState.wait);
        }
        if (m_TurnEnd)
        {
            SetState(GameState.end);
        }
        if(m_AttackSelected)
        {
            SetState(GameState.battle);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void StateResponse()
    {
        if(m_TurnEnd)
        {
            SetState(GameState.end);
        }
    }

    private void StateWait()
    {

    }

    private void StateBattle()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    private void StateEnd()
    {
        SetState(GameState.start);
    }
    #endregion

    //===================================================================================================
    //  GAME STATES
    //===================================================================================================

    public void EndTurn()
    {
        m_TurnEnd = true;
    }

    public void PassTurn()
    {
        m_Passed = true;
    }

    public void AttackSelected()
    {
        m_AttackSelected = true;
    }
}
