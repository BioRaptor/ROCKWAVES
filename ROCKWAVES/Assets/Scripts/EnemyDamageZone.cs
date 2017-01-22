using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageZone : MonoBehaviour
{

    public int damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().TakeDamage(damage);
            if (this.transform.name == "FireRange")
            {
                Destroy(this.gameObject.transform.parent.gameObject, 0.01f);
            }
            else if (this.transform.name == "bullet(Clone)")
            {
                Destroy(this.gameObject, 0.01f);
            }
        }
    }
}

