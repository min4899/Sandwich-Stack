using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    public bool touched = false;

    private HingeJoint hj;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<PlayerController>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        // object with "Top" tag should always be the top ingredient on the sandwich stack.
        if (other.gameObject.tag == "Top" && !touched)
        {
            // attach object to top as a joint
            hj = gameObject.AddComponent<HingeJoint>() as HingeJoint;
            hj.connectedBody = other.rigidbody; // connect this object to detected object
            //hj.massScale = 3.0f; // how fast the connected object should follow each other
            //GetComponent<Rigidbody>().mass = 0.00001f;
            GetComponent<Collider>().material.bounciness = 0f;
            GetComponent<Rigidbody>().freezeRotation = true;
            GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);

            // set object as child of Sandwich game object
            // child index should be last (added like queue)
            gameObject.transform.SetParent(other.transform.parent);

            touched = true;

            other.gameObject.tag = "Touched"; // object below is no longer stickable
            gameObject.tag = "Top"; // This object will now be the stickable one

            // TEST
            Sandwich sandwich = gameObject.transform.parent.GetComponent<Sandwich>();
            sandwich.SandwichStackUpdate();

            GameController.instance.updateScore();
        }
        else if(other.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
        }
        else // did not touch top of stack, hit another object, label it 'touched' so it cant stick to anything else
        {
            touched = true;
        }
    }

    public void Unstick()
    {
        if (hj != null)
            Destroy(hj);

        GetComponent<Rigidbody>().mass = 1;
    }

    public void UnstickBottom()
    {
        if(hj != null)
            Destroy(hj);

        GetComponent<PlayerController>().enabled = true;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().mass = 1;
        GetComponent<Rigidbody>().drag = 0;
    }
}
