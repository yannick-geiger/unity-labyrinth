using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        transform.position += new Vector3(1, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
