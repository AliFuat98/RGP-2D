using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Enemy : MonoBehaviour {

  #region Components

  public Animator animator { get; private set; }
  public Rigidbody2D rb { get; private set; }

  #endregion Components


  #region States

  public PlayerStateMachine stateMachine { get; private set; }

  #endregion States

  private void Awake() {
    stateMachine = new PlayerStateMachine();
  }
}