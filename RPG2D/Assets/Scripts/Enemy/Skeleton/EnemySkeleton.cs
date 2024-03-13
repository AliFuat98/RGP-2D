public class EnemySkeleton : Enemy {
  public SkeletonIdleState IdleState { get; private set; }
  public SkeletonMoveState MoveState { get; private set; }
  public SkeletonBattleState BattleState { get; private set; }
  public SkeletonAttackState AttackState { get; private set; }
  public SkeletonStunnedState StunnedState { get; private set; }

  protected override void Awake() {
    base.Awake();

    IdleState = new SkeletonIdleState(this, this, stateMachine, "Idle");
    MoveState = new SkeletonMoveState(this, this, stateMachine, "Move");
    BattleState = new SkeletonBattleState(this, this, stateMachine, "Move");
    AttackState = new SkeletonAttackState(this, this, stateMachine, "Attack");
    StunnedState = new SkeletonStunnedState(this, this, stateMachine, "Stunned");
  }

  protected override void Start() {
    base.Start();
    stateMachine.Initialize(IdleState);
  }

  protected override void Update() {
    base.Update();
  }

  protected override bool CanBeStunned() {
    if (base.CanBeStunned()) {
      stateMachine.ChangeState(StunnedState);
      return true;
    }

    return false;
  }
}