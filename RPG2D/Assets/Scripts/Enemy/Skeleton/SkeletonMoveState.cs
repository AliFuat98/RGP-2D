public class SkeletonMoveState : EnemyState {
  private EnemySkeleton enemy;

  public SkeletonMoveState(Enemy enemyBase, EnemySkeleton enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName) {
    this.enemy = enemy;
  }

  public override void Enter() {
    base.Enter();
  }

  public override void Exit() {
    base.Exit();
  }

  public override void Update() {
    base.Update();

    enemy.SetVelocity(enemy.moveSpeed * enemy.facingDirection, enemy.rb.velocity.y);

    if (enemy.IsWallDetected() || !enemy.IsGroundDetected()) {
      enemy.Flip();
      stateMachine.ChangeState(enemy.IdleState);
    }
  }
}