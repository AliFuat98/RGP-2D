using UnityEngine;

public class Entitiy : MonoBehaviour {

  #region Components

  public Animator animator { get; private set; }
  public Rigidbody2D rb { get; private set; }
  public EntityFX entityFX { get; private set; }

  #endregion Components

  [Header("Collision Info")]
  public Transform attackCheck;

  public float attackCheckRadius;

  [SerializeField] protected Transform groundCheck;
  [SerializeField] protected float groundCheckDistance;
  [SerializeField] protected LayerMask groundLayer;
  [SerializeField] protected Transform wallCheck;
  [SerializeField] protected float wallCheckDistance;
  [SerializeField] protected LayerMask wallLayer;

  public int facingDirection { get; private set; } = 1;
  protected bool facingRight = true;

  protected virtual void Awake() {
  }

  protected virtual void Start() {
    animator = GetComponentInChildren<Animator>();
    entityFX = GetComponent<EntityFX>();
    rb = GetComponent<Rigidbody2D>();
  }

  protected virtual void Update() {
  }

  public void SetVelocity(float xVelocity, float yVelocity) {
    rb.velocity = new Vector2(xVelocity, yVelocity);
    FlipController(xVelocity);
  }

  public void SetZeroVelocity() {
    rb.velocity = new Vector2(0f, 0f);
  }

  public virtual void FlipController(float xVelocity) {
    if (xVelocity > 0 && !facingRight) {
      Flip();
    } else if (xVelocity < 0 && facingRight) {
      Flip();
    }
  }

  public virtual void Flip() {
    facingDirection *= -1;
    facingRight = !facingRight;
    transform.Rotate(0, 180, 0);
  }

  public virtual bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayer);

  public virtual bool IsWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDirection, wallCheckDistance, groundLayer);

  public virtual void Damage() {
    entityFX.StartCoroutine(nameof(EntityFX.FlashFX));
    Debug.Log($"{gameObject.name} was damaged");
  }

  protected virtual void OnDrawGizmos() {
    Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
    Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
    Gizmos.color = Color.blue;
    Gizmos.DrawWireSphere(attackCheck.position, attackCheckRadius);
  }
}