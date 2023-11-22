using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class monsterFSM : MonoBehaviour
{
    public enum MonsterState
    {
        Idle,
        Move    
    }

    public MonsterState startState; [SerializeField]
    protected MonsterState currentState = MonsterState.Idle;


    public virtual void Initialize()
    {
        ChangeState(currentState);
    }
    protected virtual void Update()
    {
        StateUpdate(currentState);
    }

    protected virtual void FixedUpdate()
    {
        StateFixedUpdate(currentState);
    }


    public virtual void ChangeState(MonsterState newState)
    {
        if (newState == currentState)
            return;
        OnStateExit(currentState); currentState = newState;
        OnStateEnter(currentState);
    }
    public abstract void OnStateEnter(MonsterState state);

    public abstract void StateUpdate(MonsterState state);

    public abstract void StateFixedUpdate(MonsterState state);

    public abstract void OnStateExit(MonsterState state);
}
