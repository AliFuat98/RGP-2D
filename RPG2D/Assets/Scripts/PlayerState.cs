using UnityEngine;

public class PlayerState {
  protected PlayerStateMachine stateMachine;
  protected Player player;

  private string animBoolName;

  protected PlayerState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) {
    stateMachine = _stateMachine;
    player = _player;
    animBoolName = _animBoolName;
  }

  public virtual void Enter() {
    Debug.Log($"enter {animBoolName}");
  }

  public virtual void Update() {
    Debug.Log($"exit {animBoolName}");
  }

  public virtual void Exit() {
    Debug.Log($"exit {animBoolName}");
  }
}