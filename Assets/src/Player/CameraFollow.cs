using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    
    public GameObject objectToFollow;
    public GameObject goal;

    public float speed = 0.8f;
    bool lookAtGoal = false;

    void Start()
    {
        if(goal != null)
        {
            lookAtGoal = true;
            float interpolation = speed * Time.deltaTime;
            float targetX = goal.transform.position.x - 5f;
            float targetY = goal.transform.position.y + 8f;
            float targetZ = goal.transform.position.z - 6f;
            Vector3 position = this.transform.position;
            position.y = Mathf.Lerp((this.transform.position.y), targetY, 0.2f); ;
            position.x = Mathf.Lerp((this.transform.position.x), targetX, 0.2f);
            position.z = Mathf.Lerp((this.transform.position.z), targetZ, 0.2f);
            this.transform.position = position;
            StartCoroutine("HoverOnGoal");
        }
        else
        {
            lookAtGoal = false;
        }
    }

    void Update () {
        if (lookAtGoal)
        {
            float interpolation = speed * Time.deltaTime;
            float targetX = goal.transform.position.x - 5f;
            float targetY = goal.transform.position.y + 8f;
            float targetZ = goal.transform.position.z - 6f;
            Vector3 position = this.transform.position;
            position.y = Mathf.Lerp((this.transform.position.y), targetY, 0.2f); ;
            position.x = Mathf.Lerp((this.transform.position.x), targetX, 0.2f);
            position.z = Mathf.Lerp((this.transform.position.z), targetZ, 0.2f);
            this.transform.position = position;
        }
        else
        {
            float interpolation = speed * Time.deltaTime;
            float targetX = objectToFollow.transform.position.x - 5f;
            float targetY = objectToFollow.transform.position.y + 8f;
            float targetZ = objectToFollow.transform.position.z - 6f;
            Vector3 position = this.transform.position;
            position.y = Mathf.Lerp((this.transform.position.y), targetY, 0.8f); ;
            position.x = Mathf.Lerp((this.transform.position.x), targetX, interpolation);
            position.z = Mathf.Lerp((this.transform.position.z), targetZ, interpolation);
            this.transform.position = position;
        }


    }

    IEnumerator HoverOnGoal()
    {
        yield return new WaitForSeconds(02); // wait 1 seconds
        lookAtGoal = false;
    }
}