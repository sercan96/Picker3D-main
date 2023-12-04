using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private GameObject explosionEfectPrefab;
    [SerializeField] private Rigidbody myRb;
    [SerializeField] private float force;
    public bool isInside=false;
    

    public void SetStatus(bool _isInside)
    {
        isInside = _isInside;
    }
    
    public void Explode(Material platformMat)
    {
        GameObject spawnedEffectObj = Instantiate(explosionEfectPrefab, transform.position, Quaternion.identity);
        ParticleSystemRenderer psr = spawnedEffectObj.GetComponent<ParticleSystemRenderer>();
        psr.material = platformMat;
        spawnedEffectObj.GetComponent<ParticleSystem>().Play();
        AudioManager.Instance.PlayPopSound();
        Destroy(gameObject);
        Destroy(spawnedEffectObj,3f);
    }
    private void CheckIsInside()
    {
        if (isInside)
        {
            ThrowForward();
        }
    }
    private void ThrowForward()
    {
        Vector3 forceDirection = (transform.position + new Vector3(transform.position.x,
            transform.position.y +15f,transform.position.z+5f)).normalized;
        myRb.velocity = Vector3.zero;
        myRb.angularVelocity = Vector3.zero;
        myRb.AddForce(forceDirection * force);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Road"))
        {
            myRb.constraints = RigidbodyConstraints.None;
        }
    }

    private void OnEnable()
    {
        EventManager.OnHittedBallCollector += CheckIsInside;
    }
    private void OnDisable()
    {
        EventManager.OnHittedBallCollector += CheckIsInside;
    }
}
