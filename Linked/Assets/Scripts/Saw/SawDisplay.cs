using System;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class SawDisplay : MonoBehaviour {

	public Saw saw;
	public List<Transform> listPoint;


	private bool _goToFirstPoint = false;
	
	private void Start() {
		if (listPoint.Count != 2) 
			throw new Exception("List point must have only 2 points in his component list");
		gameObject.tag = saw.tag.ToString();
	}

	private void Update() {
		GoToPosition(!_goToFirstPoint ? listPoint[0] : listPoint[1]);
	}

	private void GoToPosition(Transform target) {
		float step = saw.speed * Time.deltaTime;
		
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
		if (transform.position == target.position)
			_goToFirstPoint = !_goToFirstPoint;
	}
}