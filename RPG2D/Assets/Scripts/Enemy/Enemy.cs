using UnityEngine;

public class Enemy : Entitiy {
  [SerializeField] protected LayerMask PlayerLayerMask;

  [Header("Stunned Info")]
  public float stunDuration;

  public Vector2 stunDirection;
  public bool canBeStunned;
  [SerializeField] protected GameObject counterImage;

  [Header("Move Info")]
  public float moveSpeed;

  public float idleTime;
  public float battleTime;
  public float battleRange;
  public float backBattleRange;

  [Header("Attack Info")]
  public float attackDistance;

  public float attackCooldown;
  [HideInInspector] public float lastTimeAttacked;

  public EnemyStateMachine stateMachine { get; private set; }

  protected override void Awake() {
    stateMachine = new EnemyStateMachine();
  }

  protected override void Start() {
    base.Start();
  }

  protected override void Update() {
    base.Update();

    stateMachine.currentState.Update();
  }

  public virtual void OpenCounterAttackWindow() {
    canBeStunned = true;
    counterImage.SetActive(true);
  }

  public virtual void CloseCounterAttackWindow() {
    canBeStunned = false;
    counterImage.SetActive(false);
  }

  public virtual bool CanBeStunned() {
    if (canBeStunned) {
      CloseCounterAttackWindow();
      return true;
    }

    return false;
  }

  public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();

  public virtual RaycastHit2D IsPlayerDetected() => Physics2D.Raycast(transform.position, Vector2.right * facingDirection, 50, PlayerLayerMask);

  protected override void OnDrawGizmos() {
    base.OnDrawGizmos();

    Gizmos.color = Color.yellow;
    Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + attackDistance * facingDirection, transform.position.y));
  }
}