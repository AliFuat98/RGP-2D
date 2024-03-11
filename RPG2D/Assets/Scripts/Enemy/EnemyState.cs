using UnityEngine;

public class EnemyState {
  protected EnemyStateMachine stateMachine;
  protected Enemy enemy;

  private string animBoolName;

  protected float stateTimer;
  protected bool triggerCalled;

  public EnemyState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) {
    this.enemy = enemy;
    this.stateMachine = stateMachine;
    this.animBoolName = animBoolName;
  }

  public virtual void Enter() {
    enemy.animator.SetBool(animBoolName, true);
    triggerCalled = false;
  }

  public virtual void Update() {
    stateTimer -= Time.deltaTime;
  }

  public virtual void Exit() {
    triggerCalled = true;
    enemy.animator.SetBool(animBoolName, false);
  }
}