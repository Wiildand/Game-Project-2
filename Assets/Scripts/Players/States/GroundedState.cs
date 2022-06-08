using UnityEngine;

public class GroundedState : APlayerState {

    public GroundedState(Player player) : base(player) {
    }

    public override void CheckForChangeInState() {
        if (!player.IsGrounded()) {
            player.ChangeState(new ClassicFall(player));
        }
        if (player.playerJumped()) {
            player.ChangeState(new JumpingState(player));
        }
    }

    public override void PhysicsUpdate( ) {

        if (player._raycastHitted)
        {
            Vector3 vel = player._rb.velocity;
            Vector3 rayDir = player.transform.TransformDirection(Vector3.down);

            float rayDirVel = Vector3.Dot(rayDir, vel);
            float x = player._rayHit.distance - player.RideHeight; 
            float springForce = (x * player.RideSpringStrenght) - (rayDirVel * player.RideSpringDamper); 

            player._rb.AddForce(rayDir * springForce);
        }
    }

}

