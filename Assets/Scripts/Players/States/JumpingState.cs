using UnityEngine;

public class JumpingState : APlayerState {
    private float _jumpingTimer;
    private float _timeOfAnimation;

    public JumpingState(Player player) : base(player) {
        _jumpingTimer = 0;
        _timeOfAnimation = player.JumpVelocityCurve.keys[player.JumpVelocityCurve.length - 1].time;
        player._rb.velocity = new Vector3(player._rb.velocity.x, 0, player._rb.velocity.z);
    }

    public override void CheckForChangeInState() {
        if (player._rb.velocity.y < 0.1f && !player.IsGrounded()) {

            player.ChangeState(new AfterJumpFall(player));
        }
        _jumpingTimer += Time.deltaTime;
    }

    public override void PhysicsUpdate( ) {
        float neededAccelerationToReachGoalVelocity = 
            (player.JumpVelocityCurve.Evaluate(_jumpingTimer) * player.JumpForce - player._rb.velocity.y) / Time.fixedDeltaTime;
        player._rb.AddForce(Vector3.up * neededAccelerationToReachGoalVelocity, ForceMode.Force);
    }

}

