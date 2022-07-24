using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornBullet : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    public GameObject BulletUser { get; set; }
    public float BulletDamage { get; set; }
    private void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        //�ε��� ���� ��ų ����ڰ� �ƴϰ� ����ü(Entity)���
        //Debug.Log($"other.gameObject = {other.gameObject}")
        //Debug.Log($"other.gameObject = {other.gameObject}");
        if (other && BulletUser)
        {
            if (other.gameObject.tag != BulletUser.tag )
            {
                if (other.gameObject != null)
                {
                    //Player��� ������ ����
                    if (other.gameObject.CompareTag("Player"))
                    {
                        other.gameObject.GetComponent<PlayerHealth>().Damage(BulletDamage);
                    }
                    //Enemy��� ������ ����
                    else if(other.gameObject.CompareTag("Enemy"))
                    {
                        other.gameObject.GetComponent<EnemyHealth>().Damage(BulletDamage);
                    }
                    Destroy(gameObject, 3f);
                }
            }
        }

    }
}
