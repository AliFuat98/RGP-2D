using UnityEngine;

public class Enemy : Entitiy {
  [SerializeField] protected LayerMask PlayerLayerMask;

  [Header("Move Info")]
  public float moveSpeed;

  public float idleTime;

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

  public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();

  public virtual RaycastHit2D IsPlayerDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDirection, 50, PlayerLayerMask);

  protected override void OnDrawGizmos() {
    base.OnDrawGizmos();

    Gizmos.color = Color.yellow;
    Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + attackDistance * facingDirection, transform.position.y));
  }
}