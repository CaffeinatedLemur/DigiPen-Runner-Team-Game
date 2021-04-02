/*******************************************
 * Authors: Thomas A
 * Date: 4/2/2021
 * Desc: Makes the Dino follow the player with a slight lerp to make it more dynamic
 * ****************************************/
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
        //make sure there is a target in the first place
        if (Target != null)
        {
            //update target position to match player
            Vector3 newPos = Target.transform.position;
            //sure sure the end pos is next to the player
            newPos.x = newPos.x - 1;
            newPos.y = newPos.y - 0.5f;
            //move towords the player
            transform.position = Vector3.Lerp(transform.position, newPos, 0.3f);
            
        }
    }
}