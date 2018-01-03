using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Boundary boundary;
    public float tilt;
    public GameObject shot;
    public Transform[] turrets;
    public float fireRate;
    private float nextFire = 0.0f;
    void FixedUpdate()
    { 
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        GetComponent<Rigidbody>().velocity = new Vector3(moveHorizontal, 0.0f, moveVertical)*speed;
        GetComponent<Rigidbody>().position = new Vector3
            (
                Mathf.Clamp(GetComponent<Rigidbody>().position.x,boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
            );
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(GetComponent<Rigidbody>().velocity.z * tilt, 0.0f, GetComponent<Rigidbody>().velocity.x*-tilt);
    }

     void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            foreach (Transform gun in turrets)
            {

                Instantiate(shot, gun.position, Quaternion.Euler(0f,gun.rotation.y,0f));
            }
            GetComponent<AudioSource>().Play();
        }
    }


}
[System.Serializable]
public struct Boundary
{
    public float xMin, xMax, zMin, zMax;
}
