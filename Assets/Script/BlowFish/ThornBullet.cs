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
        //부딪힌 것이 스킬 사용자가 아니고 생명체(Entity)라면
        //Debug.Log($"other.gameObject = {other.gameObject}")
        //Debug.Log($"other.gameObject = {other.gameObject}");
        if (other && BulletUser)
        {
            if (other.gameObject.tag != BulletUser.tag )
            {
                if (other.gameObject != null)
                {
                    //Player라면 데미지 깎음
                    if (other.gameObject.CompareTag("Player"))
                    {
                        other.gameObject.GetComponent<PlayerHealth>().Damage(BulletDamage);
                    }
                    //Enemy라면 데미지 깎음
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
