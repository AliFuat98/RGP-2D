using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Enemy : Entitiy {

  [Header("Move Info")]
  public float moveSpeed;
  public float idleTime;

  public EnemyStateMachine stateMachine { get; private set; }

  protected override void Awake() {
    stateMachine = new EnemyStateMachine();
  }

  protected override void Start() {
    base.Start();
  }

  protected override void Update() {
    base.Update();

    stateMachine.currentState.Update();
  }
}