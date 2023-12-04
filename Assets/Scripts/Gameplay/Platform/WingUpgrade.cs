using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingUpgrade : MonoBehaviour
{
    [SerializeField] bool rotateLeft;
    [SerializeField] float rotateSpeed;

    [SerializeField] private Helicopter helicopter;
    private bool canRotate = false;
    private int rotationSide = 1;
    [SerializeField] private Vector3 direction;

    private void Update()
    {
        if (canRotate)
            Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(direction * (rotationSide * Time.deltaTime * rotateSpeed));
    }

    public void PlayHelicopter()
    {
        helicopter?.MoveAlongPath();
    }

    private void OnEnable()
    {
        canRotate = true;
        rotationSide = rotateLeft ? -1 : 1;
    }

    private void OnDisable()
    {
        canRotate = false;
    }
}
