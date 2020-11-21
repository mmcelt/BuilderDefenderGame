﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/BuildingType")]
public class BuildingTypeSO : ScriptableObject
{
	#region Fields

	public string _name;
	public Transform _prefab;
	public Sprite _sprite;
	public ResourceGeneratorData _resourceData;
	public float _minConstructionRadius;
	public ResourceAmount[] _constructionResourceCostArray;

	#endregion
}
