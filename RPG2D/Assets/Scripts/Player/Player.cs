using System.Collections;
using UnityEngine;

public class Player : Entitiy {

  [Header("Attack Info")]
  public Vector2[] attackMovement;

  public float comboWindow = 2f;
  public bool isBussy { get; private set; }
  public float counterAttackDuration;

  [Header("Move Info")]
  public float moveSpeed = 6f;

  public float jumpForce = 12f;

  [Header("Dash Info")]
  public float dashSpeed = 12f;

  public float dashDuration = 1.5f;
  public float dashDirection { get; private set; }

  #region States

  public PlayerStateMachine stateMachine { get; private set; }
  public PlayerIdleState idleState { get; private set; }
  public PlayerMoveState moveState { get; private set; }
  public PlayerJumpState jumpState { get; private set; }
  public PlayerAirState airState { get; private set; }
  public PlayerDashState dashState { get; private set; }
  public PlayerWallSlideState wallSlideState { get; private set; }
  public PlayerWallJumpState wallJumpState { get; private set; }
  public PlayerPrimaryAttackState primaryAttackState { get; private set; }
  public PlayerCounterAttackState counterAttackState { get; private set; }

  #endregion States

  protected override void Awake() {
    base.Awake();

    stateMachine = new PlayerStateMachine();
    idleState = new PlayerIdleState(stateMachine, this, "Idle");
    moveState = new PlayerMoveState(stateMachine, this, "Move");
    jumpState = new PlayerJumpState(stateMachine, this, "Jump");
    airState = new PlayerAirState(stateMachine, this, "Jump");
    dashState = new PlayerDashState(stateMachine, this, "Dash");
    wallSlideState = new PlayerWallSlideState(stateMachine, this, "WallSlide");
    wallJumpState = new PlayerWallJumpState(stateMachine, this, "Jump");
    primaryAttackState = new PlayerPrimaryAttackState(stateMachine, this, "Attack");
    counterAttackState = new PlayerCounterAttackState(stateMachine, this, "CounterAttack");
  }

  protected override void Start() {
    base.Start();
    stateMachine.Initialize(idleState);
    //Application.targetFrameRate = 20;
  }

  protected override void Update() {
    base.Update();

    CheckForDashInput();
    stateMachine.currentState.Update();
  }

  public IEnumerator BusyFor(float seconds) {
    isBussy = true;

    yield return new WaitForSeconds(seconds);

    isBussy = false;
  }

  public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();

  private void CheckForDashInput() {
    // reset dash when you see a wall
    if (IsWallDetected()) {
      return;
    }

    if (Input.GetKeyDown(KeyCode.LeftShift) && SkillManager.instance.dashSkill.CanUseSkill()) {
      dashDirection = Input.GetAxisRaw("Horizontal");

      if (dashDirection == 0) {
        dashDirection = facingDirection;
      }

      stateMachine.ChangeState(dashState);
    }
  }
}