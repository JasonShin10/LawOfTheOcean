using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "EnemySkill/testSkill")]
public class test : Skill
{
    [SerializeField] private GameObject bullet;
    
    public override void UseSkill()
    {
        //bullet ����
        GameObject bulletPre = Instantiate(bullet);
        //bullet���� User�� �������� �˷���
        bulletPre.GetComponent<TestBullet>().User = this.User;
        //bullet���� Power�� ����������� �˷���
        bulletPre.GetComponent<TestBullet>().BulletDamage = this.Power;
        //bullet ������ġ
        bulletPre.transform.position = User.transform.position;
    }
}
