using UnityEngine;
using System.Collections;

public class PlatformerEnemy : Enemy
{
	void Start()
	{
		SpriteRenderer sRenderer = renderer as SpriteRenderer;
		sRenderer.color = new Color(Random.Range(0.7f, 0.9f), Random.Range(0.7f, 0.9f), Random.Range(0.7f, 0.9f));
	}
}
