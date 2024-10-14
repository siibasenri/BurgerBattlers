using UnityEngine;

namespace BurgerBattler.Manager
{
    //各パネルの表示を切り替えるクラス
    public class PanelManager : MonoBehaviour
    {
        public GameObject charaPanel, burgerPanel, battelePanel,ResultPanel;

        //キャラ選択パネルを表示
        public void ActiveCharaPanel()
        {
            charaPanel.SetActive(true);
            burgerPanel.SetActive(false);
            battelePanel.SetActive(false);
            ResultPanel.SetActive(false);
        }

        //バーガー作成パネルを表示
        public void ActiveBurgerPanel()
        {
            charaPanel.SetActive(false);
            burgerPanel.SetActive(true);
            battelePanel.SetActive(false);
            ResultPanel.SetActive(false);

        }

        //バトルパネルを表示
        public void ActiveBattlePanel()
        {
            charaPanel.SetActive(false);
            burgerPanel.SetActive(false);
            battelePanel.SetActive(true);
            ResultPanel.SetActive(false);
        }

        //リザルトパネルを表示
        public void ActiveResultPanel()
        {

            charaPanel.SetActive(false);
            burgerPanel.SetActive(false);
            battelePanel.SetActive(false);
            ResultPanel.SetActive(true);
        }
    }
}
