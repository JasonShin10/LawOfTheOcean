using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemySkill/JellySkill")]
public class JellyFishSkill : Skill
{
    [SerializeField] private GameObject skillFactory;

    public override void UseSkill()
    {
        GameObject bullet = Instantiate(skillFactory);
        //bullet���� User�� �������� �˷���
        bullet.GetComponent<TestBullet>().User = this.User;
        //bullet���� Power�� ����������� �˷���
        bullet.GetComponent<TestBullet>().BulletDamage = this.Power;
        bullet.transform.position = User.transform.position;
    }

    // Start is called before the first frame update

}
