using UnityEngine;

public class SkeletonGroundedState : EnemyState {
  protected EnemySkeleton enemy;
  protected Transform player;

  public SkeletonGroundedState(Enemy enemyBase, EnemySkeleton enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName) {
    this.enemy = enemy;
  }

  public override void Enter() {
    base.Enter();

    player = PlayerManager.instance.player.transform;
  }

  public override void Exit() {
    base.Exit();
  }

  public override void Update() {
    base.Update();

    if (enemy.IsPlayerDetected() || Vector2.Distance(enemy.transform.position, player.position) < enemy.backBattleRange) {
      stateMachine.ChangeState(enemy.BattleState);
    }
  }
}