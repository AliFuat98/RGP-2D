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

    player = PlayerManager.instance.player.transform;
  }

  public override void Exit() {
    base.Exit();
  }

  public override void Update() {
    base.Update();

    RaycastHit2D hitPlayer = enemy.IsPlayerDetected();
    if (hitPlayer) {
      stateTimer = enemy.battleTime;
      if (hitPlayer.distance < enemy.attackDistance) {
        if (CanAttack()) {
          stateMachine.ChangeState(enemy.AttackState);
        }
      }
    } else {
      // no player Detected
      if (stateTimer < 0 || Vector2.Distance(player.position, enemy.transform.position) > enemy.battleRange) {
        stateMachine.ChangeState(enemy.IdleState);
      }
    }

    // move towards player
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