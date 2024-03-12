using UnityEngine;

public class SkeletonAttackState : EnemyState {
  private Transform player;
  private EnemySkeleton enemy;
  private int moveDir;

  public SkeletonAttackState(Enemy enemyBase, EnemySkeleton enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName) {
    this.enemy = enemy;
  }

  public override void Enter() {
    base.Enter();

    player = GameObject.Find("Player").transform;
    enemy.SetZeroVelocity();
  }

  public override void Exit() {
    base.Exit();

    enemy.lastTimeAttacked = Time.time;
  }

  public override void Update() {
    base.Update();

    if (triggerCalled) {
      stateMachine.ChangeState(enemy.BattleState);
    }
  }
}