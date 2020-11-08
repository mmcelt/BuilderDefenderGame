using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingManager : MonoBehaviour
{
	#region Fields

	public static BuildingManager Instance { get; private set; }

	BuildingTypeSO _activeBuildingType;
	BuildingTypeListSO _buildingTypeList;

	Camera _mainCamera;

	#endregion

	#region MonoBehaviour Methods

	void Awake()
	{
		if (Instance == null)
			Instance = this;
		else if (Instance != this)
			Destroy(gameObject);

		_buildingTypeList = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);
		_activeBuildingType = null;
	}

	void Start() 
	{
		_mainCamera = Camera.main;
	}
	
	void Update() 
	{
		if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
		{
			if(_activeBuildingType != null)
				Instantiate(_activeBuildingType._prefab, GetMouseWorldPosition(), Quaternion.identity);
		}
	}
	#endregion

	#region Public Methods

	public void SetActiveBuildingType(BuildingTypeSO buildingType)
	{
		_activeBuildingType = buildingType;
	}

	public BuildingTypeSO GetActiveBuildingType()
	{
		return _activeBuildingType;
	}
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
