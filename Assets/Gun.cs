using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Ray �� �̿��ؼ� �ٶ󺸰� �������� ���� ���ʹ�. (�Ѿ� �ڱ��� ����� �ʹ�.)
public class Gun : MonoBehaviour
{
    public ParticleSystem bulletImpact;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ���콺 ���ʹ�ư�� ������
        if (Input.GetButtonDown("Fire1"))
        {

            // 1. �ü��� ����� Ray(��ġ, ����)
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            // 2. �� �ü��� �̿��ؼ� �ٶ�ôµ� ���� ��°��� �ִٸ�?
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                // 3. ���� ���� �Ѿ��ڱ��� ����� �ʹ�.
                bulletImpact.transform.position = hitInfo.point;
                // 4. �Ѿ��ڱ�vfx�� ����ϰ�ʹ�.
                bulletImpact.Stop();
                bulletImpact.Play();
                // 5. �Ѿ��ڱ��� ������ �������� Normal�������� ȸ���ϰ�ʹ�.
                // �Ѿ��ڱ��� forward����� �������� Normal������ ��ġ��Ű��ʹ�.
                bulletImpact.transform.forward = hitInfo.normal;
            }
        }   
    }
}
