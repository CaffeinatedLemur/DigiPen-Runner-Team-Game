using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{

    [SerializeField] float timLimit = 10;
    public float temp = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        temp += Time.deltaTime;
        if (temp >= timLimit)
            Destroy(gameObject);
    }
}
