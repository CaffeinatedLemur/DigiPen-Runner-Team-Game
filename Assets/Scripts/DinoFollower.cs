using UnityEngine;

public class DinoFollower : MonoBehaviour
{
    //target of follow 
    public GameObject Target;
    public float smoothVal = 0.5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Target != null)
        {
            Vector3 newPos = Target.transform.position;
            newPos.x = newPos.x - 1;
            newPos.y = newPos.y - 0.5f;
            transform.position = Vector3.Lerp(transform.position, newPos, 0.3f);
            
        }
    }
}