using UnityEngine;

public class RaveComponentParticle: MonoBehaviour {
    private ParticleSystem ps;

    private void Start() {
        ps = this.gameObject.GetComponent<ParticleSystem>();
    }

    private void Update() {
        ps.startColor = LightManager.currentColor;
    }
}