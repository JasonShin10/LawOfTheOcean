using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    private float damage;
    //��ų�� ����ϴ� User�� �������� �� �� �ִ� ������Ƽ
    public GameObject User { get; set; }
    //������ ��, Power�� ��� �������� �� �� �ִ� ������Ƽ
    public float BulletDamage { get { return damage; } set { damage = value; } }
    void Update()
    {
        Vector3 dir = Vector3.forward;
        transform.position += dir * speed * Time.deltaTime;        
    }
    private void OnTriggerEnter(Collider other)
    {
        //�ε��� ���� ��ų ����ڰ� �ƴϰ� ����ü(Entity)���
        if (other.gameObject != User && other.gameObject.layer == 7)
        {
            //Player��� ������ ����
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.GetComponent<PlayerHealth>().Damage(damage);
            }
            //Enemy��� ������ ����
            else
            {
                other.gameObject.GetComponent<EnemyHealth>().Damage(damage);
            }
            //�Ѿ� ����
            Destroy(gameObject);
        }

    }
}
