using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourcesUI : MonoBehaviour
{
	#region Fields

	[SerializeField] Transform _resourceTemplate;

	ResourceTypeListSO _resourceTypeList;
	Dictionary<ResourceTypeSO, Transform> _resourceTypeTransformDict;

	#endregion

	#region MonoBehaviour Methods

	void Awake() 
	{
		_resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);

		_resourceTypeTransformDict = new Dictionary<ResourceTypeSO, Transform>();

		_resourceTemplate.gameObject.SetActive(false);

		int index = 0;
		foreach(ResourceTypeSO resourceType in _resourceTypeList._list)
		{
			Transform resourceTransform = Instantiate(_resourceTemplate, transform);
			resourceTransform.gameObject.SetActive(true);
			float offsetAmount = -160f;
			resourceTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmount * index, 0);

			resourceTransform.Find("Image").GetComponent<Image>().sprite = resourceType._sprite;

			_resourceTypeTransformDict[resourceType] = resourceTransform;

			index++;
		}
	}

	void Start()
	{
		ResourceManager.Instance.OnResourceAmountChanged += ResourceManager_OnResourceAmountChanged;

		UpdateResourceAmount();
	}

	void ResourceManager_OnResourceAmountChanged(object sender, System.EventArgs e)
	{
		UpdateResourceAmount();
	}

	void Update() 
	{
		
	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods

	void UpdateResourceAmount()
	{
		foreach (ResourceTypeSO resourceType in _resourceTypeList._list)
		{
			int resourceAmount = ResourceManager.Instance.GetResourceAmount(resourceType);
			Transform resourceTransform = _resourceTypeTransformDict[resourceType];

			resourceTransform.Find("Text").GetComponent<TextMeshProUGUI>().SetText(resourceAmount.ToString());
		}

	}
	#endregion
}
