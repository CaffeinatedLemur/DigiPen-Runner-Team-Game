using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{

    [SerializeField] float timLimit = 10;
    public Transform playerTransform;
    public float temp = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        temp += Time.deltaTime;
        if (temp >= timLimit && playerTransform.transform.position.y > gameObject.transform.position.y + 10)
            Destroy(gameObject);
    }
}
