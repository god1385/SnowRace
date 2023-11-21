using System.Collections.Generic;
using UnityEngine;

public class SkinsInitializer : MonoBehaviour
{
    [SerializeField] private List<Skin> _skins;
    [SerializeField] private TemplatesData _templatesData;
    [SerializeField] private Player _player;
    
    private void Start()
    {
        TryChangeSkin();
    }

    private void TryChangeSkin()
    {
        var inventory = Inventory.Load();

        for (int i = 0; i < _skins.Count; i++)
            {
                if (_skins[i].gameObject.activeSelf&&_skins[i].Id!=inventory.SelectedGuid)
                {
                    _skins[i].gameObject.SetActive(false);
                }

                if (_skins[i].Id==inventory.SelectedGuid)
                {
                    _skins[i].gameObject.SetActive(true);
                    _player.Init(_skins[i].Animator,_skins[i].Skelet,_skins[i].Ski);
                }
            }
    }
}
