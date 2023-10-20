using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MeleeWield : MonoBehaviour
{
    private Vector3 releasePosition = Vector3.zero;
    public void releaseGrab() {
        releasePosition = gameObject.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("dummy"))
        {
            int distance = 0;
            if (releasePosition != Vector3.zero)
            {
                distance = (int) math.floor(Vector3.Distance(releasePosition, gameObject.transform.position));
                releasePosition = Vector3.zero;
            }

            GameObject dummy = collision.gameObject;
            DummyAction dummyAction = dummy.GetComponent<DummyAction>();
            DummyHP dummyHP = dummy.GetComponent<DummyHP>();
            WeaponProperties weaponProperties = gameObject.GetComponent<WeaponProperties>();

            dummyAction.toggleHit();
            dummyHP.hit(weaponProperties.damage,distance, 1);

        }
    }
}
