﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour {

	private Hashtable colliderTable = new Hashtable();

	void Start () {
		GameObject bruteObject = GameObject.Find ("Brute");
		MonsterHP brute = bruteObject.GetComponent<Brute> ().monster;
		Collider[] bruteCollider = bruteObject.GetComponentsInChildren<Collider> ();
		for (int i = 0; i < bruteCollider.Length; ++i) {
			colliderTable.Add (bruteCollider [i], brute);
		}
		Transform ghostPool = GameObject.Find ("GhostPool").transform;
		int ghostId = 0;
		while (true) {
			string ghostName = "Ghost" + ghostId.ToString ();
			Transform ghost = ghostPool.Find (ghostName);
			if (ghost == null) {
				break;
			} else {
				++ghostId;
				MonsterHP monster = ghost.gameObject.GetComponent<Ghost> ().monster;
				Collider[] ghostCollider = ghost.gameObject.GetComponents<Collider> ();
				for (int i = 0; i < ghostCollider.Length; ++i) {
					colliderTable.Add (ghostCollider [i], monster);
				}
			}
		}
	}

	public void HitCollider(short atk, Collider collider) {
		if (colliderTable.Contains (collider)) {
			((MonsterHP)colliderTable [collider]).Hit (atk);
		}
	}
}
