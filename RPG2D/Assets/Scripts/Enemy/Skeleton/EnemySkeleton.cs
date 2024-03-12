public class EnemySkeleton : Enemy {

  #region States

  public SkeletonIdleState IdleState { get; private set; }
  public SkeletonMoveState MoveState { get; private set; }

  #endregion States

  protected override void Awake() {
    base.Awake();

    IdleState = new SkeletonIdleState(this, this, stateMachine, "Idle");
    MoveState = new SkeletonMoveState(this, this, stateMachine, "Move");
  }

  protected override void Start() {
    base.Start();
    stateMachine.Initialize(IdleState);
  }

  protected override void Update() {
    base.Update();
  }
}