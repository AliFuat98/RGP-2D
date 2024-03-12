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
}