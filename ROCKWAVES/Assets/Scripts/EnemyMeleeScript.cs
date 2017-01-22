using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeScript : MonoBehaviour
{
    public Transform player;
    float damp = 2f;
    float velocidadePerseguidor = 4f;
    public SphereCollider atakCollider;

    void Update()
    {
        if (player != null)
        {
            if (Vector3.Distance(player.position, transform.position) < 20 && Vector3.Distance(player.position, transform.position) > 3)
            {
                var rotate = Quaternion.LookRotation(player.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotate, damp * Time.deltaTime);
                transform.Translate(0, 0, velocidadePerseguidor * Time.deltaTime);
            }

            if (Vector3.Distance(player.position, transform.position) < 2)
            {
                    Fire();
            }
        }
    }

    void Fire()
    {
        atakCollider.gameObject.SetActive(true);
    }
}
