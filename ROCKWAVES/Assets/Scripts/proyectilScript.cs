using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proyectilScript : MonoBehaviour {
    Rigidbody _rb;
    public float force;
    private void Awake()
    {
      _rb = GetComponent<Rigidbody>();
    }
    // Use this for initialization
    void Start () {
        _rb.GetComponent<Rigidbody>().velocity = transform.forward * 3;
    }
}
