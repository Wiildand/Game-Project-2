class Lever : AInteractable {

    private bool activated = false;

    override public void OnInteractionStart(Player player) {
        if (activated) {
            launchStartActions(player);
            activated = false;
        } else {
            launchEndActions(player);
            activated = true;
        }
    }
}