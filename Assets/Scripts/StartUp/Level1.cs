using UnityEngine;
using System.Collections;

public class Level1 : MonoBehaviour
{
    public delegate void DragonWasHit(int Damage);
    public static event DragonWasHit OnHit;

    Dragon PlayerCharacter;


    // Use this for initialization
	void Start ()
    {
        GameObject Dragon = Instantiate(Resources.Load("Prefabs/Dragon")) as GameObject;
        Dragon.transform.parent = transform;

        PlayerCharacter = Dragon.GetComponent<Dragon>();

        GameObject UI = Instantiate(Resources.Load("Prefabs/UI")) as GameObject;
        UI.transform.parent = transform;

        OnHit += DoHit;
        StartCoroutine(Level1Behaviour());
    }

    private void DoHit(int Damage)
    {
        PlayerCharacter.Health -= Damage;
    }

    private IEnumerator Level1Behaviour()
    {
        int coolDown = 60;
        while (true)
        {
            if (coolDown > 0)
            {
                coolDown--;
            }
            else
            {
                GameObject tmpEnemy = Instantiate(Resources.Load("Prefabs/Enemy1")) as GameObject;
                tmpEnemy.transform.parent = transform;
                int pos = Random.Range(-5, 10);

                tmpEnemy.transform.position = new Vector3(10, pos, tmpEnemy.transform.position.z);
                coolDown = 60;
            }
            yield return null;
        }
    }
}
