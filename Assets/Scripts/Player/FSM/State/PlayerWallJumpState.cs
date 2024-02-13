using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJumpState : IPlayerState
{
    public PlayerController player { get; set; }
    public PlayerMovementStateMachine stateMachine { get; set; }

    public PlayerWallJumpState(PlayerMovementStateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
        player = stateMachine.playerController;
    }

    public HashSet<PlayerMovementEnums> inputHash { get; } = new HashSet<PlayerMovementEnums>()
    {
    };

    public HashSet<PlayerMovementEnums> logicHash { get; } = new HashSet<PlayerMovementEnums>()
    {
        PlayerMovementEnums.WALLSLIDE,
        PlayerMovementEnums.FALL
    };

    public void Update()
    {
        player.wallJumpCounter -= Time.deltaTime;
        
        if(player.wallJumpCounter < 0f)
        {
            //if (player.rigid.velocity.y < 0f)
                stateMachine.ChangeStateLogic(PlayerMovementEnums.FALL);
        }

            // ���� (���� �ֵ�����) > ��� > ���� > ���� ���� å�� ��Ģ ������ ���� ������Ʈ�� 2���� ������ �ϰ��־� ������϶� ���Եǰ� ���� �ֵ����� ��ɶ��� ���ԵǾ��־� �״ϱ�����
    }

    public void FixedUpdate()
    {
    }

    public void OnEnter()
    {
        player.isWallJump = true;
        player.PlayAnimation("Jump");
        player.WallJump();
    }

    public void OnExit()
    {
        player.isWallJump = false;
    }
}
