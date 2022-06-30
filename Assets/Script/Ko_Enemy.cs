using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ko_Enemy : MonoBehaviour
{
    public float speed = 4;
    Vector3 dir;

    private void Start()
    {
        dir = new Vector3(0, 0, 0);
    }
    private void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("�ν�");
            dir = other.transform.position - transform.position;
            dir.Normalize();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("�ν�");
            dir = other.transform.position - transform.position;
            dir.Normalize();
        }
    }

}
