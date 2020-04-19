using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rigidB;
    private Transform transform;

    public Animator transition;
    public GameObject levelLoader;
    LevelLoaderTest levelLoaderScript;


    public int speed = 5;
    float initalScale = 1;
    float maxScale = 1.5f;
    bool isGrounded = false;
    bool isRefilling = false, isBeingBoosted = false;

    void Start()
    {
        levelLoaderScript = (LevelLoaderTest)levelLoader.GetComponent(typeof(LevelLoaderTest));
        rigidB = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
    }

    void Update()
    {
        float speedToApply = 10;
        Vector3 newScale = new Vector3(0, 0, 0);
        float scaleDecay = -0.1f;
        GroundCheck();
        if (!isGrounded)
        {
            speedToApply -= 7;
        }

        if (isBeingBoosted)
        {
            speedToApply += 5;
        }

        if (Input.GetKey("up"))
            {
                rigidB.AddForce(Vector3.forward * (speedToApply * 100f) * Time.deltaTime);
                if (!isRefilling)
                {
                    newScale.x -= scaleDecay;
                    newScale.y -= scaleDecay;
                    newScale.z -= scaleDecay;
                }

            }
            if (Input.GetKey("down"))
            {
                rigidB.AddForce(Vector3.back * (speedToApply * 100f) * Time.deltaTime);
                if (!isRefilling)
                {
                    newScale.x -= scaleDecay;
                    newScale.y -= scaleDecay;
                    newScale.z -= scaleDecay;
                }
            }
            if (Input.GetKey("right"))
            {
                rigidB.AddForce(Vector3.right * (speedToApply * 100f) * Time.deltaTime);
                if (!isRefilling)
                {
                    newScale.x -= scaleDecay;
                    newScale.y -= scaleDecay;
                    newScale.z -= scaleDecay;
                }
            }
            if (Input.GetKey("left"))
            {
                rigidB.AddForce(Vector3.left * (speedToApply * 100f) * Time.deltaTime);
                if (!isRefilling)
                {
                    newScale.x -= scaleDecay;
                    newScale.y -= scaleDecay;
                    newScale.z -= scaleDecay;
                }
            }

        if (isRefilling && transform.localScale.y < maxScale && transform.localScale.y < maxScale && transform.localScale.z < maxScale)
        {
            newScale.x += scaleDecay*2;
            newScale.y += scaleDecay*2;
            newScale.z += scaleDecay*2;
        }

        if (rigidB.velocity.magnitude > 14f)
            rigidB.velocity = rigidB.velocity.normalized * 14;


        if ((transform.localScale.y < 0.1f && transform.localScale.y < 0.1f && transform.localScale.z < 0.1f) || transform.position.y < 0)
        {
            Debug.Log("You lose");
            levelLoaderScript.ReloadCurrentLevel();
            //transition.SetTrigger("GameOver");
        }
        else
        {
            // if we are still big enough
            // keep applying scale
            transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale - newScale, Time.deltaTime);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "refill")
        {
            isRefilling = true;
        }
        if (other.gameObject.tag == "booster")
        {
            isBeingBoosted = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "refill")
        {
            isRefilling = false;
        }
        if (other.gameObject.tag == "booster")
        {
            isBeingBoosted = false;
        }
    }

    void GroundCheck()
    {
        RaycastHit hit;
        float distance = 0.8f;
        Vector3 dir = new Vector3(0, -1);

        if (Physics.Raycast(transform.position, dir, out hit, distance))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
