using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingController : MonoBehaviour
{
    [SerializeField] private GameObject rightWing;
    [SerializeField] private GameObject leftWing;
    private void OnEnable()
    {
        EventManager.OnHittedBallCollector += DisableWings;
    }
    private void OnDisable()
    {
        EventManager.OnHittedBallCollector -= DisableWings;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WingUpgrade"))
        {
            other.GetComponent<WingUpgrade>().PlayHelicopter();
            other.gameObject.SetActive(false);
            EnableWings();
        }
    }

    private void EnableWings()
    {
        leftWing.SetActive(true);
        rightWing.SetActive(true);
    }

    private void DisableWings()
    {
        leftWing.SetActive(false);
        rightWing.SetActive(false);
    }
}
