using UnityEngine;

public class PlayerCounterAttackState : PlayerState {

  public PlayerCounterAttackState(PlayerStateMachine stateMachine, Player player, string animBoolName) : base(stateMachine, player, animBoolName) {
  }

  public override void Enter() {
    base.Enter();
    stateTimer = player.counterAttackDuration;
    player.animator.SetBool("SuccessfulCounterAttack", false);
  }

  public override void Exit() {
    base.Exit();
  }

  public override void Update() {
    base.Update();

    player.SetZeroVelocity();

    Collider2D[] colliders = Physics2D.OverlapCircleAll(player.attackCheck.position, player.attackCheckRadius);

    foreach (Collider2D hit in colliders) {
      if (hit.GetComponent<Enemy>() != null) {
        if (hit.GetComponent<Enemy>().CanBeStunned()) {
          stateTimer = 10f;
          player.animator.SetBool("SuccessfulCounterAttack", true);
        }
      }
    }

    if (stateTimer < 0 || triggerCalled) {
      stateMachine.ChangeState(player.idleState);
    }
  }
}