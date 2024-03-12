public class SkeletonIdleState : SkeletonGroundedState {

  public SkeletonIdleState(Enemy enemyBase, EnemySkeleton enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemyBase, enemy, stateMachine, animBoolName) {
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