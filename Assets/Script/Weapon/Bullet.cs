using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�ʿ� �Ӽ�: ���콺 ������ ��ġ, �Ѿ� �ӵ�
public class Bullet : MonoBehaviour
{
    [Header("�Ѿ� �Ӽ�")]
    [SerializeField] private float speed = 10;
    private GameObject player;
    private PlayerShooter playerShooter;
    private Vector3 dir;
    //�Ѿ��� ���콺 ������ �������� �̵���Ų��.
    private void Awake()
    {
        //�ʿ�Ӽ�: �Է°�
        player = GameObject.Find("Player");
        playerShooter = player.GetComponent<PlayerShooter>();
    }
    private void Start()
    {
        if (playerShooter.IsEnemyHit)
        {
            dir = playerShooter.EnemyPosition - this.transform.position;
            playerShooter.IsEnemyHit = false;
        }
        else
        {
            dir = playerShooter.BulletMaxDirection;
        }
        transform.rotation = Quaternion.LookRotation(dir).normalized;
    }
    void Update()
    {
        //�Ѿ��� �̵���Ų��.
        this.transform.position += dir.normalized * speed* Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        string colliderTag = other.gameObject.tag;
        if (colliderTag != "Player" && colliderTag != "DeadZone" && colliderTag != "Platform")
        {
            if (colliderTag == "Enemy")
            {
                other.gameObject.GetComponent<EnemyHealth>().Damage(10);
                Destroy(gameObject);
            }
            else
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }
    
}
