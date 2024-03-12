using UnityEngine;

public class EnemySkeletonAnimationTriggers : MonoBehaviour {
  private Enemy enemy => GetComponentInParent<Enemy>();

  public void AnimationTrigger() {
    enemy.AnimationTrigger();
  }

  public void AttackTrigger() {
    Collider2D[] colliders = Physics2D.OverlapCircleAll(enemy.attackCheck.position, enemy.attackCheckRadius);

    foreach (Collider2D hit in colliders) {
      if (hit.GetComponent<Player>() != null) {
        hit.GetComponent<Player>().Damage(enemy.facingDirection);
      }
    }
  }
}