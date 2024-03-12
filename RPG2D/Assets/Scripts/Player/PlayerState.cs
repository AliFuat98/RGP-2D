using UnityEngine;

public class PlayerState {
  protected PlayerStateMachine stateMachine;
  protected Player player;
  protected Rigidbody2D rb;

  private string animBoolName;
  protected float xInput;
  protected float yInput;

  protected float stateTimer;

  protected bool triggerCalled;

  public PlayerState(PlayerStateMachine stateMachine, Player player, string animBoolName) {
    this.stateMachine = stateMachine;
    this.player = player;
    this.animBoolName = animBoolName;
    rb = this.player.GetComponent<Rigidbody2D>();
  }

  public virtual void Enter() {
    player.animator.SetBool(animBoolName, true);
    triggerCalled = false;
  }

  public virtual void Update() {
    stateTimer -= Time.deltaTime;

    xInput = Input.GetAxisRaw("Horizontal");
    yInput = Input.GetAxisRaw("Vertical");
    player.animator.SetFloat("yVelocity", rb.velocity.y);
  }

  public virtual void Exit() {
    player.animator.SetBool(animBoolName, false);
  }

  public virtual void AnimationFinishTrigger() {
    triggerCalled = true;
  }
}