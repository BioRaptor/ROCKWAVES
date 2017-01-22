using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    Boundary bounds;
    public Transform player;
    float damp = 2f;
    float velocidadePerseguidor = 4f;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 10;
    float tiempoEntreDisparos = 0.2f;
    float tiempo = 0f;
    int currentEnemyHP;
    int maxEnemyHP = 100;

    private void Awake()
    {
        currentEnemyHP = maxEnemyHP;
    }

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

            if (Vector3.Distance(player.position, transform.position) < 3)
            {
                if (Time.time > tiempo)
                {
                    Fire();
                    tiempo = Time.time + tiempoEntreDisparos;
                }
            }
        }

        /*GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, bounds.xMin, bounds.xMax),
            0,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, bounds.zMin, bounds.zMax)
        );*/

    }

    private void FixedUpdate()
    {
        if (currentEnemyHP <= 0)
        {
            Die();
        }
    }

    void Fire()
    {

        var bullet = (GameObject)Instantiate(
        bulletPrefab,
        bulletSpawn.position,
        bulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 20;
        // Destroy the bullet after 2 seconds
        Destroy(bullet, 1f);
    }

    public void TakeDamage(int amount)
    {
        currentEnemyHP = currentEnemyHP - amount;
    }

    void Die()
    {
        Destroy(this.gameObject, 0.1f);
        print(this.gameObject.name + " dead");
    }
}

