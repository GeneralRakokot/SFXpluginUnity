using UnityEngine;

public class Example : MonoBehaviour
{
    public void playClick()
    {
        // Nethod Play can take string[] of names and play random of them
        string[] clicks = { "click01", "click02", "click03", "click04" };
        SFXCore.Play(clicks);
    }

    public void playMew()
    {
        // You can tune audio pitch in second argument.
        SFXCore.Play("mew", 0.25f);
    }
}
