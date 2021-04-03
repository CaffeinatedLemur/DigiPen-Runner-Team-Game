using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateScore : MonoBehaviour
{
    [SerializeField] GameObject scorekeeper;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        scorekeeper = GameObject.Find("Scorekeeper");
        text.SetText("Altitude Reached: " + (int)PlayerScore.playerHeight);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
