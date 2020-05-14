using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BangExplode:MonoBehaviour
{
    float Timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.activeSelf)
        {
            Timer += Time.deltaTime;
            if (Timer >= 2)
            {
                gameObject.SetActive(false);
                PoolManager.gameObject.PutObjectInPool("BangExplode", this.gameObject);
                Timer = 0;
            }
        }
    }
}
