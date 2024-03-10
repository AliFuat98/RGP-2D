public class PlayerWallJumpState : PlayerState {

  public PlayerWallJumpState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName) {
  }

  public override void Enter() {
    base.Enter();

    player.SetVelocity(5 * -player.facingDirection, player.jumpForce);
  }

  public override void Exit() {
    base.Exit();
  }

  public override void Update() {
    base.Update();

    if (player.IsGroundDetected()) {
      stateMachine.ChangeState(player.idleState);
      return;
    }

    if (rb.velocity.y < 0) {
      stateMachine.ChangeState(player.airState);
    }
  }
}