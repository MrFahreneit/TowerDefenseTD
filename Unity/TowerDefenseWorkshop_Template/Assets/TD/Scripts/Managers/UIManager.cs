namespace GSGD1
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class UIManager : Singleton<UIManager>
    {
        [SerializeField]
        private scr_UITurretMenu _TurretPlaceMenu;
        [SerializeField]
        private scr_TowerUpgradeCanva _TurretUpgradeMenu;

        private bool _aMenuIsOpen = false;

        [SerializeField]
        private GameObject _mainMenu;

        [SerializeField]
        private GameObject _optionMenuSetting;

        [SerializeField]
        private GameObject _optionsInGame;

        [SerializeField]
        private GameObject _bestiaire;

        [SerializeField]
        private GameObject _towerBestiaire; 
        
        [SerializeField]
        private GameObject _enemyBestiaire;



        public scr_UITurretMenu GetUITurretMenu()
        {
            return _TurretPlaceMenu;

        }

        public scr_TowerUpgradeCanva GetUITowerUpgrade()
        {
            return _TurretUpgradeMenu;
        }

        public bool GetMenuOpen()
        {
            return _aMenuIsOpen;

        }
        public void SetMenuOpen(bool menuOpen)
        {
            _aMenuIsOpen = menuOpen;

        }

        public void MainMenuToOptions()
        {
            _mainMenu.SetActive(false);
            _optionMenuSetting.SetActive(true);
        }

        public void OptionsToMainMenu()
        {
            _optionMenuSetting.SetActive(false);
            _mainMenu.SetActive(true);

        }

        public void GameToOptions()
        {
            _optionsInGame.SetActive(true);
        }

        public void OptionsToGame()
        {
            _optionsInGame.SetActive(false);

        }

        public void GameToBestiaire()
        {
            _bestiaire.SetActive(true);
        }

        public void BestiaireToGame()
        {
            _bestiaire.SetActive(false);

        }

        public void TowerBestiaire()
        {
            _towerBestiaire.SetActive(true);

        }


        public void EnemyBestiaire()
        {
            _enemyBestiaire.SetActive(true);

        }


    }
}