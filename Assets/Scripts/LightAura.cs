using UnityEngine;
using UnityEngine.UI;

public class LightAura : MonoBehaviour {
    public SpriteRenderer sr;

    private Image aura;

    private void Start () {
        aura = this.gameObject.GetComponent<Image>();
    }

    private void Update () {
        aura.color = sr.color;
    }
}