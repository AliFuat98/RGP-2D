using UnityEngine;

public class SkillManager : MonoBehaviour {
  public static SkillManager instance;

  public DashSkill dashSkill { get; private set; }

  private void Awake() {
    if (instance == null) {
      instance = this;
    } else {
      Destroy(gameObject);
    }
  }

  private void Start() {
    dashSkill = GetComponent<DashSkill>();
  }
}