using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_IA : MonoBehaviour {
    [SerializeField] private float speed;
    private Transform target;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        //Comentei a linha porque tava dando "compile error", e nao da pra dar playtest com o erro.
        //transform.position = Vector2.MoveTowards(transform.Translate() = new Vector3(target.transform.position.x, target.transform.position, );
	}
}
