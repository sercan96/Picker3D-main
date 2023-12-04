using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    [Header("Propeller")]
    [SerializeField] GameObject propeller;
    [SerializeField] float rotateSpeed;

    [Header("Helicopter")]
    [SerializeField] Transform collectableHolder;
    [SerializeField] float duration;
    [SerializeField] float ballDropDuration;
    [SerializeField] Transform[] path;

    [Header("Collectables")]
    [SerializeField] GameObject[] collectables;

    private bool canRotate;
    private Sequence sequence;

    public void MoveAlongPath()
    {
        sequence = DOTween.Sequence();
        
        StartCoroutine(DropBall());

        foreach (var p in path)
        {
            sequence.Append(transform.DOLocalMove(p.transform.localPosition, duration));
        }
        
    }

    private IEnumerator DropBall()
    {
        foreach (var obj in collectables)
        {
            yield return new WaitForSeconds(ballDropDuration);
            obj.transform.SetParent(collectableHolder);
            obj.SetActive(true);
        }
    }

    private void Update()
    {
        if (canRotate)
            PropellerRotate();
    }

    private void PropellerRotate()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
    }

    private void OnEnable()
    {
        canRotate = true;
    }

    private void OnDisable()
    {
        canRotate = false;
    }
}
