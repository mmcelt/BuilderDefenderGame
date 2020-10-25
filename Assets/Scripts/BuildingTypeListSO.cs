using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/BuildingTypeList")]
public class BuildingTypeListSO : ScriptableObject
{
	#region Fields

	public List<BuildingTypeSO> _list;

	#endregion
}
