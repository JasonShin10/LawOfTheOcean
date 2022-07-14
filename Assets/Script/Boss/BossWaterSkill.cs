using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemySkill/BossWaterSkill")]
public class BossWaterSkill : Skill
{
    [SerializeField] private GameObject waterCanonPrefab;
    [SerializeField] private int bulletCount = 10;
    public override void UseSkill()
    {
        float deltaAngle = 360 / bulletCount;
        for (int i = 1; i <= bulletCount; i++)
        {
            GameObject water = Instantiate(waterCanonPrefab);

            water.GetComponent<WaterBullet>().BulletUser = User;
            water.GetComponent<WaterBullet>().BulletDamage = Power;
            //2. �߻��� ������ ���ϰ� �ʹ�.
            water.transform.rotation = Quaternion.Euler(0, 0, deltaAngle * i);
            //3. �Ѿ� �ϳ� �߻��ϰ� �ʹ�.
            water.transform.position = User.transform.position;
            //water.GetComponent<Rigidbody>().AddForce()

        }
    }

}
