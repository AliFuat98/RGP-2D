using UnityEngine;

public class EnemySkeletonAnimationTriggers : MonoBehaviour {
  private Enemy enemy => GetComponentInParent<Enemy>();

  public void AnimationTrigger() {
    enemy.AnimationTrigger();
  }
}