using UnityEngine;
using System.Collections;

public class Enemy : Character {

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Player")
        {
            other.transform.GetComponent<Character>().Kill();
        }
    }

    public IEnumerator KillAnimation()
    {
        float curtime = Time.fixedTime;
        float delta;
        Vector3 dirvector = Random.onUnitSphere * (float) Random.Range(10, 1000);
        int rot =  Random.Range(-180, 180);
        while (Time.fixedTime < curtime + 1f)
        {
            delta = 1f - Time.fixedTime - curtime;
            transform.position += dirvector;
            transform.Rotate(new Vector3(rot, 0));
            transform.localScale = transform.localScale * delta;
        }
        yield break;
    }

    public override void Kill()
    {
        Dead = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine(KillAnimation());
        Destroy(gameObject, 1f);
    }
}
