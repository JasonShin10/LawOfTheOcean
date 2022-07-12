using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornBullet : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    public GameObject BulletUser { get; set; }
    public float BulletDamage { get; set; }
    public Vector3 BulletDir { get; set; }
    private void Update()
    {
        transform.position += BulletDir * speed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        //�ε��� ���� ��ų ����ڰ� �ƴϰ� ����ü(Entity)���
        if (other.gameObject != BulletUser && other.gameObject.layer == 7)
        {
            //Player��� ������ ����
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.GetComponent<PlayerHealth>().Damage(BulletDamage);
            }
            //Enemy��� ������ ����
            else
            {
                other.gameObject.GetComponent<EnemyHealth>().Damage(BulletDamage);
            }
            //�Ѿ� ����
            Destroy(gameObject);
        }

    }
}
