using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFishFire : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    float currentTime;
    [SerializeField]
    private float createTime = 2;
    public GameObject bulletFactory;
    // Update is called once per frame
    void Update()
    {
       
    }
    public void JellyFishAttack()
    {
        // �ð��� �帣�ٰ�  
        currentTime += Time.deltaTime;
        // �����ð��� �Ǹ�
        if (currentTime > createTime)
        {
            // �Ѿ˰��忡�� �Ѿ��� ������
            GameObject bullet = Instantiate(bulletFactory);
            // �� ��ġ�� ������ ���´�.
            bullet.transform.position = transform.position;
            // 3. ������ �ѵڿ��� �ð��� �ʱ�ȭ�Ѵ�.
            currentTime = 0;
        }
    }
    
    

}
