using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
	#region Fields

	BuildingTypeSO _buildingType;
	BuildingTypeListSO _buildingTypeList;

	Camera _mainCamera;

	#endregion

	#region MonoBehaviour Methods

	void Awake()
	{
		_buildingTypeList = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);
		_buildingType = _buildingTypeList._list[0];
	}

	void Start() 
	{
		_mainCamera = Camera.main;
	}
	
	void Update() 
	{
		if (Input.GetMouseButtonDown(0))
		{
			Instantiate(_buildingType._prefab, GetMouseWorldPosition(), Quaternion.identity);
		}

		if (Input.GetKeyDown(KeyCode.T))
		{
			_buildingType = _buildingTypeList._list[0];
		}

		if (Input.GetKeyDown(KeyCode.Y))
		{
			_buildingType = _buildingTypeList._list[1];
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
