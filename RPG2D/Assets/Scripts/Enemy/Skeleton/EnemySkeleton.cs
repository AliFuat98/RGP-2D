public class EnemySkeleton : Enemy {

  #region States

  public SkeletonIdleState IdleState { get; private set; }
  public SkeletonMoveState MoveState { get; private set; }
  public SkeletonBattleState BattleState { get; private set; }
  public SkeletonAttackState AttackState { get; private set; }

  #endregion States

  protected override void Awake() {
    base.Awake();

    IdleState = new SkeletonIdleState(this, this, stateMachine, "Idle");
    MoveState = new SkeletonMoveState(this, this, stateMachine, "Move");
    BattleState = new SkeletonBattleState(this, this, stateMachine, "Move");
    AttackState = new SkeletonAttackState(this, this, stateMachine, "Attack");
  }

  protected override void Start() {
    base.Start();
    stateMachine.Initialize(IdleState);
  }

  protected override void Update() {
    base.Update();
  }
}