using UnityEngine;
using System.Collections;

public class MoveWithClick : MonoBehaviour
{
    float Speed = 5f;
    Vector3 Target = new Vector3();
    int CoolDownCount = 5;

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
                Debug.Log("Shoot");
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
