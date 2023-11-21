using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shop : MonoBehaviour
{
   [SerializeField] private TemplatesData _templatesDataIsSkinsForBuy;
   [SerializeField] private Wallet _wallet;
   [SerializeField] private SkinView _temlate;
   [SerializeField] private GameObject _skinContainer;


   [SerializeField] private List<SkinView> _skinViews = new List<SkinView>();

    private int _countNewSkins;
    private Skin _skinForAdvertising;
    private SkinView _viewSkinForAdvertising;

    
    public SkinView LastSkinView => _skinViews[_skinViews.Count - 1];
    public event UnityAction SkinSelected;
    
    private void Start()
    {
        Init();
    }
    
    
    private void Init()
    {
        var inventory = Inventory.Load();

        for (int i = 0; i < _templatesDataIsSkinsForBuy.SkinTemplates.Count; i++)
        {
            if (inventory.Contains(_templatesDataIsSkinsForBuy.SkinTemplates[i]))
            {
                _templatesDataIsSkinsForBuy.SkinTemplates[i].Buy();
            }
            AddSkin(_templatesDataIsSkinsForBuy.SkinTemplates[i]);
        }
        _skinViews.RemoveAt(0);
        RefreshCurrentSkinViewButton();
    }

    public void RefreshCurrentSkinViewButton()
    {
        var inventory = Inventory.Load();

        Skin SelectedSkinView = _skinViews[inventory.SelectedGuid].Skin;
        SelectedSkinView.Buy();
        inventory.SelectSkin(SelectedSkinView);
        inventory.Save();
        SkinSelected?.Invoke();

        foreach (var skinView in _skinViews)
        {
            skinView.ChangeButtonText();
        }
    }

    public void AddSkin(Skin skin)
   {
        SkinView view = Instantiate(_temlate, _skinContainer.transform);
        _skinViews.Add(view);
       view.SellButonClick += OnSellButonClick;
       view.Selected += OnSelected;
       view.Render(skin);
       
   }

    private void OnSellButonClick(Skin skin,SkinView view)
   {
       TrySellSkin(skin,view);
   }

   private void TrySellSkin(Skin skin,SkinView view)
   {
        if (skin.IsSkinForAdvesting)
        {
            _skinForAdvertising = skin;
            _viewSkinForAdvertising = view;

            SellSkin(_skinForAdvertising, _viewSkinForAdvertising);

        }


        if (skin.Price <= _wallet.Value)
        {
            _wallet.Take( skin.Price);
            SellSkin(skin,view);
        }
        else
        {
            Debug.Log("not walue");
        }
    }


    

    private void SellSkin(Skin skin,SkinView view)
   {
       skin.Buy();
       var inventory = Inventory.Load();
       inventory.AddSkin(skin);
       inventory.Save();
       view.SellButonClick -= OnSellButonClick;

       for (int i = 0; i < _skinViews.Count; i++)
       {
           _skinViews[i].Render();
       }
    }
   
   private void OnSelected()
   {
       SkinSelected?.Invoke();
       
       for (int i = 0; i < _skinViews.Count; i++)
       {
           _skinViews[i].Render();
       }
   }

    public void Unsubscribe()
   {
       for (int i = 0; i < _skinViews.Count; i++)
       {
           _skinViews[i].Selected -= OnSelected;
           _skinViews[i].Unsubscribe();
       }
       
   }
    

    private void OnRewardedCallback()
    {
        SellSkin(_skinForAdvertising, _viewSkinForAdvertising);
    }

   
    private void OnOpenCallback()
    {
        AudioListener.volume = 0;
        Constants.IsWatchAdd = true;
    }

    private void OnClosed()
    {

        AudioListener.volume = 1;
        Constants.IsWatchAdd = false;
    }

    private void OnErrorCallback(string errorText)
    {
        AudioListener.volume = 1;
        Constants.IsWatchAdd = false;
        Debug.Log($"OnErrorCallback = {errorText}");
        OnRewardedCallback();
    }

}


