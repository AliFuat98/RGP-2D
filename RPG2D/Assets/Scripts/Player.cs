using UnityEngine;

public class Player : MonoBehaviour {
  public PlayerStateMachine stateMachine { get; private set; }
  public PlayerIdleState idleState { get; private set; }
  public PlayerIdleState moveState { get; private set; }

  private void Awake() {
    stateMachine = new PlayerStateMachine();
    idleState = new PlayerIdleState(stateMachine, this, "Idle");
    moveState = new PlayerIdleState(stateMachine, this, "Move");
  }

  private void Start() {
    stateMachine.Initialize(idleState);
  }

  private void Update() {
    stateMachine.currentState.Update();
  }
}