using UnityEngine;

public class PlayerPrimaryAttackState : PlayerState {
  private int comboCounter;
  private float lastTimeAttacked;

  public PlayerPrimaryAttackState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName) {
  }

  public override void Enter() {
    base.Enter();

    if (comboCounter > 2 || Time.time >= lastTimeAttacked + player.comboWindow) {
      comboCounter = 0;
    }

    player.animator.SetInteger("ComboCounter", comboCounter);

    float attackDirection = player.facingDirection;
    if (xInput != 0) {
      attackDirection = xInput;
    }

    player.SetVelocity(player.attackMovement[comboCounter].x * attackDirection, player.attackMovement[comboCounter].y);

    stateTimer = 0.1f;
  }

  public override void Exit() {
    base.Exit();

    player.StartCoroutine(nameof(Player.BusyFor), 0.1f);

    comboCounter++;
    lastTimeAttacked = Time.time;
  }

  public override void Update() {
    base.Update();

    // wait 0.1 second for to stop
    if (stateTimer < 0) {
      rb.velocity = Vector2.zero;
    }

    if (triggerCalled) {
      stateMachine.ChangeState(player.idleState);
    }
  }
}