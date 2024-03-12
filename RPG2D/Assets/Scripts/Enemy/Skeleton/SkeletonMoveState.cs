public class SkeletonMoveState : SkeletonGroundedState {

  public SkeletonMoveState(Enemy enemyBase, EnemySkeleton enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemyBase, enemy, stateMachine, animBoolName) {
  }

  public override void Enter() {
    base.Enter();
  }

  public override void Exit() {
    base.Exit();
  }

  public override void Update() {
    base.Update();

    enemy.SetVelocity(enemy.moveSpeed * enemy.facingDirection, rb.velocity.y);

    if (enemy.IsWallDetected() || !enemy.IsGroundDetected()) {
      enemy.Flip();
      stateMachine.ChangeState(enemy.IdleState);
    }
  }
}