using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.UI;
public class TurnManager : MonoBehaviour {
    public static TurnManager instance;
    public enum TurnState
    {
        Nobody,
        PlayerTurn,
        EnemyTurn
    }

    public TurnState currentTurnState;
    private TurnState _previousTurnState;

    public Text turnText;
    public float timeBetweenTurns;

    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        Invoke("InitTurn", 0.2f);
        
    }

    void InitTurn()
    {
        NewTurn(TurnState.PlayerTurn);
    }

    void ChangeTurn()
    {
        if (_previousTurnState == TurnState.PlayerTurn)
        {
            NewTurn(TurnState.EnemyTurn);
        }
        else if (_previousTurnState == TurnState.EnemyTurn)
        {
            NewTurn(TurnState.PlayerTurn);
        }

        
    }

    void NewTurn(TurnState state)
    {
        turnText.text = state.ToString();
        Debug.Log(state.ToString());
        ChangeTurnState(state);
        _previousTurnState = state;
        TurnHandler();
    }

    IEnumerator WaitBetweenTurns(float duration)
    {
        ChangeTurnState(TurnState.Nobody);
        yield return new WaitForSeconds(duration);
        AllReady();
        ChangeTurn();
    }

    void AllReady()
    {
        foreach (Entity entity in (CombatManager.instance.playerEntities))
        {
            entity.hasDoneAction = false;
        }

        foreach (Entity entity in (CombatManager.instance.enemyEntities))
        {
            entity.hasDoneAction = false;
        }
    }

    void ChangeTurnState(TurnState state)
    {
        currentTurnState = state;

    }

    public void CheckEndTurn(Entity entity)
    {
        if(entity.currentCamp == Entity.Camp.Player)
        {
            if(CombatManager.instance.playerEntities.TrueForAll(en => en.hasDoneAction))
            {
                StartCoroutine(WaitBetweenTurns(1f));
            }
        }else if (entity.currentCamp == Entity.Camp.Enemy)
        {

            if (CombatManager.instance.enemyEntities.TrueForAll(en => en.hasDoneAction))
            {
                StartCoroutine(WaitBetweenTurns(1f));

            }
        }
    }

    void TurnHandler()
    {
        if(currentTurnState == TurnState.PlayerTurn)
        {
            for(int i = 0; i < CombatManager.instance.playerEntities.Count; i++)
            {
                StartCoroutine(ExecuteWithDelay( CombatManager.instance.playerEntities[i], i+1f));
            }

        }
        else if(currentTurnState == TurnState.EnemyTurn)
        {
            for (int i = 0; i < CombatManager.instance.enemyEntities.Count; i++)
            {
                StartCoroutine(ExecuteWithDelay(CombatManager.instance.enemyEntities[i], i+1f));
            }
        }
    }

    IEnumerator ExecuteWithDelay(Entity entity, float time)
    {
        
        yield return new WaitForSeconds(time);
        entity.gambit.CheckAllCondition();
    }
}
