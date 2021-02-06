using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomAnimation : MonoBehaviour
{

    public RuntimeAnimatorController runtimeAnimController;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            PlayAnim();
        }
    }

    public void PlayAnim()
    {
        AnimationClip[] anims = runtimeAnimController.animationClips;
        int ind = Random.Range(0, anims.Length);
        anim.Play(anims[ind].name);
    }
}
