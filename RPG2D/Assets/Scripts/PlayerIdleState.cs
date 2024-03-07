using UnityEngine;

public class PlayerIdleState : PlayerGroundedState {

  public PlayerIdleState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName) {
  }

  public override void Enter() {
    base.Enter();
    rb.velocity = Vector2.zero;
  }

  public override void Exit() {
    base.Exit();
  }

  public override void Update() {
    base.Update();

    if (xInput == player.facingDirection && player.IsWallDetected()) {
      return;
    }

    //if (xInput != 0 && !player.isBussy) {
    //if (xInput != 0 ) {
    if (xInput != 0 && !triggerCalled) {
      stateMachine.ChangeState(player.moveState);
    }
  }
}