using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewScript : MonoBehaviour
{
    public int levelDifficulty = 1;

    public GameObject exampleElement;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Estas en el nivel " + levelDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 postionEx = exampleElement.transform.position;
        exampleElement.transform.position =
            new Vector2(postionEx.x + 0.001f, postionEx.y );
    }
}
