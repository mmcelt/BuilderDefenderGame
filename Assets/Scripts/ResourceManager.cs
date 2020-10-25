﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
	#region Fields

	Dictionary<ResourceTypeSO, int> _resourceAmountDict;

	#endregion

	#region MonoBehaviour Methods

	void Awake() 
	{
		//initialize the Dictionary
		_resourceAmountDict = new Dictionary<ResourceTypeSO, int>();
		//load the ResourceTypeList from Resources folder
		ResourceTypeListSO resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);
		//initialize the dictionary resource values to 0
		foreach (ResourceTypeSO resourceType in resourceTypeList._list)
			_resourceAmountDict[resourceType] = 0;

		TestLogResourceDictionaryAmounts();
	}

	void Update() 
	{
		if (Input.GetKeyDown(KeyCode.T))
		{
			ResourceTypeListSO resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);
			AddResource(resourceTypeList._list[0], 2);
			TestLogResourceDictionaryAmounts();
		}
	}
	#endregion

	#region Public Methods

	public void AddResource(ResourceTypeSO resourceType,int amount)
	{
		_resourceAmountDict[resourceType] += amount;
	}
	#endregion

	#region Private Methods

	void TestLogResourceDictionaryAmounts()
	{
		foreach (ResourceTypeSO resourceType in _resourceAmountDict.Keys)
			Debug.Log(resourceType._name + ": " + _resourceAmountDict[resourceType]);
	}
	#endregion
}