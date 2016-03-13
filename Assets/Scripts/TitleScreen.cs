using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {

    public GameObject canvas;
    public GameObject title;
    public float titleWavelength = 0.3f;
    public float titleOffset = 0.0f;

    public GameObject subtitle;
    public float subtitleWavelength = 0.1f;
    public float subtitleOffset = 1.0f;

    public GameObject[] credits;
    public float creditsWavelength = 0.05f;

    public ParticleSystem star;
    public Camera cam;

    private Color startColor;
    
    
    AudioManager am;
    
    void Start () {
        am = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        cam = Camera.main;
        canvas.SetActive(false);
        startColor = cam.backgroundColor;
        cam.backgroundColor = Color.black;
        StartCoroutine(Splash());
    }

    private IEnumerator Splash () {
        yield return new WaitForSeconds(star.startLifetime);
        Init();
    }

    private void Init () {
        // Start music
        
        am.PlayMusic(am.titleMusic);
        
        
        
        cam.backgroundColor = startColor;
        canvas.SetActive(true);
        foreach (GameObject credit in credits)
        {
            credit.SetActive(true);
        }

        StartCoroutine(Hover(title.transform, titleWavelength, titleOffset));
        StartCoroutine(Hover(subtitle.transform, subtitleWavelength, subtitleOffset));

        for (int i = 0; i < credits.Length; i++)
        {
            StartCoroutine(Hover(credits[i].transform, creditsWavelength, (float)i));
        }
    }

    private void Update () {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("Instructions");
        }
    }

    private IEnumerator Hover (Transform tr, float waveStr, float offSet) {
        while (true)
        {
            var pos = tr.position;
            pos.y += Mathf.Sin(Time.time + offSet) * waveStr;
            tr.position = pos;
            yield return null;
        }
    }
}