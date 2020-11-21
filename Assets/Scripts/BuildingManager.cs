using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingManager : MonoBehaviour
{
	#region Fields

	public static BuildingManager Instance { get; private set; }

	public event EventHandler<OnActiveBuildingTypeChangedEventArgs> OnActiveBuildingTypeChanged;

	public class OnActiveBuildingTypeChangedEventArgs : EventArgs 
	{
		public BuildingTypeSO activeBuildingType;
	}

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
			if(_activeBuildingType != null && CanSpawnBuilding(_activeBuildingType, Utils.GetMouseWorldPosition()))
			{
				if (ResourceManager.Instance.CanAfford(_activeBuildingType._constructionResourceCostArray))
				{
					ResourceManager.Instance.SpendResources(_activeBuildingType._constructionResourceCostArray);

					Instantiate(_activeBuildingType._prefab, Utils.GetMouseWorldPosition(), Quaternion.identity);
				}
			}
		}
	}
	#endregion

	#region Public Methods

	public void SetActiveBuildingType(BuildingTypeSO buildingType)
	{
		_activeBuildingType = buildingType;

		OnActiveBuildingTypeChanged?.Invoke(this, new OnActiveBuildingTypeChangedEventArgs { activeBuildingType = _activeBuildingType });
	}

	public BuildingTypeSO GetActiveBuildingType()
	{
		return _activeBuildingType;
	}
	#endregion

	#region Private Methods

	bool CanSpawnBuilding(BuildingTypeSO buildingType, Vector2 position)
	{ 
		BoxCollider2D boxCollider = buildingType._prefab.GetComponent<BoxCollider2D>();
		//check the area underneath the building for obstacles...
		Collider2D[] colliders = Physics2D.OverlapBoxAll(position + boxCollider.offset, boxCollider.size, 0);

		bool isAreaClear = colliders.Length == 0;
		if (!isAreaClear) return false;

		colliders = Physics2D.OverlapCircleAll(position, buildingType._minConstructionRadius);

		foreach (Collider2D collider in colliders)
		{
			//colliders inside the construction radius...
			BuildingTypeHolder buildingTypeHolder = collider.GetComponent<BuildingTypeHolder>();
			if(buildingTypeHolder != null)
			{
				//has a BuildingType...
				if (buildingTypeHolder._buildingType == buildingType)
				{
					//there is already a building of this type within the construction radius..
					return false;
				}
			}
		}

		float maxConstructionRadius = 25f;
		colliders = Physics2D.OverlapCircleAll(position, maxConstructionRadius);

		foreach (Collider2D collider in colliders)
		{
			//colliders inside the construction radius...
			BuildingTypeHolder buildingTypeHolder = collider.GetComponent<BuildingTypeHolder>();
			if (buildingTypeHolder != null)
			{
				//it's a Building...
				return true;
			}
		}

		return false;
	}
	#endregion
}
