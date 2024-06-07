using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class JumpPlayerController : MonoBehaviour
{
    [SerializeField] private List<GameObject> jumpAreas;
    [SerializeField] private Animator playerAnimator;
    private bool isJump = true;
    private int jumpValue = 0;
    void Start()
    {
        
    }

    private void OnEnable()
    {
        BusSystem.OnPlayerJump += JumpPlayer;
    }

    private void OnDisable()
    {
        BusSystem.OnPlayerJump -= JumpPlayer;
    }

    private void JumpPlayer()
    {
        if (isJump)
        {
            var pos = new Vector3(jumpAreas[jumpValue].transform.localPosition.x, 0.52f,
                jumpAreas[jumpValue].transform.localPosition.z);
            isJump = false;
            playerAnimator.SetTrigger("Jump");
            gameObject.transform.DOLocalJump(pos, 3, 1,1).OnComplete((() =>
            {
                jumpValue++;
                isJump = true;
                if (jumpValue == jumpAreas.Count)
                {
                    BusSystem.CallJumpLevelDone();
                    playerAnimator.SetTrigger("Dance");
                    isJump = false;
                    BusSystem.CallLevelWinStatusForCanvas(true);
                }
            }));
            
        }
    }
}
