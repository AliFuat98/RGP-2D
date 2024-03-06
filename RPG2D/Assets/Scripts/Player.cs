using UnityEngine;

public class Player : MonoBehaviour {

  #region Components

  public Animator animator { get; private set; }

  #endregion Components

  #region States

  public PlayerStateMachine stateMachine { get; private set; }
  public PlayerIdleState idleState { get; private set; }
  public PlayerMoveState moveState { get; private set; }

  #endregion States

  private void Awake() {
    stateMachine = new PlayerStateMachine();
    idleState = new PlayerIdleState(stateMachine, this, "Idle");
    moveState = new PlayerMoveState(stateMachine, this, "Move");
  }

  private void Start() {
    animator = GetComponentInChildren<Animator>();
    stateMachine.Initialize(idleState);
  }

  private void Update() {
    stateMachine.currentState.Update();
  }
}