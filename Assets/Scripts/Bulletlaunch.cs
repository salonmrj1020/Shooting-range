using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bulletlaunch : MonoBehaviour
{
    [SerializeField]
    private Rigidbody BulletRigidBody;
    [SerializeField]
    private float BulletPower = 1500;
    [SerializeField]
    private GameObject muzzle;
    [SerializeField]
    private float COOLDOWN_TIME = 0.5f;
    private float coolDown = 0;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (coolDown <= 0)
        {
            if (Input.GetButtonUp("Fire1"))
            {
                coolDown = COOLDOWN_TIME;
                // Instantiate the projectile.
                Rigidbody aInstance = Instantiate(BulletRigidBody,
                muzzle.transform.position, transform.rotation) as Rigidbody;
                // Add force.
                Vector3 forward = transform.TransformDirection(Vector3.forward);
                aInstance.AddForce(forward * BulletPower);
                // Destroy the object after X seconds.
                Destroy(aInstance.gameObject, 8);
            }
        }
        else
        {
            coolDown = coolDown - Time.deltaTime;
        }
    }
}