using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePipeScript : MonoBehaviour
{
    private float PipeSpeed;
    private float DeletePipeZone;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name.Contains("PipeGO"))
        {
            PipeSpeed = 8f; 
        }
        if (gameObject.name.Contains("CloudGO"))
        {
            PipeSpeed = 16f; 
        }
        DeletePipeZone = -36f; 
    }

    // Update is called once per frame
    void Update()
    {
        MovePipe(); 
    }

    private void MovePipe()
    {
        transform.position = transform.position + (Vector3.left * PipeSpeed * Time.deltaTime); 
        if(transform.position.x < DeletePipeZone)
        {
            Destroy(gameObject); 
        }
    }
}
