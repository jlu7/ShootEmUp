using UnityEngine;
using System.Collections;

public class MoveWithClick : MonoBehaviour
{
    float Speed = 5f;
    Vector3 Target = new Vector3();
    int CoolDownCount = 20;

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
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit) && Input.GetMouseButton(0))
            {
                Target = hit.point;
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
