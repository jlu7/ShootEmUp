using UnityEngine;
using System.Collections;

public class Enemy1Logic : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        StartCoroutine(Logic());
    }

    // Update is called once per frame
    public IEnumerator Logic()
    {
        while (true)
        {
            transform.position += new Vector3(-.1f, 0, 0);
            if (transform.position.x < -10)
            {
                Destroy(this.gameObject);
            }
            yield return null;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        Destroy(col.gameObject);
        Destroy(gameObject);
    }
}
