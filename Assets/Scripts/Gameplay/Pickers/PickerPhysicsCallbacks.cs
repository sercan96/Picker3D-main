using UnityEngine;
using System;

public class PickerPhysicsCallbacks : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BallCollecter"))
        {
            other.gameObject.tag = "Untagged";
            BallCollecterPlatform ballCollecterPlatform = other.gameObject.GetComponentInParent<BallCollecterPlatform>();
            ballCollecterPlatform.CheckCollecterStatus();
            other.gameObject.SetActive(false);
            EventManager.InvokeOnHittedBallCollector();
        }
        if (other.gameObject.CompareTag("LevelEnd"))
        {
            other.gameObject.tag = "Untagged";
            EventManager.InvokeOnHittedLevelEnd();
        }
        if (other.gameObject.CompareTag("Ball"))
        {
            AudioManager.Instance.PlayPopSound();
            other.gameObject.GetComponent<Ball>().SetStatus(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            other.gameObject.GetComponent<Ball>().SetStatus(false);
        }
    }
}
