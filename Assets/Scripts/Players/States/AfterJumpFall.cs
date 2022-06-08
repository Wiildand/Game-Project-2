using UnityEngine;

public class AfterJumpFall : APlayerState {

    public AfterJumpFall(Player player) : base(player) {

    }

    public override void CheckForChangeInState() {
        if (player.IsGrounded()) {  
            player.ChangeState(new GroundedState(player));
        }
    }

    public override void PhysicsUpdate( ) {
        player._rb.AddForce(Physics.gravity * player.GravityForce, ForceMode.Acceleration);
    }

}