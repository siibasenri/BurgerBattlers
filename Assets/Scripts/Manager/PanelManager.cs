using UnityEngine;

namespace BurgerBattler.Manager
{
    public class PanelManager : MonoBehaviour
    {
        public GameObject charaPanel, burgerPanel, battelePanel,ResultPanel;

        public void ActiveCharaPanel()
        {
            charaPanel.SetActive(true);
            burgerPanel.SetActive(false);
            battelePanel.SetActive(false);
            ResultPanel.SetActive(false);
        }

        public void ActiveBurgerPanel()
        {
            charaPanel.SetActive(false);
            burgerPanel.SetActive(true);
            battelePanel.SetActive(false);
            ResultPanel.SetActive(false);

        }

        public void ActiveBattlePanel()
        {
            charaPanel.SetActive(false);
            burgerPanel.SetActive(false);
            battelePanel.SetActive(true);
            ResultPanel.SetActive(false);
        }

        public void ActiveResultPanel()
        {

            charaPanel.SetActive(false);
            burgerPanel.SetActive(false);
            battelePanel.SetActive(false);
            ResultPanel.SetActive(true);
        }
    }
}
