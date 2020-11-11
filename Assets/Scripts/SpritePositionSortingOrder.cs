using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritePositionSortingOrder : MonoBehaviour
{
	#region Fields

	[SerializeField] bool _runOnce;
	[SerializeField] float _positionOffsetY;

	SpriteRenderer _theSprite;

	#endregion

	#region MonoBehaviour Methods

	void Awake()
	{
		_theSprite = GetComponent<SpriteRenderer>();
	}

	void Start() 
	{
		
	}
	
	void LateUpdate() 
	{
		float precisionMultiplier = 5f;
		_theSprite.sortingOrder = (int)(-(transform.position.y + _positionOffsetY) * precisionMultiplier);

		if (_runOnce)
			Destroy(this);
	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods


	#endregion
}
