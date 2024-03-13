using System.Collections;
using UnityEngine;

public class EntityFX : MonoBehaviour {
  private SpriteRenderer spriteRenderer;
  private Material originalMaterial;

  [SerializeField] private Material hitMaterial;
  [SerializeField] private float flashDuration;

  private void Start() {
    spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    originalMaterial = spriteRenderer.material;
  }

  public IEnumerator FlashFX() {
    spriteRenderer.material = hitMaterial;
    yield return new WaitForSeconds(flashDuration);
    spriteRenderer.material = originalMaterial;
  }

  public void RedColorBlink() {
    if (spriteRenderer.color != Color.white) {
      spriteRenderer.color = Color.white;
    } else {
      spriteRenderer.color = Color.red;
    }
  }

  private void CancelColorBlink() {
    CancelInvoke();
    spriteRenderer.color = Color.white;
  }
}