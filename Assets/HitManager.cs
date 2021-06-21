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
        // 태어날 때 imageHit를 보이지않게 하고싶다.
        imageHit.SetActive(false);
    }
    public void Hit() 
    {
        //깜빡거리고싶다.
        StartCoroutine("IeHit");
    }

    IEnumerator IeHit()
    {
        // 1. imageHit를 보이게화고싶다.
        imageHit.SetActive(true);
        // 2. 0.1초 후에 
        yield return new WaitForSeconds(0.1f);
        // 3. imageHit를 안보이게 하고싶다.
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
