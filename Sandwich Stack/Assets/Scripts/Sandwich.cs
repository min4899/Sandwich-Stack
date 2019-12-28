using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sandwich : MonoBehaviour
{
    [Tooltip("Max count of ingredients to render.")]
    public int stackCount = 5;

    public float height;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        // If max amount of ingredients on the stack is reached, delete bottom ingredient
        if(transform.childCount > stackCount)
        {
            GameObject bottom = transform.GetChild(0).gameObject;
            GameObject next = transform.GetChild(1).gameObject;
            GameObject top = transform.GetChild(transform.childCount-1).gameObject;

            // delete bottom ingredient
            Destroy(bottom);

            // unstick next ingredient and activate proper physics
            next.GetComponent<FoodScript>().UnstickBottom();

            // record new height for camera, despawner, spawner positioning
            height = top.transform.position.y;
        }
        */
    }

    public void SandwichStackUpdate()
    {
        if(transform.childCount > 0)
        {
            GameObject top = transform.GetChild(transform.childCount - 1).gameObject;

            // record new height for camera, despawner, spawner positioning
            height = top.transform.position.y;
            Debug.Log("Height: " + height);
        }

        // If max amount of ingredients on the stack is reached, delete bottom ingredient
        if (transform.childCount > stackCount)
        {
            GameObject bottom = transform.GetChild(0).gameObject;
            GameObject next = transform.GetChild(1).gameObject;
            GameObject top = transform.GetChild(transform.childCount - 1).gameObject;

            // delete bottom ingredient
            Destroy(bottom);

            // unstick next ingredient and activate proper physics
            next.GetComponent<FoodScript>().UnstickBottom();
        }       
    }
}
