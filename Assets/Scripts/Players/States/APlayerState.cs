abstract public class APlayerState {

    protected Player player;

    public APlayerState(Player player) {
        this.player = player;
    }

    public abstract void CheckForChangeInState();

    public abstract void PhysicsUpdate();

}
