public class EnemyStateMachine {
  public EnemyState currentState { get; private set; }

  public void Initialize(EnemyState enemyState) {
    currentState = enemyState;
    currentState.Enter();
  }

  public void ChangeState(EnemyState newState) {
    currentState.Exit();
    currentState = newState;
    currentState.Enter();
  }
}