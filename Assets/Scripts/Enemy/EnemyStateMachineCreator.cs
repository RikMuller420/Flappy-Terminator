using System;
using UnityEngine;

public class EnemyStateMachineCreator : MonoBehaviour
{
    [SerializeField] private float appearSpeed = 8f;
    [SerializeField] private float appearOffsetY = 15f;
    [SerializeField] private float deadSpeed = 15f;
    [SerializeField] private float deadOffsetY = -20;

    public StateMachine Create(EnemyMover enemyMover, Transform player, Collider2D enemyCollider,
                               EnemyShooter shooter, Action enemyDeactiveDelegate,
                               out Action changeStateToAppear, out Action changeStateToDead)
    {
        StateMachine stateMachine = new StateMachine();

        AppearState appearState = new AppearState(stateMachine, appearSpeed, appearOffsetY, enemyCollider, enemyMover, player);
        FightState fightState = new FightState(stateMachine, enemyMover, shooter, player);
        DeadState deadState = new DeadState(stateMachine, deadSpeed, deadOffsetY, enemyCollider, enemyMover, player);
        DisabledState disabledState = new DisabledState(stateMachine, enemyDeactiveDelegate);

        ToFightStateTransition toFightStateTransition = new ToFightStateTransition(fightState, player, enemyMover);
        ToDisabledStateTransition toDisabledStateTransition = new ToDisabledStateTransition(disabledState, deadOffsetY, player, enemyMover);

        changeStateToAppear = () => stateMachine.ChangeState(appearState);
        appearState.AddTransition(toFightStateTransition);
        changeStateToDead = () => stateMachine.ChangeState(deadState);
        deadState.AddTransition(toDisabledStateTransition);

        stateMachine.ChangeState(appearState);

        return stateMachine;
    }
}
