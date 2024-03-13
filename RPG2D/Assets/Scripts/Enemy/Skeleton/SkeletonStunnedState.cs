using UnityEngine;

public class SkeletonStunnedState : EnemyState {
  private EnemySkeleton enemy;

  public SkeletonStunnedState(Enemy enemyBase, EnemySkeleton enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName) {
    this.enemy = enemy;
  }

  public override void Enter() {
    base.Enter();

    enemy.entityFX.InvokeRepeating(nameof(EntityFX.RedColorBlink), 0f, 0.1f);

    stateTimer = enemy.stunDuration;
    enemy.rb.velocity = new Vector2(-enemy.facingDirection * enemy.stunDirection.x, enemy.stunDirection.y);
  }

  public override void Exit() {
    base.Exit();

    enemy.entityFX.Invoke("CancelColorBlink", 0f);
  }

  public override void Update() {
    base.Update();

    if (stateTimer < 0) {
      stateMachine.ChangeState(enemy.IdleState);
    }
  }
}