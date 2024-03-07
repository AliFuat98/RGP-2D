using UnityEngine;

public class Player : MonoBehaviour {

  [Header("Move Info")]
  public float moveSpeed = 6f;

  public float jumpForce = 12f;

  [Header("Collision Info")]
  [SerializeField] private Transform groundCheck;

  [SerializeField] private float groundCheckDistance;
  [SerializeField] private LayerMask groundLayer;
  [SerializeField] private Transform wallCheck;
  [SerializeField] private float wallCheckDistance;
  [SerializeField] private LayerMask wallLayer;

  #region Components

  public Animator animator { get; private set; }
  public Rigidbody2D rb { get; private set; }

  #endregion Components

  #region States

  public PlayerStateMachine stateMachine { get; private set; }
  public PlayerIdleState idleState { get; private set; }
  public PlayerMoveState moveState { get; private set; }
  public PlayerJumpState jumpState { get; private set; }
  public PlayerAirState airState { get; private set; }

  #endregion States

  private void Awake() {
    stateMachine = new PlayerStateMachine();
    idleState = new PlayerIdleState(stateMachine, this, "Idle");
    moveState = new PlayerMoveState(stateMachine, this, "Move");
    jumpState = new PlayerJumpState(stateMachine, this, "Jump");
    airState = new PlayerAirState(stateMachine, this, "Jump");
  }

  private void Start() {
    animator = GetComponentInChildren<Animator>();
    rb = GetComponent<Rigidbody2D>();
    stateMachine.Initialize(idleState);
  }

  private void Update() {
    stateMachine.currentState.Update();
  }

  public void SetVelocity(float xVelocity, float yVelocity) {
    rb.velocity = new Vector2(xVelocity, yVelocity);
  }

  public bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayer);

  private void OnDrawGizmos() {
    Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
    Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
  }
}