using UnityEngine;

public class PlayerState {
  protected PlayerStateMachine stateMachine;
  protected Player player;
  protected Rigidbody2D rb;

  private string animBoolName;
  protected float xInput;

  public PlayerState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) {
    stateMachine = _stateMachine;
    player = _player;
    animBoolName = _animBoolName;
    rb = player.GetComponent<Rigidbody2D>();
  }

  public virtual void Enter() {
    player.animator.SetBool(animBoolName, true);
  }

  public virtual void Update() {
    xInput = Input.GetAxisRaw("Horizontal");
    player.animator.SetFloat("yVelocity", rb.velocity.y);
  }

  public virtual void Exit() {
    player.animator.SetBool(animBoolName, false);
  }
}