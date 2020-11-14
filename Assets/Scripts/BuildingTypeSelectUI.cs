using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingTypeSelectUI : MonoBehaviour
{
	#region Fields

	[SerializeField] Transform _buttonTemplate;
	[SerializeField] Sprite _arrowSprite;
	[SerializeField] List<BuildingTypeSO> _ignoreBuildingTypeList;

	Transform _arrowButton;

	BuildingTypeListSO _buildingTypeList;

	Dictionary<BuildingTypeSO, Transform> _btnTransformDict;

	#endregion

	#region MonoBehaviour Methods

	void Awake()
	{
		_buttonTemplate.gameObject.SetActive(false);
		_buildingTypeList = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);
		_btnTransformDict = new Dictionary<BuildingTypeSO, Transform>();

		float index = 0;

		_arrowButton = Instantiate(_buttonTemplate, transform);
		_arrowButton.gameObject.SetActive(true);

		float offsetAmount = 130f;
		_arrowButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmount * index, 0);

		_arrowButton.Find("Image").GetComponent<Image>().sprite = _arrowSprite;
		_arrowButton.Find("Image").GetComponent<RectTransform>().sizeDelta = new Vector2(0, -30);

		_arrowButton.GetComponent<Button>().onClick.AddListener(() => { BuildingManager.Instance.SetActiveBuildingType(null); });

		index++;

		foreach (BuildingTypeSO buildingType in _buildingTypeList._list)
		{
			if (_ignoreBuildingTypeList.Contains(buildingType)) continue;

			Transform btnTransform = Instantiate(_buttonTemplate, transform);
			btnTransform.gameObject.SetActive(true);

			offsetAmount = 130f;
			btnTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmount * index, 0);

			btnTransform.Find("Image").GetComponent<Image>().sprite = buildingType._sprite;

			btnTransform.GetComponent<Button>().onClick.AddListener(() => { BuildingManager.Instance.SetActiveBuildingType(buildingType); });

			_btnTransformDict[buildingType] = btnTransform;

			index++;
		}
	}

	void Start()
	{
		BuildingManager.Instance.OnActiveBuildingTypeChanged += BuildingManager_OnActiveBuildingTypeChanged;
		UpdateActiveBuildingTypeButton();
	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods

	void UpdateActiveBuildingTypeButton()
	{
		_arrowButton.Find("Selected").gameObject.SetActive(false);

		foreach (BuildingTypeSO buildingType in _btnTransformDict.Keys)
		{
			Transform btnTransform = _btnTransformDict[buildingType];
			btnTransform.Find("Selected").gameObject.SetActive(false);
		}

		BuildingTypeSO activeBuildingType = BuildingManager.Instance.GetActiveBuildingType();

		if(activeBuildingType==null)
			_arrowButton.Find("Selected").gameObject.SetActive(true);
		else
			_btnTransformDict[activeBuildingType].Find("Selected").gameObject.SetActive(true);
	}

	void BuildingManager_OnActiveBuildingTypeChanged(object sender, BuildingManager.OnActiveBuildingTypeChangedEventArgs e)
	{
		UpdateActiveBuildingTypeButton();
	}
	#endregion
}
