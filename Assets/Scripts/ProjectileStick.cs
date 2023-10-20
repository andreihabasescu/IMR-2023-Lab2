using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileStick : MonoBehaviour
{

    private Rigidbody rb;

    private bool targetHit;

    public bool stickAction = false;

    public float destroyTime = 5f;

    public Vector3 originalPosition;

    public Vector3 targetPosition;

    public Vector3 recentVelocity = Vector3.zero;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalPosition = rb.position;
    }

    public float calcDistance(Vector3 init,Vector3 final) {
        return Vector3.Distance(final, init);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (targetHit)
        {
            return;
        }
        else {
            if (stickAction) {
                rb.isKinematic = true;
            }
            Destroy(gameObject, destroyTime);
        }

        if (collision.gameObject.CompareTag("dummy")) {
            GameObject dummy = collision.gameObject;
            DummyAction dummyAction = dummy.GetComponent<DummyAction>();
            DummyHP dummyHP = dummy.GetComponent<DummyHP>();
            WeaponProperties weaponProperties = gameObject.GetComponent<WeaponProperties>();

            dummyAction.toggleHit();
            int distance = (int)math.floor(calcDistance(originalPosition, rb.position));
            dummyHP.hit(weaponProperties.damage, distance, (int)recentVelocity.magnitude) ;
        }

        transform.SetParent(collision.transform);
    }

    private void FixedUpdate()
    {
        if (rb.velocity != Vector3.zero)
        {
            recentVelocity = rb.velocity;
        }  
    }
}
