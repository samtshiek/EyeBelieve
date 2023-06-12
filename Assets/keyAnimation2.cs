using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyAnimation2 : MonoBehaviour
{
    GameObject key;
    GameObject keyObject;
    Light light;
    Vector3 rotation = new Vector3(10, 10, 10);
    bool increase = false;
    bool decrease = true;
    // Start is called before the first frame update
    void Start()
    {
        light = gameObject.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        
        gameObject.transform.Rotate(rotation * Time.deltaTime * 7);

        if (increase && light.intensity !> 10)
        {
            Debug.Log("INTENSITY: " + light.intensity);
            light.intensity += 0.1f;
        }
        else
        {
            decrease = true;
            increase = false;
        }

        if (decrease && light.intensity! < 0)
        {
            Debug.Log("INTENSITY: " + light.intensity);
            light.intensity -= 0.1f;
        }
        else
        {
            increase = true;
            decrease = false;
        }
    }
}
