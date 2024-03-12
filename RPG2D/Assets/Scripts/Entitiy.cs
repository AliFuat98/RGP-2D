using System.Collections;
using UnityEngine;

public class Entitiy : MonoBehaviour {

  #region Components

  public Animator animator { get; private set; }
  public Rigidbody2D rb { get; private set; }
  public EntityFX entityFX { get; private set; }

  #endregion Components

  [Header("Knockback Info")]
  [SerializeField] protected Vector2 knockbackDirection;

  [SerializeField] protected float knockbackDuration;
  [SerializeField] protected bool isKnocked;

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
    if (isKnocked) {
      return;
    }

    rb.velocity = new Vector2(xVelocity, yVelocity);
    FlipController(xVelocity);
  }

  public void SetZeroVelocity() {
    if (isKnocked) {
      return;
    }

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

  public virtual void Damage(int knockDirection) {
    entityFX.StartCoroutine(nameof(EntityFX.FlashFX));
    StartCoroutine(nameof(HitKnockback),knockDirection);
  }

  protected virtual IEnumerator HitKnockback(int knockDirection) {
    isKnocked = true;
    rb.velocity = new Vector2(knockbackDirection.x * knockDirection, knockbackDirection.y);
    yield return new WaitForSeconds(knockbackDuration);
    isKnocked = false;
  }

  protected virtual void OnDrawGizmos() {
    Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
    Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
    Gizmos.color = Color.blue;
    Gizmos.DrawWireSphere(attackCheck.position, attackCheckRadius);
  }
}