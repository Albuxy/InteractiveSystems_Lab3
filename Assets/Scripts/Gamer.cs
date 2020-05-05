using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gamer : MonoBehaviour
{
    public Text countText;
    public Text winText;
    private int count; 


    public AudioClip Sonido = null;

    public float Volumen = 1.0f;

    private Vector3 cameraPosition; // 5    
    protected Transform Posicion = null;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
	SetCountText ();
	winText.text = "";
	Posicion = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        cameraPosition = Camera.main.transform.position; // 2
    }


    void OnTriggerEnter(Collider other)
    {
	if(other.gameObject.CompareTag("Pick Up"))
	{
		other.gameObject.SetActive (false);
		count = count + 1;
		SetCountText ();

		if(Sonido != null)
		{
			AudioSource.PlayClipAtPoint(Sonido, cameraPosition );
		}
	}
    }


    void SetCountText ()
    {
	countText.text = "Points: " + count.ToString ();
	if (count >= 7)
	{
		GameOver();
	}
    }

    private void GameOver()
    {
  	winText.text = "VICTORY";
    }

}
