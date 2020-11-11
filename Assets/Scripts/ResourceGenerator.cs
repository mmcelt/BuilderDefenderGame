using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGenerator : MonoBehaviour
{
	#region Fields

	float _timer;
	float _timerMax;
	//BuildingTypeSO _buildingType;
	ResourceGeneratorData _resourceGeneratorData;

	#endregion

	#region MonoBehaviour Methods

	void Awake() 
	{
		_resourceGeneratorData = GetComponent<BuildingTypeHolder>()._buildingType._resourceData;
		_timerMax = _resourceGeneratorData._timerMax;
	}

	void Start()
	{
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _resourceGeneratorData._resourceDetectionRadius);

		int nearbyResourceAmount = 0;
		foreach (Collider2D collider in colliders)
		{
			ResourceNode resourceNode = collider.GetComponent<ResourceNode>();
			if (resourceNode != null)  //it's a resource node...
			{
				//it's the correct type...
				if (resourceNode._resourceType == _resourceGeneratorData._resourceType)
				{
					nearbyResourceAmount++;
				}
			}
		}

		nearbyResourceAmount = Mathf.Clamp(nearbyResourceAmount, 0, _resourceGeneratorData._maxResourceAmount);

		if (nearbyResourceAmount == 0)
		{
			//no resource nodes nearby...disable Resource Generator...
			enabled = false;
		}
		else
		{
			_timerMax = (_resourceGeneratorData._timerMax / 2f) + _resourceGeneratorData._timerMax * (1 - (float)nearbyResourceAmount / _resourceGeneratorData._maxResourceAmount);
		}

		Debug.Log("Resources: " + nearbyResourceAmount + "- tMax: " + _timerMax);
	}

	void Update() 
	{
		_timer -= Time.deltaTime;
		if (_timer <= 0f)
		{
			_timer = _timerMax;
			//Debug.Log("Ding!! " + _buildingType._resourceData._resourceType._name);
			ResourceManager.Instance.AddResource(_resourceGeneratorData._resourceType, 1);
		}
	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods


	#endregion
}
