using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HitManager : MonoBehaviour
{

    public static HitManager instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject imageHit;
    // Start is called before the first frame update
    void Start()
    {
        // �¾ �� imageHit�� �������ʰ� �ϰ�ʹ�.
        imageHit.SetActive(false);
    }
    public void Hit() 
    {
        //�����Ÿ���ʹ�.
        StartCoroutine("IeHit");
    }

    IEnumerator IeHit()
    {
        // 1. imageHit�� ���̰�ȭ��ʹ�.
        imageHit.SetActive(true);
        // 2. 0.1�� �Ŀ� 
        yield return new WaitForSeconds(0.1f);
        // 3. imageHit�� �Ⱥ��̰� �ϰ�ʹ�.
        imageHit.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Hit();
        }
    }
}
