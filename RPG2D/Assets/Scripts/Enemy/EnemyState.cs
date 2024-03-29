using UnityEngine;

public class EnemyState {
  protected EnemyStateMachine stateMachine;
  protected Enemy enemyBase;
  protected Rigidbody2D rb;

  private string animBoolName;

  protected float stateTimer;
  protected bool triggerCalled;

  public EnemyState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName) {
    this.enemyBase = enemyBase;
    this.stateMachine = stateMachine;
    this.animBoolName = animBoolName;
    rb = this.enemyBase.GetComponent<Rigidbody2D>();
  }

  public virtual void Enter() {
    enemyBase.animator.SetBool(animBoolName, true);
    triggerCalled = false;
  }

  public virtual void Update() {
    stateTimer -= Time.deltaTime;
  }

  public virtual void Exit() {
    triggerCalled = true;
    enemyBase.animator.SetBool(animBoolName, false);
  }

  public virtual void AnimationFinishTrigger() {
    triggerCalled = true;
  }

}