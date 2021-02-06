using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour
{
    public SpriteRenderer face;

    // Update is called once per frame
    void Update()
    {
        LookAtTheCamera();
        
    }

    public void SetFace(Sprite s)
    {
        face.sprite = s;
        GetComponent<PlayRandomAnimation>().PlayAnim();
        LookAtTheCamera();
    }

    void LookAtTheCamera()
    {
        transform.LookAt(Camera.main.transform);
        Vector3 angle = transform.rotation.eulerAngles;
        angle.x = 0;
        angle.z = 0;
        transform.eulerAngles = angle;
    }

}
