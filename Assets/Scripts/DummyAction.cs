using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class DummyAction : MonoBehaviour
{
    [SerializeField] Animator animator;
    private bool isHit;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void hitDummy() {
        animator.SetBool("isHit", true);
        
        print("HIT");
    }

    public void toggleHit() {
        isHit = !isHit;
    }

    public void dummyUnHit()
    {
        animator.SetBool("isHit", false);
        print("animation reset");
    }

private void Update()
    {
        if (isHit) {
            hitDummy();
            isHit = false;
        }
    }
}
