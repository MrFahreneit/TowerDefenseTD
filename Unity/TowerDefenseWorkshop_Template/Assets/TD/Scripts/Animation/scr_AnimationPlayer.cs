using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_AnimationPlayer : MonoBehaviour
{
    [SerializeField]
    private Animator _playCreateAnimator;

    [SerializeField]
    private AnimationClip _animToPlay;

    public void PlayAnim()
    {
        _playCreateAnimator.Play(_animToPlay.name, 0,0.0f);
    }
}
