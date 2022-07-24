using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CrabBullet : MonoBehaviour
{

    [SerializeField] private float speed;
    private float damage;
    private GameObject user;
    [SerializeField] private float heal = 10;
    //��ų�� ����ϴ� User�� �������� �� �� �ִ� ������Ƽ
    public GameObject User { get { return user; } set { user = value; } }

    //������ ��, Power�� ��� �������� �� �� �ִ� ������Ƽ
    [SerializeField] private float skillMaxDistance = 50;
    public Transform target;
    private PlayerInput playerInput;
    Vector3 dir;
    Vector3 cdir;
    public float BulletDamage { get { return damage; } set { damage = value; } }
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        playerInput = player.GetComponent<PlayerInput>();


        target = player.transform;
        if (User == player)
        {
            Vector3 mousepos = new Vector3(Screen.width / 2, Screen.height / 2);
            mousepos.z = skillMaxDistance;
            cdir = Camera.main.ScreenToWorldPoint(mousepos);
            dir = cdir - transform.position;
            dir.Normalize();
            Quaternion prot = Quaternion.LookRotation(dir.normalized);
            transform.rotation = prot;
        }
        else
        {
            dir = target.position - user.transform.position;
            dir.Normalize();
            Quaternion rot = Quaternion.LookRotation(dir.normalized);
            transform.rotation = rot;
            print(user);
        }
    }
    void Update()
    {
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
                user.gameObject.GetComponent<EnemyHealth>().Heal(10);
                print("��Ҵ�" + damage);
            }
            //Enemy��� ������ ����
            else
            {
                other.gameObject.GetComponent<EnemyHealth>().Damage(damage);
                user.gameObject.GetComponent<PlayerHealth>().Heal(10);
            }
            //�Ѿ� ����
            Destroy(gameObject);
        }

    }


}
