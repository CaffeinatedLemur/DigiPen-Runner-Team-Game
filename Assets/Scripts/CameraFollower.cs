using UnityEngine;

public class CameraFollower : MonoBehaviour
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
            //figure our where the target is
            Vector3 newPos = Target.transform.position;
            //maintain cam z
            newPos.z = transform.position.z;
            newPos.x = transform.position.x;
            //use linear interpolation to smoothly go to the target
            transform.position = Vector3.Lerp(transform.position, newPos, smoothVal);
        }
    }
}