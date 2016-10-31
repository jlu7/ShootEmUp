using UnityEngine;
using System.Collections;

public class Bullet1 : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(Logic());
	}
	
	// Update is called once per frame
	public IEnumerator Logic ()
    {
        while (true)
        {
            transform.position += new Vector3(0, .1f, 0);
            if (transform.position.y > 10)
            {
                Destroy(this);
            }
            yield return null;
        }
    }
}
