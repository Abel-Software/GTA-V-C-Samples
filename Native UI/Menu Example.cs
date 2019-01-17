// Native UI Menu Template 3.0 - Abel Software
// You must download and use Scripthook V Dot Net Reference and NativeUI Reference (LINKS AT BOTTOM OF THE TEMPLATE)
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

    //Here we will add the code to use a .INI file for your menu open key
    ScriptSettings config;
    Keys OpenMenu;

    //Now, we will add your sub menu, which in this case, will be player menu to change your player model.
    public void PlayerModelMenu(UIMenu menu)
    {
        var playermodelmenu = _menuPool.AddSubMenu(menu, "Player Model Menu");
        for (int i = 0; i < 1; i++) ;

        //We will change our player model to the male LSPD officer
        var malecop = new UIMenuItem("Male LSPD Officer", "");
        playermodelmenu.AddItem(malecop);
        playermodelmenu.OnItemSelect += (sender, item, index) =>
        {
            if (item == malecop)
            {
                Game.Player.ChangeModel("S_M_Y_COP_01");
            }
        };
    }

    //Now, we will add your sub menu, which in this case, will be vehicle menu to spawn a car
    public void VehicleMenu(UIMenu menu)
    {
        var vehiclemenu = _menuPool.AddSubMenu(menu, "Vehicle Spawning");
        for (int i = 0; i < 1; i++) ;

        //For this example, we will be spawning the Adder
        var adder = new UIMenuItem("Adder", "");
        vehiclemenu.AddItem(adder);
        vehiclemenu.OnItemSelect += (sender, item, index) =>
        {
            if (item == adder)
            {
                Vehicle car = World.CreateVehicle("ADDER", Game.Player.Character.Position);
                Game.Player.Character.SetIntoVehicle(car, VehicleSeat.Driver);
            }
        };
    }

    //Now, we will add your sub menu, which in this case, will be weapon menu to equip a weapon
    public void WeaponMenu(UIMenu menu)
    {
        var weapons = _menuPool.AddSubMenu(menu, "Weapon Menu");
        for (int i = 0; i < 1; i++) ;

        //For this example, we will equipping a flashlight, combat pistol, and pump shotgun
        var newweapons = new UIMenuItem("Issue Weapons", "");
        weapons.AddItem(newweapons);
        weapons.OnItemSelect += (sender, item, index) =>
        {
            if (item == newweapons)
            {
                Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_FLASHLIGHT"), 1, true, true); //Weapon Hash, Weapon Equipped, Ammo Loaded
                Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_COMBATPISTOL"), 9999, false, true);
                Game.Player.Character.Weapons.Give((WeaponHash)Function.Call<int>(Hash.GET_HASH_KEY, "WEAPON_PUMPSHOTGUN"), 9999, false, true);
                UI.Notify("~g~You have been issued weapons!"); //This notification will appear with green text above the radar
                UI.ShowSubtitle("~g~You have been issued weapons!"); //This notification will appear at the bottom of the screen with green text
            }
        };
    }

    //Now we will add all of our sub menus into our main menu, and set the general information of the entire menu
    public NativeUITemplate()
    {
        _menuPool = new MenuPool();
        var mainMenu = new UIMenu("~r~Police~w~Menu ~b~V", "~b~Mod by Abel Gaming! ~r~V 1.9");
        _menuPool.Add(mainMenu);
        PlayerModelMenu(mainMenu); //Here we add the Player Model Sub Menu
        VehicleMenu(mainMenu); //Here we add the Vehicle Spawning Sub Menu
        WeaponMenu(mainMenu); //Here we add the Weapon Sub Menu
        _menuPool.RefreshIndex();

        //We will now call from the .INI file for our controls
        config = ScriptSettings.Load("scripts\\settings.ini");
        OpenMenu = config.GetValue<Keys>("Options", "OpenMenu", Keys.F7); //The F7 key will be set my default, but the user can change the key

        //This code will run with every ms tick
        Tick += (o, e) => _menuPool.ProcessMenus();

        //This code will open the menu
        KeyDown += (o, e) =>
        {
            if (e.KeyCode == OpenMenu && !_menuPool.IsAnyMenuOpen()) // Our menu on/off switch
                mainMenu.Visible = !mainMenu.Visible;
        };
    }
}
//Useful Links
//All Vehicles - https://pastebin.com/uTxZnhaN
//All Player Models - https://pastebin.com/i5c1zA0W
//All Weapons - https://pastebin.com/M3kD9pnJ
//Native UI - https://gtaforums.com/topic/809284-net-nativeui/
//GTA V ScriptHook V Dot Net - https://www.gta5-mods.com/tools/scripthookv-net
