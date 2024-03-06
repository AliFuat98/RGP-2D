using UnityEngine;

public class PlayerState {
  protected PlayerStateMachine stateMachine;
  protected Player player;

  private string animBoolName;
  protected float xInput;

  protected PlayerState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) {
    stateMachine = _stateMachine;
    player = _player;
    animBoolName = _animBoolName;
  }

  public virtual void Enter() {
    player.animator.SetBool(animBoolName, true);
  }

  public virtual void Update() {
    xInput = Input.GetAxisRaw("Horizontal");
  }

  public virtual void Exit() {
    player.animator.SetBool(animBoolName, false);
  }
}