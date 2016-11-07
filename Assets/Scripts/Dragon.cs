using UnityEngine;
using System.Collections;

public class Dragon : MonoBehaviour
{
    public int Health = 5;

    float Speed = 5f;
    int CoolDownCount = 5;
    Vector3 Target = new Vector3();

    void Start()
    {
        Target = transform.position;
        StartCoroutine(Movement());
        StartCoroutine(FireBullet());
    }

    protected IEnumerator Movement()
    {
        while (true)
        {
            Vector3 pos = Input.mousePosition;
            pos = Camera.main.ScreenToWorldPoint(pos);
            if (Input.GetMouseButton(0))
            {
                Target = pos;
            }
            transform.position = Vector3.Lerp(transform.position, new Vector3(Target.x, Target.y, transform.position.z), Speed * Time.deltaTime);
            yield return null;
        }
    }

    protected IEnumerator FireBullet()
    {
        int coolDown = CoolDownCount;
        while(true)
        {
            if (coolDown <= 0 && Input.GetMouseButton(0))
            {
                coolDown = CoolDownCount;
                GameObject blah = Instantiate(Resources.Load<GameObject>("Prefabs/Sphere"));
                blah.transform.position = this.transform.position;
            }
            if (coolDown > 0)
            {
                coolDown--;
            }
            yield return new WaitForSeconds(.1f);
        }
    }
}
