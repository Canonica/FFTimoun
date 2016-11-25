using UnityEngine;
using System.Collections;

public class TurnManager : MonoBehaviour {

    public enum TurnState
    {
        Nobody,
        PlayerTurn,
        Enemyturn
    }

    public TurnState currentTurnState;
    private TurnState _previousTurnState;

    public float timeBetweenTurns;
    private bool _isChangingTurn;

    void Start()
    {
        NewTurn(TurnState.PlayerTurn);
    }

    void ChangeTurn()
    {
        _isChangingTurn = false;
        if (_previousTurnState == TurnState.PlayerTurn)
        {
            NewTurn(TurnState.Enemyturn);
        }
        else if (_previousTurnState == TurnState.Enemyturn)
        {
            NewTurn(TurnState.PlayerTurn);
        }
    }

    void NewTurn(TurnState state)
    {
        Debug.Log(state.ToString());
        ChangeTurnState(state);
        _previousTurnState = state;
    }

    IEnumerator WaitBetweenTurns(float duration)
    {
        _isChangingTurn = true;
        ChangeTurnState(TurnState.Nobody);
        yield return new WaitForSeconds(duration);
        ChangeTurn();
    }

    void ChangeTurnState(TurnState state)
    {
        currentTurnState = state;

    }
}
