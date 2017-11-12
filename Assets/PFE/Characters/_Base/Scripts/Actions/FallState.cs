using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TrueSync;

[System.Serializable]
public class FallState : BaseAction {

    public override void ActionStart () {
        base.ActionStart();
        Con.Anim.PlayAnimation(Con.CI.CombatStances[0].BasicMoves.FallStraight.Animation, true);
        ActionTimerDuration = Con.CI.AttributesInfo.JumpSquat;
        Con.IsGrounded = false;
        Con.ApplyGravity();
    }

    public override void ActionUpdate () {
        if (!ActionInterrupt()) {
            Con.ApplyGravity();
            Con.AirDrift();
            CurrentActionTime++;
        }
    }

    public override bool ActionInterrupt () {
        if(Con.GetJumpButton(0) && !Con.GetJumpButton(1)) {
            Con.currentJump++;
            Con.ChangeState("Jump");
            return true;
        } else if (Con.IsGrounded) {
            Con.currentJump = 0;
            Con.ChangeState("Idle");
            return true;
        }
        return false;
    }
}