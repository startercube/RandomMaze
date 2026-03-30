using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smooth_follow : MonoBehaviour
{
    public Transform target;
    float distance = 5.0f;
    float height = 5.0f;
    float heightDamping = 1.0f;
    float rotationDamping = 2.0f;

    int r = 0;

    // Update is called once per frame
    void LateUpdate()
    {
        if (r == 0)
        {
            if (Input.GetKeyUp(KeyCode.C))
            {
                distance = 5.0f;
                height = 1.5f;
                heightDamping = 1.0f;
                r = 1;
            }
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.C))
            {
                distance = 5.0f;
                height = 5.0f;
                heightDamping = 1.0f;
                r = 0;
            }
        }
        

        if (!target) return;

        float wantedRotationAngle = target.eulerAngles.y;
        float wantedHeight = target.position.y + height;
        float currentRotationAngle = this.transform.eulerAngles.y;
        float currentHeight = this.transform.position.y;

        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

        Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        this.transform.position = target.position;
        this.transform.position -= currentRotation * Vector3.forward * distance;

        Vector3 temp_position = this.transform.position;
        temp_position.y = currentHeight;
        this.transform.position = temp_position;

        this.transform.LookAt(target);
    }
    private void OnCollisionExit(Collision collision)
    {

    }
}
