using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public Rigidbody2D shield;
    public int damage;
    public float speed;

    void Start()
    {
        speed = 0.5f;
        
    }

    void Update()
    {
        if (shield.transform.position.x < -3)
        {
            Destroy(this.gameObject);
        }
        shield.transform.position += Vector3.left * speed * Time.deltaTime;
        
    }

    //public void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.transform.CompareTag("Player"))
    //    {
    //        Debug.Log("shield touches player");
    //        collision.gameObject.transform.parent = collision.transform;
            
    //    }
            
    //}


}



//private void OnTriggerEnter2D(Collider2D collision)
//{
//    if (collision.transform.CompareTag("Player"))
//    {
//        collision.transform.GetComponent<Enemy>().TakeDamage(damage);
//        Destroy(this.gameObject);
//    }
//}
