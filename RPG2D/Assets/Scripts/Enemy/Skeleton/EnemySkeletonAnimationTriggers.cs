using UnityEngine;

public class EnemySkeletonAnimationTriggers : MonoBehaviour {
  private Enemy enemy => GetComponentInParent<Enemy>();

  private void AnimationTrigger() {
    enemy.AnimationTrigger();
  }

  private void AttackTrigger() {
    Collider2D[] colliders = Physics2D.OverlapCircleAll(enemy.attackCheck.position, enemy.attackCheckRadius);

    foreach (Collider2D hit in colliders) {
      if (hit.GetComponent<Player>() != null) {
        hit.GetComponent<Player>().Damage(enemy.facingDirection);
      }
    }
  }

  private void OpenCounterWindow() => enemy.OpenCounterAttackWindow();

  private void CloseCounterWindow() => enemy.CloseCounterAttackWindow();
}