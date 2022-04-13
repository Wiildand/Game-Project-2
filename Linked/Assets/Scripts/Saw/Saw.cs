using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

[CreateAssetMenu(fileName = "New Trap Saw", menuName = "Trap_Saw")]
public class Saw : ScriptableObject {
    public Sprite artwork = null;
    public new string name;
    public int speed = 5;
    public TagList tag;
    
    public void Print() {
        Debug.Log("Saw : " + name);
    }
}
