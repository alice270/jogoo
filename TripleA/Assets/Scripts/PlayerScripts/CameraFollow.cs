using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    private void LateUpdate()
    {
        if(target != null)
        {
            //transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z), Time.deltaTime); Para se mover com a camera seguindo com delay

            transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        }
        else
        {
            Debug.Log("Camera nao tem um target");
        }
    }
}
