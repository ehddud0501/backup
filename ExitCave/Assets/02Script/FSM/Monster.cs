using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Monster : monsterFSM
{

    public override void Initialize()
    {
        base.Initialize();
    }


    public override void OnStateEnter(MonsterState state)
    {
        switch (state)
        {
            case MonsterState.Idle:
                break;
            case MonsterState.Move:
                break;
        }
    }

    public override void OnStateExit(MonsterState state)
    {
        switch (state)
        {
            case MonsterState.Idle:
                break;
            case MonsterState.Move:
                break;
        }
    }

    public override void StateFixedUpdate(MonsterState state)
    {
        switch (state)
        {
            case MonsterState.Idle:

                break;
            case MonsterState.Move:
                break;
        }
    }

    public override void StateUpdate(MonsterState state)
    {
        switch (state)
        {
            case MonsterState.Idle:
                break;
            case MonsterState.Move:
                break;
        }
    }
}
