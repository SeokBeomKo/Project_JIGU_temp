using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerState
{
    PlayerController player { get; set; }
    PlayerMovementStateMachine stateMachine { get; set; }

    // >> : ����Ʈ�� �ڱ��ڽ��� ���� ������ ���� ��� ���� \ get : ���� �������� �͸� ����
    HashSet<PlayerMovementEnums> inputHash { get; } // Ű �Է¹޾��� �� ����Ǵ� state
    HashSet<PlayerMovementEnums> logicHash { get; } // ������ ����Ǵ� state


    void Update();
    void FixedUpdate();
    void OnEnter();
    void OnExit();
}
