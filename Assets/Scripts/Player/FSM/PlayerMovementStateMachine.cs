using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementStateMachine : MonoBehaviour
{
    [Header("�÷��̾� ��Ʈ�ѷ�")]
    public PlayerController playerController;

    [HideInInspector] public IPlayerState curState;
    public Dictionary<PlayerMovementEnums, IPlayerState> stateDictionary;

    private void Awake()
    {
        stateDictionary = new Dictionary<PlayerMovementEnums, IPlayerState>
        {
            {PlayerMovementEnums.IDLE, new PlayerIdleState(this) },
            {PlayerMovementEnums.MOVE, new PlayerMoveState(this) },
            {PlayerMovementEnums.DODGE, new PlayerDodgeState(this) },
            {PlayerMovementEnums.JUMP, new PlayerJumpState(this) },
            {PlayerMovementEnums.RISE, new PlayerRiseState(this) },
            {PlayerMovementEnums.FALL, new PlayerFallState(this) },
            {PlayerMovementEnums.LAND, new PlayerLandState(this) },
            {PlayerMovementEnums.ATTACK, new PlayerAttackState(this) },
            {PlayerMovementEnums.DOWNJUMP, new PlayerDownJumpState(this) },
            {PlayerMovementEnums.WALLSLIDE, new PlayerWallSlideState(this) },
            {PlayerMovementEnums.WALLJUMP, new PlayerWallJumpState(this) },
            {PlayerMovementEnums.SKILL, new PlayerSkillState(this) },
        };

        if(stateDictionary.TryGetValue(PlayerMovementEnums.IDLE, out IPlayerState newState))
        {
            // TryGetValue Key�� �ִ��� Ȯ�ΰ� ���ÿ� Value�� ��ȯ

            curState = newState;
            curState.OnEnter();
        }
    }

    public void ChangeStateAny(PlayerMovementEnums newStateType) // �������� ���� ����
    {
        if (curState == null) return;

        curState.OnExit();

        if(stateDictionary.TryGetValue(newStateType, out IPlayerState newState))
        {
            curState = newState;
            curState.OnEnter();
        }
    }

    public void ChangeStateInput(PlayerMovementEnums newStateType) // �Է¹޾��� �� ���� ����
    {
        if (curState == null) return;
        if (!curState.inputHash.Contains(newStateType)) return;

        curState.OnExit();

        if(stateDictionary.TryGetValue(newStateType, out IPlayerState newState))
        {
            newState.OnEnter();
            curState = newState;
        }
    }

    public void ChangeStateLogic(PlayerMovementEnums newStateType) // ������ ���� ���� 
    {
        if (curState == null) return;
        if (!curState.logicHash.Contains(newStateType)) return;
    
        curState.OnExit();

        if (stateDictionary.TryGetValue(newStateType, out IPlayerState newState))
        {
            curState = newState;
            curState.OnEnter();
        }
    }
}
