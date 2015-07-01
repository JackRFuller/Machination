using UnityEngine;
using System.Collections;

public class ObjectWrapping : MonoBehaviour {

	[SerializeField] private bool wrapWidth = false;
	[SerializeField] private bool wrapHeight = true;

	private Renderer ObjectRenderer;
	private Transform Objecttransform;
	private Camera MainCamera;
	private Vector2 viewportPosition;

	[SerializeField] bool isWrappingWidth;
	[SerializeField] bool isWrappingHeight;
	private Vector2 newPosition;

	// Use this for initialization
	void Start () {

		ObjectRenderer = GetComponent<Renderer>();
		Objecttransform = transform;
		MainCamera = Camera.main;
		viewportPosition = Vector2.zero;
		isWrappingWidth = false;
		isWrappingHeight = false;
		newPosition = transform.position;
	
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		Wrap();
	}

	void Wrap()
	{
		bool isVisible = IsBeingRendered();

		if(isVisible)
		{
			isWrappingHeight = false;
			isWrappingWidth = false;
		}

		newPosition = transform.position;
		viewportPosition = MainCamera.WorldToViewportPoint(newPosition);

		if(wrapWidth)
		{
			if(!isWrappingWidth)
			{
				if(viewportPosition.x > 1)
				{
					newPosition.x = MainCamera.ViewportToWorldPoint(Vector2.zero).x;
					isWrappingWidth = true;
				}
				else if(viewportPosition.x < 0)
				{
					newPosition.x = MainCamera.ViewportToWorldPoint(Vector2.zero).x;
					isWrappingWidth = true;
				}
			}
		}

		if(wrapHeight)
		{
			if(!isWrappingHeight)
			{
				if(viewportPosition.y > 1)
				{
					newPosition.y = MainCamera.ViewportToWorldPoint(Vector2.zero).y;
					isWrappingHeight = true;
				}
				else if(viewportPosition.y < 0)
				{
					newPosition.y = MainCamera.ViewportToWorldPoint(Vector2.zero).y;
					isWrappingHeight = true;
				}
			}
		}

		transform.position = newPosition;
	}

	private bool IsBeingRendered()
	{
		if(ObjectRenderer.isVisible)
			return true;
		return false;
	}
}
