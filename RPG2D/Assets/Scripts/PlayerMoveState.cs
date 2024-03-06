using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState {

  public PlayerMoveState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName) {
  }

  public override void Enter() {
    base.Enter();
  }

  public override void Exit() {
    base.Exit();
  }

  public override void Update() {
    base.Update();

    player.SetVelocityOnlyX(xInput * player.moveSpeed);

    if (xInput == 0) {
      stateMachine.ChangeState(player.idleState);
    }
  }
}