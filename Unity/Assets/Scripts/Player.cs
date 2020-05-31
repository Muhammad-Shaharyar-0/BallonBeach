using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public float PlayerSpeed;
    public float DirectionalSpeed;
    public AudioClip ScoreUp;
    public AudioClip damage;
    public GameObject SceneManger;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

        
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPlayer
        float moveHorizontal= Input.GetAxis("Horizontal");
        transform.position = Vector3.Lerp(gameObject.transform.position,new Vector3(Mathf.Clamp(gameObject.transform.position.x+moveHorizontal,-2.103f,2.103f), gameObject.transform.position.y, gameObject.transform.position.z),DirectionalSpeed*Time.deltaTime);

#endif
      

       
    }
    private void OnMouseDrag()
    {
        //Mobile Controls
        Vector2 touch = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10f));
        if (Input.touchCount > 0)
        {
            transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(touch.x, transform.position.y, transform.position.z), DirectionalSpeed * Time.deltaTime);
        }
    }
    private void FixedUpdate()
    {

        if (SceneManger.GetComponent<AppInitilize>().InGameUI.gameObject.activeSelf==true && PlayerSpeed<2000)
        {
            PlayerSpeed = PlayerSpeed + 0.32f;
        }
        else if(SceneManger.GetComponent<AppInitilize>().InGameUI.gameObject.activeSelf == true && PlayerSpeed < 2500)
        {
            PlayerSpeed = PlayerSpeed + 0.22f;
        }
        else if(SceneManger.GetComponent<AppInitilize>().InGameUI.gameObject.activeSelf == true && PlayerSpeed < 3000)
        {
            PlayerSpeed = PlayerSpeed + 0.1f;
        }
        GetComponent<Rigidbody>().velocity = Vector3.forward * (PlayerSpeed * Time.deltaTime);
        transform.Rotate(Vector3.right * GetComponent<Rigidbody>().velocity.z/3);
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("gap"))
        {
            GetComponent<AudioSource>().PlayOneShot(ScoreUp, 0.2f);
            Destroy((other.gameObject));
        }
        if (other.gameObject.CompareTag("triangle"))
        {
            GetComponent<AudioSource>().PlayOneShot(damage, 0.2f);
            SceneManger.GetComponent<AppInitilize>().GameOver();
        }


    }
}
