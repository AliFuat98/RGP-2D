using UnityEngine;

public class SkeletonBattleState : EnemyState {
  private Transform player;
  private EnemySkeleton enemy;
  private int moveDir;

  public SkeletonBattleState(Enemy enemyBase, EnemySkeleton enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName) {
    this.enemy = enemy;
  }

  public override void Enter() {
    base.Enter();

    player = GameObject.Find("Player").transform;
  }

  public override void Exit() {
    base.Exit();
  }

  public override void Update() {
    base.Update();

    RaycastHit2D hitPlayer = enemy.IsPlayerDetected();
    if (hitPlayer) {
      if (hitPlayer.distance < enemy.attackDistance) {
        if (CanAttack()) {
          stateMachine.ChangeState(enemy.AttackState);
        }
      }
    }

    if (player.position.x > enemy.transform.position.x) {
      moveDir = 1;
    } else {
      moveDir = -1;
    }

    enemy.SetVelocity(enemy.moveSpeed * moveDir, rb.velocity.y);
  }

  private bool CanAttack() {
    if (Time.time >= enemy.lastTimeAttacked + enemy.attackCooldown) {
      return true;
    }

    return false;
  }
}