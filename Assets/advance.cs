using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class advance : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "enemy") {
            other.gameObject.GetComponent<Collider>().enabled = false;
            other.gameObject.GetComponent<ParticleSystem>().Play();
            other.gameObject.GetComponent<AudioSource>().Play();

            StartCoroutine(destroy(other.gameObject));
        }
    }

    private IEnumerator destroy(GameObject obj) {
        yield return new WaitForSeconds(1);
        Destroy(obj);

    }
}
