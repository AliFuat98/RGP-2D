public class SkeletonIdleState : EnemyState {
  private EnemySkeleton enemy;

  public SkeletonIdleState(Enemy enemyBase, EnemySkeleton enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName) {
    this.enemy = enemy;
  }

  public override void Enter() {
    base.Enter();

    stateTimer = enemy.idleTime;
  }

  public override void Exit() {
    base.Exit();
  }

  public override void Update() {
    base.Update();

    if (stateTimer < 0) {
      stateMachine.ChangeState(enemy.MoveState);
    }
  }
}