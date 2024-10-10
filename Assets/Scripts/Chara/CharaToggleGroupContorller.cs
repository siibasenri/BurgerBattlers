using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


namespace BurgerBattler.Chara
{
    public class CharaToggleGroupContorller : MonoBehaviour
    {
        List<Toggle> togglesList = new List<Toggle>();
        public CharaModel model;
        //[SerializeField] CharaDetail detail;
        [SerializeField] GameObject selectButton;


        private void Start()
        {
            model = new CharaModel(0); //èâä˙âª
        }

        public void SetToggleGroup()
        {
            var toggles = this.gameObject.GetComponentsInChildren<Transform>(); //éqÇÃtoggleÇëSïîéÊìæ
            
            foreach (var toggle in toggles)
            {
                if (toggle.GetComponent<Toggle>() != null)
                {
                    togglesList.Add(toggle.GetComponent<Toggle>());
                    toggle.GetComponent<Toggle>().onValueChanged.AddListener(Change);  //ChangeÇonValueChangeÇ…ê›íË
                    toggle.GetComponent<Toggle>().group = GetComponent<ToggleGroup>(); //toggleÇÃgroupÇÇ±ÇÃobjectÇ…ê›íË
                }
            }
        }

        public void Change(bool state)
        {
            if (state)
            {
                foreach (var toggle in togglesList)
                {
                    if (toggle.isOn)
                    {
                        model = toggle.GetComponent<CharaController>().model;
                        toggle.transform.DOScale(Vector2.one * 1.1f, 0.1f).SetEase(Ease.OutBounce);
                    }
                    else
                    {
                        toggle.transform.DOScale(Vector2.one, 0.1f).SetEase(Ease.OutBounce);
                    }
                }
                selectButton.SetActive(true);
            }
        }
    }
}
