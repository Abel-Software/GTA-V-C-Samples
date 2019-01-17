using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using GTA;
using GTA.Native;
using NativeUI;

public class NativeUITemplate : Script
{
    private Ped playerPed = Game.Player.Character;
    private Player player = Game.Player;
    private MenuPool _menuPool;

    ScriptSettings config;
    Keys OpenMenu;

    public void ClearWantedLevel(UIMenu menu)
    {
        var onestar = new UIMenuItem("Clear Wanted Level", "");
        menu.AddItem(onestar);
        menu.OnItemSelect += (sender, item, index) =>
        {
            if (item == onestar)
            {
                Game.Player.WantedLevel = 0;
            }
        };
    }

    public void OneStarWantedLevel(UIMenu menu)
    {
        var onestar = new UIMenuItem("One Star Wanted Level", "");
        menu.AddItem(onestar);
        menu.OnItemSelect += (sender, item, index) =>
        {
            if (item == onestar)
            {
                Game.Player.WantedLevel = 1;
            }
        };
    }

    public void TwoStarWantedLevel(UIMenu menu)
    {
        var onestar = new UIMenuItem("Two Star Wanted Level", "");
        menu.AddItem(onestar);
        menu.OnItemSelect += (sender, item, index) =>
        {
            if (item == onestar)
            {
                Game.Player.WantedLevel = 2;
            }
        };
    }

    public void ThreeStarWantedLevel(UIMenu menu)
    {
        var onestar = new UIMenuItem("Three Star Wanted Level", "");
        menu.AddItem(onestar);
        menu.OnItemSelect += (sender, item, index) =>
        {
            if (item == onestar)
            {
                Game.Player.WantedLevel = 3;
            }
        };
    }

    public void FourStarWantedLevel(UIMenu menu)
    {
        var onestar = new UIMenuItem("Four Star Wanted Level", "");
        menu.AddItem(onestar);
        menu.OnItemSelect += (sender, item, index) =>
        {
            if (item == onestar)
            {
                Game.Player.WantedLevel = 4;
            }
        };
    }

    public void FiveStarWantedLevel(UIMenu menu)
    {
        var onestar = new UIMenuItem("Five Star Wanted Level", "");
        menu.AddItem(onestar);
        menu.OnItemSelect += (sender, item, index) =>
        {
            if (item == onestar)
            {
                Game.Player.WantedLevel = 5;
            }
        };
    }

    public void PlayerOptionsSubMenu(UIMenu menu)
    {
        var playeroptions = _menuPool.AddSubMenu(menu, "Player Options");
        for (int i = 0; i < 1; i++) ;

        //Heal Player
        var healplayer = new UIMenuItem("Heal Player", "");
        healplayer.SetRightBadge(UIMenuItem.BadgeStyle.Heart);
        playeroptions.AddItem(healplayer);
        playeroptions.OnItemSelect += (sender, item, index) =>
        {
            if (item == healplayer)
            {
                Game.Player.Character.Health = 100;
                Game.Player.RefillSpecialAbility();
            }
        };

        //Armour
        var armour = new UIMenuItem("Give Armour", "");
        armour.SetRightBadge(UIMenuItem.BadgeStyle.Armour);
        playeroptions.AddItem(armour);
        playeroptions.OnItemSelect += (sender, item, index) =>
        {
            if (item == armour)
            {
                Game.Player.Character.Armor = 100;
            }
        };

        //Clean Clothes
        var cleanclothes = new UIMenuItem("Clean Player Clothes", "");
        cleanclothes.SetRightBadge(UIMenuItem.BadgeStyle.Clothes);
        playeroptions.AddItem(cleanclothes);
        playeroptions.OnItemSelect += (sender, item, index) =>
        {
            if (item == cleanclothes)
            {
                Game.Player.Character.ClearBloodDamage();
            }
        };
    }

    
    public NativeUITemplate()
    {
        _menuPool = new MenuPool();
        var mainMenu = new UIMenu("Wanted Level Menu", "Example by Abel Software"); //"Wanted Level Menu" is the menu title, while "Example by Abel Software" is the description
        _menuPool.Add(mainMenu); //This sets the menu, don't delete this.
        ClearWantedLevel(mainMenu);
        OneStarWantedLevel(mainMenu);
        TwoStarWantedLevel(mainMenu);
        ThreeStarWantedLevel(mainMenu);
        FourStarWantedLevel(mainMenu);
        FiveStarWantedLevel(mainMenu);
        PlayerOptionsSubMenu(mainMenu);
        _menuPool.RefreshIndex();

        //INI Configuration File
        config = ScriptSettings.Load("scripts\\WantedLevelMenu.ini");
        OpenMenu = config.GetValue<Keys>("Options", "OpenMenu", Keys.F7); //The F7 key will be set my default, but the user can change the key

        //This code will run with every ms tick
        Tick += (o, e) => _menuPool.ProcessMenus();

        //This code will open the menu, do not delete this.
        KeyDown += (o, e) =>
        {
            if (e.KeyCode == OpenMenu && !_menuPool.IsAnyMenuOpen()) // Our menu on/off switch
                mainMenu.Visible = !mainMenu.Visible;
        };
    }
}
