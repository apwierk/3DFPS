using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Ray 를 이요해서 바라보고 닿은곳에 총을 쏘고싶다. (총알 자국을 남기고 싶다.)
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
        // 마우스 왼쪽버튼을 누르면
        if (Input.GetButtonDown("Fire1"))
        {

            // 1. 시선을 만들고 Ray(위치, 방향)
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            // 2. 그 시선을 이용해서 바라봤는데 만약 닿는곳이 있다면?
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                // 3. 닿은 곳에 총알자국을 남기고 싶다.
                bulletImpact.transform.position = hitInfo.point;
                // 4. 총알자국vfx를 재생하고싶다.
                bulletImpact.Stop();
                bulletImpact.Play();
                // 5. 총알자국의 방향을 닿은곳의 Normal방향으로 회전하고싶다.
                // 총알자국의 forward방향과 닿은곳의 Normal방향을 일치시키고싶다.
                bulletImpact.transform.forward = hitInfo.normal;
            }
        }   
    }
}
