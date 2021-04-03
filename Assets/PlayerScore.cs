using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScore : MonoBehaviour
{
    public static float playerHeight;

    [SerializeField] Transform playerTransform;
    [SerializeField] TextMeshProUGUI text;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        playerHeight = playerTransform.position.y;
        /*
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            //text.SetText("Altitude Reached: " + (int)playerHeight);
        }
        */
    }
}
