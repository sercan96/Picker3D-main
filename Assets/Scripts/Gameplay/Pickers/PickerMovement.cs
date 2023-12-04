using System;
using UnityEngine;
using DG.Tweening;
using Gameplay;
using Lean.Touch;

public class PickerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float horiztontalSpeed = 10f;
    [SerializeField] private float verticalSpeed = 10f;
    public bool canMove = false;
    public bool canRun = false;
    private float horizontal;
    private Vector3 mousePosition;

    private LeanFinger myFinger;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    private void MovePlayer()
    {
        var velocity = _rigidbody.velocity;
        velocity = new Vector3(InputManager.Instance.moveVector.x * horiztontalSpeed, velocity.y, velocity.z);
        _rigidbody.velocity = velocity;
    }

    private void VerticalMove()
    {
        var velocity = _rigidbody.velocity;
        velocity = new Vector3( velocity.x, velocity.y, verticalSpeed);
        _rigidbody.velocity = velocity;
    }

    private void ClampRigid()
    {
        var position1 = _rigidbody.position;
        var position = new Vector3(Mathf.Clamp(position1.x, -1.3f, 1.3f),
            position1.y, position1.z);
        _rigidbody.position = position;
    }
    private void Update()
    {
        if (canRun)
        {
            ClampRigid();
        }
    }
    private void FixedUpdate()
    {
        if (canRun)
        {
            VerticalMove();
        }
        MovePlayer();
    }
    private void EnableMovement()
    {
        canMove = true;
        canRun = true;
    }
    private void DisableMovement()
    {
        canMove = false;
        canRun = false;
        _rigidbody.velocity = Vector3.zero;
    }
    private void DisableVerticalMovement()
    {
        canRun = false;
        _rigidbody.velocity = Vector3.zero;
    }
    private void EnableVerticalMovement()
    {
        canRun = true;
    }
    private void MoveToNextLevelStartPos()
    {
        DisableMovement();
        float curLevellength = LevelManager.Instance.GetCurrentLevelLength(LevelManager.Instance.GetCurrentLevel());
        Vector3 targetPos = new Vector3(0, transform.position.y, curLevellength-10f);
        transform.DOMove(targetPos, 2f).OnComplete(() =>
        {
            EventManager.InvokeOnMovedToNextStart();
        });
    }
    private void OnEnable()
    {
        EventManager.OnGameStarted += EnableMovement;
        EventManager.OnGameFinished += DisableMovement;
        EventManager.OnHittedBallCollector += DisableVerticalMovement;
        EventManager.OnHittedLevelEnd += MoveToNextLevelStartPos;
        EventManager.OnCollectorSuccess += EnableVerticalMovement;
    }
    private void OnDisable()
    {
        EventManager.OnGameStarted -= EnableMovement;
        EventManager.OnGameFinished -= DisableMovement;
        EventManager.OnHittedBallCollector -= DisableVerticalMovement;
        EventManager.OnHittedLevelEnd -= MoveToNextLevelStartPos;
        EventManager.OnCollectorSuccess -= EnableVerticalMovement;
    }
}
