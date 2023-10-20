using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyHP : MonoBehaviour
{
    int hp = 100;
    private Animator animator;
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void hit(int damage,int distance, int velocity) {
        int dmg = damage + (velocity / 3) - distance / 3;

        DamageNumbers.Instance.CreateText(transform.position+Vector3.up, dmg.ToString(), Color.red);
        DamageNumbers.Instance.totalDamage += dmg;

        if (hp - dmg < 0)
        {
            hp = 0;
            animator.SetBool("isDead", true);
        }
        else {
            hp -= dmg;
        }

        
        print("HP ="+hp+", DMG ="+dmg+ ", VEL="+velocity);
    }

    public void revive()
    {
        hp = 100;
        animator.SetBool("isDead",false);
    }

    private void Update()
    {
        if (hp == 0) {
            //revive();
        }
    }
}
