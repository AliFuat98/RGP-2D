public class SkeletonGroundedState : EnemyState {
  protected EnemySkeleton enemy;

  public SkeletonGroundedState(Enemy enemyBase, EnemySkeleton enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName) {
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

    if (enemy.IsPlayerDetected()) {
      stateMachine.ChangeState(enemy.BattleState);
    }
  }
}