using UnityEngine;

namespace BurgerBattler.Manager
{
    //�e�p�l���̕\����؂�ւ���N���X
    public class PanelManager : MonoBehaviour
    {
        public GameObject charaPanel, burgerPanel, battelePanel,ResultPanel;

        //�L�����I���p�l����\��
        public void ActiveCharaPanel()
        {
            charaPanel.SetActive(true);
            burgerPanel.SetActive(false);
            battelePanel.SetActive(false);
            ResultPanel.SetActive(false);
        }

        //�o�[�K�[�쐬�p�l����\��
        public void ActiveBurgerPanel()
        {
            charaPanel.SetActive(false);
            burgerPanel.SetActive(true);
            battelePanel.SetActive(false);
            ResultPanel.SetActive(false);

        }

        //�o�g���p�l����\��
        public void ActiveBattlePanel()
        {
            charaPanel.SetActive(false);
            burgerPanel.SetActive(false);
            battelePanel.SetActive(true);
            ResultPanel.SetActive(false);
        }

        //���U���g�p�l����\��
        public void ActiveResultPanel()
        {

            charaPanel.SetActive(false);
            burgerPanel.SetActive(false);
            battelePanel.SetActive(false);
            ResultPanel.SetActive(true);
        }
    }
}
