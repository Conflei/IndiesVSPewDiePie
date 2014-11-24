using UnityEngine;
using System.Collections;

public class Enemy : Character {

	public void FixedUpdate ()
	{
				if ((transform.position - GameObject.Find("Player").gameObject.transform.position).magnitude < 0.5f ) GameObject.Find("Player").gameObject.GetComponent<Player>().Kill();
	}

    public IEnumerator KillAnimation()
    {
        float curtime = Time.fixedTime;
        float delta;
				Vector3 dirvector = (transform.position - GameObject.FindWithTag("Player").transform.position);
		dirvector.Normalize();
				dirvector *= Random.Range(10, 100);
        int rot =  Random.Range(-180, 180);
        while (Time.fixedTime < curtime + 1f)
        {
            delta = 1f - Time.fixedTime - curtime;
						transform.position += dirvector * Time.deltaTime;
						transform.Rotate(new Vector3(0, 0, rot * Time.deltaTime));
            //transform.localScale = transform.localScale * delta;
			yield return new WaitForEndOfFrame();
        }
		Destroy(gameObject);
        yield break;
    }

    public override void Kill()
    {

        Dead = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
		GameState.points += 1;
        StartCoroutine(KillAnimation());
    }
}
