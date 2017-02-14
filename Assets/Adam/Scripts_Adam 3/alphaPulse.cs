using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class alphaPulse : MonoBehaviour 
{
	public float fadeSpeed;
	public float alpha;
	public float startAlpha;
	public float r;
	public float g;
	public float b;

	// Use this for initialization
	void Start () 
	{
		alpha = GetComponent<CanvasRenderer>().GetAlpha();
		//r = this.gameObject.GetComponent<Renderer>().material.color.r;
		//g = this.gameObject.GetComponent<Renderer>().material.color.g;
		//b = this.gameObject.GetComponent<Renderer>().material.color.b;

		startAlpha = alpha;
	}

	void pulse()
	{
		alpha -= fadeSpeed * Time.deltaTime;
		GetComponent<CanvasRenderer>().SetAlpha(alpha);

		if(alpha <= 0)
		{
			fadeSpeed --;
		}

		if(alpha >= startAlpha)
		{
			fadeSpeed ++;
		}
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		pulse();
	}
}
