using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody), typeof (BoxCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Volume vol;
    private LensDistortion lensD;
    public GameObject black;
    public Image img;
    public Material[] materials;
    public GameObject[] prefabs;
    public AudioSource audioSource;
    public AudioClip[] soundtracks;
    private int x = 0;
    private bool enter = false;
    private bool hit = false;
    private float dt = 0.0f;
    private float dtt = 0.0f;
    private float lastT = 0.0f;
    private float lastTt = 0.0f;
    private string targetTag0 = "astn0";
    private string targetTag1 = "astn1";
    private string targetTag2 = "astn2";
    private string targetTag3 = "astn3";
    private string targetTag4 = "astn4";
    private string targetTag5 = "astn5";
    private string targetTag6 = "astn6";
    private string targetTag7 = "astn7";
    private string targetTag8 = "astn8";
    private string targetTag9 = "astn9";
    private int n;
    private Vector3 pos;
    private Vector4 imgColor;
    private AstSpawner spawner;
    
    private void Awake()
    {
        spawner = FindObjectOfType<AstSpawner>();
    }

    void Start()
    {
        vol.profile.TryGet(out lensD);
    }
    void Update()
    {
        dt = Time.time - lastT;
        dtt = Time.time - lastTt;
        _rigidbody.velocity = new Vector3(_joystick.Vertical * moveSpeed, -_joystick.Horizontal * moveSpeed, 0);
        if (enter){
            if (imgColor.w < 1f)
            {
                if (dt > 0.02f)
                {
                    imgColor.w += 0.2f;
                    img.color = imgColor;
                    lastT = Time.time;
                }
            }
            else if (dt > 4f)
            {
                if (black.activeSelf)
                {
                    lensD.intensity.value = -1f;
                    lensD.scale.value = 0.15f;
                    List<int> select = new() {0, 1, 2, 3};
                    select.Remove(x);
                    x = select[Random.Range(0, select.Count)];
                    RenderSettings.skybox = materials[x];
                    black.SetActive(false);
                    img.color = new Vector4(0f, 0f, 0f, 0f);
                }
                else if (!black.activeSelf)
                {
                    if (lensD.scale.value < 1f)
                    {
                        lensD.scale.value += 0.85f/25f;
                    }
                    else if (lensD.intensity.value < 0f)
                    {
                        lensD.intensity.value += 1f/25f;
                    }
                    else enter = false;
                }
            }
        }
        if (hit)
        {
            if (dtt >= 0.06f)
            {
                Instantiate(prefabs[n], pos, Quaternion.identity);
                if (audioSource && soundtracks.Length > 0)
                {
                    PlayRandomTrack();
                }
                hit = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BlackHole"))
        {
            if (!enter)
            {
                imgColor = new Vector4(0f, 0f, 0f, 0.2f);
                img.color = imgColor;
            }
            black.SetActive(true);
            enter = true;
        }
    }

    void OnCollisionEnter(Collision other){
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag(targetTag0) || other.gameObject.CompareTag(targetTag1) || other.gameObject.CompareTag(targetTag2) || other.gameObject.CompareTag(targetTag3) || other.gameObject.CompareTag(targetTag4) || other.gameObject.CompareTag(targetTag5) || other.gameObject.CompareTag(targetTag6) || other.gameObject.CompareTag(targetTag7) || other.gameObject.CompareTag(targetTag8) || other.gameObject.CompareTag(targetTag9))
        {
            if (spawner.Reduce)
            {
                StatisticManager.Instance.AddHealth(10);
                spawner.Reduce = false;
            }
            hit = true;
            n = int.Parse(other.gameObject.tag.Substring(4));
            pos = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, other.gameObject.transform.position.z);
            lastTt = Time.time;
        }
    }
    
    void PlayRandomTrack()
    {
        if (soundtracks.Length == 0) return;
        int randomIndex= Random.Range(0, soundtracks.Length);
        audioSource.clip = soundtracks[randomIndex];
        audioSource.Play();
    }
}