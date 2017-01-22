using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float speed;
    public Boundary bounds;
    public float tilt;
    public float fireRate = 0.5f;
    public float fireRate2 = 0.3f;
    public float nextFire = 0.01f;
    public float nextFire2 = 0.01f;
    public GameObject EmissionDisparo1;
    public GameObject EmissionDisparo2;
    public AudioSource musicaAudioSource;
    public int currentHP;
    public int maxHP = 200;
    public Slider sliderHP;

    private void Awake()
    {
        currentHP = maxHP;
        print(currentHP);
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 pos = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().velocity = pos * speed;

        GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, bounds.xMin, bounds.xMax),
            0,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, bounds.zMin, bounds.zMax)
        );

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0, 0, GetComponent<Rigidbody>().velocity.x * -tilt);

        if (currentHP <= 0)
        {
            currentHP = 0;
            Die();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > nextFire && currentHP > 0)
        {
            nextFire = Time.time + fireRate;
            StartCoroutine(Disparo(EmissionDisparo1, 1f));
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && Time.time > nextFire2 && currentHP > 0)
        {
            nextFire2 = Time.time + fireRate2;
            StartCoroutine(Disparo(EmissionDisparo2, 0.7f));
        }
    }

    public IEnumerator Disparo(GameObject emission, float volume)
    {
        emission.SetActive(true);
        musicaAudioSource.volume = volume;
        yield return new WaitForSeconds(1f);
        musicaAudioSource.volume = 0.3f;
        emission.SetActive(false);
    }

    public void TakeDamage(int amount)
    {
        currentHP = currentHP - amount;
        sliderHP.value = currentHP;
        print("Current HP: " + currentHP);
    }

    public void Die()
    {
        print("HAS MUERRRRRTO");
        Time.timeScale = 0;
        musicaAudioSource.volume = 0.05f;
    }
}

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

