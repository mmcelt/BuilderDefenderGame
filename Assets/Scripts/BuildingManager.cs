using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
	#region Fields

	[SerializeField] Transform _woodHarvesterPrefab;

	Camera _mainCamera;

	#endregion

	#region MonoBehaviour Methods

	void Start() 
	{
		_mainCamera = Camera.main;
	}
	
	void Update() 
	{
		if (Input.GetMouseButtonDown(0))
		{
			Instantiate(_woodHarvesterPrefab, GetMouseWorldPosition(), Quaternion.identity);
		}
	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods

	Vector3 GetMouseWorldPosition()
	{
		Vector3 mouseWorldPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
		mouseWorldPosition.z = 0;

		return mouseWorldPosition;
	}
	#endregion
}
