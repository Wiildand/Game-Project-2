using UnityEngine;

public class ClassicFall : APlayerState {

    public ClassicFall(Player player) : base(player) {
    }

    public override void CheckForChangeInState() {

        if (player.IsGrounded()) {
            player.ChangeState(new GroundedState(player));
        }
        if (player.playerJumped()) {
            player.ChangeState(new JumpingState(player));

        }
    }

    public override void PhysicsUpdate( ) {
        player._rb.AddForce(Physics.gravity, ForceMode.Acceleration);
    }
}