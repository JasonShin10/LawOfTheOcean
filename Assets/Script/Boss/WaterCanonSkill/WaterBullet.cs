using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBullet : MonoBehaviour
{
    public GameObject BulletUser { get; set; }
    public float BulletDamage { get; set; }
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
